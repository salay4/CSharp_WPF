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
    /// Interaction logic for personalAreaGui.xaml
    /// </summary>
    public partial class personalAreaGui : Window
    {
        BL.IBL bl;
        BE.HostingUnit HUSource; // מקבל את ההוסטינג יוניט מהדיאלוג
        //BE.HostingUnit HUShow;

        public personalAreaGui(int hostkey)
        {

            InitializeComponent();
            bl = BL.Factory.GetInstance();
            HUSource =bl.getHostingUnitByID(hostkey);

            //HUShow = HUSource;
            this.DataContext = HUSource;



            this.typeComboBox.ItemsSource = Enum.GetValues(typeof(BE.Enums.TypeEnum));
            this.areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.Enums.AreaEnum));

        }

       
        private void Button_Click_edit_hostingUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateHostingUnit(HUSource);

                MessageBox.Show("יחידת אירוח מספר" + HUSource.HostingUnitKey+ " !עודכנה בהצלחה ");
            }
            catch (System.IO.InvalidDataException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"שגיאה");
            }


        }

        private void Button_Click_Delete_HostingUint(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.delHostingUnit(HUSource.HostingUnitKey);
                MessageBox.Show("יחידת אירוח מספר" + HUSource.HostingUnitKey + " !נמחקה בהצלחה ");

                this.Close();
            }

            catch (KeyNotFoundException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (BE.Tools.UnLogicException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "שגיאה");
            }




        }

        //פותח חלון הוסף הזמנה לפי מספר יחידת האירוח


   

            //רשימת הזמנות עבור יחידה זו 
        private void Button_Click_Orders_For_HostingUnit(object sender, RoutedEventArgs e)
        {
            //Orders.OrdersForHostingUnitGUI OrdersForHostingUnitShow = new Orders.OrdersForHostingUnitGUI(HUSource);
            //OrdersForHostingUnitShow.ShowDialog();


            Orders.HandlingOrders OrdersForHostingUnitShow = new Orders.HandlingOrders(HUSource.HostingUnitKey);
            OrdersForHostingUnitShow.ShowDialog();

            

        }
    }
}
