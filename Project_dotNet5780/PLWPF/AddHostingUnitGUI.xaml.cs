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
    /// Interaction logic for AddHostingUnitGUI.xaml
    /// </summary>
    public partial class AddHostingUnitGUI : Window
    {


        BL.IBL bl;
        BE.HostingUnit HUshow ;
        //BE.GuestRequest GRShow =new BE.GuestRequest();//לבדוק 
        List<string> errorMessages = new List<string>(); // לממש 
        IEnumerable<BE.BankBranch> bankAccunts;


        public AddHostingUnitGUI()
        {
            InitializeComponent();

            bl = BL.Factory.GetInstance();
            HUshow = new BE.HostingUnit() { Owner=new BE.Host() { BankBranchDetails=new BE.BankBranch() } };
            this.DataContext = HUshow;
            //this.GuestRequestGrid.DataContext =GRShow; //הקשר הדטה לפי GuestRequest


            this.typeComboBox.ItemsSource = Enum.GetValues(typeof(BE.Enums.TypeEnum));
            this.areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.Enums.AreaEnum));


            bankAccunts = new List<BE.BankBranch>();
            try
            {
                bankAccunts = bl.getAllBankBranches();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


            List<string> bankNames = (from bank in bankAccunts select bank.BankName).Distinct().ToList();
            BankNameComboBox.ItemsSource = bankNames;

        }




        private void Button_Click_Save_HostingUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                //GRShow.PrivateName = this.firstNameTextBox.Text;  //קישור על ידי binding 


                int id=bl.addHostingUnit(HUshow); // add copy of gr to the BL layer
                                           // GRShow = new BE.GuestRequest();
                                           //this.GuestRequestGrid.DataContext = GRShow; //הקשר הדטה לפי GuestRequest

                // אם אין זריקה 
                MessageBox.Show("יחידת אירוח נוספה בהצלחה .\n נא לשמור את מספר יחידת האירוח : "+ id);

                this.Close();
            }

            catch (DuplicateWaitObjectException ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (System.IO.InvalidDataException ex)
            {
                MessageBox.Show(ex.Message);

            }


        }


        private void BankNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string bamkname = BankNameComboBox.SelectedValue.ToString();
            // BankNumberComboBox.Text = ((from bank in bankAccunts where bank.BankName == bamkname select bank.BankNumber).FirstOrDefault()).ToString();
            BankNumberComboBox.Text = ((from bank in bankAccunts where bank.BankName == BankNameComboBox.SelectedValue.ToString() select bank.BankNumber).FirstOrDefault()).ToString();
            List<int> BranchNumbers = (from bank in bankAccunts where bank.BankName == bamkname select bank.BranchNumber).Distinct().ToList();
            BranchNumberComboBox.IsReadOnly = false;
            BranchNumberComboBox.ItemsSource = BranchNumbers;
        }

        private void BranchNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BranchNumberComboBox.SelectedIndex != -1)
            {
                // int BranchNumber = BranchNumbers[BranchNumberComboBox.SelectedIndex];

                string bamkname = BankNameComboBox.SelectedValue.ToString();
                int BranchNumber = Convert.ToInt32(BranchNumberComboBox.SelectedValue.ToString());
                BranchCityTextBox.Text = ((from bank in bankAccunts where bank.BankName == bamkname && bank.BranchNumber == BranchNumber select bank.BranchCity).FirstOrDefault());
                BranchAddressTextBox.Text = ((from bank in bankAccunts where bank.BankName == bamkname && bank.BranchNumber == BranchNumber select bank.BranchAddress).FirstOrDefault());

            }

        }

        private void BankNumberComboBox_TextChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
