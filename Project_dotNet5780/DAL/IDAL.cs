using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BE; 


namespace DAL
{
     public interface IDAL
    {
        //GuestRequest
        void addGuestRequest(BE.GuestRequest guest);

        void updateGuestRequest(BE.GuestRequest guest);

        //HostingUnit
        int addHostingUnit(BE.HostingUnit hostUnit);
        void delHostingUnit(int hostUnitID);
        void updateHostingUnit(BE.HostingUnit hostUnit);

        //Order
        void addOrder(BE.Order order);
        void UpdateOrder(BE.Order order);


        //lists

        IEnumerable<BE.GuestRequest> GetGuestRequestList(Func<BE.GuestRequest, bool> predicat = null);

        IEnumerable<BE.HostingUnit> GetHostingUnitList(Func<BE.HostingUnit, bool> predicat = null);
        IEnumerable<BE.Order> GetOrderList(Func<BE.Order, bool> predicat = null);
        IEnumerable<BE.BankBranch> GetBankBranchList(/*Func<BE.BankBranch, bool> predicat = null*/);


        //תוספות


        BE.HostingUnit getHostingUnitByID(int ID);


        BE.GuestRequest getGuestRequestByID(int ID);


        BE.Order GetOrderById(int id);

        IEnumerable<BankBranch> getAllBankBranches();




    }
}
