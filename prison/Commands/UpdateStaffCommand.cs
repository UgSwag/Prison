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
    class UpdateStaffCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try {
                staff staff = new staff();
                StaffControl bo = new StaffControl();
                DataTable dt = new DataTable();
                dt = bo.getTable();
                staff.datagridview.ItemsSource = dt.DefaultView;

                MessageBox.Show("Staff members successfully updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }

        }
    }
}
