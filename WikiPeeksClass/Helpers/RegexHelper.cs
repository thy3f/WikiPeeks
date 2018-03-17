using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WikiPeeks.Helpers
{
    class RegexHelper
    {
        private static Regex rgx;

        public RegexHelper()
        {
            rgx = new Regex(Properties.Resources.pattern);
        }

        internal static Regex Rgx
        {
            get
            {
                return rgx;
            }
            set => rgx = new Regex(Properties.Resources.pattern);
        }

        public static bool IsMatch(string innerText)
        {
            rgx = new Regex(@Properties.Resources.pattern);
            if (rgx.IsMatch(innerText))
                return true;
            else
                return false;
        }
    }
}
