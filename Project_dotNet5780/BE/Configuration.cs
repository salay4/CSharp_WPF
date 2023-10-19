using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BE
{
    public class Configuration
    {
        public static int orderID = 10000000;
        public static int hostUnitID = 20000000;
        public static int geustReqID = 40000000;
        public static int Commission = 10;
        public static int commissionAll = 0;




        public static bool BanksXmlFinish = true;
        public static int GetGuestRequestKey()
        {
            geustReqID++;
            Tools.SaveConfigToXml();
            return geustReqID;

        }

        public static int GetOrderKey()
        {
            orderID++;
            Tools.SaveConfigToXml();
            return orderID;

        }




        public static int GetHostingUnitKey()
        {
            hostUnitID++;
            Tools.SaveConfigToXml();
            return hostUnitID;
        }


        //public static XElement ConfigRoot;


    }
}
