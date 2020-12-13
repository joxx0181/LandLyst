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
    // This class represents CheckOUTData with binding property!
    public class CheckOUTData
    {
        [BindProperty]
        public string RoomNumber { get; set; }
    }

    // This class represents CheckOUTModel with inheritance from PageModel!
    public class CheckOUTModel : PageModel
    {
        // Attribut declaration!
        private readonly string connectionString;

        // Constructor declaration!
        public CheckOUTModel(IConfiguration config)
        {
            connectionString = config.GetConnectionString("LandlystDatabase");
        }

        // Auto implemented properties with get and set accessor!
        public string TextOne { get; set; }
        public string TextTwo { get; set; }
        public string TextThree { get; set; }

        // Create objects!
        CheckOutSQL checkOUT = new CheckOutSQL();

        public void OnGet()
        {       
        }

        public void OnPostSubmit(CheckOUTData userInput)
        {
            // Call method!
            checkOUT.SqlQuery(userInput, connectionString);

            if (checkOUT.CheckRoom == "6")
            {
                this.TextOne = string.Format("Thanks for your visit.");
                this.TextTwo = string.Format("Payment is automatically deducted from your paymentcard: " + checkOUT.Pcard);

                RedirectToPage("/CheckOUT");
            }
            else
            {
                this.TextThree = string.Format("Something went wrong - is your room number entered correctly ?");
                RedirectToPage("/CheckOUT");
            }
        }
    }
}
