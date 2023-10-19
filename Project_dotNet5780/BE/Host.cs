using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Xml.Serialization;


namespace BE
{

    [Serializable]
    public class Host
    {
        private string hostKey;
        public string HostKey
        {
            get { return hostKey; }
            set
            {
                if (!Tools.ValidateID(value))
                    throw new System.IO.InvalidDataException("תעודת זהות לא תקינה.");
                hostKey = value;
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
                    throw new System.IO.InvalidDataException(/*"שם פרטי צריך להכיל 2-20 אותיות."*/"Private name need to contain 2-20 letters ");
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
                    throw new System.IO.InvalidDataException(/*"שם משפחה צריך להכיל 2-20 אותיות."*/"Family name need to contain 2-20 letters ");
                familyName = value;
            }
        }


        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {// support all israel numbers //for exampale support 0508771340 / 050-8771340 / 050-877-1340 / 025334750/ 02-5334750 / 02-533-4750
                Regex r = new Regex("(^0(5|7)[0-9]-{0,1}[0-9]{7}$)|(^0(5|7)[0-9]-{0,1}[0-9]{3}-{0,1}[0-9]{4}$)|(^0(2|3|4|7|8|9)-{0,1}[0-9]{7}$)|(^0(2|3|4|7|8|9)-{0,1}[0-9]{3}-{0,1}[0-9]{4}$)");
                if (!r.IsMatch(value))
                    throw new System.IO.InvalidDataException(/*"מספר טלפון אינו חוקי"*/"Phone number is not legal ");
                phoneNumber = value;

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

        private BankBranch bankBranchDetails;
        public BankBranch BankBranchDetails
        {
            get { return bankBranchDetails; }
            set
            { // לממש בדיקה
                bankBranchDetails = value;
            }
        }



        private int bankAccountNumber;
        public int BankAccountNumber
        {
            get { return bankAccountNumber; }
            set
            {
                if (value < 0)
                    throw new System.IO.InvalidDataException("מספר חשבון בנק לא יכול להיות שלילי.");
                bankAccountNumber = value;


            }
        }

        private bool collectionClearance;
        public string CollectionClearance //Yes/No //אישור גביה מחשבון הבנק
        {
            get
            {
                if (collectionClearance) return "Yes"; 
                else return "No";
            }
            set
            {
                if (value.Equals("yes")|| value.Equals("Yes")|| value.Equals("YES")||value.Equals("כן")) collectionClearance = true;
                else collectionClearance = false;
            }

        }




        public override string ToString()  
        {


            string str1 = "";
            str1 += "Host Key: " + HostKey + "\n" +
                "Name: " + PrivateName + " " + FamilyName + "\n" +
                "Phone Number: " + PhoneNumber + "\n" +
                "Mail Address: " + MailAddress + "\n" +
                "Bank Branch Details: " + BankBranchDetails + "\n" +
                "Bank Account Number: " + BankAccountNumber + "\n" +
                "Collection Clearance: " + CollectionClearance + "\n";         

            return str1;
        }


        //תוספת
        //תוספת רק עבור שליחת רשימת של מאחרים. עבור גרופינג
        private int numberOfHostingUnits;
        public int NumberOfHostingUnits
        {
            get=> numberOfHostingUnits;
            set => numberOfHostingUnits = value;
        }

    }

}

