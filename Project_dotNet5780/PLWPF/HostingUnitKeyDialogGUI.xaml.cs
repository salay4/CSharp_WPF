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
    /// Interaction logic for HostingUnitKeyDialogGUI.xaml
    /// </summary>
    public partial class HostingUnitKeyDialogGUI : Window
    {
        BL.IBL bl;
        BE.HostingUnit HUshow;
        public HostingUnitKeyDialogGUI()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();
            
        }

        //public string ResponseText //קלט של סרטינג לכאן
        //{
        //    get { return ResponseTextBox.Text; }
        //    set { ResponseTextBox.Text = value; }
        //}

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {

            int number = -1;
            string input = this.ResponseTextBox.Text;
            try
            {
                if (!(int.TryParse(input, out number)))
                {
                    throw new System.IO.InvalidDataException("יש להזין מספר בלבד");
                }

                HUshow=bl.getHostingUnitByID(number);
                if (HUshow==null)
                {
                    throw new KeyNotFoundException(":לא קיימת יחידת אירוח עם מספר "+number);
                }

                
                personalAreaGui HUDialogGui = new personalAreaGui(number);
                this.Close();
                HUDialogGui.ShowDialog();
                

                // אם קיימת יחידה כזו
               // MessageBox.Show("קיימת יחידה כזו"); 
            }
            catch (System.IO.InvalidDataException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {

                MessageBox.Show(ex.Message);
            }

        }



        private void EnterKeyCommand(object sender, RoutedEventArgs e)
        {
            OKButton_Click(sender, e);
        }



    }
}
