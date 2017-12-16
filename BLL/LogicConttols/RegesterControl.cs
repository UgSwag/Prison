using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using DAL;


namespace BLL
{
    public class RegesterControl 

    {
        RegesterDataBaseManuplation regester = new RegesterDataBaseManuplation();

        public void RegesterUp( string FirstName,
        string SecondName,
         string Department,
         string Address,
        string country,
        string UserName
        )

        {
            regester.Insert(FirstName, SecondName, Department, Address, country,UserName);
           
        }
        
        
    }
}
