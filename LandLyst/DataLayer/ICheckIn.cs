using LandLyst.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandLyst.Models.SQLwithTwoParametre
{
    // This interface represents ICheckIn!
    interface ICheckIn
    {
        // Create interface method!
        void SqlQuery(CheckINData userinput, string connectionString);
    }
}
