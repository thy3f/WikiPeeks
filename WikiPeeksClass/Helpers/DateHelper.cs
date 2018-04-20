using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WikiPeeks.Helpers
{
    class DateHelper
    {
        private static string date;

        public DateHelper()
        {
            date = Properties.Resources.url.Substring(Properties.Resources.url.LastIndexOf('/') + 1);
        }

        public static string changeDate(DateTime tempDate)
        {
            return monthToString(tempDate) + '_' + tempDate.Day.ToString();
        }

        public static string Date
        {
            get
            {
                return date;
            }

            set => date = value;
        }

        public static string getDate()
        {
            if(date == null)
                date = Properties.Resources.url.Substring(Properties.Resources.url.LastIndexOf('/') + 1);
            return date;
        }

        public static string getMonth()
        {
            return date.Split('_')[0];
        }

        public static string getDay()
        {
            return date.Split('_')[1];
        }

        public static string getMonth(string tempDate)
        {
            return tempDate.Split('_')[0];
        }

        public static string getDay(string tempDate)
        {
            return tempDate.Split('_')[1];
        }

        public static int dayToInt()
        {
            return Int32.Parse(getDay());
        }

        public static int monthToInt()
        {
            return DateTime.ParseExact(getMonth(), "MMMM", CultureInfo.CurrentCulture).Month;
        }

        public static string monthToString(DateTime tempDate)
        {
            return tempDate.ToString("MMMM");
            //return DateTime.ParseExact(tempDate, "MMMM", CultureInfo.CurrentCulture).Month;
        }

        public static string dayToString(int day)
        {
            //day++;
            return day.ToString();
        }

        public static void nextDay()
        {
            DateTime tempdate = new DateTime(1, monthToInt(), dayToInt());
            string temlUrl = UrlHelper.Url;
            tempdate = tempdate.AddDays(1);
            date = changeDate(tempdate);
            UrlHelper.SetUrl(getMonth(), getDay());
            // not set to null
            ListHelper.List = null;
            FileHelper.File = null;
            DataHelper.List = null;
            RequestHelper.Url = UrlHelper.Url;
        }
    }
}
