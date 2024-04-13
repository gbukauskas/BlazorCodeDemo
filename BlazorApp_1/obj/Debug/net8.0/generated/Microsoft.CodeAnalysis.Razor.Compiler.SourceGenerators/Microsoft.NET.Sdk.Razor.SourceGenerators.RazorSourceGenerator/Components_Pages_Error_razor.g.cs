﻿#pragma checksum "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\Pages\Error.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "e77473780e53f2ba6d42105b745d3eca7cdbdaec1d407bc46a8ce9338b43eb29"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorApp_1.Components.Pages
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\_Imports.razor"
using static Microsoft.AspNetCore.Components.Web.RenderMode;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\_Imports.razor"
using BlazorApp_1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\_Imports.razor"
using BlazorApp_1.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\_Imports.razor"
using BlazorApp_1.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\Pages\Error.razor"
using System.Diagnostics;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/Error")]
    public partial class Error : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Web.PageTitle>(0);
            __builder.AddAttribute(1, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(2, "Error");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(3, "\r\n\r\n");
            __builder.AddMarkupContent(4, "<h1 class=\"text-danger\">Error.</h1>\r\n");
            __builder.AddMarkupContent(5, "<h2 class=\"text-danger\">An error occurred while processing your request.</h2>");
#nullable restore
#line 9 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\Pages\Error.razor"
 if (ShowRequestId)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(6, "p");
            __builder.AddMarkupContent(7, "<strong>Request ID:</strong> ");
            __builder.OpenElement(8, "code");
#nullable restore
#line (12,45)-(12,54) 24 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\Pages\Error.razor"
__builder.AddContent(9, RequestId);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 14 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\Pages\Error.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(10, "<h3>Development Mode</h3>\r\n");
            __builder.AddMarkupContent(11, "<p>\r\n    Swapping to <strong>Development</strong> environment will display more detailed information about the error that occurred.\r\n</p>\r\n");
            __builder.AddMarkupContent(12, @"<p><strong>The Development environment shouldn't be enabled for deployed applications.</strong>
    It can result in displaying sensitive information from exceptions to end users.
    For local debugging, enable the <strong>Development</strong> environment by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>
    and restarting the app.
</p>");
        }
        #pragma warning restore 1998
#nullable restore
#line 27 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\Pages\Error.razor"
      
    [CascadingParameter]
    private HttpContext? HttpContext { get; set; }

    private string? RequestId { get; set; }
    private bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    protected override void OnInitialized() =>
        RequestId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
