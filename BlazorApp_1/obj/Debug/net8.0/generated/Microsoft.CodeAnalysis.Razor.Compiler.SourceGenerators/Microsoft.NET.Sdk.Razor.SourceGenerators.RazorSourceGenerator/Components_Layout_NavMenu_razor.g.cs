﻿#pragma checksum "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\Layout\NavMenu.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "c57c7114beaa1aa27c5a58a49e59c12d8e9b2794da92347a166b0778c1e21e82"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorApp_1.Components.Layout
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
    public partial class NavMenu : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<div class=""top-row ps-3 navbar navbar-dark"" b-2r0wsxsfgo><div class=""container-fluid"" b-2r0wsxsfgo><a class=""navbar-brand"" href b-2r0wsxsfgo>BlazorApp_1</a></div></div>

<input type=""checkbox"" title=""Navigation menu"" class=""navbar-toggler"" b-2r0wsxsfgo>

");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "nav-scrollable");
            __builder.AddAttribute(3, "onclick", "document.querySelector(\'.navbar-toggler\').click()");
            __builder.AddAttribute(4, "b-2r0wsxsfgo");
            __builder.OpenElement(5, "nav");
            __builder.AddAttribute(6, "class", "flex-column");
            __builder.AddAttribute(7, "b-2r0wsxsfgo");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "nav-item px-3");
            __builder.AddAttribute(10, "b-2r0wsxsfgo");
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Routing.NavLink>(11);
            __builder.AddComponentParameter(12, "class", "nav-link");
            __builder.AddComponentParameter(13, "href", "");
            __builder.AddComponentParameter(14, "Match", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 12 "D:\darbas\BlazorCodeDemo\BlazorApp_1\Components\Layout\NavMenu.razor"
                                                     NavLinkMatch.All

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(16, "<span class=\"bi bi-house-door-fill-nav-menu\" aria-hidden=\"true\" b-2r0wsxsfgo></span> Home\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n\r\n        ");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "nav-item px-3");
            __builder.AddAttribute(20, "b-2r0wsxsfgo");
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Routing.NavLink>(21);
            __builder.AddComponentParameter(22, "class", "nav-link");
            __builder.AddComponentParameter(23, "href", "counter");
            __builder.AddAttribute(24, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(25, "<span class=\"bi bi-plus-square-fill-nav-menu\" aria-hidden=\"true\" b-2r0wsxsfgo></span> Counter\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n\r\n        ");
            __builder.OpenElement(27, "div");
            __builder.AddAttribute(28, "class", "nav-item px-3");
            __builder.AddAttribute(29, "b-2r0wsxsfgo");
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Routing.NavLink>(30);
            __builder.AddComponentParameter(31, "class", "nav-link");
            __builder.AddComponentParameter(32, "href", "weather");
            __builder.AddAttribute(33, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(34, "<span class=\"bi bi-list-nested-nav-menu\" aria-hidden=\"true\" b-2r0wsxsfgo></span> Weather\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
