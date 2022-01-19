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

        public Visitor visitor1 = new Visitor();
        public bool SeatTaken = false;
        public Seat(string sectionCode, int rowNumber, int seatNumber)
        { 
            seatCode = sectionCode + rowNumber + "-" + seatNumber;
        }

        public void PlaceAll(List<Visitor> visitorsToPlace)
        {
            foreach (var visitor in visitorsToPlace)
            {
                if (visitor.hasSeat == false)
                {
                    if (SeatTaken == false)
                    {
                        AddVisitorToSeat(visitor);
                    }
                }
            }
        }

        public void AddVisitorToSeat(Visitor visitor)
        {
            visitor.hasSeat = true;
            SeatTaken = true;
            visitor1 = visitor;
        }

        public void GetVisitor()
        {
            if (SeatTaken == true)
            { 
                Console.WriteLine(visitor1 + "has seat: " + seatCode);
            }
        }
    }
}
