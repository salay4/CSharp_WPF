using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DAL
{


    /// get the singelton instance of BL

    static public class Factory
    {
        static IDAL instance = null;
        public static IDAL GetInstance()
        {
            if (instance == null)
                instance = new Dal_XML_imp();
                //instance = new imp_Dal();

                return instance;
        }

    }
}
