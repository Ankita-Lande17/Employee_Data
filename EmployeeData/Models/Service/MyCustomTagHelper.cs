
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;


namespace EmployeeData.TagHelpers

{
    [HtmlTargetElement("my-first-tag-helper")]
    public class MyCustomTagHelper : TagHelper
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "CustumTagHelper";
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();
            sb.AppendFormat("<span>Hi! {0}</span><b>{1}</b>", this.Name,this.Desc);

            output.PreContent.SetHtmlContent(sb.ToString());
        }

    }
}
