#pragma checksum "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c8e24e8c3424077b52763dfc77876d9d52f8bcc4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_UserDetails), @"mvc.1.0.view", @"/Views/User/UserDetails.cshtml")]
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
#line 1 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\_ViewImports.cshtml"
using BoZhou.BudgetTrackerMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\_ViewImports.cshtml"
using BoZhou.BudgetTrackerMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8e24e8c3424077b52763dfc77876d9d52f8bcc4", @"/Views/User/UserDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc5556ea1422d76895646e2181989cf06b484bf2", @"/Views/_ViewImports.cshtml")]
    public class Views_User_UserDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BoZhou.BudgetTracker.ApplicationCore.Models.UserDetailModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div>
    <h1>
        User Summary
    </h1>
    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"">User Id</th>
                <th scope=""col"">Total Income</th>
                <th scope=""col"">Total Expenditure</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>");
#nullable restore
#line 17 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
               Write(Model.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 18 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
               Write(Model.TotalIncome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 19 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
               Write(Model.TotalExpenditure);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
            </tr>
        </tbody>
    </table>
</div>
<div>
    <h1>User Income</h1>
    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"">Income Id</th>
                <th scope=""col"">Amount</th>
                <th scope=""col"">Description</th>
                <th scope=""col"">Remarks</th>
                <th scope=""col"">Income Date</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 37 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
             foreach (var income in Model.Incomes) 
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 40 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
               Write(income.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 41 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
               Write(income.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 42 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
               Write(income.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 43 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
               Write(income.Remarks);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 44 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
               Write(income.IncomeDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 46 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>
<div>
    <h1>User Expenditure</h1>
    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"">Expenditure Id</th>
                <th scope=""col"">Amount</th>
                <th scope=""col"">Description</th>
                <th scope=""col"">Remarks</th>
                <th scope=""col"">Expenditure Date</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 63 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
             foreach (var expenditure in Model.expenditures)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 66 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
                   Write(expenditure.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 67 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
                   Write(expenditure.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 68 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
                   Write(expenditure.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 69 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
                   Write(expenditure.Remarks);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 70 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
                   Write(expenditure.ExpDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 72 "C:\Users\Bo\Desktop\Antra Project\BoZhou.BudgetTracker\BoZhou.BudgetTrackerMVC\Views\User\UserDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BoZhou.BudgetTracker.ApplicationCore.Models.UserDetailModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
