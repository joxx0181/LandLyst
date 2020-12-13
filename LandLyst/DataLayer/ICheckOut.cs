using LandLyst.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandLyst.Models.SQLwithTwoParametre
{
    // This interface represents ICheckOut!
    interface ICheckOut
    {
        // Create interface method!
        void SqlQuery(CheckOUTData userinput, string connectionString);
    }
}
