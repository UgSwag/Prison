using System.Windows;
using System.Windows.Controls;
using BLL;
using System.Data;
using System.Windows.Input;
using prison.ModelViews;

namespace prison.Views
{
    /// <summary>
    /// Interaction logic for staff.xaml
    /// </summary>
    public partial class staff : UserControl
    {
        private int _errors = 0;
        StaffViewModel stafff= new StaffViewModel();
        public staff()
        {
            InitializeComponent();

            //this enables the tables to be shown when the control reloads
            StaffControl bo = new StaffControl();
            DataTable dt = new DataTable();
            dt = bo.getTable();
            datagridview.ItemsSource = dt.DefaultView;

        }

        //private void Add_Click(object sender, RoutedEventArgs e)
        //{
        //    StaffControl bo = new StaffControl();
        //    DataTable dt = new DataTable();
        //    dt = bo.getTable();
        //    datagridview.ItemsSource = dt.DefaultView;
          
        //}

        private void datagridview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StaffControl fetch = new StaffControl();
            fetch.getTable();

        }

        //private void Confirm_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = _errors == 0;
        //    e.Handled = true;
        //}

        //private void Confirm_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    stafff = new StaffViewModel();
        //    grid_staff.DataContext = stafff;
        //    e.Handled = true;
        //}

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errors++;
            else
                _errors--;


        }
    }
}

