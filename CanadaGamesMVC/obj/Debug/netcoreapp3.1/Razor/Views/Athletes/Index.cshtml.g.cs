#pragma checksum "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e50fbcbaa5e079262d4c92e3dc1d41c075b30d71"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Athletes_Index), @"mvc.1.0.view", @"/Views/Athletes/Index.cshtml")]
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
#line 1 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\_ViewImports.cshtml"
using CanadaGamesMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\_ViewImports.cshtml"
using CanadaGamesMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e50fbcbaa5e079262d4c92e3dc1d41c075b30d71", @"/Views/Athletes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27a178bfe713b07669bfce5e9f7946c06aa97f7b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Athletes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CanadaGamesMVC.Models.Athlete>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Download", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AthletePlacements", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_PagingNavBar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e50fbcbaa5e079262d4c92e3dc1d41c075b30d716662", async() => {
                WriteLiteral("Create New Athlete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    \r\n</p>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e50fbcbaa5e079262d4c92e3dc1d41c075b30d717845", async() => {
                WriteLiteral("\r\n    <input type=\"hidden\" name=\"sortDirection\"");
                BeginWriteAttribute("value", " value=\"", 267, "\"", 301, 1);
#nullable restore
#line 14 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
WriteAttributeValue("", 275, ViewData["sortDirection"], 275, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <input type=\"hidden\" name=\"sortField\"");
                BeginWriteAttribute("value", " value=\"", 348, "\"", 378, 1);
#nullable restore
#line 15 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
WriteAttributeValue("", 356, ViewData["sortField"], 356, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <div class=\"form-horizontal\">\r\n        <div class=\"row\">\r\n            <div class=\"form-group col-md-4\">\r\n                <label class=\"control-label\">Select by Coach:</label>\r\n                ");
#nullable restore
#line 20 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
           Write(Html.DropDownList("CoachID", null, "All Coaches", htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group col-md-4\">\r\n                <label class=\"control-label\">Filter by Contingent:</label>\r\n                ");
#nullable restore
#line 24 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
           Write(Html.DropDownList("ContingentID", null, "All Contingents", htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group col-md-4\">\r\n                <label class=\"control-label\">Filter by Sport:</label>\r\n                ");
#nullable restore
#line 28 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
           Write(Html.DropDownList("SportID", null, "All Sports", htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group col-md-4\">\r\n                <label class=\"control-label\">Filter by Gender:</label>\r\n                ");
#nullable restore
#line 32 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
           Write(Html.DropDownList("GenderID", null, "All Genders", htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group col-md-4\">\r\n                <label class=\"control-label\">Search Athlete Name:</label>\r\n                ");
#nullable restore
#line 36 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
           Write(Html.TextBox("SearchString", null, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group col-md-4\">\r\n                <label class=\"control-label\">Filter By Media Info:</label>\r\n                ");
#nullable restore
#line 40 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
           Write(Html.TextBox("MediaSearchString", null, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group col-md-4 align-self-end\">\r\n                <input type=\"submit\" name=\"actionButton\" value=\"Filter\" class=\"btn btn-outline-primary\" />\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e50fbcbaa5e079262d4c92e3dc1d41c075b30d7112196", async() => {
                    WriteLiteral("Clear");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            </div>
        </div>
    </div>

    <table class=""table"">
        <thead>
            <tr>
                <th>
                    <input type=""submit"" disabled=""disabled"" value=""Photo"" , class=""btn btn-link"" />
                </th>
                <th>
                    <input type=""submit"" name=""actionButton"" value=""Athlete"" , class=""btn btn-link"" />
                </th>
                <th>
                    <input type=""submit"" name=""actionButton"" value=""Hometown"" , class=""btn btn-link"" />
                </th>
                <th>
                    <input type=""submit"" name=""actionButton"" value=""Age"" , class=""btn btn-link"" />
                </th>
                <th>
                    <input type=""submit"" name=""actionButton"" value=""Sport"" , class=""btn btn-link"" />
                </th>
                <th>
                    <input type=""submit"" disabled=""disabled"" value=""Gender"" , class=""btn btn-link"" />
                </th>
                <th>
  ");
                WriteLiteral(@"                  <input type=""submit"" disabled=""disabled"" value=""Coach"" , class=""btn btn-link"" />
                </th>
                <th>
                    <input type=""submit"" disabled=""disabled"" value=""Documents"" , class=""btn btn-link"" />
                </th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 79 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\r\n                <td>\r\n");
#nullable restore
#line 83 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                      
                        if (item.AthleteThumbnail?.Content != null)
                        {
                            string imageBase64 = Convert.ToBase64String(item.AthleteThumbnail.Content);
                            string imageSrc = string.Format("data:" + item.AthleteThumbnail.MimeType + ";base64,{0}", imageBase64);

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <img");
                BeginWriteAttribute("src", " src=\"", 4028, "\"", 4043, 1);
#nullable restore
#line 88 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
WriteAttributeValue("", 4034, imageSrc, 4034, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 4044, "\"", 4083, 4);
                WriteAttributeValue("", 4050, "Profile", 4050, 7, true);
                WriteAttributeValue(" ", 4057, "Picture", 4058, 8, true);
                WriteAttributeValue(" ", 4065, "of", 4066, 3, true);
#nullable restore
#line 88 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
WriteAttributeValue(" ", 4068, item.FullName, 4069, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("title", " title=\"", 4084, "\"", 4125, 4);
                WriteAttributeValue("", 4092, "Profile", 4092, 7, true);
                WriteAttributeValue(" ", 4099, "Picture", 4100, 8, true);
                WriteAttributeValue(" ", 4107, "of", 4108, 3, true);
#nullable restore
#line 88 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
WriteAttributeValue(" ", 4110, item.FullName, 4111, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-fluid rounded\" />\r\n");
#nullable restore
#line 89 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
                WriteLiteral("                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 93 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FullName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 96 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Hometown.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 99 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Age));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 102 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Sport.Code));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 105 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Gender.Code));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 108 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Coach.FullName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 111 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                      
                        int fileCount = item.AthleteDocuments.Count;
                        if (fileCount > 0)
                        {
                            var firstFile = item.AthleteDocuments.FirstOrDefault(); ;
                            if (fileCount > 1)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <a");
                BeginWriteAttribute("class", " class=\"", 5294, "\"", 5302, 0);
                EndWriteAttribute();
                WriteLiteral(" role=\"button\" data-toggle=\"collapse\"");
                BeginWriteAttribute("href", " href=\"", 5340, "\"", 5370, 2);
                WriteAttributeValue("", 5347, "#collapseDocs", 5347, 13, true);
#nullable restore
#line 118 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
WriteAttributeValue("", 5360, item.ID, 5360, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" aria-expanded=\"false\"");
                BeginWriteAttribute("aria-controls", " aria-controls=\"", 5393, "\"", 5431, 2);
                WriteAttributeValue("", 5409, "collapseDocs", 5409, 12, true);
#nullable restore
#line 118 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
WriteAttributeValue("", 5421, item.ID, 5421, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <span class=\"badge badge-info\">");
#nullable restore
#line 119 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                                                              Write(fileCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span> Documents...\r\n                                </a>\r\n                                <div class=\"collapse\"");
                BeginWriteAttribute("id", " id=\"", 5625, "\"", 5652, 2);
                WriteAttributeValue("", 5630, "collapseDocs", 5630, 12, true);
#nullable restore
#line 121 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
WriteAttributeValue("", 5642, item.ID, 5642, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 122 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                                      
                                        foreach (var d in item.AthleteDocuments)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e50fbcbaa5e079262d4c92e3dc1d41c075b30d7122908", async() => {
#nullable restore
#line 125 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                                                                                     Write(d.FileName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 125 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                                                                       WriteLiteral(d.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" <br />\r\n");
#nullable restore
#line 126 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                                        }
                                    

#line default
#line hidden
#nullable disable
                WriteLiteral("                                </div>\r\n");
#nullable restore
#line 129 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e50fbcbaa5e079262d4c92e3dc1d41c075b30d7126098", async() => {
#nullable restore
#line 132 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                                                                                 Write(firstFile.FileName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 132 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                                                           WriteLiteral(firstFile.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 133 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                            }
                        }
                    

#line default
#line hidden
#nullable disable
                WriteLiteral("                </td>\r\n                <td>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e50fbcbaa5e079262d4c92e3dc1d41c075b30d7128972", async() => {
                    WriteLiteral("Edit");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 138 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                                           WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" |\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e50fbcbaa5e079262d4c92e3dc1d41c075b30d7131253", async() => {
                    WriteLiteral("Details");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-AthleteID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 139 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                                                                                      WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["AthleteID"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-AthleteID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["AthleteID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" |\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e50fbcbaa5e079262d4c92e3dc1d41c075b30d7133822", async() => {
                    WriteLiteral("Delete");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 140 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
                                             WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 143 "C:\Users\joshi\source\repos\JWoodCanadaGames\JWoodCanadaGames\Views\Athletes\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e50fbcbaa5e079262d4c92e3dc1d41c075b30d7136393", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CanadaGamesMVC.Models.Athlete>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
