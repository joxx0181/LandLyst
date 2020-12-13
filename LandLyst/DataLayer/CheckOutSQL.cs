using LandLyst.Models.SQLwithTwoParametre;
using LandLyst.Pages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LandLyst.Models.SQLwithParametre
{
    // This class represents CheckOutSQL with inheritance from ICheckOut!
    public class CheckOutSQL : ICheckOut
    {
        // Auto implemented properties with get and set accessor!
        public string CheckRoom { get; set; }
        public string Pcard { get; set; }

        // Implement a interface method!
        public void SqlQuery(CheckOUTData userinput, string connectionString)
        {
            // Use connection to database!
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string checkOUT = "SELECT paymentcard FROM Customer_Pay JOIN Customer ON Customer_Pay.payID = Customer.payID JOIN CusRes_Keys ON CusRes_Keys.custID = Customer.custID JOIN ResRoo_Keys ON ResRoo_Keys.reservID = CusRes_Keys.reservID JOIN Room ON Room.roomID = ResRoo_Keys.roomID WHERE roomNum = @RoomNumber";
                SqlCommand cmd = new SqlCommand(checkOUT, sqlConn);
                cmd.Parameters.AddWithValue("@RoomNumber", userinput.RoomNumber);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Pcard = reader["paymentCard"].ToString();

                }

                // Close database connection!
                sqlConn.Close();

                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string checkOUT1 = "SELECT statusID FROM RooSta_Keys INNER JOIN Room ON Room.roomID = RooSta_Keys.roomID  WHERE roomNum = @RoomNumber";
                SqlCommand cmd1 = new SqlCommand(checkOUT1, sqlConn);
                cmd1.Parameters.AddWithValue("@RoomNumber", userinput.RoomNumber);

                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    CheckRoom = reader1["statusID"].ToString();
                }

                // Close database connection!
                sqlConn.Close();

                // Statement!
                if (CheckRoom == "6")
                {
                    // Open database connection!
                    sqlConn.Open();

                    // SQL Commands!
                    string checkOUT2 = "UPDATE RooSta_Keys SET statusID = 8 FROM RooSta_Keys INNER JOIN Room ON Room.roomID = RooSta_Keys.roomID  WHERE roomNum = @RoomNumber";
                    SqlCommand cmd2 = new SqlCommand(checkOUT2, sqlConn);
                    cmd2.Parameters.AddWithValue("@RoomNumber", userinput.RoomNumber);

                    cmd2.ExecuteNonQuery();

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
