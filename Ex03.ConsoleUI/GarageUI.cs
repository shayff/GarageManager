﻿using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private Garage m_Garage = new Garage();

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
                              "for A Fuel MotorCycle press 1\n" +
                              "for A Electric motorcycle press 2\n " +
                              "for A Fuel Car press 3\n" +
                              "for A Electric car press 4\n" +
                              "for A Fuel truck press 5\n");

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
                    switch (choice)
                    {
                        case '1':
                            {
                                CreateVehicle.Create(CreateVehicle.eVehicleTypes.FuelMotorCycle, nameOfModel,
                                    licenseNumber);
                                break;
                            }

                        case '2':
                            {
                                CreateVehicle.Create(CreateVehicle.eVehicleTypes.ElectricMotorCycle, nameOfModel,
                                    licenseNumber);
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

        //Request 2
        public void ViewListOfVehicleLicenseNumbers()
        {
            Console.WriteLine("For All Status - press 1\n" +
                              "For only InRepair - press 2\n" +
                              "For only Repaired - press 3\n" +
                              "For only Paid - press 4\n");

            string input = Console.ReadLine();
            if (Int32.TryParse(input, out int result))
            {
                Console.Clear(); // Clear the screen

                switch (result)
                {
                    case '1':
                        {
                            m_Garage.GetVehiclesInGarage();
                            break;
                        }

                    case '2':
                        {
                            m_Garage.GetVehiclesInGarageByStatus(VehicleInGarage.eVehicleStatus.InRepair);
                            break;
                        }

                    case '3':
                        {
                            m_Garage.GetVehiclesInGarageByStatus(VehicleInGarage.eVehicleStatus.Repaired);
                            break;
                        }

                    case '4':
                        {
                            m_Garage.GetVehiclesInGarageByStatus(VehicleInGarage.eVehicleStatus.Paid);
                            break;
                        }
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
                              "for Repaired - press 1\n" +
                              "for InRepair - press 2\n" +
                              "for Paid - press 3");
            string status = Console.ReadLine();

            Console.WriteLine("Enter a license number");
            string licenseNumber = Console.ReadLine();

            if (Int32.TryParse(status, out int result))
            {
                switch (result)
                {
                    case '1':
                        {
                            m_Garage.ChangeVehicleStatus(licenseNumber, VehicleInGarage.eVehicleStatus.Repaired);
                            break;
                        }

                    case '2':
                        {
                            m_Garage.ChangeVehicleStatus(licenseNumber, VehicleInGarage.eVehicleStatus.InRepair);
                            break;
                        }

                    case '3':
                        {
                            m_Garage.ChangeVehicleStatus(licenseNumber, VehicleInGarage.eVehicleStatus.Paid);
                            break;
                        }
                }
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

            m_Garage.InflatingWheelToMaxs(licenseNumber);

        }

        //Request 5
        public void FillFuelToFuelVehicles()
        {
            //  public enum eFuelType { Octan98, Octan96, Octan95, Soler };
            Console.WriteLine("Enter a license number");
            string licenseNumber = Console.ReadLine();


            Console.WriteLine("Enter a Fuel type:\n" +
                              "for Octan98 - press 1\n" +
                              "for Octan96 - press 2\n" +
                              "for Octan95 - press 3\n" +
                              "for Soler - press 4");
            string status = Console.ReadLine();
            if (Int32.TryParse(status, out int result))
            {
                Console.WriteLine("Enter How many liters to fill");
                string liters = Console.ReadLine();
                if (float.TryParse(liters, out float literToAdd))
                {
                    switch (result)
                    {
                        case '1':
                            {
                                m_Garage.FillFuelToFuelVehicles(licenseNumber, eFuelType.Octan98, literToAdd);
                                break;
                            }

                        case '2':
                            {
                                m_Garage.FillFuelToFuelVehicles(licenseNumber, eFuelType.Octan96, literToAdd);
                                break;
                            }

                        case '3':
                            {
                                m_Garage.FillFuelToFuelVehicles(licenseNumber, eFuelType.Octan95, literToAdd);
                                break;
                            }

                        case '4':
                            {
                                m_Garage.FillFuelToFuelVehicles(licenseNumber, eFuelType.Soler, literToAdd);
                                break;
                            }
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