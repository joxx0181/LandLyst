using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandLyst.Pages
{
    // This class represents EmailMessage with binding properties!
    public class EmailMessage 
    {
        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string FromEmail { get; set; }

        [BindProperty]
        public string MessageBody { get; set; }
    }

    // This class represents ContactModel with inheritance from PageModel!
    public class ContactModel : PageModel
    {
        // Auto implemented properties with get and set accessor!
        public string TextOne { get; set; }
        public string TextTwo { get; set; }

        public void OnGet()
        {
        }

        public void OnPostSubmit(EmailMessage emailMes)
        {
            this.TextOne = string.Format("thanks {0} {1}", emailMes.FirstName, emailMes.LastName + " for your message.");
            this.TextTwo = string.Format("You will hear from us as soon as possible - have a good day.");

            RedirectToPage("/Contact");
        }
    }
}

