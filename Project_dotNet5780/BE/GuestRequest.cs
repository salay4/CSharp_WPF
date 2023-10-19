using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using System.Net.Mail;
namespace BE
{

    [Serializable]
    public class GuestRequest
    {
        //BE.Configuration r = new BE.Configuration(); //אחי היקר שורת הקוד הזו דופקת את המערכת

        private int guestRequestKey;
        public int GuestRequestKey
        {
            get { return guestRequestKey; }
            set
            {
                if (value < 10000000) //from number with 8 letters 
                    throw new System.IO.InvalidDataException(/*מספר זיהוי אינו תקין"*/"Incorrect key!");
                guestRequestKey = value;

            }
        }


        private string privateName;
        public string PrivateName
        {
            get { return privateName; }
            set
            {
                Regex r = new Regex("^([^20]|[a-zA-Zא-ת]){2,20}$");
                if (!r.IsMatch(value))
                    throw new System.IO.InvalidDataException(/*"שם פרטי צריך להכיל 2-20 אותיות בלבד."*/"Private name need to contain 2-20 letters only ");
                privateName = value;
            }
        }


        private string familyName;
        public string FamilyName
        {
            get { return familyName; }
            set
            {
                Regex r = new Regex("^([^20]|[a-zA-Zא-ת]){2,20}$");
                if (!r.IsMatch(value))
                    throw new System.IO.InvalidDataException(/*"שם משפחה צריך להכיל 2-20 אותיות בלבד."*/"Family name need to contain 2-20 letters only ");
                familyName = value;
            }
        }



        private string mailAddress;
        public string MailAddress
        {
            get { return mailAddress; }
            set
            {
                try
                {
                    MailAddress m = new MailAddress(value);
                }
                catch (Exception)
                {
                    throw new System.IO.InvalidDataException(/*"כתובת המייל לא תקינה."*/"Email address incorrect");
                }
                mailAddress = value;
            }
        }


        private Enums.StatusGREnum status;// for example: "Active"  // פתוחה, נסגרה_עסקה_דרך_האתר, נסגרה_כי_פג_תוקפה
        public Enums.StatusGREnum Status
        {
            get { return status; }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.StatusGREnum), value))
                    throw new System.IO.InvalidDataException("Enum input illegal");
                status = value;
            }
        }


        private DateTime registrationDate;
        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set
            {// to define
                if (registrationDate == default(DateTime))
                    registrationDate = value;
            }
        }


        private DateTime entryDate;
        public DateTime EntryDate
        {
            get { return entryDate; }
            set
            {
                entryDate = value;
            }
        }


        private DateTime releaseDate;
        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set
            {

                releaseDate = value;
            }
        }





        public Enums.AreaEnum area;//All,North,South,Center,Jerusalem

        public Enums.AreaEnum Area
        {
            get { return area; }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.AreaEnum), value))
                    throw new System.IO.InvalidDataException("Enum input illegal");
                area = value;
            }

        }

        //public AreaEnum SubArea { get; private set; } .... // להגדיר באופן נכון כמו את האחרים


        private Enums.TypeEnum type;  //Zimmer\Hotel\Camping\ Etc;
        public Enums.TypeEnum Type
        {
            get { return type; }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.TypeEnum), value))
                    throw new System.IO.InvalidDataException("Enum input illegal");
                type = value;
            }

        }


        // AttractionsEnum= הכרחי/אפשרי/לא מעוניין

        private Enums.AttractionsEnum pool;
        public Enums.AttractionsEnum Pool
        {
            get { return pool; }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.AttractionsEnum), value))
                    throw new System.IO.InvalidDataException("Enum input illegal");
                pool = value;
            }
        }


        private Enums.AttractionsEnum jacuzzi;
        public Enums.AttractionsEnum Jacuzzi
        {
            get { return jacuzzi; }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.AttractionsEnum), value))
                    throw new System.IO.InvalidDataException("Enum input illegal");
                jacuzzi = value;
            }
        }


        private Enums.AttractionsEnum garden;
        public Enums.AttractionsEnum Garden
        {
            get { return garden; }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.AttractionsEnum), value))
                    throw new System.IO.InvalidDataException("Enum input illegal");
                garden = value;
            }
        }


        private Enums.AttractionsEnum childrensAttractions;
        public Enums.AttractionsEnum ChildrensAttractions
        {
            get { return childrensAttractions; }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.AttractionsEnum), value))
                    throw new System.IO.InvalidDataException("Enum input illegal");
                childrensAttractions = value;
            }
        }

        private int adults;
        public int Adults
        {
            get { return adults;  }
            set
            {
                if (value < 0)
                    throw new System.IO.InvalidDataException(/*מספר מבוגרים אינו יכול להיות שלילי"*/"Number of adults cannot be negative");
                if (value == 0)
                    throw new System.IO.InvalidDataException(/*מספר מבוגרים אינוי יכול להיות 0"*/"Number of adults cannot be 0");
                adults = value;
            }
        }



        private int children;
        public int Children
        {
            get { return children; }
            set
            {
                if (value < 0)
                    throw new System.IO.InvalidDataException(/*מספר ילדים אינו יכול להיות שלילי"*/"Number of children cannot be negative");
                children = value;
            }
        }

        public bool isEqual(BE.GuestRequest GR)
        {
            return GR.GuestRequestKey == GuestRequestKey;
        }





        public override string ToString()  // יש לממש בהתאם לדרישות הפרוייקט.
        {
            string str = "";
            str +="Guest request key : "+GuestRequestKey+ "\n" + "Geust name: " + PrivateName + " " + FamilyName + "\n" +
                "MailAddress: " + MailAddress + "\n" +
                "Status: " + Status + "\n" +
                "Registration Date: " + RegistrationDate.ToString() + "\n" +
                "Entry date: " + EntryDate.Date.ToString() + "\n" +
                "Release date: " + ReleaseDate.Date.ToString() + "\n"
                + "Area: " + Area + "\n" +
                "type: " + type + "\n" +
                "מבוגרים: " + Adults + "\n" +
                "Children" + Children + "\n" +
                "Pool: " + Pool + "\n" +
                "Jacuzzi: " + Jacuzzi + "\n" +
                "Garden: " + Garden + "\n" +
                "Childrens Attractions: " + ChildrensAttractions + "\n";
            return str;
        }
    }
}
