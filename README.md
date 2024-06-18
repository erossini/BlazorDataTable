# DataTable for Blazor
DataTable component for [Blazor WebAssembly](https://www.puresourcecode.com/tag/blazor-webassembly/) and [Blazor Server](https://www.puresourcecode.com/tag/blazor-server/) with support for client/server side paging, filtering and sorting. For more info and examples, please visit my blog [PureSourceCode.com](https://www.puresourcecode.com) at this [page](https://www.puresourcecode.com/dotnet/net-core/datatable-component-for-blazor/).

[Try DataTable online!](https://datatable.puresourcecode.com/)

## DataTable in action
![DataTable-InAction](https://user-images.githubusercontent.com/9497415/141645639-117d52d7-acf7-4ef6-a360-9a9d2f1b8295.gif)

## Anatomy of DataTable
![DataTable basis](https://user-images.githubusercontent.com/9497415/141643172-d7696fef-c7fe-42e8-8555-3373a5a548d7.png)

### IsLoading="true"
![Loading](https://user-images.githubusercontent.com/9497415/141643293-42616c61-fa18-420d-8a9f-2b88a1b3b52e.png)

### Header details 
![Header details](https://user-images.githubusercontent.com/9497415/141643492-3f2403d0-46b7-49f0-8df1-2018f3d108ef.png)

### IncludeAdvancedFilters="true"
![Advanced filters](https://user-images.githubusercontent.com/9497415/141643811-2ab88b81-3ffb-4a80-a36e-cfd473e59f78.png)

## Installation
1. Install the [NuGet](https://www.nuget.org/packages/PSC.Blazor.Components.DataTable/) package:

   ```
   > dotnet add package PSC.Blazor.Components.DataTable
   ```

   or
   
   ```
   PM> Install-Package PSC.Blazor.Components.DataTable
   ```
   Use the `--version` option to specify a specific version to install.

2. Import the components:

   Add in your `_Imports.razor` file the following using:

   ```
   @using PSC.Blazor.Components.DataTable
   @using PSC.Blazor.Components.DataTable.Models
   @using PSC.Blazor.Components.DataTable.EventsArgs
   ```
   
3. Reference js interop file:
   
    Add to your `_Host.cshtml` or your `index.html` the following:
    
    1. `link` for the CSS code in the `head`

    ```
    <link href="/_content/PSC.Blazor.Components.DataTable/css/DataTable.css" rel="stylesheet" />
    ```

    2. `script` after `<script src="_framework/blazor.webassembly.js"></script>`

    ```
    <script src="/_content/PSC.Blazor.Components.DataTable/js/DataTable.js"></script>
    ```

The component requires same external libraries to work properly:

- jQuery
- Bootstrap
- Font Awasome

## Usage

### DataTable properties

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| Items | IList | List | The list of items to display |
| UsePaging | bool | false | Boolean indicating whether to use paging or not |
| UsePageSizeSelector | bool | true | Boolean indicating hether to show the page size dropdown list (10, 25, 50 records) |
| PageNumber | int | 1   | The number of the current page (only applicable when property UsePaging is true) |
| PageSize | int | 10  | The amount of items shown on a page (only applicable when property UsePaging is true) |
| PageSizeList | List<int> | { 10, 25, 50 } | The list of number of record per page you want to display in the PageSizeSelector |
| PageCount | int | 1   | The total amount of pages (only applicable when property UsePaging is true) |
| FetchData | Func&lt;RequestArgs, Task&gt;? | null | The method used for fetching and manipulating data (paging, filtering, sorting) on the server. When this method is null, all these actions will be performed on the initial dataset on the client. |
| ShowHeaderFilters | bool | true | Indicates whether or not to show the header/grid filters |
| AllowRowSelection | bool | false | Indicates whether or not it's possible to select a row |
| RowClickedEvent | EventCallback | null | The callback for when a row is clicked (only applicable when property AllowRowSelection is true) |
| SelectedItem | TModel | null | The selected item |
| SelectedItemCssClass | string | bg-info | The css class for the selected row |
| EmptyGridText | string | "No records to show" | The text to show when the Items list is empty |
| IsLoading | bool | false | Indicates whether or not data is being fetched, used to show a spinner |
| Id  | string | ""  | The html identifier of the table tag |
| ContainerCssClass | string | "table-responsive" | The css class for the container/parent tag of the table |
| CssClass | string | "table" | The css class for the table tag |
| ApplyButtonCssClass | string | ""  | The css class for the "apply" buttons on grid/header filters |
| InputCssClass | string | ""  | The css class for the input tags in the grid/header filters |
| Styles | TableStyle \[Enum FLAGS\] | null | The style flags used for the table |
| TableAttributes | Dictionary&lt;string, object&gt;? | null | Any custom attributes for the table tag (see Blazor docs for more info) |
| RowAttributes | Dictionary&lt;string, object&gt;? | null | Any custom attributes for the rows (see Blazor docs for more info) |
| ContainerHeight | int | 300 | The height of the table container in pixels |
| ContainerHeightUnit | CssUnit | CssUnit.Px | The unit of the container height |
| IncludeAdvancedFilters | bool | true | Indicates whether to allow advanced filtering or not |
| IncludeHeaderFilters | bool | false | Indicates whether or not to include grid/header filters |
| IncludeSearchButton | bool | false | Indicates whether or not to include a search icon. When clicked filters, sorting and paging is performed on the server is FetchData has a value otherwise it happens on the client |
| IncludeToggleFilters | bool | false | Indicates whether or not to include a toggle icon. When clicked header/grid filters will re or disappear (only applicable when property |
| SearchOnApplyHeaderFilter | bool | true | Indicates whether or not a search is instantly triggered when a header/grid filter is applied |
| AutoAddFilterWhenClickedAndNoneActive | bool | true | Indicates whether or not to add an empty filter rule when a filterable column is clicked an no other filter rules exist. |
| ItemHeight | int? | null | The pixel height of a an item (tr) in the grid. Customize this to get better virtualization. |


### DataTableColumn properties

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| Property | Expression&lt;Func<TModel, object&gt;>? | null | The selector of a field/property of TModel to use for the column |
| IsSortable | bool | false | Indicates whether or not sorting is enabled for this column |
| IsFilterable | bool | false | Indicates whether or not filtering is enabled for this column |
| IsResizable | bool | false | Indicates whether the column is resizable |
| IsVisible | bool | true | Indicates whether the column should be rendered |
| CustomTitle | string | null | The name of the column header (by default the name of the property is used) |
| HeaderTemplate | RenderFragment&lt;string&gt; | null | The template to use for the grid header, the string is the name of the column |
| Id  | string | ""  | The html identifier of the table tag |
| ContainerCssClass | string | "table-responsive" | The css class for the container/parent tag of the table |
| CssClass | string | "table" | The css class for the table tag |
| IsDefaultSortColumn | bool | false | Indicates whether or not this column is sorted on by default |
| DefaultSortDirection | SortDirection \[Enum\] | SortDirection.Ascending | The sort direction of the default sorting column |
| TextAlignment | TextAlignment \[Enum\] | TextAlignment.Left | The text alignment for the column |
| VerticalAlignment | VerticalAlignment \[Enum\] | VerticalAlignment.Bottom | The vertical alignment for the column |
| Styles | TableStyle \[Enum FLAGS\] | null | The style flags used for the table |
| Attributes | Dictionary&lt;string, object&gt;? | null | Any custom attributes for the table tag (see Blazor docs for more info) |
| HeaderFilterAttributes | Dictionary&lt;string, object&gt;? | null | Any custom attributes for the header inputs |
| ContainerHeight | int | 300 | The height of the table container in pixels |
| MinWidthHeader | int | 10  | The height of the table container in the set units (default vw) |
| MinWidthHeaderUnit | CssUnit | CssUnit.Vw | The unit of the minWidthHeader property |
| IncludeHeaderFilter | bool | false | Indicates whether or not to add header/grid filters |
| IncludeSearchButton | bool | false | Indicates whether or not to include a search icon. When clicked filters, sorting and paging is performed on the server is FetchData has a value otherwise it happens on the client |
| IncludeToggleFilters | bool | false | Indicates whether or not to include a toggle icon. When clicked header/grid filters will re or disappear (only applicable when property |
| SearchOnApplyHeaderFilter | bool | false | Indicates whether or not a search is instantly triggered when a header/grid filter is applied |
| AutoAddFilterWhenClickedAndNoneActive | bool | true | Indicates whether or not to add an empty filter rule when a filterable column is clicked an no other filter rules exist. |
| RowTemplate | RenderFragment? | null | The custom render fragment to use for the column |
| RowAttributes | Dictionary&lt;string, object&gt;? | null | Any custom attributes for the rows (see Blazor docs for more info) |
| ContainerHeight | int | 300 | The height of the table container in pixels |
| MaxWidth | int | 100 | The max width in pixels of a column |
| MaxWidthUnit | CssUnit | CssUnit.Px | The unit of the MaxWidth property |
| DateTimeFormat | DateTimeFormat | DateTimeFormat.Date | The DateTimeFormat to use in header/grid filters |
| IsHeaderVisible | bool | true | Indicates whether the column is visible or not |
| IncludeAdvancedFilters | bool | false | Indicates whether to allow advanced filtering or not |
| IncludeSearchButton | bool | false | Indicates whether or not to include a search icon. When clicked filters, sorting and paging is performed on the server is FetchData has a value otherwise it happens on the client |
| IncludeToggleFilters | bool | false | Indicates whether or not to include a toggle icon. When clicked header/grid filters will re or disappear (only applicable when property |
| SearchOnApplyHeaderFilter | bool | false | Indicates whether or not a search is instantly triggered when a header/grid filter is applied |
| AutoAddFilterWhenClickedAndNoneActive | bool | true | Indicates whether or not to add an empty filter rule when a filterable column is clicked an no other filter rules exist. |

### Basic table

```cs
<DataTable TModel="WeatherForecast"
           Items="forecasts">
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.Date" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.TemperatureC"
                    CustomTitle="Celsius" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.TemperatureF"
                    CustomTitle="Fahrenheit" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.MyNullableInt" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.Summary" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.Country" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.UpdatedRecently"
                    CustomTitle="Recently updated" />
</DataTable>
```

### Custom template

```cs
<DataTable TModel="WeatherForecast"
           Items="forecasts">
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.Date" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.TemperatureC"
                    CustomTitle="Celsius" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.TemperatureF"
                    CustomTitle="Fahrenheit" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.MyNullableInt" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.Summary" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.Country" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.UpdatedRecently"
                    CustomTitle="Recently updated">
    <RowTemplate  Context="forecast">
        @if (forecast.UpdatedRecently)
        {
            <i class="fas fa-check-circle" style="color: green;" />
        }
        else
        {
            <i class="far fa-times-circle" style="color: red;" />
        }
   </RowTemplate >
    </DataTableColumn>
</DataTable>
```

### Sorting

```cs
<DataTable TModel="WeatherForecast"
           Items="forecasts">
    <DataTableColumn TModel="WeatherForecast"
                    IsSortable="true"
                    Property="(e) => e.Date" />
    <DataTableColumn TModel="WeatherForecast"
                    IsSortable="true"
                    Property="(e) => e.TemperatureC"
                    CustomTitle="Celsius" />
    <DataTableColumn TModel="WeatherForecast"
                    IsSortable="true"
                    Property="(e) => e.TemperatureF"
                    CustomTitle="Fahrenheit" />
    <DataTableColumn TModel="WeatherForecast"
                    IsSortable="true"
                    Property="(e) => e.MyNullableInt" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.Summary" />
    <DataTableColumn TModel="WeatherForecast"
                    IsSortable="true"
                    Property="(e) => e.Country" />
    <DataTableColumn TModel="WeatherForecast"
                    IsSortable="true"
                    Property="(e) => e.UpdatedRecently"
                    CustomTitle="Recently updated" />
</DataTable>
```

### Pagination

```cs
<DataTable TModel="WeatherForecast"
           Items="forecasts"
           UsePaging="true">
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.Date" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.TemperatureC"
                    CustomTitle="Celsius" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.TemperatureF"
                    CustomTitle="Fahrenheit" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.MyNullableInt" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.Summary" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.Country" />
    <DataTableColumn TModel="WeatherForecast"
                    Property="(e) => e.UpdatedRecently"
                    CustomTitle="Recently updated" />
</DataTable>
```

### Filtering

```cs
<DataTable TModel="WeatherForecast"
           Items="forecasts">
    <DataTableColumn TModel="WeatherForecast"
                    IsFilterable="true"
                    Property="(e) => e.Date" />
    <DataTableColumn TModel="WeatherForecast"
                    IsFilterable="true"
                    Property="(e) => e.TemperatureC"
                    CustomTitle="Celsius" />
    <DataTableColumn TModel="WeatherForecast"
                    IsFilterable="true"
                    Property="(e) => e.TemperatureF"
                    CustomTitle="Fahrenheit" />
    <DataTableColumn TModel="WeatherForecast"
                    IsFilterable="true"
                    Property="(e) => e.MyNullableInt" />
    <DataTableColumn TModel="WeatherForecast"
                    IsFilterable="true"
                    Property="(e) => e.Summary" />
    <DataTableColumn TModel="WeatherForecast"
                    IsFilterable="true"
                    Property="(e) => e.Country" />
    <DataTableColumn TModel="WeatherForecast"
                    IsFilterable="true"
                    Property="(e) => e.UpdatedRecently"
                    CustomTitle="Recently updated" />
</DataTable>
```

### Header/Grid filters

```cs
<DataTable TModel="WeatherForecast"
           Items="forecasts"
           SearchOnApplyHeaderFilter="true">
    <DataTableColumn TModel="WeatherForecast"
                    IsFilterable="true"
                    IncludeHeaderFilter="true"
                    Property="(e) => e.Date" />
    <DataTableColumn TModel="WeatherForecast"
                    IsFilterable="true"
                    IncludeHeaderFilter="true"
                    Property="(e) => e.TemperatureC"
                    CustomTitle="Celsius" />
    <DataTableColumn TModel="WeatherForecast"
                    IsFilterable="true"
                    IncludeHeaderFilter="true"
                    Property="(e) => e.TemperatureF"
                    CustomTitle="Fahrenheit" />
    <DataTableColumn TModel="WeatherForecast"
                    IsFilterable="true"
                    IncludeHeaderFilter="true"
                    Property="(e) => e.MyNullableInt" />
    <DataTableColumn TModel="WeatherForecast"
                    IsFilterable="true"
                    IncludeHeaderFilter="true"
                    Property="(e) => e.Summary" />
    <DataTableColumn TModel="WeatherForecast"
                    IsFilterable="true"
                    IncludeHeaderFilter="true"
                    Property="(e) => e.Country" />
    <DataTableColumn TModel="WeatherForecast"
                    IsFilterable="true"
                    IncludeHeaderFilter="true"
                    Property="(e) => e.UpdatedRecently"
                    CustomTitle="Recently updated" />
</DataTable>
```

### Server side support

```cs
<DataTable TModel="WeatherForecast"
           Items="pagedForecasts.Data"
           UsePaging="true"
           FetchData="DoFetchData"
           PageCount="@pagedForecasts.Paging.PageCount"
           PageSize="@pagedForecasts.Paging.PageSize">
    <DataTableColumn TModel="WeatherForecast"
                    IsSortable="true"
                    IsFilterable="true"
                    Property="(e) => e.Date" />
    <DataTableColumn TModel="WeatherForecast"
                    IsSortable="true"
                    IsFilterable="true"
                    Property="(e) => e.TemperatureC"
                    CustomTitle="Celsius" />
    <DataTableColumn TModel="WeatherForecast"
                    IsSortable="true"
                    IsFilterable="true"
                    Property="(e) => e.TemperatureF"
                    CustomTitle="Fahrenheit" />
    <DataTableColumn TModel="WeatherForecast"
                    IsSortable="true"
                    IsFilterable="true"
                    Property="(e) => e.MyNullableInt" />
    <DataTableColumn TModel="WeatherForecast"
                    IsSortable="true"
                    IsFilterable="true"
                    Property="(e) => e.Summary" />
    <DataTableColumn TModel="WeatherForecast"
                    IsSortable="true"
                    IsFilterable="true"
                    Property="(e) => e.Country" />
    <DataTableColumn TModel="WeatherForecast"
                    IsSortable="true"
                    IsFilterable="true"
                    Property="(e) => e.UpdatedRecently"
                    CustomTitle="Recently updated" />
</DataTable>

// Method will be called by the DataTable when necessary
private async Task DoFetchData(RequestArgs<WeatherForecast> args)
{
    pagedForecasts = await ForecastService.SearchForecastAsync(args);
    // Don't forget to call StateHasChanged() since your component is the owner of the DataTable
    StateHasChanged();
}

// ForecastService:
public async Task SearchForecastAsync(RequestArgs<WeatherForecast> args)
{
    IQueryable<WeatherForecast> result = context.Forecasts.AsQueryable();

    // RequestArgs contains all the information about sorting, paging and filtering
    foreach (var filter in args.AppliedFilters)
    {
        // Filters can easily be translated into expressions, 
        // or use the filtering info to create your own filtering solution
        result = result.Where(filter.GenerateExpression());
    }
    
    // Use the Core.Utils to easily apply paging and sorting
    // Or use the paging info in RequestArgs to build your own paging solution
    pagedResult = Utils.ApplyPaging(result, pager);

    return Task.FromResult(pagedResult);
}
```

### Support bootstrap table styles

```cs
<DataTable TModel="WeatherForecast" Items="forecasts" Styles="TableStyle.Sm">
....
</DataTable>
```


```cs
<DataTable TModel="WeatherForecast" Items="forecasts" Styles="TableStyle.Bordered">
....
</DataTable>
```

```cs
<DataTable TModel="WeatherForecast" Items="forecasts" Styles="TableStyle.Borderless">
....
</DataTable>
```

```cs
<DataTable TModel="WeatherForecast" Items="forecasts" Styles="TableStyle.Dark">
....
</DataTable>
```


```cs
<DataTable TModel="WeatherForecast" Items="forecasts" Styles="TableStyle.Hover">
....
</DataTable>
```


```cs
<DataTable TModel="WeatherForecast" Items="forecasts" Styles="TableStyle.Striped">
....
</DataTable>
```

### Alignment

```cs
<DataTable TModel="WeatherForecast"
           Items="forecasts">
    <DataTableColumn TModel="WeatherForecast"
                    TextAlignment="Core.Models.TextAlignment.Center"
                    IsSortable="true"
                    Property="(e) => e.Date" />
    <DataTableColumn TModel="WeatherForecast"
                    TextAlignment="Core.Models.TextAlignment.End"
                    IsSortable="true"
                    Property="(e) => e.TemperatureC"
                    CustomTitle="Celsius" />
    <DataTableColumn TModel="WeatherForecast"
                    TextAlignment="Core.Models.TextAlignment.Left"
                    IsSortable="true"
                    Property="(e) => e.TemperatureF"
                    CustomTitle="Fahrenheit" />
    <DataTableColumn TModel="WeatherForecast"
                    TextAlignment="Core.Models.TextAlignment.Right"
                    IsSortable="true"
                    Property="(e) => e.MyNullableInt" />
    <DataTableColumn TModel="WeatherForecast"
                    TextAlignment="Core.Models.TextAlignment.Start"
                    IsSortable="true"
                    Property="(e) => e.Summary" />
</DataTable>
```

---

## Licence and contribution
A lot of people sent me the same question. My components ([MarkdownEditor](https://www.puresourcecode.com/dotnet/blazor/markdown-editor-component-for-blazor), [DataTable](https://www.puresourcecode.com/dotnet/net-core/datatable-component-for-blazor), [SVG Icon](https://www.puresourcecode.com/dotnet/blazor/svg-icons-and-flags-for-blazor) and others that you find on my [GitHub](https://github.com/erossini)) are freeware. 

I ask you to contribute to the project in one of the following ways:

- sending your feedback
- highlight bugs
- ask for improvement
- submit code and fixes
- share the project
- share my website [PureSourceCode.com](https://www.puresourcecode.com/)

If you don't know how to do it or you:

- want to support this project
- find very useful this project and it saves you a lot of time and work
- like to sustain my work
- want to pay my a beer
- are using this component for commercial purpose and you want to set your conscience at rest and/or put a hand on one's heart 😂

then, you can buy one of the support licence I created. There are different prices. The amount is your decision. You find have a full list on [PureSourceCode Shop](https://www.puresourcecode.com/shop)

The contribution gives you:

- dedicate email support
- priority access to the support
- fast bug fix
- receive preview and beta of the components
- help to fix your code with [Visual Studio Live Share](https://www.puresourcecode.com/tools/a-guide-to-remote-development-with-visual-studio-live-share/)
    
---
   
## Other Blazor components

| Component name | Forum | Description |
|---|---|---|
| [DataTable for Blazor](https://www.puresourcecode.com/dotnet/net-core/datatable-component-for-blazor/) | [Forum](https://www.puresourcecode.com/forum/forum/datatables/) | DataTable component for Blazor WebAssembly and Blazor Server |
| [Markdown editor for Blazor](https://www.puresourcecode.com/dotnet/blazor/markdown-editor-with-blazor/) | [Forum](https://www.puresourcecode.com/forum/forum/markdown-editor-for-blazor/) |  This is a Markdown Editor for use in Blazor. It contains a live preview as well as an embeded help guide for users. |
| [CodeSnipper for Blazor](https://www.puresourcecode.com/dotnet/blazor/code-snippet-component-for-blazor/) | [Forum](https://www.puresourcecode.com/forum/codesnippet-for-blazor/) | Add code snippet in your Blazor pages for 196 programming languages with 243 styles |
| [Copy To Clipboard](https://www.puresourcecode.com/dotnet/blazor/copy-to-clipboard-component-for-blazor/) | [Forum](https://www.puresourcecode.com/forum/copytoclipboard/) | Add a button to copy text in the clipbord | 
| SVG Icons and flags for Blazor | [Forum](https://www.puresourcecode.com/forum/icons-and-flags-for-blazor/) | Library with a lot of SVG icons and SVG flags to use in your Razor pages |
| [Modal dialog for Blazor](https://www.puresourcecode.com/dotnet/blazor/modal-dialog-component-for-blazor/) | [Forum](https://www.puresourcecode.com/forum/forum/modal-dialog-for-blazor/) |  Simple Modal Dialog for Blazor WebAssembly |
| [PSC.Extensions](https://www.puresourcecode.com/dotnet/net-core/a-lot-of-functions-for-net5/) | [Forum](https://www.puresourcecode.com/forum/forum/psc-extensions/) |  A lot of functions for .NET5 in a NuGet package that you can download for free. We collected in this package functions for everyday work to help you with claim, strings, enums, date and time, expressions... |
| [Quill for Blazor](https://www.puresourcecode.com/dotnet/blazor/create-a-blazor-component-for-quill/) | [Forum](https://www.puresourcecode.com/forum/forum/quill-for-blazor/) |  Quill Component is a custom reusable control that allows us to easily consume Quill and place multiple instances of it on a single page in our Blazor application |
| [Segment for Blazor](https://www.puresourcecode.com/dotnet/blazor/segment-control-for-blazor/) | [Forum](https://www.puresourcecode.com/forum/forum/segments-for-blazor/) |  This is a Segment component for Blazor Web Assembly and Blazor Server |
| [Tabs for Blazor](https://www.puresourcecode.com/dotnet/blazor/tabs-control-for-blazor/) | [Forum](https://www.puresourcecode.com/forum/forum/tabs-for-blazor/) |  This is a Tabs component for Blazor Web Assembly and Blazor Server |
| [WorldMap for Blazor]() | [Forum](https://www.puresourcecode.com/forum/worldmap-for-blazor/) | Show world maps with your data |

## More examples and documentation
*   [Write a reusable Blazor component](https://www.puresourcecode.com/dotnet/blazor/write-a-reusable-blazor-component/)
*   [Getting Started With C# And Blazor](https://www.puresourcecode.com/dotnet/net-core/getting-started-with-c-and-blazor/)
*   [Setting Up A Blazor WebAssembly Application](https://www.puresourcecode.com/dotnet/blazor/setting-up-a-blazor-webassembly-application/)
*   [Working With Blazor Component Model](https://www.puresourcecode.com/dotnet/blazor/working-with-blazors-component-model/)
*   [Secure Blazor WebAssembly With IdentityServer4](https://www.puresourcecode.com/dotnet/blazor/secure-blazor-webassembly-with-identityserver4/)
*   [Blazor Using HttpClient With Authentication](https://www.puresourcecode.com/dotnet/blazor/blazor-using-httpclient-with-authentication/)
*   [InputSelect component for enumerations in Blazor](https://www.puresourcecode.com/dotnet/blazor/inputselect-component-for-enumerations-in-blazor/)
*   [Use LocalStorage with Blazor WebAssembly](https://www.puresourcecode.com/dotnet/blazor/use-localstorage-with-blazor-webassembly/)
*   [Modal Dialog component for Blazor](https://www.puresourcecode.com/dotnet/blazor/modal-dialog-component-for-blazor/)
*   [Create Tooltip component for Blazor](https://www.puresourcecode.com/dotnet/blazor/create-tooltip-component-for-blazor/)
*   [Consume ASP.NET Core Razor components from Razor class libraries | Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/blazor/components/class-libraries?view=aspnetcore-5.0&tabs=visual-studio)
