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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF.Orders
{
    /// <summary>
    /// Interaction logic for calanderForHU.xaml
    /// </summary>
    public partial class calanderForHU : UserControl
    {
        BL.IBL bl;
        BE.HostingUnit HU;
        public calanderForHU()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();

        }




        public void SetBlackOutDates(BE.HostingUnit hostingUnit)
        {

            HU = bl.getHostingUnitByID(number);

            DateTime LastDate = DateTime.Now.Date.AddMonths(11);
            DateTime firstDate = DateTime.Now.Date.AddMonths(-1);

            for (DateTime tempDate = firstDate; tempDate < LastDate; tempDate = tempDate.AddDays(1))
            {
                if (this[tempDate, hostingUnit])            // check if the days exists
                { vbCalendar.BlackoutDates.Add(new CalendarDateRange(tempDate)); }

            }


        }


        public bool this[DateTime generalDate, BE.HostingUnit HU] // define indexer 
        {
            private set => HU.Diary[generalDate.Day - 1, generalDate.Month - 1] = value;
            get => HU.Diary[generalDate.Day - 1, generalDate.Month - 1];
        }

        public int number { get; set; } //number of Hosting Unit

        private void Button_refresh(object sender, RoutedEventArgs e)
        {
            HU = bl.getHostingUnitByID(number);
            SetBlackOutDates(HU);
        }
    }
}
