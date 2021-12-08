using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VictorPlacementTool.Logic
{
    public class Organizer
    {
        public List<Visitor> Visitors = new List<Visitor>();
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
    }
}
