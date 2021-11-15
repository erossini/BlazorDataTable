// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-14-2021
// ***********************************************************************
// <copyright file="DataTable.js" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
window.VirtualizedComponent = {
    _ticking: false,
    _initialize: function (component, contentElement) {
        // Find closest scrollable container
        /// <summary>
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="contentElement">The content element.</param>
        let scrollableContainer = contentElement.parentElement;
        while (!(scrollableContainer.style.overflow || scrollableContainer.style.overflowY)) {
            scrollableContainer = scrollableContainer.parentElement;
            if (!scrollableContainer) {
                throw new Error('No scrollable container was found around VirtualizedComponent.');
            }
        }

        // TODO: Also listen for 'scrollableContainer' being resized or 'contentElement' moving
        // within it, and notify.NET side
        scrollableContainer.addEventListener('scroll', e => {
            const lastKnownValues = {
                containerRect: scrollableContainer.getBoundingClientRect(),
                contentRect: readClientRectWithoutTransform(contentElement)
            };

            if (!this._ticking) {
                requestIdleCallback(() => {
                    /// <summary>
                    /// </summary>
                    component.invokeMethodAsync('OnScroll', lastKnownValues);
                    this._ticking = false;
                });

                this._ticking = true;
            }
        });

        return {
            containerRect: scrollableContainer.getBoundingClientRect(),
            contentRect: readClientRectWithoutTransform(contentElement)
        };
    }
};

function readClientRectWithoutTransform(elem) {
    const rect = elem.getBoundingClientRect();
    const translateY = parseFloat(elem.getAttribute('data-translateY'));
    return { top: rect.top - translateY, bottom: rect.bottom - translateY, left: rect.left, right: rect.right, height: rect.height, width: rect.width };
}

function openModal(identifier) {
    /// <summary>
    /// Opens the modal.
    /// </summary>
    /// <param name="identifier">The identifier.</param>
    $(`#${identifier}`).modal('show');
}

function closeModal(identifier) {
    $(`#${identifier}`).modal('hide');
}