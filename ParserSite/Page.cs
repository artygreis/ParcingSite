using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSite
{
    //класс для обработки значений для БД
    class Page
    {
        //название статьи
        private static string pageArticleName;

        public static string GetpageArticleName()
        {
            return pageArticleName;
        }

        public static void SetpageArticleName(string value)
        {
            pageArticleName = value.Replace("&quot;", "");
        }

        //адрес URL статьи
        public static string pageUrl { get; set; }

        //сам текст статьи
        private static string pageArticleText;

        public static string GetpageArticleText()
        {
            return pageArticleText;
        }

        public static void SetpageArticleText(string value)
        {
            string[] array = value.Split('\n');
            string result = "";
            foreach (string str in array)
                if (String.IsNullOrWhiteSpace(str) != true)
                    result += str + '\n';
            pageArticleText = result.Trim('\n');
        }

        //HTML-текст страницы, на которой находится статья
        private static string pageAllHtml;

        public static string GetpageAllHtml()
        {
            return pageAllHtml;
        }

        public static void SetpageAllHtml(string value)
        {
            string[] array = value.Split('\n');
            string result = "";
            foreach (string str in array)
                if (String.IsNullOrWhiteSpace(str) != true)
                    result += str + '\n';
            pageAllHtml = result.Trim('\n');
        }
    }
}
