using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    /// <summary>
    /// get the singelton instance of BL
    /// </summary>
    public static class Factory
    {
        private static IBL instance = null;
        public static IBL GetInstance()
        {
            if (instance == null)
                instance = new imp_BL();
            return instance;
        }
    }

}
