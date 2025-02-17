using Microsoft.AspNetCore.Mvc.Rendering;
namespace AspNet.Extensions
{
    // defining HTML helper extension method
    public static class HtmlCopyrightExtension
    {
        public static string Copyright(this IHtmlHelper html)
        {
            int currentYear = DateTime.Now.Year;
            return $"© {currentYear} - ASPortfolio - ";
        }
    }
}
