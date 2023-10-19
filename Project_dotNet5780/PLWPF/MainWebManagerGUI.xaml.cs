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
    /// Interaction logic for MainWebManagerGUI.xaml
    /// </summary>
    public partial class MainWebManagerGUI : Window
    {
        BL.IBL bl;

        public MainWebManagerGUI()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();
            setActiveUserControl(GuestUC);

        }
        public void setActiveUserControl(UserControl control)
        {
            //הסתר ממשקי עזר
            GuestUC.Visibility = Visibility.Collapsed;
            orderUC.Visibility = Visibility.Collapsed;
            HostingUC.Visibility = Visibility.Collapsed;
            HostsUC.Visibility = Visibility.Collapsed;

            //גילוי ממשק שנשלח.
            control.Visibility = Visibility.Visible;
        }

        private void GuestsList_Button_Click(object sender, RoutedEventArgs e)
        {

            setActiveUserControl(GuestUC);
        }

        private void orderLists_Button_Click(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(orderUC);
        }

        private void hostingUnitLists_Button_Click(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(HostingUC);
        }

        private void hostLists_Button_Click(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(HostsUC);
        }
    }
}


#region שאריות קוד למחיקה
//private void btnPreviousTab_Click(object sender, RoutedEventArgs e)
//{
//    int newIndex = tcSample.SelectedIndex - 1;
//    if (newIndex < 0)
//        newIndex = tcSample.Items.Count - 1;
//    tcSample.SelectedIndex = newIndex;
//}
//Queue<KeyValuePair<string, DateTime>> notificationsQueue = new Queue<KeyValuePair<string, DateTime>>();

//private void btnNextTab_Click(object sender, RoutedEventArgs e)
//{
//    int newIndex = tcSample.SelectedIndex + 1;
//    if (newIndex >= tcSample.Items.Count)
//        newIndex = 0;
//    tcSample.SelectedIndex = newIndex;
//}

//private void btnSelectedTab_Click(object sender, RoutedEventArgs e)
//{
//    MessageBox.Show("Selected tab: " + (tcSample.SelectedItem as TabItem).Header);
//}



//private void GuestsList_Click(object sender, RoutedEventArgs e)
//{
//    UserControl.GuestsListUC GLUCObj = new UserControl.GuestsListUC();
//    WMstackPannel.Children.Add(GLUCObj);
//}


//    private void RefreshNotification()
//    {
//        NotificationRow0StackPanel.Visibility = NotificationRow1StackPanel.Visibility =
//            NotificationRow2StackPanel.Visibility = NotificationRow3StackPanel.Visibility = Visibility.Collapsed;
//        if (notificationsQueue.Count >= 1)
//        {
//            NotificationsRow3Label.Content = notificationsQueue.ElementAt(0).Key;
//            NotificationsRow3DatePicker.SelectedDate = notificationsQueue.ElementAt(0).Value;
//            NotificationRow3StackPanel.Visibility = Visibility.Visible;
//        }
//        if (notificationsQueue.Count >= 2)
//        {
//            NotificationsRow2Label.Content = notificationsQueue.ElementAt(1).Key;
//            NotificationsRow2DatePicker.SelectedDate = notificationsQueue.ElementAt(1).Value;
//            NotificationRow2StackPanel.Visibility = Visibility.Visible;
//        }
//        if (notificationsQueue.Count >= 3)
//        {
//            NotificationsRow1Label.Content = notificationsQueue.ElementAt(2).Key;
//            NotificationsRow1DatePicker.SelectedDate = notificationsQueue.ElementAt(2).Value;
//            NotificationRow1StackPanel.Visibility = Visibility.Visible;
//        }
//        if (notificationsQueue.Count >= 4)
//        {
//            NotificationsRow0Label.Content = notificationsQueue.ElementAt(3).Key;
//            NotificationsRow0DatePicker.SelectedDate = notificationsQueue.ElementAt(3).Value;
//            NotificationRow0StackPanel.Visibility = Visibility.Visible;
//        }
//    }

//    private void RemoveNotification(KeyValuePair<string, DateTime> pair)
//    {
//        notificationsQueue = new Queue<KeyValuePair<string, DateTime>>(notificationsQueue.Where(p => !p.Equals(pair)));
//        RefreshNotification();
//    }

//    private void NotificationStackPanel_MouseUp(object sender, MouseButtonEventArgs e)
//    {
//        //todo 
//        //try
//        //{
//        //    dynamic parent = e.Source;
//        //    while (parent.GetType() != typeof(Viewbox) && parent.GetType() != typeof(StackPanel))
//        //        parent = parent.Parent;
//        //    if (parent.GetType() == typeof(Viewbox))    //if the 'X' icon is pressed, remove the notification.
//        //    {
//        //        StackPanel stackPanel = parent.Parent as StackPanel;
//        //        Label label = (from dynamic item in stackPanel.Children where item is Label select item as Label).First();
//        //        notificationsQueue = new Queue<string>(notificationsQueue.Where(s => s != label.Content.ToString()));
//        //        RefreshNotification();
//        //    }
//        //}
//        //catch (Exception) { }

//        try
//        {
//            dynamic parent = e.Source;
//            while (parent.GetType() != typeof(Viewbox) && parent.GetType() != typeof(Canvas) && parent.GetType() != typeof(StackPanel))
//                parent = parent.Parent;
//            if (parent.GetType() == typeof(Viewbox) || parent.GetType() == typeof(Canvas))
//            {
//                while (parent.GetType() != typeof(StackPanel))
//                    parent = parent.Parent;
//                StackPanel stackPanel = parent as StackPanel;
//                Label label = (from dynamic item in stackPanel.Children where item is Label select item as Label).First();
//                RefreshNotification();
//            }
//        }
//        catch (Exception) { }
//    }

//    /// <summary>
//    /// Notification StackPanel MouseEnter
//    /// </summary>
//    /// <param name="sender"></param>
//    /// <param name="e"></param>
//    private void NotificationStackPanel_MouseEnter(object sender, MouseEventArgs e)
//    {
//        try
//        {
//            (e.Source as StackPanel).Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF6596F5" /*"#FF5BA5CE"*/));
//            (e.Source as StackPanel).Opacity = 1;
//            (from dynamic item in (e.Source as StackPanel).Children where item is Viewbox select item as Viewbox).First().Opacity = 0.75;
//        }
//        catch (Exception) { }
//    }

//    /// <summary>
//    /// Notification StackPanel MouseLeave
//    /// </summary>
//    /// <param name="sender"></param>
//    /// <param name="e"></param>
//    private void NotificationStackPanel_MouseLeave(object sender, MouseEventArgs e)
//    {
//        try
//        {
//            (e.Source as StackPanel).Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFCCE4F1"));
//            (e.Source as StackPanel).Opacity = 0.8;
//            (from dynamic item in (e.Source as StackPanel).Children where item is Viewbox select item as Viewbox).First().Opacity = 0.0;
//        }
//        catch (Exception) { }
//    }

//    private void Viewbox_MouseUp(object sender, MouseButtonEventArgs e)
//    {
//        try
//        {
//            dynamic parent = e.Source;
//            while (parent.GetType() != typeof(StackPanel))
//                parent = parent.Parent;
//            string messege = (string)(from dynamic item in (parent as StackPanel).Children where item is Label select item as Label).First().Content;
//            DateTime time = (DateTime)(from dynamic item in (parent as StackPanel).Children where item is DatePicker select item as DatePicker).First().SelectedDate;
//            RemoveNotification(new KeyValuePair<string, DateTime>(messege, time));
//            RefreshNotification();
//        }
//        catch (Exception) { }
//    }

//}
#endregion