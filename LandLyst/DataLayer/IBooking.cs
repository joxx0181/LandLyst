using LandLyst.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandLyst.Models.SQLwithParametre
{
    // This interface represents IBooking!
    interface IBooking
    {
        // Create interface method!
        void SqlQuery(BookingData userinput, string connectionString);
    }
}
