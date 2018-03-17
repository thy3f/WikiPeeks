using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiPeeks.Helpers
{
    class ResponseHelper
    {
        private static string response;

        public ResponseHelper()
        {
            response = RequestHelper.GetResponse();
        }

        public static string Response
        {
            get
            {
                return response;
            }
            set => response = value;
        }

        private static string SetResponse()
        {
            return RequestHelper.GetResponse();
        }

        public static HtmlDocument GetHtml()
        {
            response = SetResponse();
            var doc = new HtmlDocument();
            doc.LoadHtml(response);
            return doc;
        }
    }
}
