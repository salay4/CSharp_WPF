using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using BE;
using System.Text.RegularExpressions;




//namespace PL
//{
//    public class ConsoleMenus
//    {
//        BL.IBL bl;

//        /// <summary>
//        /// start menu
//        /// </summary>


//        #region GuestRequest 
//        //   #endregion
//        public void clientMenu()//עבור לקוח ...
//        {
//            bl = BL.Factory.GetInstance();


//            //CultureInfo CultureInfo = new CultureInfo("de-DE");

//            string data = "";
//            BE.GuestRequest gr = new BE.GuestRequest();



//            while (!data.Equals("0"))
//            {

//                try
//                {

//                    Console.WriteLine("add geust request, for exit click 0");
//                    if (data.Equals("0")) break;
//                    //  private name

//                    Console.WriteLine("\n please enter your private name");
//                    data = Console.ReadLine();
//                    gr.PrivateName = data;

//                    //  last name

//                    Console.WriteLine("\n please enter your last name");
//                    data = Console.ReadLine();
//                    gr.FamilyName = data;

//                    // email

//                    Console.WriteLine("\n please enter your e-mail");
//                    data = Console.ReadLine();
//                    gr.MailAddress = data;

//                    //  Registration date

//                    //DateTime RegistrationddateTime = new DateTime();
//                    //RegistrationddateTime = DateTime.Now;
//                    //gr.RegistrationDate = RegistrationddateTime;


//                    gr.RegistrationDate = DateTime.Now;

//                    //  entry date

//                    ////Console.WriteLine("\n please enter your entry date");
//                    ////data = Console.ReadLine();
//                    ////DateTime entryDate = new DateTime();
//                    ////try
//                    ////{
//                    ////    entryDate = DateTime.Parse(data, CultureInfo);
//                    ////    gr.RegistrationDate = entryDate;
//                    ////}
//                    ////catch (FormatException)
//                    ////{
//                    ////    Console.WriteLine($"Unable to parse '{"error wrong input, enter date in this format: dd mm yyyy"}'");
//                    ////}


//                    //////  releaseDate


//                    ////Console.WriteLine("\n please enter your release date");
//                    ////data = Console.ReadLine();
//                    ////DateTime releaseDate = new DateTime();
//                    ////try
//                    ////{
//                    ////    releaseDate = DateTime.Parse(data, CultureInfo);
//                    ////    gr.RegistrationDate = releaseDate;
//                    ////}
//                    ////catch (FormatException)
//                    ////{
//                    ////    Console.WriteLine($"Unable to parse '{"error wrong input, enter date in this format: dd mm yyyy"}'");
//                    ////}








//                    Console.WriteLine(" Enter the start date of hosting in the following format:");// הכנס תאריך תחילת אירוח בפורמט הבא 
//                    Console.WriteLine("dd/mm/yyyy");

//                    DateTime beginDate = default(DateTime);

//                    string dateFormat = Console.ReadLine();
//                    bool isSuccess = DateTime.TryParse(dateFormat, out beginDate);//check if the input is llegal 

//                    while (!isSuccess)
//                    {
//                        Console.WriteLine("Error! incorrect date input was entered ");
//                        Console.WriteLine(" Enter the start date of hosting in the following format:");// הכנס תאריך תחילת אירוח בפורמט הבא 
//                        Console.WriteLine("dd/mm/yyyy");
//                        dateFormat = Console.ReadLine();
//                        isSuccess = DateTime.TryParse(dateFormat, out beginDate);
//                    }






//                    Console.WriteLine(" Enter the end date of hosting in the following format:");// הכנס תאריך סוף אירוח בפורמט הבא 
//                    Console.WriteLine("dd/mm/yyyy");

//                    DateTime endDate = default(DateTime);

//                    dateFormat = Console.ReadLine();
//                    isSuccess = DateTime.TryParse(dateFormat, out endDate);//check if the input is llegal 

//                    while (!isSuccess)
//                    {
//                        Console.WriteLine("Error! incorrect date input was entered ");
//                        Console.WriteLine(" Enter the end date of hosting in the following format:");// הכנס תאריך סוף אירוח בפורמט הבא 
//                        Console.WriteLine("dd/mm/yyyy");
//                        dateFormat = Console.ReadLine();
//                        isSuccess = DateTime.TryParse(dateFormat, out endDate);
//                    }

//                    gr.EntryDate = beginDate;
//                    gr.ReleaseDate = endDate;















//                    //  children 


//                    Console.WriteLine("\n please enter number of children");
//                    data = Console.ReadLine();
//                    int number = -1;
//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number < 0)
//                    {
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else
//                    {
//                        gr.Children = number;
//                    }

//                    // adults

//                    Console.WriteLine("\n please enter number of adults");
//                    data = Console.ReadLine();
//                    number = -1;
//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;
//                    }
//                    else if (number < 0)
//                    {
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else
//                    {
//                        gr.Adults = number;
//                    }

//                    //  area

//                    Console.WriteLine("please enter the area:");
//                    Console.WriteLine("Choose one from the following options");
//                    Console.WriteLine("Enter 0 for All areas");
//                    Console.WriteLine("Enter 1 for North area");
//                    Console.WriteLine("Enter 2 for South area");
//                    Console.WriteLine("Enter 3 for Center area");
//                    Console.WriteLine("Enter 4 for Jerusalem area");

//                    data = Console.ReadLine();

//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number > 4 || number < 0)
//                    {
//                        Console.WriteLine("Wrong number");
//                        break;

//                    }
//                    else
//                    {

//                        BE.AreaEnum choosEnum;
//                        choosEnum = (BE.AreaEnum)number;
//                        gr.Area = choosEnum;


//                    }

//                    // TYPE

//                    Console.WriteLine("please enter the Type:");
//                    Console.WriteLine("Choose one from the following options");
//                    //Console.WriteLine("Enter 0 for Unknown");
//                    Console.WriteLine("Enter 1 for Zimmer");
//                    Console.WriteLine("Enter 2 for Hotel");
//                    Console.WriteLine("Enter 3 for Camping");

//                    data = Console.ReadLine();

//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number > 3 || number <= 0)
//                    {
//                        Console.WriteLine("Wrong number");
//                        break;
//                    }
//                    else
//                    {
//                        BE.TypeEnum choosEnum1;
//                        choosEnum1 = (BE.TypeEnum)number;
//                        gr.Type = choosEnum1;
//                    }


//                    //  pool

//                    Console.WriteLine("do you want to have a pool:");
//                    Console.WriteLine("Choose one from the following options");
//                    //Console.WriteLine("Enter 0 for Unknown");
//                    Console.WriteLine("Enter 1 for הכרחי");
//                    Console.WriteLine("Enter 2 for אפשרי");
//                    Console.WriteLine("Enter 3 for לא_מעוניין");

//                    data = Console.ReadLine();

//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number > 3 || number <= 0)
//                    {
//                        Console.WriteLine("Wrong number");
//                        break;
//                    }
//                    else
//                    {
//                        BE.AttractionsEnum choosEnum2;
//                        choosEnum2 = (BE.AttractionsEnum)number;
//                        gr.Pool = choosEnum2;
//                    }

//                    // jacuzzi


//                    Console.WriteLine("do you want to have a jacuzzi:");
//                    Console.WriteLine("Choose one from the following options");
//                    //Console.WriteLine("Enter 0 for Unknown");
//                    Console.WriteLine("Enter 1 for הכרחי");
//                    Console.WriteLine("Enter 2 for אפשרי");
//                    Console.WriteLine("Enter 3 for לא_מעוניין");

//                    data = Console.ReadLine();

//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number > 3 || number <= 0)
//                    {
//                        Console.WriteLine("Wrong number");
//                        break;
//                    }
//                    else
//                    {
//                        BE.AttractionsEnum choosEnum3;
//                        choosEnum3 = (BE.AttractionsEnum)number;
//                        gr.Jacuzzi = choosEnum3;
//                    }


//                    //  garden


//                    Console.WriteLine("do you want to have a garden:");
//                    Console.WriteLine("Choose one from the following options");
//                    //Console.WriteLine("Enter 0 for Unknown");
//                    Console.WriteLine("Enter 1 for הכרחי");
//                    Console.WriteLine("Enter 2 for אפשרי");
//                    Console.WriteLine("Enter 3 for לא_מעוניין");

//                    data = Console.ReadLine();

//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number > 3 || number <= 0)
//                    {
//                        Console.WriteLine("Wrong number");
//                        break;
//                    }
//                    else
//                    {
//                        BE.AttractionsEnum choosEnum4;
//                        choosEnum4 = (BE.AttractionsEnum)number;
//                        gr.Garden = choosEnum4;
//                    }





//                    try
//                    {
//                        bl.addGuestRequest(gr); // add copy of gr to the BL layer
//                    }
//                    catch (DuplicateWaitObjectException e)
//                    {

//                        Console.WriteLine(e.Message);
//                    }
//                    catch (ArgumentException e)
//                    {

//                        Console.WriteLine(e.Message);
//                    }



//                    //bl.addGuestRequest(BE.Tools.Clone(gr)); // add copy of gr to the BL layer

//                    //Console.WriteLine("if you dont want to add more GuestRequst enter 0");
//                    //data = Console.ReadLine();
//                    break;

//                }
//                catch (System.IO.InvalidDataException ex)
//                {
//                    Console.WriteLine(ex.Message);

//                }

//            }


//        }
//        #endregion

//        #region HostingUnit 

//        public void HostingUnitMenu()//2.0
//        {
//            int number = -1;
//            HostingUnitMenuEnum choosMenuEnum;

//            do
//            {


//                Console.WriteLine("Choose one from the following options");
//                Console.WriteLine("Enter 1 to add new Hosting Unit");
//                Console.WriteLine("Enter 2 to to enter to personal area");
//                Console.WriteLine("Enter 0 to return to the previous menu");

//                string input = Console.ReadLine();


//                if (!Int32.TryParse(input, out number))
//                {
//                    number = -1;
//                    Console.WriteLine("Wrong input");
//                    continue;
//                }
//                if (number > 2 || number < 0)
//                {
//                    Console.WriteLine("Wrong number");
//                    continue;
//                }

//                choosMenuEnum = (HostingUnitMenuEnum)number;

//                ConsoleMenus conMenu = new ConsoleMenus();
//                switch (choosMenuEnum)
//                {
//                    case HostingUnitMenuEnum.Add_Hosting_Unit:
//                        conMenu.Pl_AddHostingUnit();//2.1
//                        break;
//                    case HostingUnitMenuEnum.Personal_Area:
//                        conMenu.PersonalArea();//2.2
//                        break;
//                    case HostingUnitMenuEnum.Exit:
//                        break;
//                }


//            } while (number != 0);





//        }






//        //Hosting Unit Menu 
//        public void Pl_AddHostingUnit() //2.1
//        {


//            string data = "";
//            BE.HostingUnit hu = new HostingUnit();

//            while (!data.Equals("0"))
//            {


//                try
//                {


//                    //host
//                    Console.WriteLine("please enter host details:");

//                    //host name
//                    Console.WriteLine("please enter Host private name");
//                    data = Console.ReadLine();
//                    hu.Owner = new BE.Host();
//                    hu.Owner.BankBranchDetails = new BE.BankBranch();

//                    hu.Owner.PrivateName = data;

//                    //host last name
//                    Console.WriteLine("please enter Host last name");
//                    data = Console.ReadLine();
//                    hu.Owner.FamilyName = data;

//                    Console.WriteLine("please enter Host personal ID");
//                    data = Console.ReadLine();
//                    hu.Owner.HostKey = data;

//                    //host phone

//                    Console.WriteLine("please enter hots phone-number");
//                    data = Console.ReadLine();
//                    int number = -1;
//                    //////Regex r = new Regex("(^0(5|7)[0-9]-{0,1}[0-9]{7}$)|(^0(5|7)[0-9]-{0,1}[0-9]{3}-{0,1}[0-9]{4}$)|(^0(2|3|4|7|8|9)-{0,1}[0-9]{7}$)|(^0(2|3|4|7|8|9)-{0,1}[0-9]{3}-{0,1}[0-9]{4}$)");
//                    //////if (!r.IsMatch(data))
//                    //////    throw new Exception(/*"מספר טלפון אינו חוקי"*/"Phone number is not legal ");
//                    hu.Owner.PhoneNumber = data;

//                    //bank details

//                    Console.WriteLine("\n host bank details:");
//                    Console.WriteLine("please enter your bank number");

//                    data = Console.ReadLine();

//                    number = -1;
//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number < 0)
//                    {
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else
//                    {
//                        hu.Owner.BankBranchDetails.BankNumber = number;
//                    }

//                    // bank name

//                    Console.WriteLine("please enter your bank name");
//                    data = Console.ReadLine();
//                    hu.Owner.BankBranchDetails.BankName = data;

//                    // branch number

//                    Console.WriteLine("please enter your branch number");
//                    data = Console.ReadLine();
//                    number = -1;
//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number < 0)
//                    {
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else
//                    {
//                        hu.Owner.BankBranchDetails.BranchNumber = number;
//                    }

//                    // branch addrees

//                    Console.WriteLine("please enter your brach address");
//                    data = Console.ReadLine();
//                    hu.Owner.BankBranchDetails.BranchAddress = data;

//                    // branch city

//                    Console.WriteLine("please enter your branch city");
//                    data = Console.ReadLine();
//                    hu.Owner.BankBranchDetails.BranchCity = data;

//                    //bank account number

//                    Console.WriteLine("please enter your bank account number");
//                    data = Console.ReadLine();
//                    number = -1;
//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number < 0)
//                    {
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else
//                    {
//                        hu.Owner.BankAccountNumber = number;
//                    }

//                    //mail address

//                    Console.WriteLine("please enter your mail address");
//                    data = Console.ReadLine();
//                    hu.Owner.MailAddress = data;

//                    //CollectionClearance - לא הוספתי

//                    //hosting unit name

//                    Console.WriteLine("please enter your hosting unit name");
//                    data = Console.ReadLine();
//                    hu.HostingUnitName = data;

//                    //area


//                    Console.WriteLine("please enter the area:");
//                    Console.WriteLine("Choose one from the following options");
//                    // Console.WriteLine("Enter 0 for All areas");
//                    Console.WriteLine("Enter 1 for North area");
//                    Console.WriteLine("Enter 2 for South area");
//                    Console.WriteLine("Enter 3 for Center area");
//                    Console.WriteLine("Enter 4 for Jerusalem area");

//                    data = Console.ReadLine();

//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number > 4 || number <= 0)
//                    {
//                        Console.WriteLine("Wrong number");
//                        break;

//                    }
//                    else
//                    {

//                        BE.AreaEnum choosEnum;
//                        choosEnum = (BE.AreaEnum)number;
//                        hu.Area = choosEnum;


//                    }


//                    // TYPE

//                    Console.WriteLine("please enter the Type:");
//                    Console.WriteLine("Choose one from the following options");
//                    //Console.WriteLine("Enter 0 for Unknown");
//                    Console.WriteLine("Enter 1 for Zimmer");
//                    Console.WriteLine("Enter 2 for Hotel");
//                    Console.WriteLine("Enter 3 for Camping");

//                    data = Console.ReadLine();

//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number > 3 || number <= 0)
//                    {
//                        Console.WriteLine("Wrong number");
//                        break;
//                    }
//                    else
//                    {
//                        BE.TypeEnum choosEnum1;
//                        choosEnum1 = (BE.TypeEnum)number;
//                        hu.Type = choosEnum1;
//                    }


//                    //  pool

//                    Console.WriteLine("do you want to have a pool:" +
//                        " \n enter 1 for yes" +
//                        " \n enter 0 for no");

//                    data = Console.ReadLine();

//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number < 0 || number > 1)
//                    {
//                        Console.WriteLine("Wrong number");
//                        break;
//                    }
//                    else
//                    {
//                        if (data.Equals("1")) hu.Pool = true;

//                        else hu.Pool = false;
//                    }

//                    // jacuzzi


//                    Console.WriteLine("do you have a jacuzzi:" +
//                        " \n enter 1 for yes" +
//                        " \n enter 0 for no");

//                    data = Console.ReadLine();

//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number < 0 || number > 1)
//                    {
//                        Console.WriteLine("Wrong number");
//                        break;
//                    }
//                    else
//                    {
//                        if (data.Equals("1")) hu.Jacuzzi = true;

//                        else hu.Jacuzzi = false;
//                    }



//                    //  garden


//                    Console.WriteLine("do you have a garden:" +
//                        " \n enter 1 for yes" +
//                        " \n enter 0 for no");
//                    data = Console.ReadLine();

//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number > 1 || number < 0)
//                    {
//                        Console.WriteLine("Wrong number");
//                        break;
//                    }
//                    else
//                    {
//                        if (data.Equals("1")) hu.Garden = true;

//                        else hu.Garden = false;

//                    }

//                    Console.WriteLine("do you have a children attractions?" +
//                        " \n enter 1 for yes" +
//                        " \n enter 0 for no");
//                    data = Console.ReadLine();

//                    if (!Int32.TryParse(data, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        break;

//                    }
//                    else if (number > 1 || number < 0)
//                    {
//                        Console.WriteLine("Wrong number");
//                        break;
//                    }
//                    else
//                    {
//                        if (data.Equals("1")) hu.ChildrensAttractions = true;

//                        else hu.ChildrensAttractions = false;

//                    }
//                    bl = BL.Factory.GetInstance();

//                    try
//                    {
//                        bl.addHostingUnit(hu);
//                    }
//                    catch (System.IO.InvalidDataException e)
//                    {
//                        Console.WriteLine(string.Format("שגיאה בהזנת נתונים: \n {0}", e.Message));
//                    }
//                    catch (DuplicateWaitObjectException e)
//                    {
//                        Console.WriteLine(string.Format("יחידת אירוח עם מספר זהה קיימת כבר במערכת \n {0}", e.Message));
//                    }
//                    catch (ArgumentException e)
//                    {
//                        Console.WriteLine(e.Message);
//                    }



//                    //Console.WriteLine("you successfully add Hosting Unit. ");
//                    //Console.WriteLine("we continue to add Hosting Unit, for exit click 0");
//                    //data = Console.ReadLine();
//                    break;

//                }
//                catch (System.IO.InvalidDataException e)
//                {

//                    Console.WriteLine(e.Message);
//                }
//            }
//        }

//        public void PersonalArea() //2.2
//        {
//            bl = BL.Factory.GetInstance();

//            int number = -1;

//            try
//            {



//                Console.WriteLine("please enter your HostingUnit ID");
//                string input = Console.ReadLine();
//                if (!Int32.TryParse(input, out number))
//                {
//                    number = -1;
//                    throw new System.ArgumentException(string.Format("worng input {0} not llegal int", number));

//                }
//                BE.HostingUnit HU = bl.getHostingUnitByID(number);
//                if (HU == null) //אין יחידת אירוח עם מספר זיהוי זה
//                {
//                    throw new System.ArgumentException(string.Format("worng input {0} this HostingUnit id not exsists", number));

//                }


//                PersoanlAreaEnum choosMenuEnum;

//                do
//                {



//                    Console.WriteLine("Choose one from the following options");
//                    Console.WriteLine("Enter 1 to update Hosting Unit");
//                    Console.WriteLine("Enter 2 to to delete !THIS! Hosting Unit");
//                    Console.WriteLine("Enter 3 to to enter to orders menu");
//                    Console.WriteLine("Enter 0 to return to the previous menu");

//                    input = Console.ReadLine();


//                    if (!Int32.TryParse(input, out number))
//                    {
//                        number = -1;
//                        Console.WriteLine("Wrong input");
//                        continue;
//                    }
//                    if (number > 3 || number < 0)
//                    {
//                        Console.WriteLine("Wrong number");
//                        continue;
//                    }

//                    choosMenuEnum = (PersoanlAreaEnum)number;

//                    ConsoleMenus conMenu = new ConsoleMenus();
//                    switch (choosMenuEnum)
//                    {
//                        case PersoanlAreaEnum.Update_Hosting_Unit:
//                            conMenu.PL_UpdateHostingUnit(HU);//2.2.1
//                            break;
//                        case PersoanlAreaEnum.Delete_Hosting_Unit:
//                            conMenu.PL_DeleteHostingUnit(HU);//2.3
//                            number = 0;//ברגע שנמחק מופע אין מה לעשות כאן... 
//                            break;
//                        case PersoanlAreaEnum.Orders_Menu:
//                            conMenu.PL_OrdersMenu(HU);//3.0
//                            break;
//                        case PersoanlAreaEnum.Exit:
//                            break;
//                    }


//                } while (number != 0);

//            }
//            catch (ArgumentException e)
//            {

//                Console.WriteLine(e.Message);
//            }

//        }

//        public void PL_UpdateHostingUnit(BE.HostingUnit hu) //2.2.1
//        {
//            bl = BL.Factory.GetInstance();


//            string data = "";


//            while (!data.Equals("0"))
//            {

//                //host

//                Console.WriteLine("the following this is the Hosting Unit correct details");
//                Console.WriteLine(hu);

//                Console.WriteLine("please enter Hosting update details");

//                //host name
//                Console.WriteLine("if you want to change Host details enter 1");

//                string choose = Console.ReadLine();

//                try
//                {


//                    if (choose.Equals("1"))
//                    {
//                        Console.WriteLine("please enter Host private name");
//                        data = Console.ReadLine();

//                        hu.Owner.BankBranchDetails = new BE.BankBranch();

//                        hu.Owner.PrivateName = data;

//                        //host last name
//                        Console.WriteLine("please enter Host last name");
//                        data = Console.ReadLine();
//                        hu.Owner.FamilyName = data;

//                        Console.WriteLine("please enter Host personal ID");
//                        data = Console.ReadLine();
//                        hu.Owner.HostKey = data;

//                        //host phone

//                        Console.WriteLine("please enter Host phone-number");
//                        data = Console.ReadLine();
//                        int number = -1;
//                        ////Regex r = new Regex("(^0(5|7)[0-9]-{0,1}[0-9]{7}$)|(^0(5|7)[0-9]-{0,1}[0-9]{3}-{0,1}[0-9]{4}$)|(^0(2|3|4|7|8|9)-{0,1}[0-9]{7}$)|(^0(2|3|4|7|8|9)-{0,1}[0-9]{3}-{0,1}[0-9]{4}$)");
//                        ////if (!r.IsMatch(data))
//                        ////    throw new Exception(/*"מספר טלפון אינו חוקי"*/"Phone number is not legal ");
//                        hu.Owner.PhoneNumber = data;

//                        //bank details

//                        Console.WriteLine("\n host bank details:");
//                        Console.WriteLine("please enter your bank number");

//                        data = Console.ReadLine();

//                        number = -1;
//                        if (!Int32.TryParse(data, out number))
//                        {
//                            number = -1;
//                            Console.WriteLine("Wrong input");
//                            break;

//                        }
//                        else if (number < 0)
//                        {
//                            Console.WriteLine("Wrong input");
//                            break;

//                        }
//                        else
//                        {
//                            hu.Owner.BankBranchDetails.BankNumber = number;
//                        }

//                        // bank name

//                        Console.WriteLine("please enter your bank name");
//                        data = Console.ReadLine();
//                        hu.Owner.BankBranchDetails.BankName = data;

//                        // branch number

//                        Console.WriteLine("please enter your branch number");
//                        data = Console.ReadLine();
//                        number = -1;
//                        if (!Int32.TryParse(data, out number))
//                        {
//                            number = -1;
//                            Console.WriteLine("Wrong input");
//                            break;

//                        }
//                        else if (number < 0)
//                        {
//                            Console.WriteLine("Wrong input");
//                            break;

//                        }
//                        else
//                        {
//                            hu.Owner.BankBranchDetails.BranchNumber = number;
//                        }

//                        // branch addrees

//                        Console.WriteLine("please enter your brach address");
//                        data = Console.ReadLine();
//                        hu.Owner.BankBranchDetails.BranchAddress = data;

//                        // branch city

//                        Console.WriteLine("please enter your branch city");
//                        data = Console.ReadLine();
//                        hu.Owner.BankBranchDetails.BranchCity = data;

//                        //bank account number

//                        Console.WriteLine("please enter your bank account number");
//                        data = Console.ReadLine();
//                        number = -1;
//                        if (!Int32.TryParse(data, out number))
//                        {
//                            number = -1;
//                            Console.WriteLine("Wrong input");
//                            break;

//                        }
//                        else if (number < 0)
//                        {
//                            Console.WriteLine("Wrong input");
//                            break;

//                        }
//                        else
//                        {
//                            hu.Owner.BankAccountNumber = number;
//                        }

//                        //mail address

//                        Console.WriteLine("please enter your mail address");
//                        data = Console.ReadLine();
//                        hu.Owner.MailAddress = data;

//                    }
//                    else
//                    {
//                        Console.WriteLine("if you want to change only Hosting Unit details enter 1");

//                    }

//                    Console.WriteLine("for change Hosting Unit details enter 1");


//                    choose = Console.ReadLine();
//                    if (choose.Equals("1"))

//                    {
//                        //hosting unit name

//                        Console.WriteLine("please enter your hosting unit name");
//                        data = Console.ReadLine();
//                        hu.HostingUnitName = data;

//                        int number = -1;


//                        //area
//                        Console.WriteLine("please enter the area:");
//                        Console.WriteLine("Choose one from the following options");
//                        // Console.WriteLine("Enter 0 for All areas");
//                        Console.WriteLine("Enter 1 for North area");
//                        Console.WriteLine("Enter 2 for South area");
//                        Console.WriteLine("Enter 3 for Center area");
//                        Console.WriteLine("Enter 4 for Jerusalem area");

//                        data = Console.ReadLine();

//                        if (!Int32.TryParse(data, out number))
//                        {
//                            number = -1;
//                            Console.WriteLine("Wrong input");
//                            break;

//                        }
//                        else if (number > 4 || number <= 0)
//                        {
//                            Console.WriteLine("Wrong number");
//                            break;

//                        }
//                        else
//                        {

//                            BE.AreaEnum choosEnum;
//                            choosEnum = (BE.AreaEnum)number;
//                            hu.Area = choosEnum;


//                        }


//                        // TYPE

//                        Console.WriteLine("please enter the Type:");
//                        Console.WriteLine("Choose one from the following options");
//                        //Console.WriteLine("Enter 0 for Unknown");
//                        Console.WriteLine("Enter 1 for Zimmer");
//                        Console.WriteLine("Enter 2 for Hotel");
//                        Console.WriteLine("Enter 3 for Camping");

//                        data = Console.ReadLine();

//                        if (!Int32.TryParse(data, out number))
//                        {
//                            number = -1;
//                            Console.WriteLine("Wrong input");
//                            break;

//                        }
//                        else if (number > 3 || number <= 0)
//                        {
//                            Console.WriteLine("Wrong number");
//                            break;
//                        }
//                        else
//                        {
//                            BE.TypeEnum choosEnum1;
//                            choosEnum1 = (BE.TypeEnum)number;
//                            hu.Type = choosEnum1;
//                        }


//                        //  pool

//                        Console.WriteLine("do you want to have a pool:" +
//                            " \n enter 1 for yes" +
//                            " \n enter 0 for no");

//                        data = Console.ReadLine();

//                        if (!Int32.TryParse(data, out number))
//                        {
//                            number = -1;
//                            Console.WriteLine("Wrong input");
//                            break;

//                        }
//                        else if (number < 0 || number > 1)
//                        {
//                            Console.WriteLine("Wrong number");
//                            break;
//                        }
//                        else
//                        {
//                            if (data.Equals("1")) hu.Pool = true;

//                            else hu.Pool = false;
//                        }

//                        // jacuzzi


//                        Console.WriteLine("do you have a jacuzzi:" +
//                            " \n enter 1 for yes" +
//                            " \n enter 0 for no");

//                        data = Console.ReadLine();

//                        if (!Int32.TryParse(data, out number))
//                        {
//                            number = -1;
//                            Console.WriteLine("Wrong input");
//                            break;

//                        }
//                        else if (number < 0 || number > 1)
//                        {
//                            Console.WriteLine("Wrong number");
//                            break;
//                        }
//                        else
//                        {
//                            if (data.Equals("1")) hu.Jacuzzi = true;

//                            else hu.Jacuzzi = false;
//                        }



//                        //  garden


//                        Console.WriteLine("do you have a garden:" +
//                            " \n enter 1 for yes" +
//                            " \n enter 0 for no");
//                        data = Console.ReadLine();

//                        if (!Int32.TryParse(data, out number))
//                        {
//                            number = -1;
//                            Console.WriteLine("Wrong input");
//                            break;

//                        }
//                        else if (number > 1 || number < 0)
//                        {
//                            Console.WriteLine("Wrong number");
//                            break;
//                        }
//                        else
//                        {
//                            if (data.Equals("1")) hu.Garden = true;

//                            else hu.Garden = false;

//                        }

//                        Console.WriteLine("do you have a children attractions?" +
//                            " \n enter 1 for yes" +
//                            " \n enter 0 for no");
//                        data = Console.ReadLine();

//                        if (!Int32.TryParse(data, out number))
//                        {
//                            number = -1;
//                            Console.WriteLine("Wrong input");
//                            break;

//                        }
//                        else if (number > 1 || number < 0)
//                        {
//                            Console.WriteLine("Wrong number");
//                            break;
//                        }
//                        else
//                        {
//                            if (data.Equals("1")) hu.ChildrensAttractions = true;

//                            else hu.ChildrensAttractions = false;

//                        }
//                    }


//                }
//                catch (System.IO.InvalidDataException e)
//                {

//                    Console.WriteLine(e.Message);
//                }


//                bl = BL.Factory.GetInstance();
//                try
//                {
//                    bl.updateHostingUnit(hu);
//                }
//                catch (System.IO.InvalidDataException e)
//                {

//                    Console.WriteLine(e.Message);
//                }
//                catch (KeyNotFoundException e)
//                {

//                    Console.WriteLine(e.Message);
//                }
//                catch (ArgumentException e)
//                {

//                    Console.WriteLine(e.Message);
//                }


//                break;
//            }


//        }

//        public void PL_DeleteHostingUnit(BE.HostingUnit HU)//2.3
//        {
//            bl = BL.Factory.GetInstance();

//            try
//            {
//                bl.delHostingUnit(HU.HostingUnitKey);
//            }
//            catch (KeyNotFoundException e)
//            {

//                Console.WriteLine(e.Message);
//            }
//            catch (BE.Tools.UnLogicException e) 
//            {

//                Console.WriteLine(e.Message);
//            }


//        }


//        #endregion

//        #region Order 
//        //   #endregion
//        public void PL_OrdersMenu(BE.HostingUnit HU)//3.0
//        {
//            bl = BL.Factory.GetInstance();

//            int number = -1;
//            OrdersMenuEnum choosMenuEnum;

//            do
//            {


//                Console.WriteLine("Choose one from the following options");
//                Console.WriteLine("Enter 1 to enter to Queries For Customer List");
//                Console.WriteLine("Enter 2 to to enter to List of Orders");
//                Console.WriteLine("Enter 0 to return to the previous menu");

//                string input = Console.ReadLine();


//                if (!Int32.TryParse(input, out number))
//                {
//                    number = -1;
//                    Console.WriteLine("Wrong input");
//                    continue;
//                }
//                if (number > 2 || number < 0)
//                {
//                    Console.WriteLine("Wrong number");
//                    continue;
//                }

//                choosMenuEnum = (OrdersMenuEnum)number;

//                ConsoleMenus conMenu = new ConsoleMenus();
//                switch (choosMenuEnum)
//                {
//                    case OrdersMenuEnum.Queries_For_Customer_List:
//                        conMenu.PL_QueriesForCustomerList();//4.1 הדספה בלבד בשלב זה.
//                        string d = Console.ReadLine();
//                        Console.WriteLine("enter 1 to by geust request key");
//                        if (d.Equals("1"))
//                            addOrder(HU); //3.1  



//                        break;
//                    case OrdersMenuEnum.Orders_List:
//                        conMenu.PL_OrdersList(HU);//3.4
//                        break;
//                    case OrdersMenuEnum.Exit:
//                        break;
//                }


//            } while (number != 0);






//        }


//        public void PL_OrdersList(BE.HostingUnit HU)//3.4
//        {


//            bl = BL.Factory.GetInstance();
//            Console.WriteLine("list of all order List");
//            foreach (var item in bl.GetOrderList())
//            {
//                Console.WriteLine(item);
//            }
//            Console.WriteLine("enter order ID of order to update  ");




//            string input = Console.ReadLine();



//            int number = -1;

//            // בדיקת קלט


//            try
//            {
//                if (!Int32.TryParse(input, out number))
//                {
//                    number = -1;
//                    throw new ArgumentException(("Wrong input . the type need to be int"));
//                }
//            }
//            catch (ArgumentException e)
//            {

//                Console.WriteLine(e.Message);
//                return;

//            }



//            BE.Order order = bl.getOrderByID(number);

//            try
//            {

//                if (order.HostingUnitKey != HU.HostingUnitKey)
//                {

//                    throw new ArgumentException(string.Format("this order , {0} not belong to this {1} Hosting Unit  ", order.OrderKey, HU.HostingUnitKey));

//                }
//            }
//            catch (ArgumentException e)
//            {

//                Console.WriteLine(e.Message);
//                return;

//            }





//            //next statement for update order status (only status)

//            try
//            {
//                if (order.Status == StatusEnum.נסגר_מחוסר_הענות_הלקוח || order.Status == StatusEnum.נסגר_בהיענות_הלקוח)
//                    throw new ArgumentException("לא ניתן לשנות עסקה שנסגרה");
//            }
//            catch (ArgumentException e)
//            {

//                Console.WriteLine(e.Message);
//                return;
//            }






//            Console.WriteLine("enter the new status of the order ,0 - ative(not relevant), 1- send mail, 2- close after client not respone, 3 -close with client ");



//            BE.StatusEnum choosEnum;
//            try
//            {
//                if (number > 3 || number < 0)
//                {
//                    throw new ArgumentException("Wrong number");
                    
//                }
//            }
//            catch (ArgumentException e)
//            {

//                Console.WriteLine(e.Message);
//                return;
//            }


//            choosEnum = (BE.StatusEnum)number; //cast

//            try
//            {
//                bl.UpdateOrder(order);
//            }
//            catch (KeyNotFoundException e)
//            {

//                Console.WriteLine(e.Message);
//            }
//            catch (ArgumentException e)
//            {

//                Console.WriteLine(e.Message);
//            }

//            catch (BE.Tools.UnLogicException e)
//            {

//                Console.WriteLine(e.Message);
//            }



//            ///בהמשך, בשלב הבא נוסיף את השאילתות שמיממשנו כבר בשכבת ביסניק לוגיקה


//        }



//        public void addOrder(BE.HostingUnit HU) //מקבל יחידת אירוח וממש הוספה
//        {

//            BE.Order order = new Order() { HostingUnitKey = HU.HostingUnitKey };

//            Console.WriteLine("enter the key of the GeustRequest");

//            string input = Console.ReadLine();
//            int number = -1;


//            try
//            {
//                if (!Int32.TryParse(input, out number))
//                {
//                    number = -1;
//                    throw new ArgumentException("Wrong input");

//                }

//                BE.GuestRequest GR = bl.getGuestRequestByID(number);
//                if (GR==null)
//                {
//                    throw new ArgumentNullException(string.Format("לא קיימת דרישת לקוח מספר {0} ולכן לא ניתן ליצור הזמנה", number));
//                }


//                order.GuestRequestKey = GR.GuestRequestKey;


//                addOrder(order);
//            }
//            catch (ArgumentNullException e)
//            {

//                Console.WriteLine(e.Message);
//            }


//            catch (ArgumentException e)
//            {

//                Console.WriteLine(e.Message);
//            }





//        }


//        public void addOrder(BE.Order order)//שולח לביסניס לוגיק
//        {
//            bl = BL.Factory.GetInstance();
//            try
//            {
//                bl.addOrder(order);
//            }
//            catch (DuplicateWaitObjectException e)
//            {

//                Console.WriteLine(e.Message);
//            }
//            catch (ArgumentException e)
//            {

//                Console.WriteLine(e.Message);
//            }
//            catch (BE.Tools.UnLogicException e)
//            {

//                Console.WriteLine(e.Message);
//            }

//        }

//        //addOrder(HU); 

//        ///במילוי ידני של מספר לקוח. מספר יחידת אירוח לקבל
//        ///            //3.2  
//        ///לאפשר עדכון הזמנה וכמובן להוריד לביסניס לוגיק


//        #endregion


//        #region Web Manager Menu 
//        //   #endregion
//        //Web  Manager  Menu


//        public void WebManagerMenu() //4.0
//        {
//            int number = -1;
//            ManagMenuEnum choosMenuEnum;

//            do
//            {



//                Console.WriteLine("Choose one from the following options");
//                Console.WriteLine("Enter 1 to enter to Queries For Customer List");
//                Console.WriteLine("Enter 2 to enter to Queries For HostingUnit List");
//                Console.WriteLine("Enter 3 to to enter to Queries For Order List ");
//                Console.WriteLine("Enter 4 to to enter to Additional Queries");
//                Console.WriteLine("Enter 0 to return to the previous menu");

//                string input = Console.ReadLine();


//                if (!Int32.TryParse(input, out number))
//                {
//                    number = -1;
//                    Console.WriteLine("Wrong input");
//                    continue;
//                }
//                if (number > 4 || number < 0)
//                {
//                    Console.WriteLine("Wrong number");
//                    continue;
//                }

//                choosMenuEnum = (ManagMenuEnum)number;

//                ConsoleMenus conMenu = new ConsoleMenus();
//                switch (choosMenuEnum)
//                {
//                    case ManagMenuEnum.Queries_For_Customer_List:
//                        conMenu.PL_QueriesForCustomerList();//4.1
//                        break;
//                    case ManagMenuEnum.Queries_For_HostingUnit_List:
//                        conMenu.PL_QueriesForHostingUnitList();//4.2
//                        break;
//                    case ManagMenuEnum.Queries_For_Order_List:
//                        conMenu.PL_QueriesForOrderList();//4.3
//                        break;
//                    case ManagMenuEnum.Additional_Queries:
//                        conMenu.PL_AdditionalQueries();//4.4
//                        break;
//                    case ManagMenuEnum.Exit:
//                        break;
//                }


//            } while (number != 0);




//        }
//        #endregion

//        #region Queries
//        //   #endregion



//        public void PL_QueriesForCustomerList()//4.1
//        {
//            bl = BL.Factory.GetInstance();

//            Console.WriteLine("list of allBE.GuestRequest List");
//            foreach (var item in bl.GetGuestRequestList())
//            {
//                Console.WriteLine(item);
//            }


//            /*  תשאול אפשרי לדרישת לקוח
//                         IEnumerable<BE.GuestRequest> GR = bl.getAllGRwithCondition();
//                         foreach(var item in GR)
//                         {
//                             Console.WriteLine("{0}\n\n",item);
//                         }
//                            */


//            ///בהמשך בשלב הבא נוסיף את השאילתות שמיממשנו כבר בשכבת ביסניק לוגיקה

//        }

//        public void PL_QueriesForHostingUnitList()//4.2
//        {
//            bl = BL.Factory.GetInstance();

//            Console.WriteLine("list of all HostingUnit List");
//            foreach (var item in bl.GetHostingUnitList())
//            {
//                Console.WriteLine(item);
//            }


//            ///בהמשך בשלב הבא נוסיף את השאילתות שמיממשנו כבר בשכבת ביסניק לוגיקה

//        }

//        public void PL_QueriesForOrderList()//4.3
//        {
//            bl = BL.Factory.GetInstance();


//            Console.WriteLine("list of all Order List");
//            foreach (var item in bl.GetOrderList())
//            {
//                Console.WriteLine(item);
//            }


//            ///בהמשך בשלב הבא נוסיף את השאילתות שמיממשנו כבר בשכבת ביסניק לוגיקה

//        }

//        public void PL_AdditionalQueries()//4.4
//        {
//            Console.WriteLine("empty for this stage of project");

//        }


//        #endregion


//    }
//}
