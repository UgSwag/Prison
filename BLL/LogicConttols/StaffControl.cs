
using System.Data;
using DAL;
namespace BLL
{
    public class StaffControl
    {
        StaffDataBaseManuplation staff = new StaffDataBaseManuplation();
        public void RegesterStaffMember(
        string FirstName,
        string SecondName,
        string OtherName,
        double Id,
        string Rank,
        string PhoneNumber,
        string Address
         )

        {
            staff.AddStaffMember(FirstName, SecondName, OtherName , Id , Rank , PhoneNumber,Address);

        }

        public DataTable getTable()
        {
            StaffDataBaseManuplation FetchStaff = new StaffDataBaseManuplation();
            DataTable dt = new DataTable();
            dt = FetchStaff.getTable();
           
                if (dt == null || dt.HasErrors == true)
                {
                    return dt;
                }
            return dt;

        }

    }
}
