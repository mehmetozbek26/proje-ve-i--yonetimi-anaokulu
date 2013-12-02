using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnaOkuluBilisim
{
    public static class GlobalClass
    {
        private static string m_globalVar = "";
        public static string GlobalVar
        {
            get { return m_globalVar; }
            set { m_globalVar = value; }
        }
        private static string ogrid;
        public static string Ogrid
        {
            get { return ogrid; }
            set { ogrid = value; }
        }
    }
}
