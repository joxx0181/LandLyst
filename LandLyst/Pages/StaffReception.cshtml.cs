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
    // This class represents StaffData with properties!
    public class StaffData
    {
        public string GetReserv { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Pcard { get; set; }
        public string Rnum { get; set; }
        public string Rsta { get; set; }

        [BindProperty]
        public string RoomNO { get; set; }
    }

    // This class represents StaffReceptionModel with inheritance from PageModel!
    public class StaffReceptionModel : PageModel
    {
        // Attribut declaration!
        private readonly string connectionString;

        // Constructor declaration!
        public StaffReceptionModel(IConfiguration config)
        {
            connectionString = config.GetConnectionString("LandlystDatabase");
        }

        // Auto implemented property with get and set accessor!
        public string TextOne { get; set; }

        // Create objects!
        ViewBookSQL viewBook = new ViewBookSQL();
        UpdateBookSQL updateBook = new UpdateBookSQL();

        public void OnGet()
        {
            // Call method! 
            BookingList();
        }

        public void OnPostSubmit(StaffData userInput)
        {
            // Call method!
            updateBook.SqlQuery(userInput, connectionString);
 
            RedirectToPage("/StaffReception");

            if (updateBook.CheckRoom  != "9")
            {
                this.TextOne = string.Format("You can not update this room.");
                RedirectToPage("/StaffReception");
            }          
        }

        // List used to symbolizes the connection between a class and database table!
        public List<StaffData> BookingList()
        {
            return viewBook.SqlQuery(connectionString);
        }
    }
}