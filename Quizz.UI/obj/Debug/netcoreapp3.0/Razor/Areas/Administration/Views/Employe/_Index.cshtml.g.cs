#pragma checksum "E:\absquizz\UI\QuizzCoreMvc\Quizz.UI\Areas\Administration\Views\Employe\_Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d855256d640a7233b7e916546912928b15593fd4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administration_Views_Employe__Index), @"mvc.1.0.view", @"/Areas/Administration/Views/Employe/_Index.cshtml")]
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
#line 4 "E:\absquizz\UI\QuizzCoreMvc\Quizz.UI\Areas\Administration\Views\_ViewImports.cshtml"
using Quizz.DomainModel.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\absquizz\UI\QuizzCoreMvc\Quizz.UI\Areas\Administration\Views\_ViewImports.cshtml"
using DataTables.AspNetCore.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d855256d640a7233b7e916546912928b15593fd4", @"/Areas/Administration/Views/Employe/_Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85d838a58c0207e0a09098b7d33447e511709208", @"/Areas/Administration/Views/_ViewImports.cshtml")]
    public class Areas_Administration_Views_Employe__Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EmployeAfficheViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    <table id=""tabemployes""  class=""table table-striped table-bordered dt-responsive nowrap"" width=""100%"" cellspacing=""0"">
                                    <thead>
                                        <tr>
                                             <th>Id</th>
                                            <th>Nom</th>
                                            <th>Societe</th>
                                            <th>Type Employe</th>
                                            <th>Matricule</th>
                                            <th>E-Mail</th>
                                            <th>Telephone</th>
                                            <th>Edit</th>  
                                            <th>Delete</th>  
                                        </tr>
                                    </thead>
</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EmployeAfficheViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
