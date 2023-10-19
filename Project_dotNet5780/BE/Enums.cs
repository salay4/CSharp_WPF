

namespace BE
{
    public class Enums
    {

        /// <summary>
        /// in C# uninitialize enum value is the first value
        /// </summary>
        public enum AreaEnum
        {
            All, North, South, Center, Jerusalem
        }

        //enum SubArea
        //{
        //  Tel_Aviv
        //}

        public enum TypeEnum // type of hosting 
        {
            Unknown, Zimmer, Hotel, Camping
        }
        public enum AttractionsEnum
        {
            Unknown,
            הכרחי,
            אפשרי,
            לא_מעוניין
            //Necessary,
            //Possible,
            //Not_interested
        }

        public enum StatusEnum // status Order enum
        {
            טרם_טופל,
            נשלח_מייל,
            נסגר_מחוסר_הענות_הלקוח,
            נסגר_בהיענות_הלקוח,
            נסגר_היות_ויחידית_אירוח_נתפסה_כבר
            //Not_yet_treated,
            //Mail_has_been_sent,
            //Closes_for_lack_of_customer_responsiveness,
            //Customer_responsiveness_closes
        }

        public enum StatusGREnum //Status for GuestRequest
        {
            פתוחה,
            נסגרה_עסקה_דרך_האתר,
            נסגרה_כי_פג_תוקפה
            //Open,
            //Deal_closed_through_the_site,
            //Closed_because_expired
        }
    }

}
