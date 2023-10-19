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
    /// Interaction logic for MainHostingUnitGUI.xaml
    /// </summary>
    public partial class MainHostingUnitGUI : Window
    {
        public MainHostingUnitGUI()
        {
            InitializeComponent();
        }

        private void Add_Hosting_Unit_Button(object sender, RoutedEventArgs e)
        {
            AddHostingUnitGUI GuestGUIShow = new AddHostingUnitGUI();
            GuestGUIShow.ShowDialog();//פתיחה באופן זה במחייב התייחסות לחלון זה ולא מאפשר להשתמש בחלון שקרא לו.

        }

        private void Personal_Area_Hosting_Unit_Button(object sender, RoutedEventArgs e)
        {
            HostingUnitKeyDialogGUI HUDialogGui = new HostingUnitKeyDialogGUI();
            HUDialogGui.ShowDialog();

        }
    }
}
