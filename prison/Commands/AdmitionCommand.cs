using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;
using BLL;
using prison.Views;
using prison.ModelViews;

namespace prison.Commands
{
    public class AdmitionCommand : ICommand
    {
        AdministrationControl control = new AdministrationControl();
        
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
          

            try
            {
                var Admitionmodel = parameter as AdmitionViewModel;
                if (Admitionmodel != null)
                {
                    if ((Admitionmodel.FirstName != null) && (Admitionmodel.SurName != null) && (Admitionmodel.CellNumber!= 0) && (Admitionmodel.FileNumber != 0) && (Admitionmodel.Period  != 0)  && (Admitionmodel.Crime != null) && (Admitionmodel.Age != 0) && (Admitionmodel.Sex  != null) && (Admitionmodel.Weight != 0) && (Admitionmodel.Height!= 0))
                    {
                        
                        control.InsertPrisoner(Admitionmodel.SurName, Admitionmodel.FirstName, Admitionmodel.OtherNames, Admitionmodel.CellNumber , Admitionmodel.FileNumber , Admitionmodel.Period ,  Admitionmodel.Crime, Admitionmodel.Age , Admitionmodel.Sex , Admitionmodel.Weight ,Admitionmodel.Height );
                        MessageBox.Show("Prisoner successfully admited");
                    }
                    else
                    {
                        MessageBox.Show("Check your entries and try again");
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
