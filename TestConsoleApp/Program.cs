using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]


namespace TestConsoleApp
{
    class Program
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        //    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            WikiPeeks.WikiPeeksClass wikiPeeks = new WikiPeeks.WikiPeeksClass();
            wikiPeeks.RunMe(DateTime.Today.ToString());
            //log.Info("Info logging");
            //log.Error("This is my error", ex);
            //log4net.GlobalContext.Properties["testProperty"] = "This is my test property information";
            Console.ReadLine();
        }
    }
}
