using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VictorPlacementTool.Logic
{
    public class Event
    {
        public List<Visitor> Visitors = new List<Visitor>();
        public List<Section> Sections = new List<Section>();

        public string Name;
        public DateTime Date;

        private int currentSectionNumber = 65;

        public Event(string name, DateTime date)
        {
            this.Name = name;
            this.Date = date;
        }



        public void CreateEvent()
        {
            //Event Event = new Event();
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
            string sectioncode = ((char)currentSectionNumber).ToString();
            Section section = new Section(sectioncode, rows, seats);
            currentSectionNumber++;
            Sections.Add(section);

        }
    }
}
