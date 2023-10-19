using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;


namespace DAL
{
    class Dal_XML_imp :IDAL
    {

        //////XElement OrderRoot;
        XElement bankAccuntsRoot;

        //public static List<BE.GuestRequest> GuestRequestList1;

        public static List<BE.HostingUnit> HostingUnitList1;

        public static List<BE.BankBranch> bankAccuntsList;
        public static List<BE.Order> OrderList;

        XElement GuestRoot;




        internal Dal_XML_imp()
        {




            /// config file
            if (!File.Exists(BE.Tools.configPath))
            {
                BE.Tools.SaveConfigToXml();
            }
            else
            { 


                BE.Tools.ConfigRoot = XElement.Load(BE.Tools.configPath);
                BE.Configuration.geustReqID = Convert.ToInt32(BE.Tools.ConfigRoot.Element("geustReqID").Value);
                BE.Configuration.hostUnitID = Convert.ToInt32(BE.Tools.ConfigRoot.Element("hostUnitID").Value);
                BE.Configuration.orderID = Convert.ToInt32(BE.Tools.ConfigRoot.Element("orderID").Value);
                BE.Configuration.Commission = Convert.ToInt32(BE.Tools.ConfigRoot.Element("Commission").Value);
                //BE.Configuration.commissionAll = Convert.ToInt32(BE.Tools.ConfigRoot.Element("commissionAll").Value);

            }

            if (!File.Exists(BE.Tools.GuestPath))
            {
                GuestRoot = new XElement("GuestRequests");
                GuestRoot.Save(BE.Tools.GuestPath);

            }
            if (!File.Exists(BE.Tools.OrderPath))
            {
                BE.Tools.SaveToXML(new List<BE.Order>(), BE.Tools.OrderPath);

            }


            if (!File.Exists(BE.Tools.HostingUnitPath))
            {
                BE.Tools.SaveToXML(new List<BE.HostingUnit>(), BE.Tools.HostingUnitPath);
            }

            GuestRoot = XElement.Load(BE.Tools.GuestPath);
            HostingUnitList1 = BE.Tools.LoadFromXML<List<HostingUnit>>(BE.Tools.HostingUnitPath);
            OrderList = BE.Tools.LoadFromXML<List<Order>>(BE.Tools.OrderPath);
            //GuestRequestList1 = BE.Tools.LoadFromXML<List<GuestRequest>>(BE.Tools.GuestPath);

        }








        #region GuestRequest
        //#endregion

        public void addGuestRequest(BE.GuestRequest guest)
        {
            try
            {
                if (getGuestRequestByID(guest.GuestRequestKey) != null)
                {
                    throw new DuplicateWaitObjectException("Duplicate Wait Object Exception");
                }
            }
            catch (Exception)
            {
                 //תופס מצב שיש שוויון ל null

            }
           
            try
            {
                guest.GuestRequestKey=BE.Configuration.GetGuestRequestKey();
                XElement guestXml = new XElement("GuestRequest");
                guestXml.Add(
                    new XElement("GuestRequestKey", guest.GuestRequestKey),
                    new XElement("PrivateName", guest.PrivateName),
                    new XElement("FamilyName", guest.FamilyName),
                    new XElement("Status", guest.Status),
                    new XElement("RegistrationDate", guest.RegistrationDate),
                    new XElement("EntryDate", guest.EntryDate),
                    new XElement("ReleaseDate", guest.ReleaseDate),
                    new XElement("Area", guest.Area),
                    new XElement("Type", guest.Type),
                    new XElement("Jacuzzi", guest.Jacuzzi),
                    new XElement("Garden", guest.Garden),
                    new XElement("ChildrensAttractions", guest.ChildrensAttractions),
                    new XElement("Adults", guest.Adults),
                    new XElement("Children", guest.Children),
                    new XElement("Pool", guest.Pool),
                    new XElement("MailAddress", guest.MailAddress)


                    );


                GuestRoot.Add(guestXml);
                GuestRoot.Save(BE.Tools.GuestPath);
            }
            catch (Exception ex)
            {
                throw new System.Xml.XmlException("שגיאה בהוספת דרישת אירוח בxml");
            }

        }

        // updateOrder function   add update Order  to Xml data
        public void updateGuestRequest(BE.GuestRequest guest)
        {
            guest = guest.Clone();
            XElement oldGuest = (from guestXml in GuestRoot.Elements()
                                 where guestXml.Element("GuestRequestKey").Value == guest.GuestRequestKey.ToString()
                                 select guestXml).FirstOrDefault();

            oldGuest.Element("GuestRequestKey").Value = guest.GuestRequestKey.ToString();
            oldGuest.Element("PrivateName").Value = guest.PrivateName.ToString();
            oldGuest.Element("FamilyName").Value = guest.FamilyName.ToString();
            oldGuest.Element("Status").Value = guest.Status.ToString();
            oldGuest.Element("RegistrationDate").Value = guest.RegistrationDate.ToString();
            oldGuest.Element("EntryDate").Value = guest.EntryDate.ToString();
            oldGuest.Element("ReleaseDate").Value = guest.ReleaseDate.ToString();
            oldGuest.Element("Area").Value = guest.Area.ToString();
            oldGuest.Element("Type").Value = guest.Type.ToString();
            oldGuest.Element("Pool").Value = guest.Pool.ToString();
            oldGuest.Element("Jacuzzi").Value = guest.Jacuzzi.ToString();
            oldGuest.Element("Garden").Value = guest.Garden.ToString();
            oldGuest.Element("ChildrensAttractions").Value = guest.ChildrensAttractions.ToString();
            oldGuest.Element("Adults").Value = guest.Adults.ToString();
            oldGuest.Element("Children").Value = guest.Children.ToString();
            oldGuest.Element("MailAddress").Value = guest.MailAddress.ToString();

            GuestRoot.Save(BE.Tools.GuestPath);

        }

        // GetOrder function get Order Key and return Order obj from xml data.
        public BE.GuestRequest getGuestRequestByID(int ID)
        {

            return (from guest in GuestRoot.Elements().Where(x => x.Element("GuestRequestKey").Value == ID.ToString())
                       select new BE.GuestRequest()
                       {
                           GuestRequestKey = Convert.ToInt32(guest.Element("GuestRequestKey").Value),
                           Adults = Convert.ToInt32(guest.Element("Adults").Value),
                           Children = Convert.ToInt32(guest.Element("Children").Value),

                           Area = (BE.Enums.AreaEnum)Enum.Parse(typeof(BE.Enums.AreaEnum), guest.Element("Area").Value),
                           Status = (BE.Enums.StatusGREnum)Enum.Parse(typeof(BE.Enums.StatusGREnum), guest.Element("Status").Value),
                           Type = (BE.Enums.TypeEnum)Enum.Parse(typeof(BE.Enums.TypeEnum), guest.Element("Type").Value),
                           Pool = (BE.Enums.AttractionsEnum)Enum.Parse(typeof(BE.Enums.AttractionsEnum), guest.Element("Pool").Value),
                           Jacuzzi = (BE.Enums.AttractionsEnum)Enum.Parse(typeof(BE.Enums.AttractionsEnum), guest.Element("Jacuzzi").Value),
                           Garden = (BE.Enums.AttractionsEnum)Enum.Parse(typeof(BE.Enums.AttractionsEnum), guest.Element("Garden").Value),
                           ChildrensAttractions = (BE.Enums.AttractionsEnum)Enum.Parse(typeof(BE.Enums.AttractionsEnum), guest.Element("ChildrensAttractions").Value),

                           PrivateName = guest.Element("PrivateName").Value,
                           FamilyName = guest.Element("FamilyName").Value,
                           MailAddress= guest.Element("MailAddress").Value,

                           EntryDate = DateTime.Parse(guest.Element("EntryDate").Value),
                           RegistrationDate = DateTime.Parse(guest.Element("RegistrationDate").Value),
                           ReleaseDate = DateTime.Parse(guest.Element("ReleaseDate").Value)


                       }).FirstOrDefault().Clone();



        }













        #region כתיבה פשוטה ללא לינק לאקסאמאל לדרישות אירוח

        //public void addGuestRequest(BE.GuestRequest guest)
        //{
        //    bool exists = GuestRequestList1.Any(x => x.GuestRequestKey == guest.GuestRequestKey);
        //    if (exists)
        //    {
        //        throw new DuplicateWaitObjectException((/* "ישנו מספר זהה של דרישת אירוח"*/"Cannot add.duplicate GuestRequest key on data "));

        //    }
        //    if (guest.GuestRequestKey == 0)
        //    {
        //        guest.GuestRequestKey = BE.Configuration.GetGuestRequestKey();

        //    }

        //    GuestRequestList1.Add(guest.Clone());
        //    BE.Tools.SaveToXML<List<BE.GuestRequest>>(GuestRequestList1, BE.Tools.GuestPath);


        //}

        //public void updateGuestRequest(BE.GuestRequest guest)

        //{

        //    if (guest.GuestRequestKey == 0)//זה אומר שאין קוד ייחודי שהרי הערך לא מאותחל על ברירת מחדל- דרישות דף פרוייקט.
        //        guest.GuestRequestKey = BE.Configuration.GetGuestRequestKey(); //הענק לו קוד ייחודי

        //    //אם זה קיים הוא מוחק ישן ושם חדש. אם לא קיים, פשוט יוסיף אותו. 
        //    GuestRequestList1.RemoveAll(x => x.GuestRequestKey == guest.GuestRequestKey);
        //    addGuestRequest(guest);

        //    //אם איו מופע כנ"ל משמע שלא מצא אותו ברשימה


        //}


        //public BE.GuestRequest getGuestRequestByID(int ID)
        //{

        //    var list = from item in GetGuestRequestList()
        //               where item.GuestRequestKey == ID
        //               select item.Clone();

        //    return list.FirstOrDefault();

        //}

        #endregion

        #endregion




        #region HostingUnit


        //HostingUnit







        public int addHostingUnit(BE.HostingUnit hostUnit)
        {
            if (hostUnit.HostingUnitKey == 0)
            {
                hostUnit.HostingUnitKey = BE.Configuration.GetHostingUnitKey();
            }


            if (HostingUnitList1.Any(x => x.HostingUnitKey == hostUnit.HostingUnitKey))
            {
                throw new DuplicateWaitObjectException(/* "ישנו מספר זהה של יחידת אירוח"*/"Cannot add.duplicate HostingUnit key on data ");
            }

            HostingUnitList1.Add(hostUnit.Clone());
            BE.Tools.SaveToXML<List<BE.HostingUnit>>(HostingUnitList1, BE.Tools.HostingUnitPath);
            
            return hostUnit.HostingUnitKey;




        }




        public void delHostingUnit(int hostUnitID)
        {

            int count = HostingUnitList1.RemoveAll(x => x.HostingUnitKey == hostUnitID);
            if (count == 0)
                throw new KeyNotFoundException(string.Format("מחיקה נכשלה! לא נמצאה יחידת אירוח {0}", hostUnitID));
            BE.Tools.SaveToXML<List<HostingUnit>>(HostingUnitList1, BE.Tools.HostingUnitPath);

        }



        public void updateHostingUnit(BE.HostingUnit hostUnit)
        {

            if (hostUnit.HostingUnitKey == 0)//זה אומר שאין קוד ייחודי שהרי הערך לא מאותחל על ברירת מחדל
                hostUnit.HostingUnitKey =BE.Configuration.GetHostingUnitKey(); //הענק לו קוד ייחודי


            HostingUnitList1.RemoveAll(x => x.HostingUnitKey == hostUnit.HostingUnitKey);
            addHostingUnit(hostUnit.Clone());

            //BE.Tools.SaveToXML<List<HostingUnit>>(HostingUnitList1, BE.Tools.HostingUnitPath);


        }


        public BE.HostingUnit getHostingUnitByID(int ID)
        {

            var list = from item in HostingUnitList1
                       where item.HostingUnitKey == ID
                       select item.Clone();
            return list.FirstOrDefault();


        }


        #endregion


        #region Order









        public void addOrder(BE.Order order)
        {

            if (order.OrderKey == 0)
            { order.OrderKey = BE.Configuration.GetOrderKey(); }


            bool exists = OrderList.Any(x => x.OrderKey == order.OrderKey);
            if (exists)
            {
                throw new DuplicateWaitObjectException(("שגיאה. לא ניתן להוסיף הזמנה. ישנו מספר הזמנה זהה בבבסיס הנתונים."));

            }


            if (order.CreateDate == default)
            {
                order.CreateDate = DateTime.Now;
            }


            OrderList.Add(order.Clone());
            BE.Tools.SaveToXML<List<BE.Order>>(OrderList, BE.Tools.OrderPath);

        }


        public void UpdateOrder(BE.Order order)//עדכון סטטוס הזמנה 
        {


            if (order.OrderKey == 0)
            { order.OrderKey = BE.Configuration.GetOrderKey(); }


            //אם זה קיים הוא מוחק ישן ושם חדש. אם לא קיים, פשוט יוסיף אותו. 
            OrderList.RemoveAll(x => x.OrderKey == order.OrderKey);


            if ((order.OrderDate == default) && (order.Status == BE.Enums.StatusEnum.נשלח_מייל))
            {
                order.OrderDate = DateTime.Now; //עדכון זמן שליחת מייל
            }

            addOrder(order);


        }





        public BE.Order GetOrderById(int id)
        {

            var list = from item in OrderList
                       where item.OrderKey == id
                       select item.Clone();
            return list.FirstOrDefault();

        }


        #endregion


        //lists


        #region Lists




        // getAllOrders function  return all Order obj from xml data.
        public IEnumerable<BE.GuestRequest> GetGuestRequestList(Func<BE.GuestRequest, bool> predicat = null)
        {
            try
            {
                return (from guest in GuestRoot.Elements()
                        let guestObject = new BE.GuestRequest()
                        {

                            GuestRequestKey = Convert.ToInt32(guest.Element("GuestRequestKey").Value),
                            Adults = Convert.ToInt32(guest.Element("Adults").Value),
                            Children = Convert.ToInt32(guest.Element("Children").Value),

                            Area = (BE.Enums.AreaEnum)Enum.Parse(typeof(BE.Enums.AreaEnum), guest.Element("Area").Value),
                            Status = (BE.Enums.StatusGREnum)Enum.Parse(typeof(BE.Enums.StatusGREnum), guest.Element("Status").Value),
                            Type = (BE.Enums.TypeEnum)Enum.Parse(typeof(BE.Enums.TypeEnum), guest.Element("Type").Value),
                            Pool = (BE.Enums.AttractionsEnum)Enum.Parse(typeof(BE.Enums.AttractionsEnum), guest.Element("Pool").Value),
                            Jacuzzi = (BE.Enums.AttractionsEnum)Enum.Parse(typeof(BE.Enums.AttractionsEnum), guest.Element("Jacuzzi").Value),
                            Garden = (BE.Enums.AttractionsEnum)Enum.Parse(typeof(BE.Enums.AttractionsEnum), guest.Element("Garden").Value),
                            ChildrensAttractions = (BE.Enums.AttractionsEnum)Enum.Parse(typeof(BE.Enums.AttractionsEnum), guest.Element("ChildrensAttractions").Value),

                            PrivateName = guest.Element("PrivateName").Value,
                            FamilyName = guest.Element("FamilyName").Value,
                            MailAddress = guest.Element("MailAddress").Value,


                            EntryDate = DateTime.Parse(guest.Element("EntryDate").Value),
                            RegistrationDate = DateTime.Parse(guest.Element("RegistrationDate").Value),
                            ReleaseDate = DateTime.Parse(guest.Element("ReleaseDate").Value)

                        }
                        where predicat == null ? true : predicat(guestObject)
                        select guestObject).ToList().Clone();
            }
            catch (Exception) 
            {
                throw new System.Xml.XmlException("שגיאה בלקיחת דרישת אירוח מהxml");
            }
        }



        #region מימוש ללא לינק לאקס אמ אל

        //public IEnumerable<BE.GuestRequest> GetGuestRequestList(Func<BE.GuestRequest, bool> predicat = null)
        //{

        //    var li = from item in GuestRequestList1
        //             where predicat == null ? true : predicat(item)
        //             select item.Clone();

        //    return li;

        //}
        #endregion


        public IEnumerable<BE.HostingUnit> GetHostingUnitList(Func<BE.HostingUnit, bool> predicat = null)
        {

            var li = from item in HostingUnitList1
                     where predicat == null ? true : predicat(item)
                     select item.Clone();

            return li;

        }
        public IEnumerable<BE.Order> GetOrderList(Func<BE.Order, bool> predicat = null)
        {

            var li = from order in OrderList
                     where predicat == null ? true : predicat(order)
                     select order.Clone();
            return li;

        }







        public IEnumerable<BE.BankBranch> GetBankBranchList()
        {


            

            string BankAccuntPath_temp = BE.Tools.BankAccuntPath;
            if (!File.Exists(BE.Tools.BankAccuntPath) || BE.Configuration.BanksXmlFinish == false)
            {
                BankAccuntPath_temp = "atmTemp.xml";
            }
            else
            {
                long length = new FileInfo(BE.Tools.BankAccuntPath).Length;
                if (length < 10000)
                    BankAccuntPath_temp = "atmTemp.xml";
            }
            try
            {
                bankAccuntsRoot = XElement.Load(BankAccuntPath_temp);

            }
            catch { }

            bankAccuntsList = BE.Tools.XmlToBankAccunt(bankAccuntsRoot);


            var IenumBank = from BankAccunt in bankAccuntsList
                            select BankAccunt.Clone();
            return IenumBank;





        }




        public static List<BankBranch> saveBankBranches(string pathToBankdetails)
        {

            XElement bankAccuntsRoot = XElement.Load(pathToBankdetails);

            try
            {

                return (from BB in bankAccuntsRoot.Elements()
                        select new BankBranch()
                        {
                            BankName = BB.Element("שם_בנק").Value.Trim(),
                            BankNumber = Convert.ToInt32(BB.Element("קוד_בנק").Value.Trim()),
                            BranchAddress = BB.Element("כתובת_ה-ATM").Value.Trim(),
                            BranchCity = BB.Element("ישוב").Value.Trim(),
                            BranchNumber = Convert.ToInt32(BB.Element("קוד_סניף").Value.Trim())
                        }
                        ).Distinct().ToList();
            }
            catch (Exception ex)
            {
                // throw new Exception("file_problem_Order");
                throw ex;
            }
        }
        public IEnumerable<BankBranch> getAllBankBranches()
        {

            string BankAccuntPath_temp = Tools.BankAccuntPath;
            if (!File.Exists(Tools.BankAccuntPath))
            {
                BankAccuntPath_temp = "atmTemp.xml";
            }
            else
            {
                long length = new FileInfo(Tools.BankAccuntPath).Length;
                if (length < 10000)
                    BankAccuntPath_temp = "atmTemp.xml";
            }
            try
            {
                bankAccuntsRoot = XElement.Load(Tools.BankAccuntPath);

            }
            catch { }

            bankAccuntsList = saveBankBranches(Tools.BankAccuntPath);
            //SaveToXML(bankAccunts, "banks.xml");
            return from BankAccunt in bankAccuntsList

                   select BankAccunt.Clone();
            // throw new Exception("banks file problem");



        }


        #endregion



    }
}



