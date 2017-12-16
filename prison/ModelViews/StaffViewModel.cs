using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prison.Commands;
using System.Windows.Input;

namespace prison.ModelViews
{
    class StaffViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        public string Error
        {
                get { throw new NotImplementedException(); }
            
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "FirstName")
                {
                    if (string.IsNullOrEmpty(FirstName)  || FirstName.Length >= 14)
                        result = "Please enter a FirstName";
                }
                if (columnName == "SecondName")
                {
                    if (string.IsNullOrEmpty(SecondName) || SecondName.Length >= 14)
                        result = "Please enter a SecondName";
                }
                if (columnName == "OtherName")
                {
                    if (string.IsNullOrEmpty(OtherName) || OtherName.Length >= 18 )
                        result = "Please enter a SecondName";
                }
                if (columnName == "Address")
                {
                    if (string.IsNullOrEmpty(Address) ||Address.Length >= 18)
                        result = "Please enter a correct address";
                }
                if (columnName == "Rank")
                {
                    if (string.IsNullOrEmpty(Rank) ||Rank.Length > 18)
                        result = "Please enter a rank";
                }
                if (columnName == "Id")
                {
                    if ( Id >= 8)
                        result = "Please enter an Id";
                }
                if (columnName == "PhoneNumber")
                {
                    if (string.IsNullOrEmpty(PhoneNumber) || PhoneNumber.Length < 6 || PhoneNumber.Length >= 14)
                        result = "Please enter an Id";
                }
                return result;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void DoPropertyChanged(string Name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }

        //Private staff model fields
        private string FirstNameValue;
        private string SecondNameValue;
        private string OtherNameValue;
        private double IdValue;
        private string RankValue;
        private string AddressValue;
        private string PhoneNumberValue;
       

        //Public properties for staff members
        public string FirstName { get { return FirstNameValue; } set { FirstNameValue = value; } }
        public string SecondName { get { return SecondNameValue; } set { SecondNameValue = value; } }
        public string OtherName { get { return OtherNameValue; } set { OtherNameValue = value; } }
        public double Id { get { return IdValue; } set { IdValue = value; } }
        public string Rank { get { return RankValue; } set { RankValue = value; } }
        public string PhoneNumber { get { return PhoneNumberValue; } set { PhoneNumberValue = value; } }
        public string Address{ get { return AddressValue; } set { AddressValue = value; } }

      

        public StaffViewModel()
        {
            //Initialising staff member properties
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.OtherName = OtherName;
            this.Id = Id;
            this.Rank = Rank;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
           
            StaffMember = new StaffCommand();
            RefreshStaff = new UpdateStaffCommand();

        }
        public ICommand StaffMember { get; set; }
        public ICommand RefreshStaff { get; set; }
    }
}
