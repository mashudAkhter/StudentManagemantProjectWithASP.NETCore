#pragma checksum "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6aa24058347d65fd2ac54d2750e82f8649d15c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fee_EditMultiple), @"mvc.1.0.view", @"/Views/Fee/EditMultiple.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Fee/EditMultiple.cshtml", typeof(AspNetCore.Views_Fee_EditMultiple))]
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
#line 1 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\_ViewImports.cshtml"
using SchoolManagementCore;

#line default
#line hidden
#line 2 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\_ViewImports.cshtml"
using SchoolManagementCore.Models;

#line default
#line hidden
#line 3 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\_ViewImports.cshtml"
using SchoolManagementCore.Models.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6aa24058347d65fd2ac54d2750e82f8649d15c8", @"/Views/Fee/EditMultiple.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2525cbbc90e0b0824b6a6cc040c716bf5c5cce9f", @"/Views/_ViewImports.cshtml")]
    public class Views_Fee_EditMultiple : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SchoolManagementCore.Models.ViewModels.VmStudentWiseCourseFee>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
  
    ViewBag.Title = "Edit";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(153, 227, true);
            WriteLiteral("<div class=\"container\">\r\n    <div style=\"background-color:palegoldenrod\">\r\n        <h2 style=\"text-align:center; background-color:palevioletred\">Edit CourseFee</h2>\r\n        <div style=\"padding-right:20px;padding-left:20px;\">\r\n");
            EndContext();
#line 10 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
             using (Html.BeginForm("EditMultiple", "Fee", FormMethod.Post, new { enctype = "multipart/form-data" }))
            {
                

#line default
#line hidden
            BeginContext(530, 23, false);
#line 12 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(557, 209, true);
            WriteLiteral("                <div class=\"form-horizontal\">\r\n                    <div class=\"form-group\">\r\n                        Student\r\n                        <select id=\"StudentInfoId\" name=\"StudentInfoId\" required>\r\n");
            EndContext();
#line 18 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
                             foreach (var item in Model.StudentList)
                            {
                                var Selected = item.StudentInfoId == Model.StudentInfoId ? "selected" : "";

#line default
#line hidden
            BeginContext(976, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(1008, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6aa24058347d65fd2ac54d2750e82f8649d15c85495", async() => {
                BeginContext(1045, 16, false);
#line 21 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
                                                               Write(item.StudentName);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 21 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
                                   WriteLiteral(item.StudentInfoId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1070, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 22 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
                            }

#line default
#line hidden
            BeginContext(1103, 1091, true);
            WriteLiteral(@"                        </select>
                    </div>
                    <div class=""form-group"">
                        <div id=""FeeData"" class=""Table"">
                            <div id=""RowData"" class=""Row"">
                                <input type=""hidden"" name=""FeeTblId"" />
                                <input type=""text"" name=""Month"" style=""max-width:150px"" placeholder=""Month"" />&nbsp;&nbsp;
                                <input type=""text"" name=""ExamFee"" style=""max-width:150px"" placeholder=""ExamFee"" />&nbsp;&nbsp;
                                <input type=""text"" name=""CourseFee"" style=""max-width:150px""  placeholder=""CourseFee"" />&nbsp;&nbsp;
                                <input type=""date"" name=""AdmissionDate"" style=""max-width:150px"" placeholder=""AdmissionDate"" />&nbsp;&nbsp;
                                <input type=""file"" name=""imgFile"" style=""max-width:250px"" placeholder=""imgFile"" />
                                <a id=""addRow"" href=""#"" class=""btn btn-xs btn-succe");
            WriteLiteral("ss\"><i>Add More</i></a><hr />\r\n                            </div>\r\n");
            EndContext();
#line 36 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
                             foreach (var item in Model.CourseFeeList)
                            {
                                var AdmissionDate = item.AdmissionDate == null ? "" : Convert.ToDateTime(item.AdmissionDate).ToString("yyyy-MM-dd");

#line default
#line hidden
            BeginContext(2447, 120, true);
            WriteLiteral("                        <div id=\"RowData\" class=\"Row\">\r\n                            <input type=\"hidden\" name=\"FeeTblId\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2567, "\"", 2589, 1);
#line 40 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
WriteAttributeValue("", 2575, item.FeeTblId, 2575, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2590, 108, true);
            WriteLiteral(" />\r\n                            <input type=\"text\" name=\"Month\" style=\"max-width:150px\" placeholder=\"Month\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2698, "\"", 2717, 1);
#line 41 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
WriteAttributeValue("", 2706, item.Month, 2706, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2718, 124, true);
            WriteLiteral(" />&nbsp;&nbsp;\r\n                            <input type=\"text\" name=\"ExamFee\" style=\"max-width:150px\" placeholder=\"ExamFee\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2842, "\"", 2863, 1);
#line 42 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
WriteAttributeValue("", 2850, item.ExamFee, 2850, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2864, 128, true);
            WriteLiteral(" />&nbsp;&nbsp;\r\n                            <input type=\"text\" name=\"CourseFee\" style=\"max-width:150px\" placeholder=\"CourseFee\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2992, "\"", 3015, 1);
#line 43 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
WriteAttributeValue("", 3000, item.CourseFee, 3000, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3016, 136, true);
            WriteLiteral(" />&nbsp;&nbsp;\r\n                            <input type=\"date\" name=\"AdmissionDate\" style=\"max-width:150px\" placeholder=\"AdmissionDate\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3152, "\"", 3174, 1);
#line 44 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
WriteAttributeValue("", 3160, AdmissionDate, 3160, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3175, 235, true);
            WriteLiteral(" />&nbsp;&nbsp;\r\n                            <input type=\"file\" name=\"imgFile\" style=\"max-width:250px\" placeholder=\"imgFile\" />\r\n                            <a id=\"deleteRow\" href=\"#\" class=\"btn btn-xs btn-danger\"><i> Remove </i></a>\r\n");
            EndContext();
            BeginContext(3493, 68, true);
            WriteLiteral("                            <hr />\r\n                        </div>\r\n");
            EndContext();
#line 50 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
                            }

#line default
#line hidden
            BeginContext(3592, 376, true);
            WriteLiteral(@"                        </div>
                    </div>

                    <div class=""form-group"">
                        <div class=""col-md-offset-2 col-md-4"">
                            <input type=""submit"" value=""Edit"" class=""btn btn-info"">

                        </div>
                        <div style=""text-align:right;"">
                            ");
            EndContext();
            BeginContext(3969, 40, false);
#line 60 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
                       Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(4009, 86, true);
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 64 "D:\Mashud\Git_Project\Project\UpdateProject\SchoolManagementCoreSln\SchoolManagementCore\Views\Fee\EditMultiple.cshtml"
            }

#line default
#line hidden
            BeginContext(4110, 1041, true);
            WriteLiteral(@"        </div>
       
    </div>
</div>

<script type=""text/javascript"" src=""https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
<script>

    $('#addRow').on('click', function () {
        $('#FeeData').append('<div id=""RowData"" class=""Row""><input type=""text"" style=""max-width:150px"" name=""Month"" placeholder=""Month"" /><input type=""text"" style=""max-width:150px"" name=""ExamFee"" placeholder=""ExamFee"" /><input type=""text"" style=""max-width:150px"" name=""CourseFee"" placeholder=""CourseFee"" /><input type=""date"" style=""max-width:150px"" name=""AdmissionDate"" placeholder=""AdmissionDate"" /><input type=""file"" style=""max-width:250px"" name=""imgFile"" placeholder=""imgFile"" /><a id=""deleteRow"" href=""#"" class=""btn btn-xs btn-danger""><i>-</i></a><hr /></div>');
        $('#FeeData').addClass();
        return false; //prevent form submission
    });
    $('#FeeData').on('click', '#deleteRow', function () {
        $(this).parent().remove();
        return false; //prevent form submission
   ");
            WriteLiteral(" });\r\n</script>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SchoolManagementCore.Models.ViewModels.VmStudentWiseCourseFee> Html { get; private set; }
    }
}
#pragma warning restore 1591
