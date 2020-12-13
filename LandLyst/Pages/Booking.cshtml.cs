using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using LandLyst.Models;
using LandLyst.Models.SQLwithParametre;

namespace LandLyst.Pages
{
    // This class represents BookingData with binding properties!
    public class BookingData 
    {
        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string Address { get; set; }

        [BindProperty]
        public string Zipcode { get; set; }

        [BindProperty]
        public string Phonenumber { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Paymentcard { get; set; }

        [BindProperty]
        public string RoomType { get; set; }

        [BindProperty]
        public string Arrivaldate { get; set; }

        [BindProperty]
        public string Nights { get; set; }
    }

    // This class represents BookingModel with inheritance from PageModel!
    public class BookingModel : PageModel
    {
        // Attribut declaration!
        private readonly string connectionString;

        // Constructor declaration!
        public BookingModel(IConfiguration config)
        {
            connectionString = config.GetConnectionString("LandlystDatabase");
        }

        // Auto implemented properties with get and set accessor!
        public string TextOne { get; set; }
        public string TextTwo { get; set; }

        // Create objects!
        BookingGuestSQL bookGuest = new BookingGuestSQL();
        BookingRoomSQL bookRoom = new BookingRoomSQL();

        public void OnGet()
        {
        }

        public void OnPostSubmit(BookingData userInput)
        {
            // Call method!
            bookRoom.SqlQuery(userInput, connectionString);

            if (bookRoom.CheckRoom == "2") {

                bookGuest.SqlQuery(userInput, connectionString);
                this.TextOne = string.Format("thanks for your reservation (No. " + bookRoom.GetReserv + " ) -  We look forward to your visit.");

                RedirectToPage("/Booking");
            }
            else
            {
                this.TextTwo = string.Format("this room is not available - try another room");
                RedirectToPage("/Booking");
            }
        }
    }
}
