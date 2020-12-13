using LandLyst.Models.SQLwithTwoParametre;
using LandLyst.Pages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LandLyst.Models.SQLwithParametre
{
    // This class represents UpdateBookSQL with inheritance from IUpdateBook!
    public class UpdateBookSQL : IUpdateBook
    {
        // Auto implemented properties with get and set accessor!
        public string CheckRoom { get; set; }
        public string RoomID { get; set; }
        public string PayID { get; set; }
        public string ContactID { get; set; }
        public string CustID { get; set; }
        public string ReservID { get; set; }

        // Implement a interface method!
        public void SqlQuery(StaffData userinput, string connectionString)
        {
            // Use connection to database!
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string checkSta = "SELECT statusID FROM RooSta_Keys JOIN Room ON Room.roomID = RooSta_Keys.roomID WHERE roomNum = " + userinput.RoomNO;
                SqlCommand cmd1 = new SqlCommand(checkSta, sqlConn);

                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    CheckRoom = reader["statusID"].ToString();
                }

                // Close database connection!
                sqlConn.Close();

                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string getId = "SELECT roomID FROM Room WHERE roomNum = " + userinput.RoomNO;
                SqlCommand comm = new SqlCommand(getId, sqlConn);

                SqlDataReader readerId = comm.ExecuteReader();
                while (readerId.Read())
                {
                    RoomID = readerId["roomID"].ToString();
                }

                // Close database connection!
                sqlConn.Close();

                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string getId1 = "SELECT payID, contactID FROM Customer JOIN CusRes_Keys ON CusRes_Keys.custID = Customer.custID JOIN ResRoo_Keys ON ResRoo_Keys.reservID = CusRes_Keys.reservID WHERE roomID = " + RoomID;
                SqlCommand comm1 = new SqlCommand(getId1, sqlConn);

                SqlDataReader readerId1 = comm1.ExecuteReader();
                while (readerId1.Read())
                {
                    PayID = readerId1["payID"].ToString();
                    ContactID = readerId1["contactID"].ToString();
                }

                // Close database connection!
                sqlConn.Close();

                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string getId2 = "SELECT custID FROM Customer WHERE contactID = " + ContactID;
                SqlCommand comm2 = new SqlCommand(getId2, sqlConn);

                SqlDataReader readerId2 = comm2.ExecuteReader();
                while (readerId2.Read())
                {
                    CustID = readerId2["custID"].ToString();
                }

                // Close database connection!
                sqlConn.Close();

                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string getId3 = "SELECT reservID FROM CusRes_Keys WHERE custID = " + CustID;
                SqlCommand comm3 = new SqlCommand(getId3, sqlConn);

                SqlDataReader readerId3 = comm3.ExecuteReader();
                while (readerId3.Read())
                {
                    ReservID = readerId3["reservID"].ToString();
                }
                sqlConn.Close();

                // Statement!
                if (CheckRoom == "9")
                {
                    // Open database connection!
                    sqlConn.Open();

                    // SQL Commands!
                    string updateQ = "UPDATE RooSta_Keys SET statusID = 2 WHERE roomID = @RoomID";
                    SqlCommand cmdUp = new SqlCommand(updateQ, sqlConn);
                    cmdUp.Parameters.AddWithValue("@RoomID", RoomID);

                    cmdUp.ExecuteNonQuery();

                    // Close database connection!
                    sqlConn.Close();

                    // Open database connection!
                    sqlConn.Open();

                    // SQL Commands!
                    string deleteQ4 = "DELETE FROM CusRes_Keys WHERE custID = " + CustID;
                    SqlCommand cmdDel4 = new SqlCommand(deleteQ4, sqlConn);

                    cmdDel4.ExecuteNonQuery();

                    // Close database connection!
                    sqlConn.Close();

                    // Open database connection!
                    sqlConn.Open();

                    // SQL Commands!
                    string deleteQ5 = "DELETE FROM ResRoo_Keys WHERE reservID = " + ReservID;
                    SqlCommand cmdDel5 = new SqlCommand(deleteQ5, sqlConn);

                    cmdDel5.ExecuteNonQuery();

                    // Close database connection!
                    sqlConn.Close();

                    // Open database connection!
                    sqlConn.Open();

                    // SQL Commands!
                    string deleteQ2 = "DELETE FROM Customer WHERE custID = " + CustID;
                    SqlCommand cmdDel2 = new SqlCommand(deleteQ2, sqlConn);

                    cmdDel2.ExecuteNonQuery();

                    // Close database connection!
                    sqlConn.Close();

                    // Open database connection!
                    sqlConn.Open();

                    // SQL Commands!
                    string deleteQ = "DELETE FROM Customer_Pay WHERE payID = " + PayID;
                    SqlCommand cmdDel = new SqlCommand(deleteQ, sqlConn);

                    cmdDel.ExecuteNonQuery();

                    // Close database connection!
                    sqlConn.Close();

                    // Open database connection!
                    sqlConn.Open();

                    // SQL Commands!
                    string deleteQ1 = "DELETE FROM Customer_Contact WHERE contactID = " + ContactID;
                    SqlCommand cmdDel1 = new SqlCommand(deleteQ1, sqlConn);

                    cmdDel1.ExecuteNonQuery();

                    // Close database connection!
                    sqlConn.Close();

                    // Open database connection!
                    sqlConn.Open();

                    // SQL Commands!
                    string deleteQ3 = "DELETE FROM Reservation WHERE reservID = " + ReservID;
                    SqlCommand cmdDel3 = new SqlCommand(deleteQ3, sqlConn);

                    cmdDel3.ExecuteNonQuery();

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
