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
    /// Interaction logic for hostingListsUC.xaml
    /// </summary>
    public partial class hostingListsUC : UserControl
    {


        #region כללי
        BL.IBL bl;
        BE.HostingUnit HostingShow;
        IEnumerable<BE.HostingUnit> IenumaHosting;


        public hostingListsUC()
        {
            InitializeComponent(); InitializeComponent();
            bl = BL.Factory.GetInstance();

            IenumaHosting = bl.GetHostingUnitList();

            list.ItemsSource = IenumaHosting;


            void mouseClick(object sender, RoutedEventArgs e)
            {
                var btn = sender as System.Windows.Controls.Button;
                list.SelectedItem = btn.DataContext;
                HostingShow = (BE.HostingUnit)list.SelectedItem;

            }
        }




        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)//https://social.msdn.microsoft.com/Forums/vstudio/en-US/194ee5ad-a3cf-48ae-8c0e-1aab84a1df97/how-to-get-wpf-listview-click-event?forum=wpf
        {
            HostingShow = (BE.HostingUnit)list.SelectedItem;

            if (HostingShow != null)
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
            BE.HostingUnit selectedObject = (BE.HostingUnit)list.SelectedItem;
            selectedObject.ToString();
        }

        #endregion
        #region סינון 

        private void showAllRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showAllRadio.IsChecked == true)
            {
                IenumaHosting = bl.GetHostingUnitList();
                list.ItemsSource = IenumaHosting;


            }
        }

        private void showPoolRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showPoolRadio.IsChecked == true)
            {
                IenumaHosting = bl.GetHostingUnitList((x => x.Pool == true));
                list.ItemsSource = IenumaHosting;


            }
        }

        private void showJacuzziRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showJacuzziRadio.IsChecked == true)
            {
                IenumaHosting = bl.GetHostingUnitList((x => x.Jacuzzi == true));
                list.ItemsSource = IenumaHosting;

            }
        }

        private void showGardenRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showGardenRadio.IsChecked == true)
            {
                IenumaHosting = bl.GetHostingUnitList((x => x.Garden == true));
                list.ItemsSource = IenumaHosting;



            }
        }
        private void showChildAtraRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (showChildAtraRadio.IsChecked == true)
            {
                IenumaHosting = bl.GetHostingUnitList((x => x.ChildrensAttractions == true));
                list.ItemsSource = IenumaHosting;

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
