using System;
using System.Collections.Generic;
using System.Text;

namespace WikiPeeks.Helpers
{
    class ListHelper
    {
        // takes list
        // saves list to DB
        // saves list to File
        private static List<string> list;

        public static List<string> List
        {
            get
            {
                return list;
            }

            set => list = value;
        }

        public static List<string> GetList()
        {
            list = DataHelper.List;
            if (list == null || list.Count == 0)
                list = DataHelper.GetList();
            return list;
        }

        public static void WriteToFile()
        {
            if (list == null || list.Count == 0)
                GetList();
            FileHelper.WriteToFile(list);
        }
    }
}