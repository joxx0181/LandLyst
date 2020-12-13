using LandLyst.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandLyst.Models
{
    // This interface represents IViewClean!
    interface IViewClean
    {
        // Create interface method with List<CleaningData> functionality to create a list of objects!
        List<CleaningData> SqlQuery(string connectionString);
    }
}
