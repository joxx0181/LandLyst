using LandLyst.Models.SQLwithTwoParametre;
using LandLyst.Pages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LandLyst.Models.SQLwithParametre
{
    // This class represents CheckInSQL with inheritance from ICheckIn!
    public class CheckInSQL : ICheckIn
    {
        // Auto implemented properties with get and set accessor!
        public string CheckRoom { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Rdesc { get; set; }
        public string Rnum { get; set; }

        // Implement a interface method!
        public void SqlQuery(CheckINData userinput, string connectionString)
        {
            // Use connection to database!
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string checkIN = "SELECT firstName, lastName FROM Customer INNER JOIN CusRes_Keys ON CusRes_Keys.custID = Customer.custID WHERE reservID = @ReservationNumber";
                SqlCommand cmd = new SqlCommand(checkIN, sqlConn);
                cmd.Parameters.AddWithValue("@ReservationNumber", userinput.ReservationNumber);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Fname = reader["firstName"].ToString();
                    Lname = reader["lastName"].ToString();
                }

                // Close database connection!
                sqlConn.Close();

                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string checkIN1 = "SELECT roomName, roomDesc FROM Room INNER JOIN ResRoo_Keys ON ResRoo_Keys.roomID = Room.roomID WHERE reservID = @ReservationNumber";
                SqlCommand cmd1 = new SqlCommand(checkIN1, sqlConn);
                cmd1.Parameters.AddWithValue("@ReservationNumber", userinput.ReservationNumber);

                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    Rnum = reader1["roomName"].ToString();
                    Rdesc = reader1["roomDesc"].ToString();
                }

                // Close database connection!
                sqlConn.Close();

                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string checkIN2 = "SELECT statusID FROM RooSta_Keys INNER JOIN ResRoo_Keys ON RooSta_Keys.roomID = ResRoo_Keys.roomID  WHERE reservID = @ReservationNumber";
                SqlCommand cmd2 = new SqlCommand(checkIN2, sqlConn);
                cmd2.Parameters.AddWithValue("@ReservationNumber", userinput.ReservationNumber);

                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    CheckRoom = reader2["statusID"].ToString();
                }

                // Close database connection!
                sqlConn.Close();

                // Statement!
                if (CheckRoom == "4")
                {
                    // Open database connection!
                    sqlConn.Open();

                    // SQL Commands!
                    string checkIN3 = "UPDATE RooSta_Keys SET statusID = 6 FROM RooSta_Keys INNER JOIN ResRoo_Keys ON RooSta_Keys.roomID = ResRoo_Keys.roomID  WHERE reservID = @ReservationNumber";
                    SqlCommand cmd3 = new SqlCommand(checkIN3, sqlConn);
                    cmd3.Parameters.AddWithValue("@ReservationNumber", userinput.ReservationNumber);

                    cmd3.ExecuteNonQuery();

                    // Close database connection!
                    sqlConn.Close();
                }
                else
                {
                    
                }
            }
        }
    }
}
