using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [Serializable]
    public class Order  //מחלקה בשם Order שמייצגת הזמנה )כלומר את הקשר בין לקוח ליחידת אירוח( ותכלול:
    {

        private int hostingUnitKey;
        public int HostingUnitKey
        {
            get { return hostingUnitKey; }
            set
            {
                //if (value < 10000000) //from number with 8 letters 
                 //   throw new Exception(/*מספר זיהוי אינו תקין"*/"Incorrect key!");
                hostingUnitKey = value;
            }

        }



        private int guestRequestKey;
        public int GuestRequestKey
        {
            get { return guestRequestKey; }
            set
            {
                //to define
                if(GuestRequestKey==0)
                    guestRequestKey = value;
            }

        }






        private int orderKey;
        public int OrderKey
        {
            get { return orderKey; }
            set
            {
                //to define
                if (value < 10000000) //from number with 8 letters 
                    throw new System.IO.InvalidDataException(/*מספר זיהוי אינו תקין"*/"Incorrect key!");
                orderKey = value;

            }
        }




        ///eunm - //טרם טופל, נשלח מייל, נסגר מחוסר הענות של הלקוח ,נסגר בהיענות של הלקוח
        private Enums.StatusEnum status;
        public Enums.StatusEnum Status
        {
            get { return status; }
            set
            {
                //if (!Enum.IsDefined(typeof(StatusEnum), value))
                //    throw new System.IO.InvalidDataException("Enum input illegal");
                //if (status == StatusEnum.נסגר_מחוסר_הענות_הלקוח || status == StatusEnum.נסגר_בהיענות_הלקוח)
                //    throw new ArgumentException("לא ניתן לשנות עסקה שנסגרה");

                status = value;
            }
        }


        private DateTime createDate;
        public DateTime CreateDate  //לממש == ליום יצירת ההזמנה
        {
            get { return createDate; }
            set
            {
                //to define
                createDate = value;
                
               
            }

        }


        private DateTime orderDate;
        public DateTime OrderDate  //לממש == תאריך משלוח המייל ללקוח
        {
            get { return orderDate; }
            set
            {
                //to define
                orderDate = value;
            }

        }


        public override string ToString()  // יש לממש בהתאם לדרישות הפרוייקט.
        {
            string str = "";
            str += "מספר הזמנה: " + OrderKey + "\n" +
                "עבור יחידת אירוח מספר " + HostingUnitKey + "\n" + "מספר דרישת אירוח " + GuestRequestKey + "\n" +
                //"Status: " + Status + "\n" +
                "תאריך יצירת הזמנה  " + CreateDate.ToString() + "\n" 
                ;
            return str;
        }

        //public bool isEqual(Order order)
        //{
        //    return order.OrderKey == OrderKey;
        //}

    }
}
