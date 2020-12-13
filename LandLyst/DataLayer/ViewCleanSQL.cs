using LandLyst.Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LandLyst.Models.SQLwithoutParametre
{
    // This class represents ViewCleanSQL with inheritance from IViewClean!
    public class ViewCleanSQL : IViewClean
    {
        // Implement from interface - List used to symbolizes the connection between a class and database table!
        public List<CleaningData> SqlQuery(string connectionString)
        {
            // Use connection to database!
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                // Create list!
                var cleaningList = new List<CleaningData>();

                // Create dataset to store multiple dataTables in a single collection!
                DataSet ds = new DataSet();

                // Open database connection!
                sqlConn.Open();

                // SQL Commands!
                string cleanView = "SELECT cleanStatus, roomName, STUFF ((SELECT ', ' + inteName FROM Interior JOIN RooInt_Keys ON RooInt_Keys.inteID = Interior.inteID WHERE RooInt_Keys.roomID = Room.roomID FOR XML PATH('')),1,1,'') AS 'inteName', STUFF((SELECT ', ' + inteDesc FROM Interior JOIN RooInt_Keys ON RooInt_Keys.inteID = Interior.inteID WHERE RooInt_Keys.roomID = Room.roomID FOR XML PATH('')),1,1,'') AS 'inteDesc' FROM Status JOIN RooSta_Keys ON RooSta_Keys.statusID = Status.statusID JOIN Room ON Room.roomID = RooSta_Keys.roomID JOIN ResRoo_Keys ON ResRoo_Keys.roomID = Room.roomID";
                SqlCommand cmd = new SqlCommand(cleanView, sqlConn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                // Close database connection!
                sqlConn.Close();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    // Create object!
                    var cleaningData = new CleaningData
                    {
                        GetCleanSta = Convert.ToString(dr["cleanStatus"]),
                        Rnum = Convert.ToString(dr["roomName"]),
                        Rinterior = Convert.ToString(dr["inteName"]),
                        RinteDesc = Convert.ToString(dr["inteDesc"])
                    };

                    // Adding to list!
                    cleaningList.Add(cleaningData);
                }
                return cleaningList;
            }
        }
    }
}
