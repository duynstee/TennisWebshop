using Microsoft.VisualStudio.TestTools.UnitTesting;
using VictorPlacementTool.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VictorPlacementTool.Logic.Tests
{
    [TestClass()]
    public class OrganizerTests
    {
        [TestMethod()]
        public void CreateEventTest()
        {
            //arrange 
            Organizer o = new Organizer();
            string eventName = "Event1";
            DateTime eventDate = DateTime.Now;

            //act
            Event event1 = o.CreateEvent(eventName, eventDate);
            //assert
            Assert.IsInstanceOfType(event1, typeof(Event));
        }
    }
}