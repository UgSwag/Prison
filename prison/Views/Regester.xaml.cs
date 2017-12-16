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
using prison;
using prison.ModelViews;

namespace prison.Views
{
    /// <summary>
    /// Interaction logic for Regester.xaml
    /// </summary>
    public partial class Regester : UserControl
    {
        private int _errors = 0;
        RegesterViewModel Reg = new RegesterViewModel();
        public Regester()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errors++;
            else
                _errors--;
        } 

    }
}
