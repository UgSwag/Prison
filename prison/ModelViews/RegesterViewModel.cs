using System;
using System.Collections.Generic;
using BLL;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using prison.Commands;
namespace prison.ModelViews
{
   public  class RegesterViewModel: IDataErrorInfo, INotifyPropertyChanged
    {

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                //REVIEW: Use String.Equal, not == for string comparing
                if (columnName == "FirstName")
                {
                    if (string.IsNullOrEmpty(FirstName) || FirstName.Length >= 14)
                        result = "Please enter a FirstName";
                }
                if (columnName == "SecondName")
                {
                    if (string.IsNullOrEmpty(SecondName) || SecondName .Length >= 14)
                        result = "Please enter a SecondName";
                }
                if (columnName == "Department")
                {
                    if (string.IsNullOrEmpty(Department) || Department.Length >= 14)
                        result = "Please enter a department name";
                }
                if (columnName == "Address")
                {
                    if (string.IsNullOrEmpty(Address) || Address.Length >= 14)
                        result = "Please enter an address";
                }
                if (columnName == "UserName")
                {
                    if (string.IsNullOrEmpty(UserName) || UserName.Length >= 14)
                        result = "Please enter a username";
                }
                return result;
            }
        }

        #region Realising Inotify propetychanged interface

        public ObservableCollection<string> countries { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void DoPropertyChanged(string Name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }
        #endregion

        //Fields
        private string FirstNameValue;
        private string SecondNameValue;
        private string departmentValue;
        private string addressValue;
        private string countryValue;
        private string UserNameValue;
       

        //These are the properties that realise all fields
        public string FirstName { get { return FirstNameValue; } set { FirstNameValue = value; } }

        public string SecondName { get { return SecondNameValue; }set { SecondNameValue = value; } }

        public string Department{get { return departmentValue; } set { departmentValue = value; }}

        public string Address {get { return addressValue; }set { addressValue = value; } }


        public string country  { get { return countryValue; } set{ countryValue = value; DoPropertyChanged("country"); }}

        public string UserName { get { return UserNameValue; } set { UserNameValue = value; } }

       

        /*This is the icommand for saving data*/
        public ICommand Saved { get; set; }

       

        #region Constractor
        public RegesterViewModel()
        {
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.Department = Department;
            this.Address = Address;
            this.UserName = UserName;
          

            countries = new ObservableCollection<string>()

                    {
                        "Uganda","Kenya","Tanzania","Rwanda",
                        "Bulundi","Nigeria","Zambia","SouthAfrica",
                        "Sudan","DRC","Angola","Ethopia","Namibia"
                    };

            Saved = new RegesterCommand();
        }

        #endregion
    }
}


