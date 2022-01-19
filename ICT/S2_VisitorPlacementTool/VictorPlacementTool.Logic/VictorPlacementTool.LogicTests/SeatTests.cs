using Microsoft.VisualStudio.TestTools.UnitTesting;
using VictorPlacementTool.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace VictorPlacementTool.Logic.Tests
{
    [TestClass()]
    public class SeatTests
    {
        [TestMethod()]
        public void SeatTest()
        {
            //arrange
            string sectionCode = "A";
            int rowNumer = 2;
            int seatNumber = 2;
            string testSeatCode = "A2-2";
            //act
            Seat s = new Seat(sectionCode, rowNumer, seatNumber);
            //assert
            Assert.AreEqual(testSeatCode, s.seatCode);
        }

        [TestMethod()]
        public void AddVisitorToSeatTest()
        {
            //arrange
            Visitor visitor = new Visitor("olaf");
            Seat s = new Seat("A", 2, 2);

            //act
            s.AddVisitorToSeat(visitor);
            
            //assert
            Assert.IsTrue(visitor.hasSeat);
        }

        [TestMethod()]
        public void AddVisitorToSeatTest2()
        {
            //arrange
            Visitor visitor = new Visitor("olaf");
            Seat s = new Seat("A", 2, 2);

            //act
            s.AddVisitorToSeat(visitor);

            //assert
            Assert.IsTrue(s.SeatTaken);
        }
    }
}