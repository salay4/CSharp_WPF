//imp_BL

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BE;
//using DAL; // יש להוריד על פניה מלאה לclone  שנמצא בdal . 
namespace BL
{
    public class imp_BL : IBL
    {

        DAL.IDAL IDAL;

        internal imp_BL()
        {
            IDAL = DAL.Factory.GetInstance();
        }


        #region GuestRequest methods
        //   #endregion
        public void addGuestRequest(BE.GuestRequest guest)
        {

            //אם לא הושלם מילוי
            if (guest.PrivateName == "" || guest.FamilyName == "" || guest.MailAddress == null || guest.EntryDate == null || guest.ReleaseDate == null)
                throw new ArgumentException("חובה למלא את כל השדות");
            if (!checkRequestDates(guest))// if the dates are not legal
                throw new ArgumentException("Dates are not legal!");

            ///throw new System.ArgumentException(string.Format("worng input {0} not llegal ", generalDate));


            if (guest.Adults < 0)
                throw new System.ArgumentException(/*מספר מבוגרים אינו יכול להיות שלילי"*/"Number of adults cannot be negative");
            if (guest.Adults == 0)
                throw new System.ArgumentException(/*מספר מבוגרים אינוי יכול להיות 0"*/"Number of adults cannot be 0");
            if (guest.Type == BE.Enums.TypeEnum.Unknown)
                throw new System.ArgumentException(/*חובה לבחור סוג יחידת יחידת אירוח"*/"Select unit type of hosting unit is required");

            //AttractionsEnum // Unknown,הכרחי, אפשרי, לא_מעוניין
            if (guest.Pool == BE.Enums.AttractionsEnum.Unknown)
                throw new System.ArgumentException(/*חובה לבחור האם מעוניין בבריכה"*/"Must choose whether you want a pool");
            if (guest.Jacuzzi == BE.Enums.AttractionsEnum.Unknown)
                throw new System.ArgumentException(/*חובה לבחור האם מעוניין בג'קוזי"*/"Must choose whether you want a jacuzzi");
            if (guest.Garden == BE.Enums.AttractionsEnum.Unknown)
                throw new System.ArgumentException(/*חובה לבחור האם מעוניין בגינה"*/"Must choose whether you want a garden");
            if ((guest.ChildrensAttractions == BE.Enums.AttractionsEnum.Unknown) && (guest.Children > 0))
                throw new System.ArgumentException(/*חובה לבחור האם מעוניין באטראקציות לילדים"*/"Must choose whether you want a Childrens Attractions");


            if (!(checkDateLegallOneYear(guest.EntryDate))) //אם התאריכים חורגים מהטווח של חודש אחורה ו11 חודש קדימה
            {
                throw new System.ArgumentException(string.Format("worng input {0} not in the span of dates ", guest.EntryDate));

            }
            if (!(checkDateLegallOneYear(guest.ReleaseDate)))
            {
                throw new System.ArgumentException(string.Format("worng input {0} not in the span of dates ", guest.ReleaseDate));
            }





            //מילוי ערכים שגויים
            DateTime theDateToday = new DateTime();
            theDateToday = DateTime.Now;
            theDateToday = new DateTime(theDateToday.Year, theDateToday.Month, theDateToday.Day); //איפוס שעון ל00:00:00
            if (guest.EntryDate < theDateToday)
                throw new System.ArgumentException(/*תאריך כניסה אינו יכול להיות  מוקדם מעכשיו"*/"EntryDate cannot be earlier from now ");

            if (guest.ReleaseDate < theDateToday.AddDays(1))
                throw new System.ArgumentException(/*תאריך יציאה אינו יכול להיות  מוקדם מעוד יום"*/"ReleaseDate cannot be earlier from tomorrow ");

            if (guest.Status != BE.Enums.StatusGREnum.פתוחה)
                throw new System.ArgumentException(/* "סטטוס דרישת לקוח שגוי.סטטוס דרישה חדשה יהיה תמיד פתוח"*/"Incorrect GuestRequest status. New GuestRequest status will always be open ");


            // after we cheek all the possible problems we can transfer the data to DAL layer

            guest.RegistrationDate = DateTime.Now;
            try
            {
                IDAL.addGuestRequest(guest/*.Clone()*/);
            }
            catch (DuplicateWaitObjectException e)
            {

                throw e;
            }


            //throw new NotImplementedException();
        }
        public BE.GuestRequest getGuestRequestByID(int ID)
        {

            return IDAL.getGuestRequestByID(ID)/*.Clone()*/;

        }


        public bool checkRequestDates(BE.GuestRequest guest)
        {
            if (guest.EntryDate >= guest.ReleaseDate) // check if the dates are not equal and if the relase date are not bigger then EntryDate
                return false;
            return true;

        }


        /// <summary>
        /// //אם התאריך חורג מהטווח של חודש אחורה ו11 חודש קדימה
        /// </summary>
        /// <param name="generalDate"></param>
        /// <returns></returns>
        public bool checkDateLegallOneYear(DateTime generalDate) //return true if its ok
        {
            DateTime lastMonth = DateTime.Now.Date.AddMonths(-1);
            if (generalDate < lastMonth)
            {
                return false;
                //throw new System.ArgumentException(string.Format("worng input {0} not llegal ", generalDate));

            }
            lastMonth = DateTime.Now.Date.AddMonths(11);

            if (generalDate > lastMonth)
            {
                return false;
                throw new System.ArgumentException(string.Format("worng input {0} not llegal ", generalDate));

            }

            return true;
        }


        public void updateGuestRequest(BE.GuestRequest guest) //בהנחה שמעדכנים אך ורק סטטוס הזמנה 
        {
            BE.GuestRequest oldGuest = getGuestRequestByID(guest.GuestRequestKey);
            if (oldGuest == null)
            {
                throw new System.ArgumentException(string.Format("The GuestRequest with {0} key now exists", guest.GuestRequestKey));
            }


            if (!(oldGuest.Status == BE.Enums.StatusGREnum.פתוחה))
            {
                throw new ArgumentException(string.Format("לא ניתן לשנות דרישת לקוח שאינה פתוחה"));
            }

            try
            {
                IDAL.updateGuestRequest(guest/*.Clone()*/);
            }
            catch (KeyNotFoundException e)
            {

                throw e;
            }


        }


        #endregion


        #region HostingUnit methods
        //   #endregion
        public int addHostingUnit(BE.HostingUnit hostUnit)
        {

            //אם לא הושלם מילוי
            if (/*hostUnit.Owner == null ||*/ hostUnit.HostingUnitName == "" ||
                hostUnit.Owner.PrivateName == "" || hostUnit.Owner.FamilyName == "" ||
                hostUnit.Owner.PhoneNumber == "" || hostUnit.Owner.MailAddress == null ||
                hostUnit.Owner.BankBranchDetails == null || hostUnit.Owner.BankAccountNumber == 0)
                throw new ArgumentException("חובה למלא את כל השדות");

            if (!ValidateID(hostUnit.Owner.HostKey))
                throw new System.IO.InvalidDataException("תעודת זהות של מארח לא תקינה.");
            if (!Enum.IsDefined(typeof(BE.Enums.AreaEnum), hostUnit.Area))
                throw new System.IO.InvalidDataException("Enum input illegal");
            if (hostUnit.Area == BE.Enums.AreaEnum.All)
                throw new System.IO.InvalidDataException("Enum input illegal. HostingUnit cannot be in All regions");

            if (hostUnit.Type == BE.Enums.TypeEnum.Unknown)
                throw new System.IO.InvalidDataException("חובה להגיד סוג יחידת אירוח");





            // after we cheek all the possible problems we can transfer the data to DAL layer
            int id;
            try
            {
                id = IDAL.addHostingUnit(hostUnit/*.Clone()*/);
                return id;
            }
            catch (DuplicateWaitObjectException e)
            {

                throw e;
            }


            // throw new NotImplementedException();
        }



        public void delHostingUnit(int hostUnitID)
        {
            if (getHostingUnitByID(hostUnitID) == null)
            {
                throw new KeyNotFoundException(string.Format("Hosting Unit with {0} key is not exists ", hostUnitID));
            }

            // check if there is "open" order connect to this Hosting Unit
            //תנאים למחיקה

            var ls = from item in GetOrderList()
                     where ((item.HostingUnitKey == hostUnitID) && ((item.Status == BE.Enums.StatusEnum.טרם_טופל) || (item.Status == BE.Enums.StatusEnum.נשלח_מייל)))
                     select hostUnitID;
            foreach (var item in ls)
            {
                throw new BE.Tools.UnLogicException(string.Format("this Hosting {0} has open order (order key : {1}) ", hostUnitID, item));

            }

            try
            {
                IDAL.delHostingUnit(hostUnitID);
            }
            catch (KeyNotFoundException e)
            {

                throw e;
            }

        }

        public void updateHostingUnit(BE.HostingUnit hostUnit)
        {
            BE.HostingUnit beforeChangeHostUnit = getHostingUnitByID(hostUnit.HostingUnitKey);
            //אם לא הושלם מילוי
            if (/*hostUnit.Owner == null ||*/ hostUnit.HostingUnitName == "" ||
                hostUnit.Owner.PrivateName == "" || hostUnit.Owner.FamilyName == "" ||
                hostUnit.Owner.PhoneNumber == "" || hostUnit.Owner.MailAddress == null ||
                hostUnit.Owner.BankBranchDetails == null || hostUnit.Owner.BankAccountNumber == 0)

                throw new ArgumentException("חובה למלא את כל השדות");
            if (!ValidateID(hostUnit.Owner.HostKey))
                throw new System.IO.InvalidDataException("תעודת זהות של מארח לא תקינה.");
            if (!Enum.IsDefined(typeof(BE.Enums.AreaEnum), hostUnit.Area))
                throw new System.IO.InvalidDataException("Enum input illegal");
            if (hostUnit.Area == BE.Enums.AreaEnum.All)
                throw new System.IO.InvalidDataException("Enum input illegal. HostingUnit cannot be in All regions");

            if (hostUnit.Type == BE.Enums.TypeEnum.Unknown)
                throw new System.IO.InvalidDataException("חובה להגיד סוג יחידת אירוח");


            if (beforeChangeHostUnit.Owner.CollectionClearance.Equals("Yes") && (hostUnit.Owner.CollectionClearance.Equals("No")))//אם רוצה לשנות הרשאת חשבון בנק
            {
                var checkOrder = from item in GetOrderList()
                                 where (item.HostingUnitKey == hostUnit.HostingUnitKey) &&
                                 ((item.Status == BE.Enums.StatusEnum.טרם_טופל) ||
                                 (item.Status == BE.Enums.StatusEnum.נשלח_מייל))
                                 select item;

                foreach (var item in checkOrder)
                {
                    throw new System.ArgumentException("לא ניתן לבטל הראשאת חיוב חשבון כל עוד יש הזמנה פתוחה");
                }


            }

            // after we cheek all the possible problems we can transfer the data to DAL layer

            try
            {
                IDAL.updateHostingUnit(hostUnit/*.Clone()*/);
            }
            catch (KeyNotFoundException e)
            {

                throw e;
            }

        }



        public BE.HostingUnit getHostingUnitByID(int ID)
        {


            return IDAL.getHostingUnitByID(ID)/*.Clone()*/;
        }

        public BE.Order getOrderByID(int ID)
        {
            return IDAL.GetOrderById(ID)/*.Clone()*/;
        }





        public bool this[DateTime generalDate, BE.HostingUnit HU] // define indexer 
        {
            private set => HU.Diary[generalDate.Day - 1, generalDate.Month - 1] = value;
            get => HU.Diary[generalDate.Day - 1, generalDate.Month - 1];
        }



        public bool ApproveRequest(BE.GuestRequest guestReq, BE.HostingUnit HU) //check if the dates are available on matrix.   // if not, return false.
        {
            //DateTime LastNight = guestReq.EntryDate.AddDays(-2);

            for (DateTime tempDate = guestReq.EntryDate; tempDate < guestReq.ReleaseDate; tempDate = tempDate.AddDays(1))
                if (this[tempDate, HU]) { return false; }// check if the days are avaiable
            return true;
        }


        #endregion

        #region Order methods
        //   #endregion
        public void addOrder(BE.Order order)
        {
            BE.GuestRequest GR = getGuestRequestByID(order.GuestRequestKey);
            BE.HostingUnit HU = getHostingUnitByID(order.HostingUnitKey); // בהנחה שזה קיים אחרת לא נשלחה בקשה לפונקציה זו

            var alredayExisits = from item in GetOrderList(x => x.GuestRequestKey == order.GuestRequestKey) //איפה שיש כבר הזמנה לדרישה זו
                                 where item.HostingUnitKey == order.HostingUnitKey
                                 select item;

            if(alredayExisits.Count()>0) //זאת אומרת שכבר יש הזמנה לדרישת אירוח זו וליחדת אירוח זו
            {
                throw new DuplicateWaitObjectException(string.Format("לא ניתן ליצור הזמנה כפולה!" +
                    "קיימת כבר הזמנה  מס' " 
                    + alredayExisits.FirstOrDefault().OrderKey + " עבור דרישת לקוח מספר " + alredayExisits.FirstOrDefault().GuestRequestKey + "ויחידה מספר: "
                    + alredayExisits.FirstOrDefault().HostingUnitKey));
            }
            

            if (GR == null)
            {
                throw new System.ArgumentNullException(string.Format("worng input {0} not exsits ", order.GuestRequestKey));

            }

            if (!(GR.Status == BE.Enums.StatusGREnum.פתוחה))
            {
                throw new BE.Tools.UnLogicException(string.Format("This Guest request {0} are close ", order.GuestRequestKey));

                //throw new System.Diagnostics.Eventing.Reader.EventLogInvalidDataException(string.Format("This Guest request {0} are close ", order.GuestRequestKey));

            }

            if (GR.Type != HU.Type)
            {
                throw new System.ArgumentException(string.Format("the Guest request and the Hosting Unit are not fit in Type parmater  "));
            }
            if ((!(GR.Area == BE.Enums.AreaEnum.All)) && (!(GR.Area == HU.Area)))
            {
                throw new System.ArgumentException(string.Format("the Guest request and the Hosting Unit are not fit in Area parmater  "));
            }


            if ((!(HU.Pool) && (GR.Pool == BE.Enums.AttractionsEnum.הכרחי)) || (((HU.Pool) && (GR.Pool == BE.Enums.AttractionsEnum.לא_מעוניין))))
            {
                throw new System.ArgumentException(string.Format("the Guest request and the Hosting Unit are not fit in the Pool parmater  "));
            }

            if ((!(HU.Jacuzzi) && (GR.Jacuzzi == BE.Enums.AttractionsEnum.הכרחי)) || (((HU.Jacuzzi) && (GR.Jacuzzi == BE.Enums.AttractionsEnum.לא_מעוניין))))
            {
                throw new System.ArgumentException(string.Format("the Guest request and the Hosting Unit are not fit in the Jacuzzi parmater  "));
            }
            if ((!(HU.Garden) && (GR.Garden == BE.Enums.AttractionsEnum.הכרחי)) || (((HU.Garden) && (GR.Garden == BE.Enums.AttractionsEnum.לא_מעוניין))))
            {
                throw new System.ArgumentException(string.Format("the Guest request and the Hosting Unit are not fit in the Garden parmater  "));
            }
            if ((!(HU.ChildrensAttractions) && (GR.ChildrensAttractions == BE.Enums.AttractionsEnum.הכרחי)) || (((HU.ChildrensAttractions) && (GR.ChildrensAttractions == BE.Enums.AttractionsEnum.לא_מעוניין))))
            {
                throw new System.ArgumentException(string.Format("the Guest request and the Hosting Unit are not fit in the ChildrensAttractions parmater  "));
            }

            //ליתר ביטחון
            if (!(checkDateLegallOneYear(GR.EntryDate))) //אם התאריכים חורגים מהטווח של חודש אחורה ו11 חודש קדימה
            {
                throw new System.ArgumentException(string.Format("worng input {0} not in the span of dates ", GR.EntryDate));

            }
            if (!(checkDateLegallOneYear(GR.ReleaseDate)))
            {
                throw new System.ArgumentException(string.Format("worng input {0} not in the span of dates ", GR.ReleaseDate));
            }



            if (!ApproveRequest(GR, HU))  //check if the dates are available on matrix.   // if not, return false.
            {
                throw new BE.Tools.UnLogicException(string.Format("The dates on Hosting unit are not available"));
            }

            // if the dates are available on matrix update the Hosint Unit


            try
            {
                IDAL.addOrder(order/*.Clone()*/);
            }
            catch (DuplicateWaitObjectException e)
            {

                throw e;
            }



        }



        public void UpdateOrder(BE.Order order)
        {

            BE.GuestRequest GR = getGuestRequestByID(order.GuestRequestKey);
            BE.HostingUnit HU = getHostingUnitByID(order.HostingUnitKey); // בהנחה שזה קיים אחרת לא נשלחה בקשה לפונקציה זו
            BE.Order orderBeforeChange = getOrderByID(order.OrderKey);

            

            if (!(ApproveRequest(GR, HU))) //check if the dates are available on matrix.   // if not, return false.)
            {
                throw new BE.Tools.UnLogicException(string.Format("The dates on Hosting unit are not available"));
            }


            if ((HU.Owner.CollectionClearance == "No") && (order.Status == BE.Enums.StatusEnum.נשלח_מייל))
                throw new BE.Tools.UnLogicException(string.Format("בעל יחידת דיור אינו מורשה לשלוח מייל כל עוד לא חתם על הרשאה לחיוב חשבון בנק"));


            if (orderBeforeChange.Status == BE.Enums.StatusEnum.נסגר_בהיענות_הלקוח ||
                orderBeforeChange.Status == BE.Enums.StatusEnum.נסגר_מחוסר_הענות_הלקוח || 
                orderBeforeChange.Status == BE.Enums.StatusEnum.נסגר_היות_ויחידית_אירוח_נתפסה_כבר)
            {
                throw new BE.Tools.UnLogicException(string.Format("לא ניתן לשנות סטטוס הזמנה שנסגרה"));

            }

            if ((HU.Owner.CollectionClearance == "No") && (order.Status == BE.Enums.StatusEnum.נסגר_בהיענות_הלקוח))
                throw new BE.Tools.UnLogicException(string.Format("בעל יחידת דיור אינו מורשה לסגור עסקה כל עוד לא חתם על הרשאה לחיוב חשבון בנק"));


            if (GR.Status == BE.Enums.StatusGREnum.נסגרה_כי_פג_תוקפה || GR.Status == BE.Enums.StatusGREnum.נסגרה_עסקה_דרך_האתר)
            {
                throw new BE.Tools.UnLogicException(string.Format("דרישת הלקוח נסגרה"));

            }



            if (!(orderBeforeChange.Status == BE.Enums.StatusEnum.נשלח_מייל)&& order.Status == BE.Enums.StatusEnum.נסגר_בהיענות_הלקוח)
            {
                throw new BE.Tools.UnLogicException(string.Format("לא ניתן לסגור עסקה לפני שליחת מייל."));

            }



            bool flag; //מסמן אם העדכון הינו עבור סגירת עסקה או עבור שליחת דואר.
            flag = false;


            if ((HU.Owner.CollectionClearance == "Yes") && (order.Status == BE.Enums.StatusEnum.נסגר_בהיענות_הלקוח))
            {
                flag = true;
                int Chargeamount = 0;

                if (!(checkAvailabilityGuestAndHosing(GR, HU))) //אם זה לא זמין ייכנס לתוך
                {
                    throw new BE.Tools.UnLogicException(string.Format("שגיאה! יחידה האירוח " + HU.HostingUnitKey  + "\n"+
                      "\n" + " תפוסה בתאריכי דרישת האירוח" + GR.GuestRequestKey + "\n" +
                        "  לא ניתן לעדכן הזמנה" + order.OrderKey));
                }
                for (DateTime tempDate = GR.EntryDate; tempDate < GR.ReleaseDate; tempDate = tempDate.AddDays(1))
                {
                    this[tempDate, HU] = true;//put the nights on matrix
                    Chargeamount += BE.Configuration.Commission; //חישוב עמלה על כל יום שנתפס
                    BE.Configuration.commissionAll += BE.Configuration.Commission;

                }



  
                BE.GuestRequest tempGR = GR;
                GR.Status = BE.Enums.StatusGREnum.נסגרה_עסקה_דרך_האתר;
                try
                {
                    updateGuestRequest(GR);

                }
                catch (ArgumentException e)
                {

                    throw e;
                }
                catch (KeyNotFoundException e)
                {

                    throw e;
                }

                try
                {
                    IDAL.UpdateOrder(order/*.Clone()*/);
                    

                }
                catch (KeyNotFoundException e)
                {
                    GR = getGuestRequestByID(order.GuestRequestKey);
                    try
                    {
                        updateGuestRequest(GR);

                    }
                    catch (ArgumentException ex)
                    {

                        throw ex;
                    }
                    catch (KeyNotFoundException ex)
                    {

                        throw ex;
                    }
                    throw e;
                }

                try
                {
                    IDAL.updateHostingUnit(HU);
                }
                catch (Exception ex) //אין שגיאה מוגדרת להוספה
                {

                    throw ex;
                }





                try
                {
                    foreach (var item in GetOrderList(x => (x.GuestRequestKey == GR.GuestRequestKey)))//לוקח את כל שאר ההזמנות שמשוייכות לדרישת אירוח זו
                    {
                        if (item.OrderKey!=order.OrderKey)
                        {
                            item.Status = BE.Enums.StatusEnum.נסגר_מחוסר_הענות_הלקוח;
                            IDAL.UpdateOrder(item/*.Clone()*/);
                        }

                    }

                    ///סגירת כל הזמנות שמתנגשות עם ההזמנה שאושרה!
                    ///
                    foreach (var item in GetOrderList(x => (x.GuestRequestKey != GR.GuestRequestKey)))//לוקח את כל שאר ההזמנות שמשוייכות לדרישת אירוח זו
                    {
                        if (item.OrderKey != order.OrderKey)
                        {

                            BE.GuestRequest guest = getGuestRequestByID(item.GuestRequestKey);
                            BE.HostingUnit hosting = getHostingUnitByID(item.HostingUnitKey); // בהנחה שזה קיים אחרת לא נשלחה בקשה לפונקציה זו
                            if (!(checkAvailabilityGuestAndHosing(guest, hosting))) //אם זה לא זמין ייכנס לתוך
                            {
                                item.Status = BE.Enums.StatusEnum.נסגר_היות_ויחידית_אירוח_נתפסה_כבר; //היות וכבר נתפס ע"י מישהו אחר
                                IDAL.UpdateOrder(item/*.Clone()*/);
                            }


                        }

                    }


                }
                catch (KeyNotFoundException e)
                {

                    throw e;
                }

            }


            if ((flag != true)&& (!(order.Status == BE.Enums.StatusEnum.נסגר_בהיענות_הלקוח))) // במידה ומסנים לעדכן שדה שהוא לא השדה ההמוזכר. 
            {
                try
                {
                    IDAL.UpdateOrder(order/*.Clone()*/);
                }
                catch (KeyNotFoundException e)
                {

                    throw e;
                }
            }
           

        }


        #endregion


        #region return lists

        public IEnumerable<BE.BankBranch> GetBankBranchList(/*Func<BE.BankBranch, bool> predicat = null*/)
        {
            //throw new NotImplementedException();
            return IDAL.GetBankBranchList(/*predicat*/)/*.Clone()*/;
        }

        public IEnumerable<BE.GuestRequest> GetGuestRequestList(Func<BE.GuestRequest, bool> predicat = null)
        {
            //throw new NotImplementedException();
            return IDAL.GetGuestRequestList(predicat);

        }


        public IEnumerable<BE.HostingUnit> GetHostingUnitList(Func<BE.HostingUnit, bool> predicat = null)
        {
            //throw new NotImplementedException();
            return IDAL.GetHostingUnitList(predicat)/*.Clone()*/;
        }

        public IEnumerable<BE.Order> GetOrderList(Func<BE.Order, bool> predicat = null)
        {


            return IDAL.GetOrderList(predicat).ToList();

            //IEnumerable<BE.Order> list = IDAL.GetOrderList(); 
            //return list;


            //foreach (var item in IDAL.GetOrderList()/*.Clone()*/)
            //{
            //    list.Add(item);
            //}
            //throw new NotImplementedException();


        }

        #endregion

        #region other methods






        public void bankAccountDebit(BE.HostingUnit HU, int Chargeamount)
        {

            BE.Configuration.commissionAll += Chargeamount; 

        }





        //תוספות  בBL

        public IEnumerable<BE.HostingUnit> availableUnits(DateTime enteryDate, int numOfDayes)//פונקציה שמקבלת תאריך ומספר ימי נופש ומחזירה את רשימת היחידות הפנויות בתאריך זה
        {


            var list = from item in GetHostingUnitList()
                       where (checkAvailability(enteryDate, numOfDayes, item))
                       select item;

            List<BE.HostingUnit> newList = new List<HostingUnit>();
            foreach (var item in list)
            {
                newList.Add(item);
            }

            return newList;
        }


        bool checkAvailability(DateTime enteryDate, int numOfDayes, BE.HostingUnit HU) //check if the dates are available on matrix.   // if not, return false.
        {
            DateTime LastNight = enteryDate.AddDays(numOfDayes - 2);
            for (DateTime tempDate = enteryDate; tempDate <= LastNight; tempDate = tempDate.AddDays(1))
                if (this[tempDate, HU]) { return false; }// check if the days are avaiable


            //DateTime LastNight = enteryDate.AddDays(numOfDayes - 1);


            //for (DateTime tempDate = enteryDate; tempDate < guestReq.ReleaseDate; tempDate = tempDate.AddDays(1))
            //    if (this[tempDate, HU]) { return false; }// check if the days are avaiable


            return true;
        }




        /// <summary>
        /// בדיקה האם יש זמינות עבור דרישת אירוח ויחידת אירוח
        /// </summary>
        /// <param name="GR"></param>
        /// <param name="HU"></param>
        /// <returns></returns>
        bool checkAvailabilityGuestAndHosing(BE.GuestRequest GR, BE.HostingUnit HU) //check if the dates are available on matrix.   // if not, return false.
        {
          
            for (DateTime tempDate = GR.EntryDate; tempDate < GR.ReleaseDate; tempDate = tempDate.AddDays(1))
                if (this[tempDate, HU]) { return false; }// check if the days are avaiable
            return true;
        }





        public int numberOfDayes(DateTime start, DateTime end = default(DateTime)) //מספר הימים שעברו בטווח תאריכים מסוים או מתאריך מסוים ועד היום.
        {//default(DateTime) =01/01/0001

            if (start < end)
            {
                end = DateTime.Now;
            }

            int number = 0;

            TimeSpan timeSpan;
            number = int.Parse((timeSpan = start.Date - end.Date).ToString()); //חישוב טווח תאריכים

            return number;
        }

        public IEnumerable<BE.Order> ordersDayesPast(int numOfDays)
        {
            //פונקציה שמקבלת מספר ימים ומחזירה רשימה של הזמנות שמשך הזמן שעבר מאז שנוצרו ועד היום גדול או שווה למספר שהתקבל

            List<BE.Order> ls = new List<BE.Order>();

            DateTime date = DateTime.Now.Date;//היום - באפוס שניות
            TimeSpan timeSpan;

            var list = from item in GetOrderList()
                       where (((int.Parse((timeSpan = date - item.CreateDate.Date).ToString())) >= numOfDays)) ||
                             (((int.Parse((timeSpan = date - item.OrderDate.Date).ToString())) >= numOfDays))
                       select item;
            foreach (var item in list)
            {
                ls.Add(item);
            }

            return ls;
        }





        public int numeberOfOrderSendToGuestRequest(BE.GuestRequest guest)
        {

            int number = 0;
            var ls = from item in GetOrderList()
                     where ((item.GuestRequestKey == guest.GuestRequestKey) &&
                           ((item.Status == BE.Enums.StatusEnum.נשלח_מייל)))//סימון נשלח מייל
                     select item;
            foreach (var item in ls)
            {
                number++;
            }
            return number;
        }


        public int numeberOfOrderSendFromHostingUnit(BE.HostingUnit HU)
        {

            int number = 0;
            var ls = from item in GetOrderList()
                     where ((item.HostingUnitKey == HU.HostingUnitKey) &&
                           ((item.Status == BE.Enums.StatusEnum.נשלח_מייל) ||
                           (item.Status == BE.Enums.StatusEnum.נסגר_בהיענות_הלקוח)))//משמע הזמנה נסגרה דרך האתר ויחידה נתפסה
                     select item;
            foreach (var item in ls)
            {
                number++;
            }
            return number;
        }

        #endregion



        #region Grouping

        /// <summary>
        /// מחזיר גרופינג של דרישות לקוח לפי איזור. 
        /// </summary>
        /// <returns> ערך אחד. יש לבצע בפונקציה המזמנת forech</returns>
        public IEnumerable<IGrouping<BE.Enums.AreaEnum, BE.GuestRequest>> groupByAreaGR()
        {
            var result = from item in GetGuestRequestList()
                         group item by item.Area;

            return result.ToList();

        }



        /// <summary>
        /// מחזיר גרופינג של דרישות לקוח לפי מספר הנופשים. 
        /// </summary>
        /// <returns> ערך אחד. יש לבצע בפונקציה המזמנת forech</returns>
        public IEnumerable<IGrouping<int, BE.GuestRequest>> groupByNumberOfPeopleInGR() // סידור לפי מספר הנופשים - מבוגרים וילדים
        {
            var result = from item in GetGuestRequestList()
                         group item by (item.Adults + item.Children);
            return result.ToList();

        }





        /// <summary>
        /// מחזיר גרופינג של מארחים מסודר לפי מספר יחידת אירוח של כל מארח. 
        /// </summary>
        /// <returns> ערך אחד. יש לבצע בפונקציה המזמנת forech</returns>
        public IEnumerable<IGrouping<int, BE.Host>> groupByNumberOfHosintgUnitForHost()
        {
            //var hostingUnits = GetHostingUnitList();

            return from Unit in GetHostingUnitList()
                   group Unit by Unit.Owner.HostKey into Units
                   let Owner = Units.FirstOrDefault().Owner
                   let num_of_Unit = Units.Count() 
                   group Owner by num_of_Unit;
        }





        /// <summary>
        /// מחזיר גרופינג של יחידת אירוח מסודר לפי איזור. 
        /// </summary>
        /// <returns> ערך אחד. יש לבצע בפונקציה המזמנת forech</returns>
        public IEnumerable<IGrouping<BE.Enums.AreaEnum, BE.HostingUnit>> groupByAreaHostingUnit()
        {

            return from item in GetHostingUnitList()
                   group item by item.Area;
            //var result = from item in GetHostingUnitList()
            //             group item by item.Area;

            //return result/*.ToList()*/;

        }



        /// <summary>
        ///  מחזיר רשימת יחידות אירוח עבור מארח ספיצפי
        /// </summary>
        /// <returns> ערך אחד. יש לבצע בפונקציה המזמנת forech</returns>
        public IEnumerable<BE.HostingUnit> hostsHostingUnit(string IDHost)
        {
            //List<BE.HostingUnit> list = new List<BE.HostingUnit>();


            var li = from item in GetHostingUnitList()
                     where ((item.Owner.HostKey)) == IDHost
                     select item;
            return li;
            //foreach (var item in li)
            //{
            //    list.Add(item);
            //}

            //return list;

        }




        #endregion



        #region send mail

        public void sendMail(BE.Order order) //לממש שליחת מייל עם פרטי הזמנה בשלב הבא
        {
            Console.WriteLine("the mail as been sent");
        }

        public void sendAnEamil()
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("zimmerisrael123@gmail.com", "Aa12345678910"),
                EnableSsl = true
            };

            client.Send("shuker@g.jct.ac.il", "shuker@g.jct.ac.il", "hi behrooz, how was your nohrooz?", "this is a messege from your iranian friend. \n messege number: ");
            Console.WriteLine("Sent");
        }

        /// <summary>
        /// מימוש שליחת מייל 
        /// </summary>
        public void sendAnEmail()
        {



        }
        #endregion


        #region bank Data

        public void updateBankDetails()
        {
            Console.WriteLine("\n\n\n\n\n in the func1 \n\n\n\n\n\n");


          //  try
            {
                string sw = "";
                //string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                string path  = (Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +@"\BL\bank\f.txt");

                Console.WriteLine("\n\npath path path\n\n"+ path+"\n\n");
               
                sw = System.IO.File.ReadAllText(path);
                DateTime dff = DateTime.Parse(sw); //תאריך שקוראים מתוך קובץ זמן עדכון אחרון לתאריך בנקים.




                Console.WriteLine(sw);
                if ((DateTime.Now.Subtract(dff)).TotalDays >= 1)
                {
                    Console.WriteLine("\n\n\n\n\n in the if \n\n\n\n\n\n");
                    getBankDetails();
                    Console.WriteLine("fdsfhkdsjfhdskjfhkdsjfs");
                string now = DateTime.Now.ToString();
                Console.WriteLine(now);
                System.IO.File.WriteAllText(path, now);
                }


            }
           // catch (Exception e)
            {

               // throw new Exception();
            }
            
           


            }

        public void getBankDetails()
        {

            Console.WriteLine("\n\n in the func2 \n\n");
            //StreamWriter sw = new StreamWriter(@"‏‏C:\Users\mgaru\source\repos\Project_CSH\32\f.txt");
            string path = BE.Tools.BankAccuntPath;



            WebClient wc = new WebClient();
            try
            {
                string xmlServerPath = @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
                wc.DownloadFile(xmlServerPath, path);



            }
            catch (Exception)
            {
                string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                wc.DownloadFile(xmlServerPath, path);

            }
            finally
            {
                wc.Dispose();
            }
            char[] gg = path.ToCharArray();

            Console.WriteLine(gg);


        }

        public void bankThread()
        {
            Thread th = new Thread(DownloadBankXmlLoop);
            th.Start();
        }



        public void DownloadBankXmlLoop()
        {
            while (true)
            {
                Thread.Sleep(2000);

                try
                {
                    if (new System.Net.NetworkInformation.Ping().Send("google.com").Status == IPStatus.Success)
                    {
                        updateBankDetails();
                     
                        long length = new FileInfo(BE.Tools.BankAccuntPath).Length;
                        if (length > 50000) break; 
                    }
                }
                catch { }
            }


        }


        #endregion 

        /// <summary>
        /// בדיקת חוקיות ת"ז בישראל
        /// </summary>
        /// <param name="IDNum"></param>
        /// <returns></returns>
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

        public void sendEmail(Order order)
        {
            GuestRequest guest = new GuestRequest();
            guest = getGuestRequestByID(order.GuestRequestKey);
            HostingUnit HUshow = new HostingUnit();
            HUshow = getHostingUnitByID(order.HostingUnitKey);
            Order orderTemp = new Order();

            try
            {
               
                //  System.Windows.MessageBox.Show(" נסגרה בהצלחה");

                string str = "שלום  " + guest.PrivateName + " " + guest.FamilyName +
                     "\n" + " אנחנו נרגשים  לבשר לך שנמצאה התאמה באתרינו עבור דרישת האירוח שלך!" +
                     "פרטי ההזמנה : "
                    +
                    (order.ToString() + "\n \n\n "
                     + " " + "  " + HUshow.HostingUnitName + " מאיזור ה " + HUshow.Area +
                     " הזמנה עבור יחידת אירות מסוג " + HUshow.Type + "תאריך כניסה :" + guest.EntryDate + "\n  תאריך יציאה: " + guest.ReleaseDate + "\n"
                     + "\n" + " לפרטים ולסגירת עסקה אנא צרו קשר עם המארח במספר טלפון: " + HUshow.Owner.PhoneNumber
                     + "\n  :או במייל בכתובת " + HUshow.Owner.MailAddress);


                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("zimmerisrael123@gmail.com", "Aa12345678910"),
                    EnableSsl = true
                };

                Thread T1 = new Thread(delegate ()
                {
                    using (var message = new MailMessage("zimmerisrael123@gmail.com", getGuestRequestByID(order.GuestRequestKey).MailAddress)
                    {
                        Subject = "נמצאה התאמת בקשת אירוח!",
                        Body = str
                    })
                    {
                        {
                            client.Send(message);
                        }
                    }
                });



                T1.Start();
                
               /* MessageBox.Show("המייל נשלח בהצלחה!", "המייל נשלח");


                IenumaOrder = bl.GetOrderList(x => x.HostingUnitKey == number); *///הצג רק הזמנות רלוונטיות ליחידת אירוח זו. 

             }
            catch (ArgumentNullException ex)
            {
                order = orderTemp;
                throw ex;
            }

            catch (ArgumentException ex)
            {
                order = orderTemp;
                throw ex;

            }
            catch (KeyNotFoundException ex)
            {
                order = orderTemp;
                throw ex;


            }
            catch (BE.Tools.UnLogicException ex)
            {
                order = orderTemp;
                throw ex;


            }
            catch (SmtpFailedRecipientsException ex)
            {
                order = orderTemp;
                throw ex;


            }
            catch (InvalidOperationException ex)
            {
                order = orderTemp;
                throw ex;

            }

            catch (SmtpException ex)
            {
                order = orderTemp;
                throw ex;

            }
            catch (Exception ex)
            {
                order = orderTemp;
                throw ex;

            }
        
            
        }

        public IEnumerable<BE.BankBranch> getAllBankBranches() //getAllBankBranches function.
        { //the function return all Bank Branches
            try
            {
                return IDAL.getAllBankBranches();

            }
            catch
            {
                throw new Exception("שגיאה בהורדת נתוני בנקים");
            }
        }

    }




}


