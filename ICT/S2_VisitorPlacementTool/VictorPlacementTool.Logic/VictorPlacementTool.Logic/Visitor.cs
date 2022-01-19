using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorPlacementTool.Logic
{
    public class Visitor
    {
        public string Name { get; set; }
        public DateTime Birthday;
        public bool hasSeat;
        public string seatCode;

        public Visitor()
        {
            
        }
        
        public Visitor(string name)
        {
            this.Name = name;
        }

        public void AddVisitor(Visitor visitor, List<Section> sections)
        {
            foreach (var section in sections)
            {
                
            }
        }

        public override string ToString()
        {
            return "Visitor " + Name + " has this seat: ";
        }
    }
}
