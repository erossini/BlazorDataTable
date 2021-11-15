using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using PSC.Blazor.Components.DataTable.EventsArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable
{
    /// <summary>
    /// Class Virtualize.
    /// Implements the <see cref="Microsoft.AspNetCore.Components.ComponentBase" />
    /// </summary>
    /// <typeparam name="TModel">The type of the t model.</typeparam>
    /// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
    public class Virtualize<TModel> : ComponentBase
    {
        [Parameter] public string TagName { get; set; } = "div";
        [Parameter] public RenderFragment<TModel> ChildContent { get; set; }
        [Parameter] public ICollection<TModel> Items { get; set; }
        [Parameter] public double ItemHeight { get; set; }
        [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> Attributes { get; set; }

        [Inject] IJSRuntime JS { get; set; }

        ElementReference contentElement;
        int numItemsToSkipBefore;
        int numItemsToShow;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            // Render actual content
            builder.OpenElement(0, TagName);
            builder.AddMultipleAttributes(1, Attributes);

            var translateY = numItemsToSkipBefore * ItemHeight;
            builder.AddAttribute(2, "style", $"transform: translateY({ translateY }px);");
            builder.AddAttribute(2, "data-translateY", translateY);
            builder.AddElementReferenceCapture(3, @ref => { contentElement = @ref; });

            // As an important optimization, *don't* use builder.AddContent(seq, ChildContent, item) because that implicitly
            // wraps a new region around each item, which in turn means that @key does nothing (because keys are scoped to
            // regions). Instead, create a single container region and then invoke the fragments directly.
            builder.OpenRegion(4);
            foreach (var item in Items.Skip(numItemsToSkipBefore).Take(numItemsToShow))
            {
                ChildContent(item)(builder);
            }
            builder.CloseRegion();

            builder.CloseElement();

            // Also emit a spacer that causes the total vertical height to add up to Items.Count()*numItems
            builder.OpenElement(5, "div");
            var numHiddenItems = Items.Count - numItemsToShow;
            builder.AddAttribute(6, "style", $"width: 1px; height: { numHiddenItems * ItemHeight }px;");
            builder.CloseElement();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var objectRef = DotNetObjectReference.Create(this);
                var initResult = await JS.InvokeAsync<ScrollEventArgs>("VirtualizedComponent._initialize", objectRef, contentElement);
                OnScroll(initResult);
            }
        }

        [JSInvokable]
        public void OnScroll(ScrollEventArgs args)
        {
            // TODO: Support horizontal scrolling too
            var relativeTop = args.ContainerRect.Top - args.ContentRect.Top;
            numItemsToSkipBefore = Math.Max(0, (int)(relativeTop / ItemHeight));

            var visibleHeight = args.ContainerRect.Bottom - (args.ContentRect.Top + numItemsToSkipBefore * ItemHeight);
            numItemsToShow = (int)Math.Ceiling(visibleHeight / ItemHeight) + 3;

            StateHasChanged();
        }
    }
}