using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //WikiPeeks.WikiPeeksClass wikiPeeks = new WikiPeeks.WikiPeeksClass();
            //wikiPeeks.WriteToFile(new DateTime(1, 12, 31));

            WikiPeeks.WikiPeeksClass wikiPeeks = new WikiPeeks.WikiPeeksClass(new DateTime(1, 1, 4));


            List<List<string>> list = new List<List<string>>();
            list = wikiPeeks.GetList(new DateTime(1, 1, 6));

            foreach(List<string> tempList in list)
            {
                foreach (string line in tempList)
                {
                    Console.WriteLine(line);
                }
                //Console.ReadLine();
            }
            //log.Info("Info logging");
            //log.Error("This is my error", ex);
            //log4net.GlobalContext.Properties["testProperty"] = "This is my test property information";
            //Console.ReadLine();
        }
    }
}
