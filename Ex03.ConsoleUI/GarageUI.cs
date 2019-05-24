using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        const string k_WelcomeGarage = "Welcome to garage of Shay and Nelly!\n";
        const string k_CarAlreadyInGarage = "The car is already in the garage ";


        private readonly Garage m_Garage = new Garage();

        public void Start()
        {
            bool flag = true;

            while (flag)
            {
                Console.Clear(); // Clear the screen
                Console.WriteLine(k_WelcomeGarage);
                PrintMainMenu();
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out int result))
                {
                    Console.Clear();

                    switch (result)
                    {
                        case 1:
                            {
                                InsertVehicleToGarage();
                                break;
                            }
                        case 2:
                            {
                                ViewListOfVehicleLicenseNumbers();
                                break;
                            }
                        case 3:
                            {
                                ChangeVehicleStatus();
                                break;
                            }
                        case 4:
                            {
                                InflatingWheelToMax();
                                break;
                            }
                        case 5:
                            {
                                FillFuelToFuelVehicles();
                                break;
                            }
                        case 6:
                            {
                                ChargingElectricVehicle();
                                break;
                            }
                        case 7:
                            {
                                ShowAllDetails();
                                break;
                            }
                        case 8:
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
            Console.WriteLine("Insert a car type:\n" +
                              "0. Fuel MotorCycle\n" +
                              "1. Electric motorcycle\n" +
                              "2. Fuel Car\n" +
                              "3. Electric car\n" +
                              "4. Fuel truck\n");

            string typeOfVehicle = Console.ReadLine();

            if (Int32.TryParse(typeOfVehicle, out int choice))
            {
                Console.WriteLine("Enter a vehicle model");
                string nameOfModel = Console.ReadLine();
                string licenseNumber = AskLicenseNumber();

                if (m_Garage.IsLicenseNumberInGarage(licenseNumber))
                {
                    Console.WriteLine(k_CarAlreadyInGarage);
                }
                else
                {
                    try
                    {
                        Vehicle newVehicle = CreateVehicle.Create((CreateVehicle.eVehicleTypes)choice, nameOfModel, licenseNumber);

                        //*Details wheels*//
                        RequestDetailsWheels(newVehicle.GetMaxAirPressureLevel(), out string o_NameOfWheelManuFacturer, out float o_AirPressureLevel);
                        newVehicle.AddDetailsWheels(o_NameOfWheelManuFacturer, o_AirPressureLevel);

                        Dictionary<string, int> fieldsToSet = GetAdditionalFieldsData(newVehicle.GetListOfAdditionalFields());
                        newVehicle.SetAdditionalFields(fieldsToSet);
                        CreateVehicleInGarage(newVehicle);
                    }
                    catch
                    {
                        Console.WriteLine("Error");
                    }
                }
            }
        }

        //Request 2
        public void ViewListOfVehicleLicenseNumbers()
        {
            Console.WriteLine("How would you like the list?" +
                              "0. only InRepair\n" +
                              "1. only Repaired \n" +
                              "2. only Paid\n" +
                              "3. All Status\n");

            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                try
                {
                    if (result == 3)
                    {
                        List<string> listsGarage = m_Garage.GetVehiclesInGarage();
                        foreach (string licenseNumber in listsGarage)
                        {
                            Console.WriteLine(licenseNumber);
                        }
                    }
                    else
                    {
                        List<string> listsGarage = m_Garage.GetVehiclesInGarageByStatus((VehicleInGarage.eVehicleStatus)result);

                        foreach (string licenseNumber in listsGarage)
                        {
                            Console.WriteLine(licenseNumber);
                        }

                    }
                }
                catch
                {
                    Console.WriteLine("Error");
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

            string licenseNumber = AskLicenseNumber();

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
            string licenseNumber = AskLicenseNumber();
            m_Garage.InflatingWheelToMax(licenseNumber);
        }

        //Request 5
        public void FillFuelToFuelVehicles()
        {
            string licenseNumber = AskLicenseNumber();

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
                    catch (ValueOutOfRangeException)
                    {
                        Console.WriteLine("You tried to fill more capacity");
                    }
                    catch
                    {
                        Console.WriteLine("Error");
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
            string licenseNumber = AskLicenseNumber();

            Console.WriteLine("Enter How many minutes will you charge");
            string minutesStr = Console.ReadLine();

            if (float.TryParse(minutesStr, out float minutes))
            {
                try
                {
                    float hours = minutes / 60;
                    m_Garage.ChargingElectricVehicle(licenseNumber, hours);
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine("You tried to fill more capacity");
                }
                catch
                {
                    Console.WriteLine("Error");
                }
            }
        }

        //Request 7
        public void ShowAllDetails()
        {
            string licenseNumber = AskLicenseNumber();

            try
            {
                string toPrintAllDetails = m_Garage.ShowAllDetails(licenseNumber);
                Console.WriteLine(toPrintAllDetails);
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        public void PrintMainMenu()
        {
            Console.WriteLine("1. Put a new car into the garage\n" +
                                  "2. View the list of vehicle license numbers in the garage\n" +
                                  "3. Change the condition of a car in the garage\n" +
                                  "4. Inflate the air in the wheels of a vehicle to the maximum\n" +
                                  "5. Fuel a vehicle powered by fuel\n" +
                                  "6. To charge an electric vehicle\n" +
                                  "7. View full data of a vehicle by license number\n" +
                                  "8. Exit");
        }

        public void SetAdditionalFields()
        {


        }

        public Dictionary<string, int> GetAdditionalFieldsData(Dictionary<string, string> i_AdditionalFieldsName)
        {
            Dictionary<string, int> additionalFieldsData = new Dictionary<string, int>();
            foreach (KeyValuePair<string, string> field in i_AdditionalFieldsName)
            {
                int fieldData = GetFieldData(field.Value);
                additionalFieldsData.Add(field.Key, fieldData);
            }
            return additionalFieldsData;
        }

        public int GetFieldData(string i_FieldName) //NT check if the input is ok
        {
            Console.Write("Please enter ");
            Console.WriteLine(i_FieldName);
            string fieldData = Console.ReadLine();
            Int32.TryParse(fieldData, out int res);
            return res;
        }

        public void CreateVehicleInGarage(Vehicle i_NewVehicle)
        {

            Console.WriteLine("Enter the owner's name");
            string ownerName = Console.ReadLine();

            Console.WriteLine("Enter the Phone Number");
            string phoneNumber = Console.ReadLine();

            if (Int32.TryParse(phoneNumber, out int number))
            {
                m_Garage.InsertVehicleToGarage(ownerName, phoneNumber, i_NewVehicle);
            }
            else
            {
                Console.WriteLine("Error");
            }

        }

        public void RequestDetailsWheels(float i_MaxAirPressureLevel, out string o_NameOfWheelManufacturer, out float o_AirPressureLevel)
        {
            bool inputCorrectly = true;
            o_AirPressureLevel = 0;
            while (inputCorrectly)
            {
                Console.WriteLine("Enter the current air pressure in the wheels " +
                                  "(The maximum is- " + i_MaxAirPressureLevel + ") ");
                string airPressureLevelStr = Console.ReadLine();

                float.TryParse(airPressureLevelStr, out float airPressureLevel);

                if (airPressureLevel <= i_MaxAirPressureLevel && airPressureLevel >= 0)
                {
                    o_AirPressureLevel = airPressureLevel;
                    inputCorrectly = false;
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again ");
                }

            }

            Console.WriteLine("EnterThe manufacturer's name of the wheels");

            o_NameOfWheelManufacturer = Console.ReadLine();

        }

        public string AskLicenseNumber()
        {
            Console.WriteLine("Enter a license number");
            return Console.ReadLine();
        }
    }


}