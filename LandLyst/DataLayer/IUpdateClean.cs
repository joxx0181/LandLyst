using LandLyst.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandLyst.Models.SQLwithTwoParametre
{
    // This interface represents IUpdateClean!
    interface IUpdateClean
    {
        // Create interface method!
        void SqlQuery(CleaningData userinput, string connectionString);
    }
}
