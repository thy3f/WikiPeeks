using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiPeeks.Helpers
{
    class DataHelper
    {
        private static HtmlDocument doc;
        private static List<string> list;
        private static HtmlNodeCollection htmlNode;

        public DataHelper()
        {
            doc = ResponseHelper.GetHtml();
            list = new List<string>();
            //htmlNode = doc.DocumentNode.SelectNodes("//div[contains(@class, \"mw-parser-output\")]/ul/li");
            htmlNode = doc.DocumentNode.SelectNodes(@Properties.Resources.parser);
        }

        private static HtmlDocument Doc
        {
            get => doc;
            set => doc = ResponseHelper.GetHtml();
        }

        public static List<string> List
        {
            get => list;
            set => list = value;
        }
        public static HtmlNodeCollection HtmlNode
        {
            get
            {
                return htmlNode;
            }
            set => htmlNode = SetHtmlNode();
        }

        private static HtmlNodeCollection SetHtmlNode()
        {
            doc = ResponseHelper.GetHtml();
            return doc.DocumentNode.SelectNodes("//div[contains(@class, \"mw-parser-output\")]/ul/li");
        }

        public static List<string> GetList()
        {
            htmlNode = SetHtmlNode();
            list = new List<string>();

            foreach (var node in htmlNode)
            {
                if(RegexHelper.IsMatch(node.InnerText))
                {
                    list.Add(node.InnerText);
                }
            }
            return list;
        }

    }
}
