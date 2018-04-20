using System;

namespace WikiPeeks.Helpers
{
    public class UrlHelper
    {
        private static string url;

        public UrlHelper()
        {
            url = SetUrl(DateHelper.getMonth(), DateHelper.getDay());
        }

        public static string Url
        {
            get
            {
                return url;
            }

            set => url = value;
        }

        public static string SetUrl(string month, string day)
        {
            url = Properties.Resources.url;

            DateTime tempdate = new DateTime(1, DateHelper.monthToInt(), DateHelper.dayToInt());
            //tempdate = tempdate.AddDays(1);

            url = url.Substring(0, url.LastIndexOf('/') + 1) + month + "_" + day;

            return url;
        }
    }
}