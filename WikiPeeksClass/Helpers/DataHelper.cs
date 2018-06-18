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
            try
            {
                htmlNode = SetHtmlNode();
                list = new List<string>();
                list.Add(DateHelper.Date.ToString());

                List<string> categoryList = new List<string>();
                categoryList.Add("Events");
                categoryList.Add("Births");
                categoryList.Add("Deaths");
                int categoryId = 0;
                int tempYear = -9999;

                foreach (var node in htmlNode)
                {
                    if (RegexHelper.IsMatch(node.InnerText))
                    {
                        int tempDate = GetYearFromString(node.InnerText.Split('–')[0].Trim());

                        if (tempDate + 300 >= tempYear)
                        {
                            tempYear = tempDate;
                        }
                        else
                        {
                            categoryId++;
                            tempYear = -9999;
                        }

                        list.Add(categoryList[categoryId] + " – " + tempDate.ToString() + " - " + node.InnerText.Split('–')[1].TrimEnd());
                    }
                }
                return list;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception found in {DateHelper.Date.ToString()} \n {ex.Message}");
                return list;
            }
        }

        public static int GetYearFromString(string text)
        {
            if (text.ToUpper().Contains("AD"))
                text = text.ToUpper().Remove(text.IndexOf('A'), 2);
            else if (text.ToUpper().Contains("BCE"))
                text = "-" + text.ToUpper().Remove(text.IndexOf("B"), 3);
            else if (text.ToUpper().Contains("BC"))
                text = "-" + text.ToUpper().Remove(text.IndexOf("B"), 2);
            else if (text.ToUpper().Contains("("))
                text = text.ToUpper().Remove(text.ToUpper().IndexOf("("), text.Length - text.ToUpper().IndexOf("(")).Trim();
            else if (text.ToUpper().Contains("OR"))
                text = text.ToUpper().Remove(text.ToUpper().IndexOf("O"), text.Length - text.ToUpper().IndexOf("O")).Trim();
            else if (text.ToUpper().Contains("O.S."))
                text = text.ToUpper().Remove(text.ToUpper().IndexOf("("), text.Length - text.ToUpper().IndexOf("(")).Trim();
            else if (text.ToUpper().Contains("-"))
                text = text.ToUpper().Remove(text.ToUpper().IndexOf("-"), text.Length - text.ToUpper().IndexOf("-")).Trim();
            else if (text.ToUpper().Contains("/"))
                text = text.ToUpper().Remove(text.ToUpper().IndexOf("/"), text.Length - text.ToUpper().IndexOf("/")).Trim();
            return Int32.Parse(text);
        }
    }
}
