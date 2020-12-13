using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandLyst.Pages;

namespace LandLyst.Models.SQLwithTwoParametre
{
    // This interface represents IUpdateBook!
    interface IUpdateBook
    {
        // Create interface method!
        void SqlQuery(StaffData userinput, string connectionString);
    }
}
