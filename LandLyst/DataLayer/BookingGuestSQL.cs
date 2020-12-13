using LandLyst.Pages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LandLyst.Models.SQLwithParametre
{
    // This class represents BookingGuestSQL with inheritance from IBooking!
    public class BookingGuestSQL : IBooking
    {
        // Implement a interface method!
        public void SqlQuery(BookingData userinput, string connectionString)
        {
            // Use connection to database!
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string query = "INSERT INTO Customer_Contact (phoneNumber, email) VALUES(@Phonenumber, @Email)";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@Phonenumber", userinput.Phonenumber);
                cmd.Parameters.AddWithValue("@Email", userinput.Email);

                string query1 = "INSERT INTO Customer_Pay (paymentCard) VALUES(@Paymentcard)";
                SqlCommand cmd1 = new SqlCommand(query1, sqlConn);
                cmd1.Parameters.AddWithValue("@Paymentcard", userinput.Paymentcard);

                string query2 = "INSERT INTO Customer (firstName, lastName, addr, zipcode, contactID, payID) VALUES(@FirstName, @LastName, @Address, @Zipcode, (SELECT contactID FROM Customer_Contact WHERE contactID = (SELECT MAX(contactID) FROM Customer_Contact)), (SELECT payID FROM Customer_Pay WHERE payID = (SELECT MAX(payID) FROM Customer_Pay)))";
                SqlCommand cmd2 = new SqlCommand(query2, sqlConn);
                cmd2.Parameters.AddWithValue("@FirstName", userinput.FirstName);
                cmd2.Parameters.AddWithValue("@LastName", userinput.LastName);
                cmd2.Parameters.AddWithValue("@Address", userinput.Address);
                cmd2.Parameters.AddWithValue("@Zipcode", userinput.Zipcode);

                string query3 = "INSERT INTO CusRes_Keys (custID, reservID) VALUES((SELECT custID FROM Customer WHERE custID = (SELECT MAX(custID) FROM Customer)), (SELECT reservID FROM Reservation WHERE reservID = (SELECT MAX(reservID) FROM Reservation)))";
                SqlCommand cmd3 = new SqlCommand(query3, sqlConn);

                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();

                // Close database connection!
                sqlConn.Close();
            }
        }
    }
}
