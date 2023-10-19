using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for HUGuestsListUC.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for GuestsListUC.xaml
    /// </summary>
    public partial class HUGuestsListUC
    {
        BL.IBL bl;
        BE.GuestRequest GRShow;


        public HUGuestsListUC()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();


            IEnumerable<BE.GuestRequest> ieGuest = bl.GetGuestRequestList();


            list.ItemsSource = ieGuest;



            void mouseClick(object sender, RoutedEventArgs e)
            {
                var btn = sender as System.Windows.Controls.Button;
                list.SelectedItem = btn.DataContext;
                GRShow = (BE.GuestRequest)list.SelectedItem;
                Console.WriteLine(GRShow.ToString());
            }



        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)//https://social.msdn.microsoft.com/Forums/vstudio/en-US/194ee5ad-a3cf-48ae-8c0e-1aab84a1df97/how-to-get-wpf-listview-click-event?forum=wpf
        {
            GRShow = (BE.GuestRequest)list.SelectedItem;

            if (GRShow != null)
            {
                //int id = int.Parse(selectedrow.Row.ItemArray[0].ToString());
                //Console.WriteLine(id);
                //Console.WriteLine(bl.getGuestRequestByID(40000000 + id));
                ///////////////////////////////////////////Console.WriteLine(GRShow.ToString());  ?????
            }
        }



        private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.ListView list = (System.Windows.Controls.ListView)sender;
            BE.GuestRequest selectedObject = (BE.GuestRequest)list.SelectedItem;
            selectedObject.ToString();
        }



    }
}
