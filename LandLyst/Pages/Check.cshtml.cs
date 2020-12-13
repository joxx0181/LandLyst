using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LandLyst.Models.SQLwithParametre;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace LandLyst.Pages
{
    // This class represents CheckINData with binding property!
    public class CheckINData
    {
        [BindProperty]
        public string ReservationNumber { get; set; }
    }

    // This class represents CheckINModel with inheritance from PageModel!
    public class CheckINModel : PageModel
    {
        // Attribut declaration!
        private readonly string connectionString;

        // Constructor declaration!
        public CheckINModel(IConfiguration config)
        {
            connectionString = config.GetConnectionString("LandlystDatabase");
        }

        // Auto implemented properties with get and set accessor!
        public string TextOne { get; set; }
        public string TextTwo { get; set; }
        public string TextThree { get; set; }
        public string TextFour { get; set; }

        // Create object!
        CheckInSQL checkIN = new CheckInSQL();

        public void OnGet()
        {
        }

        public void OnPostSubmit(CheckINData userInput)
        {
            // Call method!
            checkIN.SqlQuery(userInput, connectionString);

            if (checkIN.CheckRoom == "4")
            {
                this.TextOne = string.Format("Hello " + checkIN.Fname + " " + checkIN.Lname + ",");
                this.TextTwo = string.Format("Welcome to Hotel Landlyst  -  You are checked into room " + checkIN.Rnum + ".");
                this.TextThree = string.Format(checkIN.Rdesc);

                RedirectToPage("/Check");
            }
            else
            {
                this.TextFour = string.Format("Something went wrong - is your reservation number entered correctly ?");
                RedirectToPage("/Check");
            }          
        }        
    }
}
