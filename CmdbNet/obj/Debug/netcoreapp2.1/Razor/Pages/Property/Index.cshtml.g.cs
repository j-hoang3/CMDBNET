#pragma checksum "C:\Users\joseph.hoang\Source\Repos\cmdb\CmdbNet\Pages\Property\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25a72f6995977e41ac82872443fc926a791e1ec9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CmdbNet.Pages.Property.Pages_Property_Index), @"mvc.1.0.razor-page", @"/Pages/Property/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Property/Index.cshtml", typeof(CmdbNet.Pages.Property.Pages_Property_Index), null)]
namespace CmdbNet.Pages.Property
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\joseph.hoang\Source\Repos\cmdb\CmdbNet\Pages\_ViewImports.cshtml"
using CmdbNet;

#line default
#line hidden
#line 4 "C:\Users\joseph.hoang\Source\Repos\cmdb\CmdbNet\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25a72f6995977e41ac82872443fc926a791e1ec9", @"/Pages/Property/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf580a256d8e7402b56d1ff47ca7152292567a8c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Property_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\joseph.hoang\Source\Repos\cmdb\CmdbNet\Pages\Property\Index.cshtml"
  
    ViewData["Title"] = "Propery Report";
    ViewData["User"] = HttpContext.User.Identity.Name;

#line default
#line hidden
            BeginContext(157, 65, true);
            WriteLiteral("\r\n<br />\r\n\r\n<!-- Property View Table -->\r\n<div id=\"property\">\r\n\r\n");
            EndContext();
            BeginContext(452, 1377, true);
            WriteLiteral(@"
    <table id=""property_table"" class=""display cell-border compact nowrap"" style=""width:100%;"">

        <thead>
            <tr>
                <th></th>
                <th>CD Tag</th>
                <th>CMDB CD Tag</th>
                <th>AD User</th>
                <th>Current User</th>
                <th>Room</th>
                <th>stlv2</th>
                <th>Floor</th>
                <th>Location</th>
                <th>stlv1</th>
                <th>Inventory Date</th>
                <th>stlv3</th>
                <th>Inventoried By</th>
                <th>Effective Date</th>
                <th>Physical Inventory Date</th>
                <th>CMDB Status</th>
                <th>Status</th>
                <th>Sunflower User</th>
                <th>Description</th>
                <th>Model Name</th>
                <th>Class - Type</th>
                <th>Organization</th>
                <th>Cust Area</th>
                <th>Custodian</th>
              ");
            WriteLiteral(@"  <th>Host Name</th>
                <th>Resolution</th>
                <th>Resolution Date</th>
                <th>Final Event</th>
                <th>Datetime</th>
                <th>Final Event User Defined Field Label 01</th>
                <th>Final Event User Field 01</th>
            </tr>
        </thead>
    </table>

</div>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CmdbNet.Pages.Property.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CmdbNet.Pages.Property.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CmdbNet.Pages.Property.IndexModel>)PageContext?.ViewData;
        public CmdbNet.Pages.Property.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
