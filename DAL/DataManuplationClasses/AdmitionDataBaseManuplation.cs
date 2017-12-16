
using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdmitionDataBaseManuplation
    {
       // this methods adds prisoner's details to database
        public void InsertAdminstrationData(string FirstName, string SurName, string OtherName, int CellNumber, int FileNumber, int Period, string Crime, int Age, string Sex, double Weight, double Height)
        {
            if (ConfigurationManager.ConnectionStrings["DatabaseConnection"] == null)
                throw new ArgumentNullException("Bad config:)");

            string connect = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                string query = "insert into prison.admitprisoners(FirstName,SurName,OtherName,CellNumber,FileNumber,Period,Crime,Age,Sex,Weight,Height) value('" + FirstName + "','" + SurName + "','" + OtherName+ "','" + CellNumber + "','" + FileNumber + "','" + Period + "','" + Crime + "','" + Age + "','" + Sex + "','" +Weight + "','" + Height + "');";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader Reader;
                using (Reader = command.ExecuteReader())
                {
                    Reader.Read();
                }
            }
        }

        //this method retrieves prisoner's  data from database
        public DataTable getTable()
        {
            if (ConfigurationManager.ConnectionStrings["DatabaseConnection"] == null)
                throw new ArgumentNullException("Bad config:)");

            string connect = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            /*Using helps to close the connection well*/
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                string myCommand = "SELECT * FROM prison.admitprisoners";
                MySqlDataAdapter sda = new MySqlDataAdapter(myCommand, connection);
                connection.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }

        }

    }
}
