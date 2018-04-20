using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiPeeks.Helpers;

namespace WikiPeeks
{
    public class WikiPeeksClass
    {
        private string filePath;
        private string parser;
        private string pattern;
        private string url;

        public WikiPeeksClass()
        {
            filePath = Properties.Resources.filePath;
            parser = Properties.Resources.parser;
            pattern = Properties.Resources.pattern;
            url = Properties.Resources.url;
        }

        public WikiPeeksClass(DateTime startDate)
        {
            filePath = Properties.Resources.filePath;
            parser = Properties.Resources.parser;
            pattern = Properties.Resources.pattern;
            
            url = Properties.Resources.url.Substring(0, Properties.Resources.url.LastIndexOf('/') + 1) + DateHelper.monthToString(startDate) + '_' + startDate.Day.ToString();

            UrlHelper.Url = url;
            DateHelper.Date = url.Substring(Properties.Resources.url.LastIndexOf('/') + 1);
        }

        public WikiPeeksClass(string filePath, string parser, string pattern, string url)
        {
            this.filePath = filePath;
            this.parser = parser;
            this.pattern = pattern;
            this.url = url;
        }

        public void WriteToFile(DateTime date)
        {
            string _date = "";
            _date = DateHelper.monthToString(date) + "_" + DateHelper.dayToString(date.Day);

            do
            {
                ListHelper.WriteToFile();
                DateHelper.nextDay();
                Console.WriteLine(DateHelper.Date);
            } while (DateHelper.Date != _date);
        }

        public List<List<string>> GetList(DateTime date)
        {
            List<List<string>> list = new List<List<string>>();
            List<string> tempList = new List<string>();
            string _date = "";
            _date = DateHelper.monthToString(date) + "_" + DateHelper.dayToString(date.Day);
            //RequestHelper.Url = 

            do
            {
                tempList = ListHelper.GetList();
                list.Add(tempList);
                DateHelper.nextDay();
                Console.WriteLine(DateHelper.Date);
                Console.ReadLine();
            } while (DateHelper.Date != _date);

            return list;
        }

        public void RunMe(string date)
        {
            do
            {
                ListHelper.WriteToFile();
                DateHelper.nextDay();
                Console.WriteLine(DateHelper.Date);
            } while (DateHelper.Date != date);
        }
    }
}
