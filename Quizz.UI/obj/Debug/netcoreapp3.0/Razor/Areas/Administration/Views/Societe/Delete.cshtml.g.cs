#pragma checksum "E:\absquizz\UI\QuizzCoreMvc\Quizz.UI\Areas\Administration\Views\Societe\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a51984b8ccf9dfa4e346e17724cd5ba16544423"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administration_Views_Societe_Delete), @"mvc.1.0.view", @"/Areas/Administration/Views/Societe/Delete.cshtml")]
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
#line 1 "E:\absquizz\UI\QuizzCoreMvc\Quizz.UI\Areas\Administration\Views\_ViewImports.cshtml"
using Quizz.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\absquizz\UI\QuizzCoreMvc\Quizz.UI\Areas\Administration\Views\_ViewImports.cshtml"
using Quizz.UI.Areas.Administration.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\absquizz\UI\QuizzCoreMvc\Quizz.UI\Areas\Administration\Views\_ViewImports.cshtml"
using Quizz.UI.Areas.Administration.Traducteur;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\absquizz\UI\QuizzCoreMvc\Quizz.UI\Areas\Administration\Views\_ViewImports.cshtml"
using DataTables.AspNetCore.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a51984b8ccf9dfa4e346e17724cd5ba16544423", @"/Areas/Administration/Views/Societe/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cd24cd85483ef24434992af2361967e8ce34cbd", @"/Areas/Administration/Views/_ViewImports.cshtml")]
    public class Areas_Administration_Views_Societe_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\absquizz\UI\QuizzCoreMvc\Quizz.UI\Areas\Administration\Views\Societe\Delete.cshtml"
  
     Layout = "_LayoutAdministration";
    ViewData["Title"] = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Suppression</h2>\r\n<p class=\"text-danger\">");
#nullable restore
#line 6 "E:\absquizz\UI\QuizzCoreMvc\Quizz.UI\Areas\Administration\Views\Societe\Delete.cshtml"
                  Write(ViewData["ErrorMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<h3>Are you sure you want to delete this?</h3>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
