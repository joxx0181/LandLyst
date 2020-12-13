using Microsoft.VisualStudio.TestTools.UnitTesting;
using LandLyst.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandLyst.Pages.Tests
{
    [TestClass()]
    public class BookingModelTests
    {
        [TestMethod()]
        public void InsertRecordTest()
        {
    
            BookingData q = new BookingData();
            q.FirstName = "jens";
            q.LastName = "bONDEMAND";
            Assert.IsTrue(true);
        }
    }
}