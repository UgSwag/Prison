using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace DAL
{
   public class StaffDataBaseManuplation
    {

        //this methods inserts data into database
        public void AddStaffMember( string FirstName, string SecondName,string OtherName, double Id, string Rank, string PhoneNumber, string Address )

        {
            if (ConfigurationManager.ConnectionStrings["DatabaseConnection"] == null)
                throw new ArgumentNullException("Bad config:)");

            string connect = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            /*Using helps to close the connection well*/
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                string query = "insert into prison.staff(FirstName,SecondName,OtherName,Id,Rank,PhoneNumber,Address) value('" + FirstName + "','" + SecondName + "','" + OtherName + "','" + Id + "','" +Rank + "','" + PhoneNumber + "','" + Address+ "');";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader Reader;
                using (Reader = command.ExecuteReader())
                {
                    Reader.Read();
                }

            }
        }

        //this method retrieves data from database
        public DataTable getTable()
        {
            if (ConfigurationManager.ConnectionStrings["DatabaseConnection"] == null)
                throw new ArgumentNullException("Bad config:)");

            string connect = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            /*Using helps to close the connection well*/
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
             string myCommand = "SELECT * FROM prison.staff";
             MySqlDataAdapter sda = new MySqlDataAdapter(myCommand, connection);
             connection.Open();
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;
            }
    
        }

    }
}
