using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorPlacementTool.Logic
{
    class Event
    {
        public string Name;
        public DateTime Date;

        public Event(string name, DateTime date)
        {
            this.Name = name;
            this.Date = date;
        }
    }
}
