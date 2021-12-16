using System;
using System.Data;
using VictorPlacementTool.Logic;


namespace ConsoleVisitorPlacementTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Organizer organizer = new Organizer();

            var newEvent = organizer.CreateEvent("muziekEvent", DateTime.Now);

            Console.WriteLine("Insert visitors:");
            newEvent.CreateVisitors(Convert.ToInt32(Console.ReadLine())); 
            
            newEvent.CreateSection(3, 3);
            newEvent.CreateSection(2, 3);


            newEvent.SeatToVisitor();


            Console.ReadLine();
        }
    }
}
