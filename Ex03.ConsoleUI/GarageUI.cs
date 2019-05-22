using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private readonly Garage m_Garage = new Garage();

        public void PrintMenu()
        {
            Console.WriteLine("Welcome to garage of Shay and Nelly!\n\n");
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Put a new car into the garage - press 1\n" +
                                  "View the list of vehicle license numbers in the garage - press 2\n" +
                                  "Change the condition of a car in the garage - press 3\n" +
                                  "Inflate the air in the wheels of a vehicle to the maximum - press 4\n" +
                                  "Fuel a vehicle powered by fuel - press 5\n" +
                                  "To charge an electric vehicle - press 6\n" +
                                  "View full data of a vehicle by license number - press 7\n");
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out int result))
                {
                    Console.Clear(); // Clear the screen

                    switch (result)
                    {
                        case '1':
                            {
                                InsertVehicleToGarage();
                                break;
                            }

                        case '2':
                            {
                                ViewListOfVehicleLicenseNumbers();
                                break;
                            }

                        case '3':
                            {
                                ChangeVehicleStatus();
                                break;
                            }

                        case '4':
                            {
                                InflatingWheelToMax();
                                break;
                            }

                        case '5':
                            {
                                FillFuelToFuelVehicles();
                                break;
                            }

                        case '8':
                            {
                                flag = false;
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }

            }
        }

        //Request 1
        public void InsertVehicleToGarage()
        {
            Console.WriteLine("Insert a car type:/n" +
                              "for A Fuel MotorCycle press 0\n" +
                              "for A Electric motorcycle press 1\n " +
                              "for A Fuel Car press 2\n" +
                              "for A Electric car press 3\n" +
                              "for A Fuel truck press 4\n");

            string typeOfVehicle = Console.ReadLine();

            if (Int32.TryParse(typeOfVehicle, out int choice))
            {
                Console.WriteLine("Enter a vehicle model");
                string nameOfModel = Console.ReadLine();

                Console.WriteLine("Enter a license number");
                string licenseNumber = Console.ReadLine();

                if (m_Garage.IsLicenseNumberInGarage(licenseNumber))
                {
                    Console.WriteLine("The car is already in the garage ");
                }
                else
                {
                    try
                    {
                        CreateVehicle.Create((CreateVehicle.eVehicleTypes)choice, nameOfModel, licenseNumber);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }

        //Request 2
        public void ViewListOfVehicleLicenseNumbers()
        {
            Console.WriteLine("For only InRepair - press 0\n" +
                              "For only Repaired - press 1\n" +
                              "For only Paid - press 2\n" +
                              "For All Status - press 3\n");

            string input = Console.ReadLine();
            if (Int32.TryParse(input, out int result))
            {
                Console.Clear(); // Clear the screen
                //public enum eVehicleStatus { InRepair, Repaired, Paid }
                if (result == 3)
                {
                    m_Garage.GetVehiclesInGarage();
                }
                else
                {
                    m_Garage.GetVehiclesInGarageByStatus((VehicleInGarage.eVehicleStatus)result);

                }
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }


        //Request 3
        public void ChangeVehicleStatus()
        {
            Console.WriteLine("Enter a Vehicle Status:\n" +
                              "for Repaired - press 0\n" +
                              "for InRepair - press 1\n" +
                              "for Paid - press 2");
            string status = Console.ReadLine();

            Console.WriteLine("Enter a license number");
            string licenseNumber = Console.ReadLine();

            if (Int32.TryParse(status, out int result))
            {
                m_Garage.ChangeVehicleStatus(licenseNumber, (VehicleInGarage.eVehicleStatus)result);
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }

        //Request 4
        public void InflatingWheelToMax()
        {
            Console.WriteLine("Enter a license number");
            string licenseNumber = Console.ReadLine();
            m_Garage.InflatingWheelToMax(licenseNumber);
        }

        //Request 5
        public void FillFuelToFuelVehicles()
        {
            Console.WriteLine("Enter a license number");
            string licenseNumber = Console.ReadLine();

            Console.WriteLine("Enter a Fuel type:\n" +
                              "for Octan98 - press 0\n" +
                              "for Octan96 - press 1\n" +
                              "for Octan95 - press 2\n" +
                              "for Soler - press 3");
            string status = Console.ReadLine();
            if (Int32.TryParse(status, out int result))
            {
                Console.WriteLine("Enter How many liters to fill");
                string liters = Console.ReadLine();
                if (float.TryParse(liters, out float literToAdd) && 0 < literToAdd)
                {
                    try
                    {
                        m_Garage.FillFuelToFuelVehicles(licenseNumber, (eFuelType)result, literToAdd);
                    }
                    catch (Exception valueOutOfRangeException)
                    {
                        Console.WriteLine("You tried to fill more capacity");
                        throw;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }


        //Request 6
        public void ChargingElectricVehicle()
        {

        }

        //Request 7
        public void ShowAllDetails()
        {

        }
    }
}