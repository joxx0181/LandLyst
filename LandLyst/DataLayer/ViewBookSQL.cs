using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LandLyst.DataLayer.SQLwithOneParametre;
using LandLyst.Pages;

namespace LandLyst.Models.SQLwithoutParametre
{
    // This class represents ViewBookSQL with inheritance from IViewBook!
    public class ViewBookSQL : IViewBook
    {
        // Implement from interface - List used to symbolizes the connection between a class and database table!
        public List<StaffData> SqlQuery(string connectionString)
        {
            // Use connection to database!
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                // Create list!
                var bookingList = new List<StaffData>();

                // Create dataset to store multiple dataTables in a single collection!
                DataSet ds = new DataSet();

                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string bookView = "SELECT reservID, firstName, lastName, addr, city, phoneNumber, email, paymentCard, STUFF ((SELECT ', ' + roomName FROM Room JOIN ResRoo_Keys ON Room.roomID = ResRoo_Keys.roomID WHERE ResRoo_Keys.reservID = CusRes_Keys.reservID  FOR XML PATH('')),1,1,'') AS 'roomName', STUFF ((SELECT ', ' + roomStatus FROM Status JOIN RooSta_Keys ON RooSta_Keys.statusID = Status.statusID JOIN Room ON Room.roomID = RooSta_Keys.roomID JOIN ResRoo_Keys ON ResRoo_Keys.roomID = Room.roomID WHERE ResRoo_Keys.reservID = CusRes_Keys.reservID FOR XML PATH('')),1,1,'') AS 'roomStatus' FROM Customer JOIN CusRes_Keys ON CusRes_Keys.custID = Customer.custID JOIN Customer_ZipArea ON Customer_ZipArea.zipcode = Customer.zipcode JOIN Customer_Contact ON Customer_Contact.contactID = Customer.contactID JOIN Customer_Pay ON Customer_Pay.payID = Customer.payID";
                SqlCommand cmd = new SqlCommand(bookView, sqlConn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                // Close database connection!
                sqlConn.Close();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    // Create object!
                    var bookingData = new StaffData
                    {
                        GetReserv = Convert.ToString(dr["reservID"]),
                        Fname = Convert.ToString(dr["firstName"]),
                        Lname = Convert.ToString(dr["lastName"]),
                        Address = Convert.ToString(dr["addr"]),
                        City = Convert.ToString(dr["city"]),
                        Phone = Convert.ToString(dr["phoneNumber"]),
                        Mail = Convert.ToString(dr["email"]),
                        Pcard = Convert.ToString(dr["paymentCard"]),
                        Rnum = Convert.ToString(dr["roomName"]),
                        Rsta = Convert.ToString(dr["roomStatus"])
                    };

                    // Adding to list!
                    bookingList.Add(bookingData);
                }
                return bookingList;
            }
        }
    }
}
