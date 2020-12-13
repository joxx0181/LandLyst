using LandLyst.Models.SQLwithTwoParametre;
using LandLyst.Pages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LandLyst.Models.SQLwithParametre
{
    // This class represents UpdateCleanSQL with inheritance from IUpdateClean!
    public class UpdateCleanSQL : IUpdateClean
    {
        // Auto implemented properties with get and set accessor!
        public string CheckRoom { get; set; }
        public string RoomID { get; set; }

        // Implement a interface method!
        public void SqlQuery(CleaningData userinput, string connectionString)
        {
            // Use connection to database!
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string checkClean = "SELECT statusID FROM RooSta_Keys JOIN Room ON Room.roomID = RooSta_Keys.roomID WHERE roomNum = " + userinput.RoomNO;
                SqlCommand cmd2 = new SqlCommand(checkClean, sqlConn);

                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    CheckRoom = reader["statusID"].ToString();
                }

                // Close database connection!
                sqlConn.Close();

                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string checkClean1 = "SELECT roomID FROM Room WHERE roomNum = " + userinput.RoomNO;
                SqlCommand cmd3 = new SqlCommand(checkClean1, sqlConn);

                SqlDataReader reader1 = cmd3.ExecuteReader();
                while (reader1.Read())
                {
                    RoomID = reader1["roomID"].ToString();
                }

                // Close database connection!
                sqlConn.Close();

                // Statement!
                if (CheckRoom == "8")
                {
                    // Open database connection!
                    sqlConn.Open();

                    // SQL Commands!
                    string updateClean = "UPDATE RooSta_Keys SET statusID = 9 WHERE roomID = @RoomID";
                    SqlCommand cmd4 = new SqlCommand(updateClean, sqlConn);
                    cmd4.Parameters.AddWithValue("@RoomID", RoomID);

                    cmd4.ExecuteNonQuery();

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
