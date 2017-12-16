using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using prison.Views;
using System.Windows;

namespace prison.Commands
{
    class UpdateRecordCommander : ICommand
    {
       
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try {
                records record = new records();
                AdministrationControl fetch = new AdministrationControl();
                DataTable dt = new DataTable();
                dt = fetch.getTable();
                record.Admitdatagridview.ItemsSource = dt.DefaultView;

                MessageBox.Show("Prisoner's records updated successfully");
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong");
            }


        }
    }
}
