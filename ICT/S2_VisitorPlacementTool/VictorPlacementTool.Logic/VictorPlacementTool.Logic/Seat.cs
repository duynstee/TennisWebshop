using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorPlacementTool.Logic
{
    public class Seat
    {
        public string seatCode { get; set; }

        public Visitor visitor = new Visitor();
        public bool SeatTaken = false;
        public Seat(string sectionCode, int rowNumber, int seatNumber)
        { 
            seatCode = sectionCode + rowNumber + "-" + seatNumber;
        }
    }
}
