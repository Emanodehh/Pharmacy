#pragma checksum "C:\Users\user\Desktop\Phramacy New\Phramacy New\Views\Users\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82d16dea033b1e358d9bab71c0a558d95b421b37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Login), @"mvc.1.0.view", @"/Views/Users/Login.cshtml")]
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
#line 1 "C:\Users\user\Desktop\Phramacy New\Phramacy New\Views\_ViewImports.cshtml"
using Phramacy_New;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Desktop\Phramacy New\Phramacy New\Views\_ViewImports.cshtml"
using Phramacy_New.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82d16dea033b1e358d9bab71c0a558d95b421b37", @"/Views/Users/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43b156ac8c9ce254e062c70a2778f6ccc71f1360", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities.User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/login.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "82d16dea033b1e358d9bab71c0a558d95b421b373786", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 6 "C:\Users\user\Desktop\Phramacy New\Phramacy New\Views\Users\Login.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <section class=""vh-100 gradient-custom"">
        <div class=""container py-5 h-100"">
            <div class=""row d-flex justify-content-center align-items-center h-100"">
                <div class=""col-12 col-md-8 col-lg-6 col-xl-5"">
                    <div class=""card bg-dark text-white"" style=""border-radius: 1rem;"">
                        <div class=""card-body p-5 text-center"">

                            <div class=""mb-md-5 mt-md-4 pb-5"">

                                <h2 class=""fw-bold mb-2 text-uppercase"">Login</h2>
                                <p class=""text-white-50 mb-5"">Please enter your login and password!</p>

                                <div class=""form-outline form-white mb-4"">
");
            WriteLiteral("                                    ");
#nullable restore
#line 22 "C:\Users\user\Desktop\Phramacy New\Phramacy New\Views\Users\Login.cshtml"
                               Write(Html.EditorFor(model => model.Email, new { htmlAttributes = new { @class = "form-control form-control-lg" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    <label class=\"form-label\" for=\"typeEmailX\">Email</label>\r\n                                </div>\r\n\r\n\r\n                                <div class=\"form-outline form-white mb-4\">\r\n");
            WriteLiteral("                                    ");
#nullable restore
#line 29 "C:\Users\user\Desktop\Phramacy New\Phramacy New\Views\Users\Login.cshtml"
                               Write(Html.PasswordFor(model => model.Password, new { htmlAttributes = new { @class = "form-control form-control-lg" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    <br />\r\n                                    <label class=\"form-label\" for=\"typePasswordX\">Password</label>\r\n                                </div>\r\n\r\n");
#nullable restore
#line 34 "C:\Users\user\Desktop\Phramacy New\Phramacy New\Views\Users\Login.cshtml"
                                 if (!String.IsNullOrEmpty(ViewBag.error))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"alert alert-danger\" role=\"alert\">\r\n                                        ");
#nullable restore
#line 37 "C:\Users\user\Desktop\Phramacy New\Phramacy New\Views\Users\Login.cshtml"
                                   Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n");
#nullable restore
#line 39 "C:\Users\user\Desktop\Phramacy New\Phramacy New\Views\Users\Login.cshtml"

                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                <p class=""small mb-5 pb-lg-2""><a class=""text-white-50"" href=""#!"">Forgot password?</a></p>

                                <button class=""btn btn-outline-light btn-lg px-5"" type=""submit"">Login</button>

                                <div class=""d-flex justify-content-center text-center mt-4 pt-1"">
                                    <a href=""#!"" class=""text-white""><i class=""fab fa-facebook-f fa-lg""></i></a>
                                    <a href=""#!"" class=""text-white""><i class=""fab fa-twitter fa-lg mx-4 px-2""></i></a>
                                    <a href=""#!"" class=""text-white""><i class=""fab fa-google fa-lg""></i></a>
                                </div>

                            </div>

                            <div>
                                <p class=""mb-0"">
                                    Don't have an account? <a href=""#!"" class=""text-white-50 fw-bold"">Sign Up</a>
                                </p>
                      ");
            WriteLiteral("      </div>\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n");
#nullable restore
#line 67 "C:\Users\user\Desktop\Phramacy New\Phramacy New\Views\Users\Login.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
