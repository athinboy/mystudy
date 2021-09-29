
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace Org.FGQ.CodeGenerate.RazorTag
{
    [HtmlTargetElement("ReverseStr")]
    public class ReverseStrTagHelper : TagHelper
    {


        // Can be passed via <email mail-to="..." />. 
        // PascalCase gets translated into kebab-case.
        public string MailTo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string content = output.Content.GetContent();
            char[] charArray = content.ToCharArray();
            Array.Reverse(charArray);
            content = new string(charArray);

            output.Content.SetContent(content);
        }

    }
}
