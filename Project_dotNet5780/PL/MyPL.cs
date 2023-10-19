using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace PL
{
    //class MyPL
    //{
    //    public static void Main(string[] args)
    //    {
    //        int number = -1;
    //        mainMenuEnum choosMenuEnum;
    //        BL.IBL bl;
    //        bl= BL.Factory.GetInstance();
    //        //IEnumerable<BE.Order> sdfsdf = bl.GetOrderList();
    //        //foreach (var item in sdfsdf)
    //        //{
    //        //    Console.WriteLine(item);
    //        //}


    //        IEnumerable<BE.GuestRequest> ieGuest = bl.GetGuestRequestList();
    //        foreach (var item in ieGuest)
    //        {
    //            Console.WriteLine(item);
    //        }

    //        List<BE.GuestRequest>  listOfGR = new List<BE.GuestRequest>();

    //        foreach (var Item in ieGuest)
    //        {
    //            listOfGR.Add(Item);
    //        }


    //        Console.ReadKey();

    //        do
    //        {



    //            Console.WriteLine("Choose one from the following options");
    //            Console.WriteLine("Enter 1 to add new Guest Request");
    //            Console.WriteLine("Enter 2 to to enter to HostingUnit menu");
    //            Console.WriteLine("Enter 3 to to enter to web manger menu");
    //            Console.WriteLine("Enter 0 to exit from the program\n");

    //            string input = Console.ReadLine();


    //            if (!Int32.TryParse(input, out number))
    //            {
    //                number = -1;
    //                Console.WriteLine("Wrong input");
    //                continue;
    //            }
    //            if (number > 3 || number < 0)
    //            {
    //                Console.WriteLine("Wrong number");
    //                continue;
    //            }

    //            choosMenuEnum = (mainMenuEnum)number;

    //            ConsoleMenus conMenu = new ConsoleMenus();
    //            switch (choosMenuEnum)
    //            {
    //                case mainMenuEnum.Add_Guest_Request:
    //                    conMenu.clientMenu();//1.0
    //                    break;
    //                case mainMenuEnum.Hosting_Unit_Menu:
    //                    conMenu.HostingUnitMenu();//2.0
    //                    break;
    //                case mainMenuEnum.WebManager:
    //                    conMenu.WebManagerMenu();//4.0
    //                    break;
    //                case mainMenuEnum.Exit:
    //                    break;
    //            }


    //        } while (number != 0);


    //    }
    //}
}

