using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        public void PrintMenu()
        {
            Console.WriteLine("Welcome to our garage!\n\n");

            Console.WriteLine("Insert a car type:/n" +
                              "for A Fuel MotorCycle press 1\n" +
                              "for A Electric motorcycle press 2\n " +
                              "for A Fuel Car press 3\n" +
                              "for A Electric car press 4\n" +
                              "for A Fuel truck press 5\n");

            string TypeOfVehicle = Console.ReadLine();

            if (Int32.TryParse(TypeOfVehicle, out int num))
            {
                Console.WriteLine("Enter a vehicle model");
                string nameOfModel = Console.ReadLine();

                Console.WriteLine("Enter a license number");
                string licenseNumber = Console.ReadLine();

                switch (num)
                {
                    case '1':
                        {
                            CreateVehicle.Create(CreateVehicle.eVehicleTypes.FuelMotorCycle, nameOfModel, licenseNumber);
                            break;
                        }
                    case '2':
                        {
                            CreateVehicle.Create(CreateVehicle.eVehicleTypes.ElectricMotorCycle, nameOfModel, licenseNumber);
                            break;
                        }
                    case '3':
                        {
                            CreateVehicle.Create(CreateVehicle.eVehicleTypes.FuelCar, nameOfModel, licenseNumber);
                            break;
                        }
                    case '4':
                        {
                            CreateVehicle.Create(CreateVehicle.eVehicleTypes.ElectricCar, nameOfModel, licenseNumber);
                            break;
                        }
                    case '5':
                        {
                            CreateVehicle.Create(CreateVehicle.eVehicleTypes.FuelTruck, nameOfModel, licenseNumber);
                            break;
                        }
                }
            }






        }
    }
}