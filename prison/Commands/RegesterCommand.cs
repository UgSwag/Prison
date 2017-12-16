using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using BLL;
using System.Windows.Input;
using System.Windows;
using prison.ModelViews;


namespace prison.Commands
{
    class RegesterCommand : ICommand
    {
       
        RegesterControl control = new RegesterControl();
         

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                var regestermodel = parameter as RegesterViewModel;
                if (regestermodel != null)
                {

                    
                    if ((regestermodel.FirstName != null) && (regestermodel.SecondName != null) && (regestermodel.Department != null) && (regestermodel.country != null) && (regestermodel.Address != null) && (regestermodel.UserName  != null) )
                    {
                        control.RegesterUp(regestermodel.FirstName, regestermodel.SecondName, regestermodel.Department, regestermodel.country, regestermodel.Address, regestermodel.UserName);
                        MessageBox.Show("You're Successfully regestered");
                        throw new Exception();
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
