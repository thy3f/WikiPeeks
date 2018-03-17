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

        public WikiPeeksClass(string filePath, string parser, string pattern, string url)
        {
            this.filePath = filePath;
            this.parser = parser;
            this.pattern = pattern;
            this.url = url;
        }

        public void RunMe(string date)
        {
            do
            {
                ListHelper.WriteToFile();
                DateHelper.nextDay();
            } while (DateHelper.Date != date);
        }
    }
}
