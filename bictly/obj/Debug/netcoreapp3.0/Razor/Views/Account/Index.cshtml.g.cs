#pragma checksum "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "79f1b657c08adc15c0d028536c3e564328101a18"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Index), @"mvc.1.0.view", @"/Views/Account/Index.cshtml")]
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
#line 1 "D:\asp.net apps\bictly\bictly\Views\_ViewImports.cshtml"
using bictly;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\asp.net apps\bictly\bictly\Views\_ViewImports.cshtml"
using bictly.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79f1b657c08adc15c0d028536c3e564328101a18", @"/Views/Account/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"455172ca782fb676a05b73de15e39348ef1f9c12", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<bictly.Models.Article>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
  
    ViewData["Title"] = "Account";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div>\r\n        <h1>Account</h1><hr />\r\n        <h2>");
#nullable restore
#line 9 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
       Write(ViewBag.UserData.username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2><hr>\r\n");
#nullable restore
#line 10 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
         if (ViewBag.UserData.username == User.Identity.Name)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <small>API access token: ");
#nullable restore
#line 12 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
                                Write(ViewBag.UserData.token);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n");
#nullable restore
#line 13 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1>Articles</h1>\r\n");
#nullable restore
#line 15 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
         if (ViewBag.UserData.username == User.Identity.Name)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a href=\"/Main/Create/\">Create Article</a><br>\r\n");
#nullable restore
#line 18 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n");
#nullable restore
#line 19 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
         foreach (var i in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div>\r\n                <small>");
#nullable restore
#line 22 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
                  Write(Html.DisplayFor(m => i.date));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - <a");
            BeginWriteAttribute("href", " href=\"", 635, "\"", 675, 2);
            WriteAttributeValue("", 642, "/Account/?name=", 642, 15, true);
#nullable restore
#line 22 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
WriteAttributeValue("", 657, i.Author.username, 657, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 22 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
                                                                                              Write(Html.DisplayFor(m => i.Author.username));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> - views: ");
#nullable restore
#line 22 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
                                                                                                                                                    Write(Html.DisplayFor(m => i.popularity));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                <h2><a");
            BeginWriteAttribute("href", " href=\"", 798, "\"", 824, 3);
            WriteAttributeValue("", 805, "/Main/Detail/", 805, 13, true);
#nullable restore
#line 23 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
WriteAttributeValue("", 818, i.id, 818, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 823, "/", 823, 1, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 23 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
                                             Write(Html.DisplayFor(m => i.title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h2>\r\n                <small>");
#nullable restore
#line 24 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
                  Write(Html.DisplayFor(m => i.description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n");
#nullable restore
#line 25 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
                 if (User.Identity.Name == i.Author.username)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 1040, "\"", 1064, 3);
            WriteAttributeValue("", 1047, "/Main/Edit/", 1047, 11, true);
#nullable restore
#line 27 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
WriteAttributeValue("", 1058, i.id, 1058, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1063, "/", 1063, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning\">Edit</a>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1122, "\"", 1148, 3);
            WriteAttributeValue("", 1129, "/Main/Delete/", 1129, 13, true);
#nullable restore
#line 28 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
WriteAttributeValue("", 1142, i.id, 1142, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1147, "/", 1147, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Delete</a>\r\n");
#nullable restore
#line 29 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <hr>\r\n            </div>\r\n");
#nullable restore
#line 32 "D:\asp.net apps\bictly\bictly\Views\Account\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<bictly.Models.Article>> Html { get; private set; }
    }
}
#pragma warning restore 1591
