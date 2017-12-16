using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace DAL
{
    public class RegesterDataBaseManuplation
    {
        /*this creates the instance of signInData class inorder to use it int his class*/
     
        
       
        public void Insert ( 
         string FirstName,
         string SecondName,
         string Department,
         string Country,
         string  Address,
         string UserName
        
            )

        {
            if (ConfigurationManager.ConnectionStrings["DatabaseConnection"] == null)
                throw new ArgumentNullException("Bad config:)");

            string connect = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            /*Using helps to close the connection well*/
            using (MySqlConnection connection = new MySqlConnection(connect))
            { 
                string query = "insert into prison.regester(FirstName,SecondName,Department,Country,Address,UserName) value('" + FirstName + "','" + SecondName + "','" + Department + "','" + Country + "','" + Address + "','" + UserName + "');";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader Reader;
                using (Reader = command.ExecuteReader())
                {
                    Reader.Read();
                }

            }
        }
    }
}
