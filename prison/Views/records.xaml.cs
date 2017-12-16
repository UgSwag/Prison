using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using BLL;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
  
namespace prison.Views
{
    /// <summary>
    /// Interaction logic for records.xaml
    /// </summary>
    public partial class records : UserControl
    {


        public records()
        {
            InitializeComponent();
            AdministrationControl bo = new AdministrationControl();
            DataTable dt = new DataTable();
            dt = bo.getTable();
            Admitdatagridview.ItemsSource = dt.DefaultView;
        }

        private void Admitdatagridview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AdministrationControl fetch = new AdministrationControl();
            fetch.getTable();
        }
        
      
    }


}
