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
    /// Interaction logic for GuestGUI.xaml
    /// </summary>
    public partial class GuestGUI : Window
    {
        BL.IBL bl;
        BE.GuestRequest GRShow;
        //BE.GuestRequest GRShow =new BE.GuestRequest();//לבדוק 
        List<string> errorMessages = new List<string>(); // לממש 


        private Calendar MyCalendar;


        public GuestGUI()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();
            GRShow = new BE.GuestRequest();
            this.DataContext = GRShow;
            //this.GuestRequestGrid.DataContext =GRShow; //הקשר הדטה לפי GuestRequest

            this.typeComboBox.ItemsSource = Enum.GetValues(typeof(BE.Enums.TypeEnum));
            this.areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.Enums.AreaEnum));
            this.poolComboBox.ItemsSource = Enum.GetValues(typeof(BE.Enums.AttractionsEnum));
            this.jacuzziComboBox.ItemsSource = Enum.GetValues(typeof(BE.Enums.AttractionsEnum));
            this.gardenComboBox.ItemsSource = Enum.GetValues(typeof(BE.Enums.AttractionsEnum));
            this.childrensAttractionsComboBox.ItemsSource = Enum.GetValues(typeof(BE.Enums.AttractionsEnum));



            #region calander
            //עבור לוח שנה
            MyCalendar = CreateCalendar();
            vbCalendar.Child = null; //מחיקה מהתצוגה של החלון הקודם
            vbCalendar.Child = MyCalendar;// הצגה של החלון הנוכחי שיצרנו
            //SetBlackOutDates();

        }


        /// <summary>
        /// הסבר הפעולה CreateCalendar :
        /// צור לוח, הצגה 'חודשית', ניתן לבחור רצף אחד, סמן את היום הנוכחי.
        /// </summary>
        /// <returns></returns>
        private Calendar CreateCalendar()
        {
            Calendar MonthlyCalendar = new Calendar();// צור לוח
            MonthlyCalendar.Name = "MonthlyCalendar";//הצגחה חודשית
            MonthlyCalendar.DisplayMode = CalendarMode.Month;//ניתן לבחור רצף אחד
            MonthlyCalendar.SelectionMode = CalendarSelectionMode.SingleRange;
            MonthlyCalendar.IsTodayHighlighted = true;
            return MonthlyCalendar;
        }


        //private void SetBlackOutDates()
        //{

            
        //}







        private void Button_Click_Save_GuestRequest(object sender, RoutedEventArgs e)
        {

            List<DateTime> myList = MyCalendar.SelectedDates.ToList();
            this.GRShow.EntryDate = myList.First();
            this.GRShow.ReleaseDate = myList.Last();

            MyCalendar = CreateCalendar();
            vbCalendar.Child = null;
            vbCalendar.Child = MyCalendar;

            //SetBlackOutDates();
            #endregion



            try
            {
                //GRShow.PrivateName = this.firstNameTextBox.Text;  //קישור על ידי binding 


                bl.addGuestRequest(GRShow); // add copy of gr to the BL layer
               // GRShow = new BE.GuestRequest();
                //this.GuestRequestGrid.DataContext = GRShow; //הקשר הדטה לפי GuestRequest
                
                // אם אין זריקה 
                MessageBox.Show("דרישת אירוח נוספה בהצלחה");
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

    }
}
