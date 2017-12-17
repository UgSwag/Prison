using System;
using System.Collections.Generic;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Media;
using System.Windows.Media.Imaging;

using BLL;
using prison.Commands;
using System.ComponentModel;
using System.Windows.Input;


namespace prison.ModelViews
{
     public class AdmitionViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        #region Admition IdataErrorInfo validation implementattion
        //Implemention IdataErrorInfo
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
                //REVIEW:Use String.Equals instead of == for strings
                if (columnName == "FirstName")
                {
                    if (string.IsNullOrEmpty(FirstName) || FirstName.Length >= 14)
                        result = "Please enter a FirstName";
                }
                if (columnName == "SurName")
                {
                    if (string.IsNullOrEmpty(SurName) || SurName.Length >= 14)
                        result = "Please enter your Surname";
                }
                
                if (columnName == "CellNumber")
                {
                    if (CellNumber==0 ||CellNumber >= 8000)
                        result = "Please enter CellNumber";
                }
                if (columnName == "FileNumber")
                {
                    if ( FileNumber >= 5000 || FileNumber ==0)
                        result = "FileNumber Required";
                }
                if (columnName == "Period")
                {
                    if (Period ==0 || Period >= 100)
                        result = "Prisoner's Jail Period required";
                }
                if (columnName == "Crime")
                {
                    if (string.IsNullOrEmpty(Crime) )
                        result = "Fill crime field";
                }
                if (columnName == "Age")
                {
                    if (Age==0||Age>=100)
                        result = "Prisoner's age required";
                }
                if (columnName == "Sex")
                {

                    if (string.IsNullOrEmpty(Sex))
                        result = "Sex required";
                }
                if (columnName == "Weight")
                {
                    if (Weight == 0 || Weight <35)
                        result = "Prisoner's weight required";
                }

                if (columnName == "Height")
                {
                    if ( Height == 0)
                        result = "Prisoner's Height required";
                }
                return result;
            }
        }
        #endregion



        public event PropertyChangedEventHandler PropertyChanged;
        private void DoPropertyChanged(string Name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }

        //private Admition model fields
        private string SurNameValue;
        private string FirstNameValue;
        private string OtherNamesValue;
        private int AgeValue;
        private int CellNumberValue;
        private double WeightValue;
        private string CrimeValue;
        private string SexValue;
        private int periodValue;
        private int FileNumberValue;
        private double HeightValue;

        //Public admition model properties
       
        public string SurName { get {return SurNameValue; } set { SurNameValue = value; } }
        public string FirstName { get { return FirstNameValue; } set { FirstNameValue = value; } }
        public string OtherNames { get { return OtherNamesValue; } set { OtherNamesValue = value; } }
        public int Age { get { return AgeValue; } set { AgeValue = value; } }
        public int CellNumber { get { return CellNumberValue; } set { CellNumberValue = value; } }
        public double Weight { get { return WeightValue; } set { WeightValue = value; } }
        public string Crime { get { return CrimeValue; } set { CrimeValue = value; } }
        public string Sex { get { return SexValue; } set { SexValue = value; } }
        public int Period { get { return periodValue; } set { periodValue = value; } }
        public int FileNumber { get { return FileNumberValue; } set { FileNumberValue = value; } }
        public double Height { get { return HeightValue; } set { HeightValue = value; } }
        //command property for the admition button
        public ICommand Admited { get; set; }

        public ICommand Export { get; set; }

        public ICommand ReloadGrid { get; set; }

        //Admition class constructor
        public AdmitionViewModel()
        {
            this.SurName = SurName;
            this.FirstName = FirstName;
            this.OtherNames = OtherNames;
            this.Age = Age;
            this.CellNumber = CellNumber;
            this.Weight = Weight;
            this.Crime = Crime;
            this.Sex = Sex;
            this.Period = Period;
            this.FileNumber = FileNumber;
            this.Height = Height;

            Admited = new AdmitionCommand();
            Export = new ExportPdfFileCommand();
            ReloadGrid = new UpdateRecordCommander();
        }
      }
    }

    
        
 

