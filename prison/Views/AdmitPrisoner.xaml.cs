using prison.ModelViews;
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

namespace prison.Views
{
    /// <summary>
    /// Interaction logic for AdmitPrison.xaml
    /// </summary>
    public partial class AdmitPrison : UserControl
    {
        private int _errors = 0;
        AdmitionViewModel admit = new AdmitionViewModel();


        public AdmitPrison()
        {
            InitializeComponent();
        }

        private void PhotoCaptureButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AdmitionViewModel();
            Content = new AdmitionViewModel();
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
