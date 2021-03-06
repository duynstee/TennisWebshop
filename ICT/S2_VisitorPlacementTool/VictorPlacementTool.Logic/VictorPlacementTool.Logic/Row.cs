using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorPlacementTool.Logic
{
    public class Row 
    {
        public int RowNumber;
        public List<Seat> Seats = new List<Seat>();

        public Row(string sectionCode, int rowNumber, int totalSeats)
        {
            for (int i = 0; i < totalSeats; i++)
            {
                int seatNumber = i + 1;
                Seat seat = new Seat(sectionCode, rowNumber, seatNumber);
                Seats.Add(seat);
            }
        }

        public void PlaceAll(List<Visitor> visitorsToPlace)
        {
            foreach (var seat in Seats)
            {
                seat.PlaceAll(visitorsToPlace);
            }
        }

        public void GetVisitor()
        {
            foreach (var seat in Seats)
            {
                seat.GetVisitor();
            }
        }
    }
}
