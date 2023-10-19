using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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
    /// Interaction logic for OrdersHostingUnitUC.xaml
    /// </summary>
    public partial class OrdersHostingUnitUC : UserControl
    {
        BL.IBL bl;
        BE.Order order;
        BE.Order orderTemp;
        IEnumerable<BE.Order> IenumaOrder;
        BE.HostingUnit HUshow;
        BE.GuestRequest guest;











        public OrdersHostingUnitUC()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();



            #region לוח שנה

            //MyCalendar = CreateCalendar();
            //vbCalendar.Child = null; //מחיקה מהתצוגה של החלון הקודם
            //vbCalendar.Child = MyCalendar;// הצגה של החלון הנוכחי שיצרנו
            //SetBlackOutDates();



        }


        //private void SetBlackOutDates()
        //{
        //    //string str;

        //    //for (int i = 0; i < 12; i++)
        //    //{
        //    //    for (int j = 0; j < 31; j++)
        //    //    {
        //    //        if(HUshow.Diary[j,i]) //אם התאריך מסומן
        //    //        {

        //    //        }
        //    //    }

        //    //}


        //    //DateTime beginDate = DateTime.Now.AddMonths(-1);//תחילת לוח
        //    //DateTime endDate = DateTime.Now.AddMonths(11); //סוף לוח

        //    //bool flag = false;

        //    //for (DateTime tempDate = beginDate; tempDate < endDate; tempDate = tempDate.AddDays(1))
        //    //{
        //    //    if (this[tempDate])
        //    //    {

        //    //    }
        //    //}






        //    //for (DateTime tempDate = GR.EntryDate; tempDate < GR.RegistrationDate; tempDate = tempDate.AddDays(1))
        //    //{
        //    //    this[tempDate, HU] = true;//put the nights on matrix
        //    //    Chargeamount += BE.Configuration.Commission; //חישוב עמלה על כל יום שנתפס
        //    //}




        ////    foreach (DateTime date in CurrentHostingUnit.AllOrders)
        ////    {
        ////        MyCalendar.BlackoutDates.Add(new CalendarDateRange(date));
        ////    }
        ////

        //}
        //private Calendar MyCalendar;
        //private Calendar CreateCalendar()
        //{
        //    Calendar MonthlyCalendar = new Calendar();
        //    MonthlyCalendar.Name = "MonthlyCalendar";
        //    MonthlyCalendar.DisplayMode = CalendarMode.Month;
        //    MonthlyCalendar.SelectionMode = CalendarSelectionMode.SingleRange;
        //    MonthlyCalendar.IsTodayHighlighted = true;
        //    return MonthlyCalendar;
        //}

        #endregion

        public void mouseClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as System.Windows.Controls.Button;
            list.SelectedItem = btn.DataContext;
            order = (BE.Order)list.SelectedItem;

        }



        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)//https://social.msdn.microsoft.com/Forums/vstudio/en-US/194ee5ad-a3cf-48ae-8c0e-1aab84a1df97/how-to-get-wpf-listview-click-event?forum=wpf
        {
            try
            {



                HUshow = bl.getHostingUnitByID(number);
                list.ItemsSource = IenumaOrder;


                //order = (BE.Order)list.SelectedItem;

                if (order != null)
                {
                    //int id = int.Parse(selectedrow.Row.ItemArray[0].ToString());
                    //Console.WriteLine(id);
                    //Console.WriteLine(bl.getGuestRequestByID(40000000 + id));
                    //Console.WriteLine(order.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה");
            }


        }
        public int number { get; set; }

        #region סגירת עיסקה
        private void Button_Click_confirm_order(object sender, RoutedEventArgs e)
        {

            order = (BE.Order)list.SelectedItem;




            //orderTemp = bl.getOrderByID(order.OrderKey) ;


            if (order != null)
            {
                guest = bl.getGuestRequestByID(order.GuestRequestKey);

                order.Status = BE.Enums.StatusEnum.נסגר_בהיענות_הלקוח;




                try
                {
                    bl.UpdateOrder(order);
                    System.Windows.MessageBox.Show("ההזמנה נסגרה בהצלחה");
                    IenumaOrder = bl.GetOrderList(x => x.HostingUnitKey == number); //הצג רק הזמנות רלוונטיות ליחידת אירוח זו. 
                    list.ItemsSource = IenumaOrder;



                }

                catch (ArgumentException ex)
                {
                    order = bl.getOrderByID(order.OrderKey);
                    MessageBox.Show(ex.Message, "שגיאה");

                }
                catch (KeyNotFoundException ex)
                {
                    order = bl.getOrderByID(order.OrderKey);
                    MessageBox.Show(ex.Message, "שגיאה");


                }
                catch (BE.Tools.UnLogicException ex)
                {
                    order = bl.getOrderByID(order.OrderKey);
                    MessageBox.Show(ex.Message, "שגיאה");


                }
                catch (Exception ex)
                {
                    order = orderTemp;
                    MessageBox.Show(ex.Message, "שגיאה");


                }


            }
            else
            {
                MessageBox.Show(" יש לבחור תחילה הזמנה מתוך הרשימה", "שגיאה");

            }


        }
        #endregion

        #region שליחת מייל


        // מה נשאר לפונ החדשה
        //  MessageBox.Show("המייל נשלח בהצלחה!", "המייל נשלח");


        //IenumaOrder = bl.GetOrderList(x => x.HostingUnitKey == number); 

        private void Button_Click_send_email(object sender, RoutedEventArgs e)
        {

            order = (BE.Order)list.SelectedItem;


            if (order != null)
            {

                guest = bl.getGuestRequestByID(order.GuestRequestKey);

                orderTemp = new BE.Order();
                orderTemp = order;//צריך לעשות new
                order.Status = BE.Enums.StatusEnum.נשלח_מייל;

                try
                {
                    bl.UpdateOrder(order);
                    bl.sendEmail(order);
                    //  System.Windows.MessageBox.Show(" נסגרה בהצלחה");

                   /* string str = "שלום  " + guest.PrivateName + " " + guest.FamilyName +
                         "\n" + " אנחנו נרגשים  לבשר לך שנמצאה התאמה באתרינו עבור דרישת האירוח שלך!" +
                         "פרטי ההזמנה : "
                        +
                        (order.ToString() + "\n \n\n "
                         + " " + "  " + HUshow.HostingUnitName + " מאיזור ה " + HUshow.Area +
                         " הזמנה עבור יחידת אירות מסוג " + HUshow.Type + "תאריך כניסה :" + guest.EntryDate + "\n  תאריך יציאה: " + guest.ReleaseDate + "\n"
                         + "\n" + " לפרטים ולסגירת עסקה אנא צרו קשר עם המארח במספר טלפון: " + HUshow.Owner.PhoneNumber
                         + "\n  :או במייל בכתובת " + HUshow.Owner.MailAddress);


                    var client = new SmtpClient("smtp.gmail.com", 587)
                    {
                        Credentials = new NetworkCredential("zimmerisrael123@gmail.com", "Aa12345678910"),
                        EnableSsl = true
                    };

                    Thread T1 = new Thread(delegate ()
                    {
                        using (var message = new MailMessage("zimmerisrael123@gmail.com", bl.getGuestRequestByID(order.GuestRequestKey).MailAddress)
                        {
                            Subject = "נמצאה התאמת בקשת אירוח!",
                            Body = str
                        })
                        {
                            {
                                client.Send(message);
                            }
                        }
                    });



                    T1.Start();




                    //Thread thr = new Thread(sendAnEamil);





                    //thr.Start();*/



                    MessageBox.Show("המייל נשלח בהצלחה!", "המייל נשלח");


                    IenumaOrder = bl.GetOrderList(x => x.HostingUnitKey == number); //הצג רק הזמנות רלוונטיות ליחידת אירוח זו. 




                }
                catch (ArgumentNullException ex)
                {
                    order = orderTemp;
                    MessageBox.Show(ex.Message, "ההודעה במייל ריקה");

                }

                catch (ArgumentException ex)
                {
                    order = orderTemp;
                    MessageBox.Show(ex.Message);

                }
                catch (KeyNotFoundException ex)
                {
                    order = orderTemp;
                    MessageBox.Show(ex.Message);


                }
                catch (BE.Tools.UnLogicException ex)
                {
                    order = orderTemp;
                    MessageBox.Show(ex.Message);


                }
                catch (SmtpFailedRecipientsException ex)
                {
                    order = orderTemp;
                    MessageBox.Show(ex.Message, "ההודעה לא יכלה להישלח לחלק מהנמענים");


                }
                catch (InvalidOperationException ex)
                {
                    order = orderTemp;
                    MessageBox.Show(ex.Message, "בעיה בנתונים שהוכנסו בהודעה (נתונים חסרים או שגויים)");

                }

                catch (SmtpException ex)
                {
                    order = orderTemp;
                    MessageBox.Show(ex.Message, "שגיאה בעת התחברות לשרת");

                }
                catch (Exception ex)
                {
                    order = orderTemp;
                    MessageBox.Show(ex.Message, "שגיאה בעת התחברות לשרת");

                }
            }
            else
            {
                MessageBox.Show(" יש לבחור תחילה הזמנה מתוך הרשימה", "שגיאה");

            }
        }
        //public void sendAnEamil()
        //{

        //    var client = new SmtpClient("smtp.gmail.com", 587)
        //    {
        //        Credentials = new NetworkCredential("zimmerisrael123@gmail.com", "Aa12345678910"),
        //        EnableSsl = true
        //    };

        //    client.Send(bl.getGuestRequestByID(order.GuestRequestKey).MailAddress,
        //        bl.getGuestRequestByID(order.GuestRequestKey).MailAddress, order.ToString(), "love you :) \n  "
        //        + " " + HUshow.Type + " " + HUshow.HostingUnitName + " from the " + HUshow.Area);
        //    //Console.WriteLine("Sent");


        //    //Console.ReadLine();
        //}

        #endregion



        #region סינון 

        private void showAllRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showAllRadio.IsChecked == true)
            {

                IenumaOrder = bl.GetOrderList(x => x.HostingUnitKey == number);
                list.ItemsSource = IenumaOrder;


            }
        }

        private void shoMailRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showMailRadio.IsChecked == true)
            {
                IenumaOrder = bl.GetOrderList(x => (x.HostingUnitKey == number) && (x.Status == BE.Enums.StatusEnum.נשלח_מייל));
                list.ItemsSource = IenumaOrder;



            }
        }
        private void showOpenRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showOpenRadio.IsChecked == true)
            {
                IenumaOrder = bl.GetOrderList(x => (x.HostingUnitKey == number) && (x.Status == BE.Enums.StatusEnum.טרם_טופל));
                list.ItemsSource = IenumaOrder;
            }
        }


        private void showCloseRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showCloseRadio.IsChecked == true)
            {
                IenumaOrder = bl.GetOrderList(x => (x.HostingUnitKey == number) && (x.Status == BE.Enums.StatusEnum.נסגר_בהיענות_הלקוח));
                list.ItemsSource = IenumaOrder;

            }
        }


        private void showLostRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showLostRadio.IsChecked == true)
            {

                IenumaOrder = bl.GetOrderList(x => (x.HostingUnitKey == number) && (x.Status == BE.Enums.StatusEnum.נסגר_מחוסר_הענות_הלקוח));
                list.ItemsSource = IenumaOrder;

            }
        }

        #endregion


        #region מיון 

        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        void GridViewColumnHeaderClickedHandler(object sender,
                                            RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
                    var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

                    Sort(sortBy, direction);

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    // Remove arrow from previously sorted header
                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }

                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }
        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(list.ItemsSource); //list is namespace of xaml

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }









        #endregion






        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine();
        }


    }

}






