// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-14-2021
// ***********************************************************************
// <copyright file="Virtualize.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using PSC.Blazor.Components.DataTable.EventsArgs;
using System;
using System.Collections.Generic;
using System.Linq;
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
		/// <summary>
		/// Gets or sets the name of the tag.
		/// </summary>
		/// <value>The name of the tag.</value>
		[Parameter] public string TagName { get; set; } = "div";
		/// <summary>
		/// Gets or sets the content of the child.
		/// </summary>
		/// <value>The content of the child.</value>
		[Parameter] public RenderFragment<TModel> ChildContent { get; set; }
		/// <summary>
		/// Gets or sets the items.
		/// </summary>
		/// <value>The items.</value>
		[Parameter] public ICollection<TModel> Items { get; set; }
		/// <summary>
		/// Gets or sets the height of the item.
		/// </summary>
		/// <value>The height of the item.</value>
		[Parameter] public double ItemHeight { get; set; }
		/// <summary>
		/// Gets or sets the attributes.
		/// </summary>
		/// <value>The attributes.</value>
		[Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> Attributes { get; set; }

		/// <summary>
		/// Gets or sets the js.
		/// </summary>
		/// <value>The js.</value>
		[Inject] IJSRuntime JS { get; set; }

		/// <summary>
		/// The content element
		/// </summary>
		ElementReference contentElement;
		/// <summary>
		/// The number items to skip before
		/// </summary>
		int numItemsToSkipBefore;
		/// <summary>
		/// The number items to show
		/// </summary>
		int numItemsToShow;

		/// <summary>
		/// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
		/// </summary>
		/// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
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

		/// <summary>
		/// on after render as an asynchronous operation.
		/// </summary>
		/// <param name="firstRender">Set to <c>true</c> if this is the first time <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> has been invoked
		/// on this component instance; otherwise <c>false</c>.</param>
		/// <returns>A Task representing the asynchronous operation.</returns>
		/// <remarks>The <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> and <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)" /> lifecycle methods
		/// are useful for performing interop, or interacting with values received from <c>@ref</c>.
		/// Use the <paramref name="firstRender" /> parameter to ensure that initialization work is only performed
		/// once.</remarks>
		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				var objectRef = DotNetObjectReference.Create(this);
				var initResult = await JS.InvokeAsync<ScrollEventArgs>("VirtualizedComponent._initialize", objectRef, contentElement);
				OnScroll(initResult);
			}
		}

		/// <summary>
		/// Handles the <see cref="E:Scroll" /> event.
		/// </summary>
		/// <param name="args">The <see cref="ScrollEventArgs"/> instance containing the event data.</param>
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