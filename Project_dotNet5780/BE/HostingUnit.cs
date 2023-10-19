using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{

    [Serializable]
    public class HostingUnit
    {


        private int hostingUnitKey;
        public int HostingUnitKey
        {
            get { return hostingUnitKey; }
            set
            {
                if (value < 10000000) //from number with 8 letters 
                    throw new System.IO.InvalidDataException(/*מספר זיהוי אינו תקין"*/"Incorrect key!");
                hostingUnitKey = value;
            }
        }

        private Host owner;

        public Host Owner
        {
            get { return owner; }
            set
            {
                owner = value; //דורש בדיקה!
            }

        }

        private string hostingUnitName;

        public string HostingUnitName
        {
            get { return hostingUnitName; }
            set
            {
                Regex r = new Regex("^([^20]|[0-9a-zA-Zא-ת]){2,30}$");
                if (!r.IsMatch(value))
                    throw new System.IO.InvalidDataException(/*"שם יחידה צריך להכיל 2-30 אותיות."*/"HostingUnitName name need to contain 2-30 letters ");
                hostingUnitName = value;
            }

        }


        private bool[,] diary = new bool[31, 12];


        [XmlIgnore]  //להתעלם בסרילזיציה כי יש בעיה להמיר מערך דו ממדי לאקס אמ אל
        public bool[,] Diary
        {
            get { return diary; }
            set
            {
                diary = value;
            }


        }




        [XmlArray("Diary")]  //אומרים לאקס אמ אל לקרוא לאלמנט הבא בשם שבין המרכאות
        public bool[] TempDiary
        {
            get { return Diary.Flatten(); }
            set { Diary = value.Expand(12); }
        }




















        public bool isEqual(HostingUnit host1)
        {
            return host1.HostingUnitKey == HostingUnitKey;
        }

        public bool isEqualID(int ID)
        {
            return ID == HostingUnitKey;
        }



        


        //overrides
        public override string ToString()  //יש לדרוס בהתאם לדרישות הפרוייקט
        {
            string str = "";
            str += "Hosting Unit Key: " + HostingUnitKey + "\n" +
                  "Hosting Unit Name: " + HostingUnitName + "\n"+
            "Owner details: \n" + Owner + "\n";
            //להשלים לפי שדות שהוספנו
            return str;
        }




        private Enums.AreaEnum area;//All,North,South,Center,Jerusalem

        public Enums.AreaEnum Area
        {
            get { return area; }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.AreaEnum), value))
                    throw new System.IO.InvalidDataException("Enum input illegal");
                if (value== Enums.AreaEnum.All)
                    throw new System.IO.InvalidDataException("Enum input illegal. HostingUnit cannot be in All regions!!!");

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
                if (value == Enums.TypeEnum.Unknown)
                    throw new System.IO.InvalidDataException("סוג יחידת אירוח אינו יכול להיות לא ידוע");
                type = value;
            }

        }



        private bool pool;
        public bool Pool
        {
            get { return pool; }
            set
            {

                pool = value;
            }
        }


        private bool jacuzzi;
        public bool Jacuzzi
        {
            get { return jacuzzi; }
            set
            {

                jacuzzi = value;
            }
        }


        private bool garden;
        public bool Garden
        {
            get { return garden; }
            set
            {
                garden = value;
            }
        }


        private bool childrensAttractions;
        public bool ChildrensAttractions
        {
            get { return childrensAttractions; }
            set
            {

                childrensAttractions = value;
            }
        }




        public bool this[DateTime generalDate] // define indexer 
        {
            private set => Diary[generalDate.Day - 1, generalDate.Month - 1] = value;
            get => Diary[generalDate.Day - 1, generalDate.Month - 1];
        }






    }
}
