using System;
using VictorPlacementTool.Logic;


namespace ConsoleVisitorPlacementTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Organizer organizer = new Organizer();
            Console.WriteLine("Insert visitors:");
            organizer.CreateVisitors(Convert.ToInt32(Console.ReadLine()));
  

            Console.ReadLine();
        }
    }
}
