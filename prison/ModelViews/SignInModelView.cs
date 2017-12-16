using prison;
using BLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace prison.ModelViews
{
    class SignInModelView: INotifyPropertyChanged
    {
           
          

        public event PropertyChangedEventHandler PropertyChanged;
        private void DoPropertyChanged(string Name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }
       

    }
}

