using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for OrderListUC.xaml
    /// </summary>
    public partial class OrderListUC : UserControl
    {

        BL.IBL bl;
        BE.Order orderShow;
        IEnumerable<BE.Order> IenumaOrder;

        public OrderListUC()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();

            IenumaOrder = bl.GetOrderList();
            list.ItemsSource = IenumaOrder;




            void mouseClick(object sender, RoutedEventArgs e)
            {
                var btn = sender as System.Windows.Controls.Button;
                list.SelectedItem = btn.DataContext;
                orderShow = (BE.Order)list.SelectedItem;

            }



        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)//https://social.msdn.microsoft.com/Forums/vstudio/en-US/194ee5ad-a3cf-48ae-8c0e-1aab84a1df97/how-to-get-wpf-listview-click-event?forum=wpf
        {
            orderShow = (BE.Order)list.SelectedItem;

            if (orderShow != null)
            {

            }
        }

    




        private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.ListView list = (System.Windows.Controls.ListView)sender;
            BE.Order selectedObject = (BE.Order)list.SelectedItem;
            selectedObject.ToString();
        }




        #region סינון 

        private void showAllRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showAllRadio.IsChecked == true)
            {

                IenumaOrder = bl.GetOrderList();
                list.ItemsSource = IenumaOrder;


            }
        }

        private void shoMailRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showMailRadio.IsChecked == true)
            {
                IenumaOrder = bl.GetOrderList((x => x.Status == BE.Enums.StatusEnum.נשלח_מייל));
                list.ItemsSource = IenumaOrder;


            }
        }
        private void showOpenRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showOpenRadio.IsChecked == true)
            {

                IenumaOrder = bl.GetOrderList((x => x.Status == BE.Enums.StatusEnum.טרם_טופל));
                list.ItemsSource = IenumaOrder;
            }
        }


        private void showCloseRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showCloseRadio.IsChecked == true)
            {
                IenumaOrder = bl.GetOrderList((x => x.Status == BE.Enums.StatusEnum.נסגר_בהיענות_הלקוח));
                list.ItemsSource = IenumaOrder;


            }
        }


        private void showLostRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showLostRadio.IsChecked == true)
            {
                IenumaOrder = bl.GetOrderList((x => x.Status == BE.Enums.StatusEnum.נסגר_מחוסר_הענות_הלקוח));
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

    }
}


     






