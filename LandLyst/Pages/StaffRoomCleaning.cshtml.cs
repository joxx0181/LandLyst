using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LandLyst.Models.SQLwithoutParametre;
using LandLyst.Models.SQLwithParametre;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace LandLyst.Pages
{
    // This class represents CleaningData with properties!
    public class CleaningData
    {
        [BindProperty]
        public string RoomNO { get; set; }

        public string Rnum { get; set; }
        public string Rinterior { get; set; }
        public string RinteDesc { get; set; }
        public string GetCleanSta { get; set; }
    }

    // This class represents StaffRoomCleaningModel with inheritance from PageModel!
    public class StaffRoomCleaningModel : PageModel
    {
        // Attribut declaration!
        private readonly string connectionString;

        // Constructor declaration!
        public StaffRoomCleaningModel(IConfiguration config)
        {
            connectionString = config.GetConnectionString("LandlystDatabase");
        }

        // Auto implemented property with get and set accessor!
        public string TextOne { get; set; }

        // Create objects!
        ViewCleanSQL viewClean = new ViewCleanSQL();
        UpdateCleanSQL updateClean = new UpdateCleanSQL();

        public void OnGet()
        {
            // Call method! 
            CleaningList();
        }

        public void OnPostSubmit(CleaningData userInput)
        {
            // Call method! 
            updateClean.SqlQuery(userInput, connectionString);

            RedirectToPage("/StaffRoomCleaning");

            if (updateClean.CheckRoom != "8")
            {
                this.TextOne = string.Format("You can not update this room.");
                RedirectToPage("/StaffRoomCleaning");
            }
        }

        // List used to symbolizes the connection between a class and database table!
        public List<CleaningData> CleaningList()
        {   
         return viewClean.SqlQuery(connectionString);
        }
    }
}
