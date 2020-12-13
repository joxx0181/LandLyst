using LandLyst.Pages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LandLyst.Models.SQLwithParametre
{
    // This class represents BookingRoomSQL with inheritance from IBooking!
    public class BookingRoomSQL : IBooking
    {
        // Auto implemented properties with get and set accessor!
        public string CheckRoom { get; set; }
        public string RoomNum { get; set; }
        public string GetReserv { get; set; }

        // Implement a interface method!
        public void SqlQuery(BookingData userinput, string connectionString)
        {
            // Use connection to database!
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                // Open database connection!
                sqlConn.Open();

                // Create Random function!
                Random ranNum = new Random();
                int ran = 0;

                // Create loop!
                for (int i = 0; i < 1; i++)
                {
                    // Statement!
                    switch (userinput.RoomType)
                    {
                        case "A: single bed":
                            int[] arrA = new int[1] { 49 };
                            ran = arrA[ranNum.Next(arrA.Length)];
                            break;
                        case "B: single bed and bath":
                            int[] arrB = new int[2] { 45, 55 };
                            ran = arrB[ranNum.Next(arrB.Length)];
                            break;
                        case "C: single bed and balcony":
                            int[] arrC = new int[2] { 47, 48 };
                            ran = arrC[ranNum.Next(arrC.Length)];
                            break;
                        case "D: single bed, bath and balcony":
                            int[] arrD = new int[1] { 42 };
                            ran = arrD[ranNum.Next(arrD.Length)];
                            break;
                        case "E: two single beds and bath":
                            int[] arrE = new int[3] { 32, 35, 52 };
                            ran = arrE[ranNum.Next(arrE.Length)];
                            break;
                        case "F: double bed":
                            int[] arrF = new int[2] { 11, 19 };
                            ran = arrF[ranNum.Next(arrF.Length)];
                            break;
                        case "G: double bed and bath":
                            int[] arrG = new int[29] { 10, 12, 13, 14, 15, 16, 17, 18, 20, 22, 23, 24, 25, 27, 28, 29, 33, 34, 37, 38, 39, 43, 44, 53, 54, 57, 58, 59, 60 };
                            ran = arrG[ranNum.Next(arrG.Length)];
                            break;
                        case "H: double bed and balcony":
                            int[] arrH = new int[1] { 56 };
                            ran = arrH[ranNum.Next(arrH.Length)];
                            break;
                        case "I: double bed, bath and jacuzzi":
                            int[] arrI = new int[3] { 30, 40, 50 };
                            ran = arrI[ranNum.Next(arrI.Length)];
                            break;
                        case "J: double bed, jacuzzi and balcony":
                            int[] arrJ = new int[4] { 21, 31, 41, 51 };
                            ran = arrJ[ranNum.Next(arrJ.Length)];
                            break;
                        case "K: double bed, jacuzzi, balcony and kitchen":
                            int[] arrK = new int[3] { 26, 36, 46 };
                            ran = arrK[ranNum.Next(arrK.Length)];
                            break;
                        default:
                            break;
                    }
                    string newRanNum = ran.ToString();

                    // SQL Commands!
                    string roomQ = "SELECT statusID FROM RooSta_Keys WHERE roomID = " + newRanNum;
                    SqlCommand comm = new SqlCommand(roomQ, sqlConn);

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        CheckRoom = reader["statusID"].ToString();
                    }

                    // Close database connection!
                    sqlConn.Close();

                    // Statement!
                    if (CheckRoom == "2")
                    {
                        // Open database connection!
                        sqlConn.Open();

                        // SQL Commands!
                        string roomQ1 = "INSERT INTO Reservation (arrivalDay, numOfDay) VALUES(@Arrivaldate, @Nights)";
                        SqlCommand comm1 = new SqlCommand(roomQ1, sqlConn);
                        comm1.Parameters.AddWithValue("@Arrivaldate", userinput.Arrivaldate);
                        comm1.Parameters.AddWithValue("@Nights", userinput.Nights);

                        string roomQ2 = "INSERT INTO ResRoo_Keys (reservID, roomID) VALUES((SELECT reservID FROM Reservation WHERE reservID = (SELECT MAX(reservID) FROM Reservation)), @RoomNum)";
                        SqlCommand comm2 = new SqlCommand(roomQ2, sqlConn);
                        comm2.Parameters.AddWithValue("@RoomNum", newRanNum);

                        string roomQ3 = "UPDATE RooSta_Keys SET statusID = 4 WHERE roomID = @RoomNum";
                        SqlCommand comm3 = new SqlCommand(roomQ3, sqlConn);
                        comm3.Parameters.AddWithValue("@RoomNum", newRanNum);

                        comm1.ExecuteNonQuery();
                        comm2.ExecuteNonQuery();
                        comm3.ExecuteNonQuery();

                        // Close database connection!
                        sqlConn.Close();
                    }
                    else
                    {
                       
                    }
                }

                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string roomQ4 = "SELECT reservID FROM Reservation WHERE reservID = (SELECT MAX(reservID) FROM Reservation)";
                SqlCommand comm4 = new SqlCommand(roomQ4, sqlConn);

                SqlDataReader reader2 = comm4.ExecuteReader();
                while (reader2.Read())
                {
                    GetReserv = reader2["reservID"].ToString();
                }

                // Close database connection!
                sqlConn.Close();

            }
        }
    }
}
