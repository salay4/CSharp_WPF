using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Net.NetworkInformation;



namespace BE
{

    public static class Tools
    {

        public static bool ValidateID(string IDNum)
        {
            // Validate correct input
            if (!System.Text.RegularExpressions.Regex.IsMatch(IDNum, @"^\d{5,9}$"))
                return false;

            // The number is too short - add leading 0000
            while (IDNum.Length < 9)
                IDNum = '0' + IDNum;

            // CHECK THE ID NUMBER
            int mone = 0;
            int incNum;
            for (int i = 0; i < 9; i++)
            {
                incNum = Convert.ToInt32(IDNum[i].ToString()) * ((i % 2) + 1);
                if (incNum > 9)
                    incNum -= 9;
                mone += incNum;
            }
            return (mone % 10 == 0);
        }






        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class UnLogicException : Exception
        {
            public int capacity { get; private set; }
            public UnLogicException() : base() { }
            public UnLogicException(string message) : base(message) { }
            public UnLogicException(string message, Exception inner) : base(message, inner) { }
            protected UnLogicException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
            // special constructor for our custom exception

            override public string ToString()
            {
                return "UnLogicException: שגיאה לוגית  " + Message;
            }
        }




        public static XElement ConfigRoot;

        public static readonly string configPath = "config.xml";
        public static readonly string HostingUnitPath = "HostingUnit.xml";
        public static readonly string OrderPath = "Order.xml";
        public static readonly string GuestPath = "Guest.xml";
        public static readonly string BankAccuntPath = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\BL\bank\atmData.xml");


        public static string xmlServerPath =
               @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";




        public static void DownloadBankXmlLoop()
        {
            while (true)
            {
                Thread.Sleep(1000);

                try
                {
                    if (new Ping().Send("google.com").Status == IPStatus.Success)
                    {
                        DownloadBankXml();
                        long length = new FileInfo(BankAccuntPath).Length;
                        if (length > 20000) break;


                    }
                }
                catch { } //ללא זריקה 
            }
        }



        public static void DownloadBankXml()
        {
            Configuration.BanksXmlFinish = false;

            WebClient wc = new WebClient();
            try
            {

                wc.DownloadFile(xmlServerPath, BankAccuntPath);

            }
            catch (Exception)
            {
                try
                {
                    string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                    wc.DownloadFile(xmlServerPath, BankAccuntPath);
                }
                catch (Exception)
                {

                }
            }
            finally
            {
                wc.Dispose();
                Configuration.BanksXmlFinish = true;
            }

        }

        public static List<BankBranch> XmlToBankAccunt(XElement bankAccuntsRoot)
        {
            try
            {
                return (from bankAccunt in bankAccuntsRoot.Elements()
                        select new BankBranch()
                        {
                            BankName = bankAccunt.Element("שם_בנק").Value.Trim(),
                            BankNumber = Convert.ToInt32(bankAccunt.Element("קוד_בנק").Value.Trim()),
                            BranchAddress = bankAccunt.Element("כתובת_ה-ATM").Value.Trim(),
                            BranchCity = bankAccunt.Element("ישוב").Value.Trim(),
                            BranchNumber = Convert.ToInt32(bankAccunt.Element("קוד_סניף").Value.Trim())
                        }
                        ).Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SaveConfigToXml()
        {
            try
            {
                ConfigRoot = new XElement("config");
                ConfigRoot.Add(
                    new XElement("geustReqID", Configuration.geustReqID),
                    new XElement("hostUnitID", Configuration.hostUnitID),
                    new XElement("orderID", Configuration.orderID),
                    new XElement("Commission", Configuration.Commission),
                    new XElement("commissionAll", Configuration.commissionAll));

                ConfigRoot.Save(configPath);

            }
            catch (Exception ) { }



        }





        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source);
            file.Close();
        }


        public static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file);
            file.Close();
            return result;
        }



        public static T[] Flatten<T>(this T[,] arr)
        {
            int rows = arr.GetLength(1);
            int columns = arr.GetLength(0);
            T[] arrFlattened = new T[rows * columns];
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    var test = arr[i, j];
                    arrFlattened[i * rows + j] = arr[i, j];
                }
            }
            return arrFlattened;
        }
        public static T[,] Expand<T>(this T[] arr, int rows)
        {
            int length = arr.GetLength(0);
            int columns = length / rows;
            T[,] arrExpanded = new T[columns, rows];
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    arrExpanded[i, j] = arr[i * rows + j];
                }
            }
            return arrExpanded;
        }



    }
}
