#pragma checksum "C:\Users\ASUS\Desktop\LastHMS1\Views\Room\BusyRooms.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc178a6141f4ea48c16bf1e2687d4724b6089cbc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Room_BusyRooms), @"mvc.1.0.view", @"/Views/Room/BusyRooms.cshtml")]
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
#line 1 "C:\Users\ASUS\Desktop\LastHMS1\Views\_ViewImports.cshtml"
using LastHMS1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\LastHMS1\Views\_ViewImports.cshtml"
using LastHMS1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc178a6141f4ea48c16bf1e2687d4724b6089cbc", @"/Views/Room/BusyRooms.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc01b71688cffe0268ef9ccba8d9a6c910bdb1ee", @"/Views/_ViewImports.cshtml")]
    public class Views_Room_BusyRooms : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LastHMS1.ShowClasses.BusyRooms>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\ASUS\Desktop\LastHMS1\Views\Room\BusyRooms.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>");
#nullable restore
#line 6 "C:\Users\ASUS\Desktop\LastHMS1\Views\Room\BusyRooms.cshtml"
   Write(item.RoomNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <br />\r\n    <h1>");
#nullable restore
#line 8 "C:\Users\ASUS\Desktop\LastHMS1\Views\Room\BusyRooms.cshtml"
   Write(item.StartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <br />\r\n    <h1>");
#nullable restore
#line 10 "C:\Users\ASUS\Desktop\LastHMS1\Views\Room\BusyRooms.cshtml"
   Write(item.PatientName);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</h1>\r\n");
#nullable restore
#line 11 "C:\Users\ASUS\Desktop\LastHMS1\Views\Room\BusyRooms.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LastHMS1.ShowClasses.BusyRooms>> Html { get; private set; }
    }
}
#pragma warning restore 1591
