using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorPlacementTool.Logic
{
    public class Organizer
    {
        private List<Event> eventList = new List<Event>();  


        public Organizer()
        {
            
        }


        public Event CreateEvent(string eventName, DateTime eventDate)
        {
            Event _event = new Event(eventName, eventDate);
            return _event;
        }
    }
}
