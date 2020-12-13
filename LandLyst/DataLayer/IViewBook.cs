using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandLyst.Pages;

namespace LandLyst.DataLayer.SQLwithOneParametre
{ 
    // This interface represents IViewBook!
    interface IViewBook
    {
        // Create interface method with List<StaffData> functionality to create a list of objects!
        List<StaffData> SqlQuery(string connectionString);
    }
}
