using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VictorPlacementTool.Logic
{
    public class Event
    {
        public List<Group> Groups = new List<Group>();
        public List<Visitor> Visitors = new List<Visitor>();
        public List<Visitor> NotPlacedVisitors = new List<Visitor>();
        public List<Section> Sections = new List<Section>();

        public string Name;
        public DateTime Date;

        private int currentSectionNumber = 65;

        public Event(string name, DateTime date)
        {
            this.Name = name;
            this.Date = date;
        }

        public void CreateVisitors(int totalVisitors)
        {
            for (int i = 0; i < totalVisitors; i++)
            {
                Visitor visitor = new Visitor();
                Visitors.Add(visitor);
            }
        }

        public void CreateSection(int rows, int seats)
        {
            //
            string sectioncode = ((char) currentSectionNumber).ToString();
            Section section = new Section(sectioncode, rows, seats);
            currentSectionNumber++;
            Sections.Add(section);
        }



        public void PlaceAll(List<Visitor> visitorToPlace)
        {
            //List<Visitor> visitorToPlace = new List<Visitor>();
            foreach (var section in Sections)
            {
                section.PlaceAll(visitorToPlace);
            }
        }

        public void GetVisitors()
        {
            foreach (var section in Sections)
            {
                section.GetVisitor();
            }
        }
        
        
        
        /*public void SeatToVisitor()
        {
            foreach (var addvisitor in Visitors)
            {
                addvisitor.AddVisitor(addvisitor, Sections );

                
      
                
                /*foreach (var section in Sections)
                {
                    foreach (var row in section.Rows)
                    {
                        foreach (var seat in row.Seats)
                        {
                                if (seat.SeatTaken == false && addvisitor.hasSeat == false)
                            {
                                seat.SeatTaken = true;
                                seat.visitor = addvisitor;
                                addvisitor.seatCode = seat.seatCode;
                                addvisitor.hasSeat = true;
                                Console.WriteLine(seat.visitor + "has seat: " + addvisitor.seatCode);
                                Visitors.Remove(addvisitor);
                                PlacedVisitors.Add(addvisitor);
                            }
                        }
                    }
                }

            }
        }*/
    }
}