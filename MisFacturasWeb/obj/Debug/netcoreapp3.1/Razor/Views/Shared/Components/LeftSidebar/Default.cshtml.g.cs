#pragma checksum "C:\lMartinez\NetCore\MisFacturasWeb\Views\Shared\Components\LeftSidebar\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a974a5b690d1094fe79550dd8c950fccff57994"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_LeftSidebar_Default), @"mvc.1.0.view", @"/Views/Shared/Components/LeftSidebar/Default.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\lMartinez\NetCore\MisFacturasWeb\Views\_ViewImports.cshtml"
using MisFacturasWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\lMartinez\NetCore\MisFacturasWeb\Views\_ViewImports.cshtml"
using MisFacturasWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a974a5b690d1094fe79550dd8c950fccff57994", @"/Views/Shared/Components/LeftSidebar/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e01b18781cb438fc31ed4554f90d51dd0a72ede7", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_LeftSidebar_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MisFacturasWeb.Models.LeftSidebarModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<script>\r\n    var modelMenu = \'");
#nullable restore
#line 5 "C:\lMartinez\NetCore\MisFacturasWeb\Views\Shared\Components\LeftSidebar\Default.cshtml"
                Write(Html.Raw(Json.Serialize(Model)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n    var ListaMenu = JSON.parse(modelMenu);\r\n</script>\r\n\r\n<header id=\"header\">\r\n    ");
#nullable restore
#line 10 "C:\lMartinez\NetCore\MisFacturasWeb\Views\Shared\Components\LeftSidebar\Default.cshtml"
Write(await Html.PartialAsync("_Header", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</header>\r\n\r\n<aside class=\"sidebar sidebar-left\">\r\n\r\n    ");
#nullable restore
#line 15 "C:\lMartinez\NetCore\MisFacturasWeb\Views\Shared\Components\LeftSidebar\Default.cshtml"
Write(await Html.PartialAsync("_LeftSidebar", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</aside>\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MisFacturasWeb.Models.LeftSidebarModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
