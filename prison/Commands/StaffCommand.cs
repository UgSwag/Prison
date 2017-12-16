using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using prison.ModelViews;
using System.Windows;
using BLL;

namespace prison.Commands
{
    class StaffCommand : ICommand
    {
        StaffControl MemberControl = new StaffControl();
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                var StaffMembers = parameter as StaffViewModel;
                if (StaffMembers != null)
                {
                    if ((StaffMembers.FirstName != null) && (StaffMembers.SecondName != null)  && (StaffMembers.Id != 0) && (StaffMembers.Rank != null) && (StaffMembers.PhoneNumber != null) && (StaffMembers.Address != null))
                    {
                        MemberControl.RegesterStaffMember(StaffMembers.FirstName, StaffMembers.SecondName, StaffMembers.OtherName, StaffMembers.Id, StaffMembers.Rank, StaffMembers.PhoneNumber, StaffMembers.Address);
                        MessageBox.Show("Staff member Successfully regestered");
                    }
                    else
                    {
                        MessageBox.Show("check your entries please!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
          }
        }
}
