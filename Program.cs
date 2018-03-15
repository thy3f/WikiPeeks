using System;
using System.IO;
using WikiPeeks.Helpers;

namespace WikiPeeks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("START!");

            do
            {
                ListHelper.WriteToFile();
                DateHelper.nextDay();
            } while (DateHelper.Date != "January_2");

            Console.WriteLine("DONE!");

            Console.ReadLine();
        }
    }
}
