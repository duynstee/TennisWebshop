using System;
using VictorPlacementTool.Logic;


namespace ConsoleVisitorPlacementTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Event _event = new Event();
            Organizer organizer = new Organizer();
            Console.WriteLine("Insert visitors:");
            _event.CreateVisitors(Convert.ToInt32(Console.ReadLine()));

            

            Console.ReadLine();
        }
    }
}
