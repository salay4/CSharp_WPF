using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{



    public class DataSource
    {

        #region אתחול רשימות  
        //   #endregion

        public static List<BE.GuestRequest> GuestRequestList = new List<BE.GuestRequest>()
        {new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="Michael",
        FamilyName="Garusi",
        MailAddress=/*@*/"mgarusi101@gmail.com",
        Status=Enums.StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(1),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=Enums.AreaEnum.North,
        Type=Enums.TypeEnum.Zimmer,
        Pool=Enums.AttractionsEnum.לא_מעוניין,
        Jacuzzi=Enums.AttractionsEnum.אפשרי,
        Garden=Enums.AttractionsEnum.הכרחי,
        Adults=2,
        Children=0,
             },
        new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלום",
        FamilyName="שוקר",
        MailAddress=/*@*/"shuker@g.jct.ac.il",
        Status=Enums.StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date,// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(7),
        Area=Enums.AreaEnum.All,
        Type=Enums.TypeEnum.Zimmer,
        Pool=Enums.AttractionsEnum.לא_מעוניין,
        Jacuzzi=Enums.AttractionsEnum.אפשרי,
        Garden=Enums.AttractionsEnum.אפשרי,
        ChildrensAttractions=Enums.AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             }
        ,
        new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="סלאי",
        FamilyName="שוקר",
        MailAddress=/*@*/"salay4@gmail.com",
        Status=Enums.StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date,// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(7),
        Area=Enums.AreaEnum.All,
        Type=Enums.TypeEnum.Zimmer,
        Pool=Enums.AttractionsEnum.לא_מעוניין,
        Jacuzzi=Enums.AttractionsEnum.אפשרי,
        Garden=Enums.AttractionsEnum.אפשרי,
        ChildrensAttractions=Enums.AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             },

                new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=Enums.StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=Enums.AreaEnum.North,
        Type=Enums.TypeEnum.Zimmer,
        Pool=Enums.AttractionsEnum.אפשרי,
        Jacuzzi=Enums.AttractionsEnum.אפשרי,
        Garden=Enums.AttractionsEnum.אפשרי,
        ChildrensAttractions=Enums.AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             }, new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=Enums.StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=Enums.AreaEnum.North,
        Type=Enums.TypeEnum.Zimmer,
        Pool=Enums.AttractionsEnum.אפשרי,
        Jacuzzi=Enums.AttractionsEnum.אפשרי,
        Garden=Enums.AttractionsEnum.אפשרי,
        ChildrensAttractions=Enums.AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             }, new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=Enums.StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=Enums.AreaEnum.North,
        Type=Enums.TypeEnum.Zimmer,
        Pool=Enums.AttractionsEnum.אפשרי,
        Jacuzzi=Enums.AttractionsEnum.אפשרי,
        Garden=Enums.AttractionsEnum.אפשרי,
        ChildrensAttractions=Enums.AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             }, new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=Enums.StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=Enums.AreaEnum.North,
        Type=Enums.TypeEnum.Zimmer,
        Pool=Enums.AttractionsEnum.אפשרי,
        Jacuzzi=Enums.AttractionsEnum.אפשרי,
        Garden=Enums.AttractionsEnum.אפשרי,
        ChildrensAttractions=Enums.AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             }, new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=Enums.StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=Enums.AreaEnum.North,
        Type=Enums.TypeEnum.Zimmer,
        Pool=Enums.AttractionsEnum.אפשרי,
        Jacuzzi=Enums.AttractionsEnum.אפשרי,
        Garden=Enums.AttractionsEnum.אפשרי,
        ChildrensAttractions=Enums.AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             }, new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=Enums.StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=Enums.AreaEnum.North,
        Type=Enums.TypeEnum.Zimmer,
        Pool=Enums.AttractionsEnum.אפשרי,
        Jacuzzi=Enums.AttractionsEnum.אפשרי,
        Garden=Enums.AttractionsEnum.אפשרי,
        ChildrensAttractions=Enums.AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             }, new BE.GuestRequest()
            {// יש לערוך ולממש כמו שצריך
        GuestRequestKey=BE.Configuration.geustReqID++,
        PrivateName="שלמה",
        FamilyName="שלמה",
        MailAddress=/*@*/"Aasdaa@gmail.com",
        Status=Enums.StatusGREnum.פתוחה,
        RegistrationDate=DateTime.Now,
        EntryDate=DateTime.Now.Date.AddDays(10),// סתם לצורך הדוגמה -
        ReleaseDate=DateTime.Now.Date.AddDays(20),
        Area=Enums.AreaEnum.All,
        Type=Enums.TypeEnum.Zimmer,
        Pool=Enums.AttractionsEnum.אפשרי,
        Jacuzzi=Enums.AttractionsEnum.אפשרי,
        Garden=Enums.AttractionsEnum.אפשרי,
        ChildrensAttractions=Enums.AttractionsEnum.אפשרי,
        Adults=2,
        Children=1,
             },

        };



        public static List<BE.HostingUnit> HostingUnitList = new List<BE.HostingUnit>()

        {
        new BE.HostingUnit()
        {
            HostingUnitKey=BE.Configuration.hostUnitID++, 
            Owner=new BE.Host(){HostKey="311600605",PrivateName="שלמה",FamilyName="הלוי",
                PhoneNumber="055-555-5355",MailAddress="a@s.com",BankAccountNumber=1123,CollectionClearance="כן",
                BankBranchDetails=new BE.BankBranch(){
            BankNumber=11,
            BankName="Discount",
            BranchNumber=510,
            BranchAddress="Har'el St 1, 9079129",
            BranchCity="Mevaseret Zion"} },
            HostingUnitName="צימר יפה",
            Area=BE.Enums.AreaEnum.Center,
            Type=BE.Enums.TypeEnum.Zimmer
        },
        new BE.HostingUnit()
        {
            HostingUnitKey=BE.Configuration.hostUnitID++, 
            Owner=new BE.Host(){HostKey="305615734",PrivateName="מיכאל ",FamilyName="גרוסי",
                PhoneNumber="055-555-5355",MailAddress="mfdgsg@gmail.com",BankAccountNumber=1123,CollectionClearance="no",
                BankBranchDetails=new BE.BankBranch(){
            BankNumber=11,
            BankName="Discount",
            BranchNumber=510,
            BranchAddress="Har'el St 1, 9079129",
            BranchCity="Mevaseret Zion"} },
            HostingUnitName="צימר יפה",
            Area=BE.Enums.AreaEnum.North,
            Type=BE.Enums.TypeEnum.Zimmer,
            
        }

        ,
                new BE.HostingUnit()
        {
            HostingUnitKey=BE.Configuration.hostUnitID++, 
            Owner=new BE.Host(){HostKey="305615734",PrivateName="מיכאל ",FamilyName="גרוסי",
                PhoneNumber="055-555-5355",MailAddress="mfdgsg@gmail.com",BankAccountNumber=1123,CollectionClearance="no",
                BankBranchDetails=new BE.BankBranch(){
            BankNumber=11,
            BankName="Discount",
            BranchNumber=510,
            BranchAddress="Har'el St 1, 9079129",
            BranchCity="Mevaseret Zion"} },
            HostingUnitName=" צימר יפה מאד",
            Area=BE.Enums.AreaEnum.North,
            Type=BE.Enums.TypeEnum.Zimmer,

        }
                        ,
                new BE.HostingUnit()
        {
            HostingUnitKey=BE.Configuration.hostUnitID++, 
            Owner=new BE.Host(){HostKey="305615734",PrivateName="מיכאל ",FamilyName="גרוסי",
                PhoneNumber="055-555-5355",MailAddress="mfdgsg@gmail.com",BankAccountNumber=1123,CollectionClearance="no",
                BankBranchDetails=new BE.BankBranch(){
            BankNumber=11,
            BankName="Discount",
            BranchNumber=510,
            BranchAddress="Har'el St 1, 9079129",
            BranchCity="Mevaseret Zion"} },
            HostingUnitName=" צימר יפה מאד",
            Area=BE.Enums.AreaEnum.North,
            Type=BE.Enums.TypeEnum.Zimmer,

        }

                        ,
                new BE.HostingUnit()
        {
            HostingUnitKey=BE.Configuration.hostUnitID++, 
            Owner=new BE.Host(){HostKey="305615734",PrivateName="מיכאל ",FamilyName="גרוסי",
                PhoneNumber="055-555-5355",MailAddress="mfdgsg@gmail.com",BankAccountNumber=1123,CollectionClearance="no",
                BankBranchDetails=new BE.BankBranch(){
            BankNumber=11,
            BankName="Discount",
            BranchNumber=510,
            BranchAddress="Har'el St 1, 9079129",
            BranchCity="Mevaseret Zion"} },
            HostingUnitName=" צימר יפה מאד",
            Area=BE.Enums.AreaEnum.North,
            Type=BE.Enums.TypeEnum.Zimmer,

        }



        };


        public static List<BE.Order> OrderList = new List<BE.Order>()
        {new Order()
        {
            HostingUnitKey=20000000,/// יש לממש  לפי הקשר
            GuestRequestKey=40000000,///יש לממש בהתאם לבקשה
            OrderKey=BE.Configuration.orderID++, /// יש לממש בעזרת מספר רץ
            Status=Enums.StatusEnum.טרם_טופל,
            CreateDate=DateTime.Now,

        },
        new Order()
        {
            HostingUnitKey=20000001,/// יש לממש  לפי הקשר
            GuestRequestKey=40000000,///יש לממש בהתאם לבקשה
            OrderKey=BE.Configuration.orderID++, /// יש לממש בעזרת מספר רץ
            Status=Enums.StatusEnum.טרם_טופל,
            CreateDate=DateTime.Now,

        }
        ,
        new Order()
        {
            HostingUnitKey=20000000,/// יש לממש  לפי הקשר
            GuestRequestKey=40000001,///יש לממש בהתאם לבקשה
            OrderKey=BE.Configuration.orderID++, /// יש לממש בעזרת מספר רץ
            Status=Enums.StatusEnum.טרם_טופל,
            CreateDate=DateTime.Now,

        }


        };

        public static List<BE.BankBranch> BankBranchList = new List<BE.BankBranch>()
        {new BankBranch()
        {
            BankNumber=11,
            BankName="Discount",
            BranchNumber=510,
            BranchAddress="Har'el St 1, 9079129",
            BranchCity="Mevaseret Zion"
        },
            new BankBranch()
        {
            BankNumber=11,
            BankName="Discount",
            BranchNumber=69,
            BranchAddress="Beit Hakerem St. 29",
            BranchCity="Jerusalem"
        },
            new BankBranch()
        {
            BankNumber=11,
            BankName="Discount",
            BranchNumber=159,
            BranchAddress="Yaffo St. 97, Jerusalem",
            BranchCity="Jerusalem"
        },
            new BankBranch()
        {
            BankNumber=11,
            BankName="Discount",
            BranchNumber=64,
            BranchAddress="ehezkel St. 11, Jerusalem",
            BranchCity="Jerusalem"
        },
            new BankBranch()
        {
            BankNumber=11,
            BankName="Discount",
            BranchNumber=321,
            BranchAddress="Sderot Rabin 10, Jerusalem",
            BranchCity="Jerusalem"
        },


        };

        #endregion

        //clone to the BL
        public List<BE.GuestRequest> getGuestRequestList() { return GuestRequestList/*.Clone()*/; }

        public List<BE.HostingUnit> getHostingUnitList() { return HostingUnitList/*.Clone()*/; }
        public List<BE.Order> getOrderList() { return OrderList/*.Clone()*/; }

        public List<BE.BankBranch> getBankBranchList() { return BankBranchList/*.Clone()*/; }



    }
}
