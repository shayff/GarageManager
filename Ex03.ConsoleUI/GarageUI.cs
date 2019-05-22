using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        public void PrintMenu()
        {
            Console.WriteLine("Welcome to our garage!\n\n");

            Console.WriteLine("Insert a car type:/n" +
                              "for A regular motorcycle press 1\n" +
                              "for A Electric motorcycle press 2\n " +
                              "for A Regular car press 3\n" +
                              "for A Electric car press 4\n" +
                              "for A truck press 5\n");

            string TypeOfVehicle= Console.ReadLine();
          //  TypeOfVehicle= Int32.Parse(Console.ReadLine());
            

        }
    }
}