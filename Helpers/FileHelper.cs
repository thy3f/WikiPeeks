using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WikiPeeks.Helpers
{
    class FileHelper
    {
        private static StreamWriter file;

        internal static StreamWriter File
        {
            get => file; set
            {
                file = value;
            }
        }

        public static StreamWriter SetFile()
        {
            if (file == null)
                file = new StreamWriter(@Properties.Resources.filePath + DateHelper.getMonth() + '_' + DateHelper.getDay() + ".txt");
            return file;
        }

        public static void WriteToFile(List<string> list)
        {
            if (file == null)
                SetFile();
            foreach(var val in list)
            {
                file.WriteLine(val);
            }
            file.Close();
        }
    }
}
