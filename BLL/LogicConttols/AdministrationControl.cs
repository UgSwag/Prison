using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class AdministrationControl 
    {
        //object of the admition data manuplation class
        AdmitionDataBaseManuplation admition = new AdmitionDataBaseManuplation();
      
       

        public void InsertPrisoner(string surName, string firstName, string otherNames, int cellNumber, int fileNumber, int period, string crime, int age, string sex, double weight, double height)
        {
            admition.InsertAdminstrationData(firstName, surName, otherNames, cellNumber, fileNumber, period, crime, age, sex, weight, height);
        }

        //This is the method that maps the datatable to the Datagrid
        public DataTable getTable()
        {
           
            DataTable dt = new DataTable();
            dt = admition.getTable();

            if (dt == null || dt.HasErrors == true)
            {
                return dt;
            }
            return dt;

        }
    }
}
