﻿using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private const int k_MinutesInOneHour = 60;
        private const int k_PhoneNumberLength = 10;
        private readonly Garage r_Garage = new Garage();

        public void Start()
        {
            bool run = true;

            while (run)
            {
                Console.Clear(); // Clear the screen
                Console.WriteLine(Messages.k_WelcomeGarage);
                printMainMenu();
                string getUserChoose = Console.ReadLine();

                if (int.TryParse(getUserChoose, out int o_result))
                {
                    Console.Clear();

                    switch (o_result)
                    {
                        case 1:
                            {
                                insertVehicleToGarage();
                                break;
                            }

                        case 2:
                            {
                                viewListOfVehicleLicenseNumbers();
                                break;
                            }

                        case 3:
                            {
                                changeVehicleStatus();
                                break;
                            }

                        case 4:
                            {
                                inflatingWheelToMax();
                                break;
                            }

                        case 5:
                            {
                                fillFuelToFuelVehicles();
                                break;
                            }

                        case 6:
                            {
                                chargingElectricVehicle();
                                break;
                            }

                        case 7:
                            {
                                showAllDetails();
                                break;
                            }

                        case 8:
                            {
                                run = false;
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine(Messages.k_IncorrectInput);
                }

                Console.WriteLine("Press Any key to back to main menu");
                Console.ReadKey();
            }
        }

        private void printMainMenu()
        {
            Console.WriteLine(Messages.k_MainMenu);
        }

        // Request 1
        private void insertVehicleToGarage()
        {
            Console.Clear();

            string ownerName = getOwnerName();
            string ownerPhoneNumber = getPhoneNumberFromUser();
            string licenseNumber = getLicenseNumber();

            if (r_Garage.IsLicenseNumberInGarage(licenseNumber))
            {
                Console.WriteLine(Messages.k_CarAlreadyInGarage);
            }
            else
            {
                string nameOfModel = getVehicleModelFromUser();
                int vehicleType = getVehicleTypeFromUser();

                try
                {
                    Vehicle newVehicle = CreateVehicle.Create(vehicleType, nameOfModel, licenseNumber);
                    setAdditionalFields(newVehicle);
                    getWheelsDetails(newVehicle);
                    r_Garage.InsertVehicleToGarage(ownerName, ownerPhoneNumber, newVehicle);
                    Console.WriteLine(Messages.k_VehicleHasEnterToGarage);
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
            }
        }

        // Request 2
        private void viewListOfVehicleLicenseNumbers()
        {
            bool isVehiclesInGarageEmpty = r_Garage.VehiclesInGarage.Count == 0;

            if (isVehiclesInGarageEmpty)
            {
                Console.WriteLine(Messages.k_ThereAreNoVehicleInGarage);
            }
            else
            {
                int i = 0;
                Console.WriteLine(Messages.k_ChooseVehicleStatusToSee);

                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    try
                    {
                        if (result == 3)
                        {
                            List<string> listsGarage = r_Garage.GetVehiclesInGarage();
                            foreach (string licenseNumber in listsGarage)
                            {
                                Console.WriteLine(i++ + "." + licenseNumber);
                            }
                        }
                        else
                        {
                            try
                            {
                                List<string> listsGarage = r_Garage.GetVehiclesInGarageByStatus(result);

                                foreach (string licenseNumber in listsGarage)
                                {
                                    Console.WriteLine(licenseNumber);
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine(Messages.k_WrongOption);
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine(Messages.k_Error);
                    }
                }
                else
                {
                    Console.WriteLine(Messages.k_IncorrectInput);
                }
            }
        }

        // Request 3
        private void changeVehicleStatus()
        {
            Console.WriteLine(Messages.k_ChooseVehicleStatus);
            string status = Console.ReadLine();

            string licenseNumber = getLicenseNumber();
            try
            {
                if (int.TryParse(status, out int result))
                {
                    r_Garage.ChangeVehicleStatus(licenseNumber, result);
                }
                else
                {
                    Console.WriteLine(Messages.k_IncorrectInput);
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine(Messages.k_WrongOption);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine(Messages.k_LicenseNumberNotFound);
            }
        }

        // Request 4
        private void inflatingWheelToMax()
        {
            string licenseNumber = getLicenseNumber();
            licenseNumber = checkWhiteSpace(licenseNumber);
            try
            {
                r_Garage.InflatingWheelToMax(licenseNumber);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine(Messages.k_LicenseNumberNotFound);
            }
        }

        // Request 5
        private void fillFuelToFuelVehicles()
        {
            string licenseNumber = getLicenseNumber();

            Console.WriteLine(Messages.k_ChooseFuelType);
            string status = Console.ReadLine();
            if (int.TryParse(status, out int result) && r_Garage.IsLicenseNumberInGarage(licenseNumber))
            {
                r_Garage.GetDetailsEnergyCapacity(licenseNumber, out float o_CurrentEnergyCapacity, out float o_MaxEnergyCapacity);
                Console.WriteLine(string.Format(Messages.k_FuelToAdd, o_CurrentEnergyCapacity, o_MaxEnergyCapacity));

                string liters = Console.ReadLine();
                if (float.TryParse(liters, out float literToAdd))
                {
                    try
                    {
                        r_Garage.FillFuelToFuelVehicles(licenseNumber, result, literToAdd);
                    }
                    catch (ValueOutOfRangeException)
                    {
                        Console.WriteLine(Messages.k_TooMuchCapacity);
                    }
                    catch (ArgumentException argumentException)
                    {
                        Console.WriteLine(argumentException.Message);
                    }
                }
                else
                {
                    Console.WriteLine(Messages.k_IncorrectInput);
                }
            }
            else
            {
                Console.WriteLine(Messages.k_IncorrectInput);
            }
        }

        // Request 6
        private void chargingElectricVehicle()
        {
            string licenseNumber = getLicenseNumber();
            if (r_Garage.IsLicenseNumberInGarage(licenseNumber))
            {
                r_Garage.GetDetailsEnergyCapacity(licenseNumber, out float o_CurrentEnergyCapacity, out float o_MaxEnergyCapacity);
                printEnergyDetails(o_CurrentEnergyCapacity, o_MaxEnergyCapacity);
                string minutesStr = Console.ReadLine();

                if (float.TryParse(minutesStr, out float minutes))
                {
                    try
                    {
                        float hours = minutes / k_MinutesInOneHour;
                        r_Garage.ChargingElectricVehicle(licenseNumber, hours);
                    }
                    catch (ValueOutOfRangeException)
                    {
                        Console.WriteLine(Messages.k_TooMuchCapacity);
                    }
                    catch
                    {
                        Console.WriteLine(Messages.k_Error);
                    }
                }
            }
            else
            {
                Console.WriteLine(Messages.k_LicenseNumberNotFound);
            }
        }

        private void printEnergyDetails(float o_CurrentEnergyCapacity, float o_MaxEnergyCapacity)
        {
            getTimeInHoursAndMinute(o_CurrentEnergyCapacity, out int o_CurrentEnergyHours, out int o_CurrentEnergyMinutes);
            getTimeInHoursAndMinute(o_MaxEnergyCapacity, out int o__MaxEnergyHours, out int o__MaxEnergyMinutes);
            Console.WriteLine(string.Format(Messages.k_EnergyDetails, o_CurrentEnergyHours, o_CurrentEnergyMinutes, o__MaxEnergyHours, o__MaxEnergyMinutes));
        }

        // Request 7
        private void showAllDetails()
        {
            bool isVehiclesInGarageEmpty = r_Garage.VehiclesInGarage.Count == 0;

            if (isVehiclesInGarageEmpty)
            {
                Console.WriteLine(Messages.k_ThereAreNoVehicleInGarage);
            }
            else
            {
                string licenseNumber = getLicenseNumber();
                licenseNumber = checkWhiteSpace(licenseNumber);
                try
                {
                    Console.WriteLine(r_Garage.ShowAllDetails(licenseNumber));
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine(Messages.k_LicenseNumberNotFound);
                }
            }
        }

        // *Getting *//
        private void setAdditionalFields(Vehicle i_NewVehicle)
        {
            Dictionary<string, string> fieldsToSet = getAdditionalFieldsData(i_NewVehicle.GetListOfAdditionalFields());
            try
            {
                i_NewVehicle.SetAdditionalFields(fieldsToSet);
            }
            catch (FormatException field)
            {
                Console.WriteLine(Messages.k_ThereWasErrorWith);
                Console.WriteLine(field.Message);
                setAdditionalFields(i_NewVehicle);
            }
        }

        private string getPhoneNumberFromUser()
        {
            Console.WriteLine(Messages.k_EnterPhoneNumber);
            string phoneNumber = Console.ReadLine();

            while (phoneNumber.Length != k_PhoneNumberLength || !int.TryParse(phoneNumber, out int result))
            {
                Console.WriteLine(Messages.k_ErrorTypeAgain);
                phoneNumber = Console.ReadLine();
            }

            return checkSpace(phoneNumber);
        }

        private string getOwnerName()
        {
            Console.WriteLine(Messages.k_EnterLicenseNumber);
            string ownerName = Console.ReadLine();
            bool isDigitPresent = IsContainNumber(ownerName);
            while (ownerName.Length == 0 || isDigitPresent)
            {
                Console.WriteLine(Messages.k_ErrorTypeAgain);
                ownerName = Console.ReadLine();
                isDigitPresent = IsContainNumber(ownerName);
            }

            return checkWhiteSpace(ownerName);
        }

        private string getLicenseNumber()
        {
            Console.WriteLine(Messages.k_InsertOwnerName);
            string licenseNumber = Console.ReadLine();
            licenseNumber = checkSpace(licenseNumber);

            return checkWhiteSpace(licenseNumber);
        }

        private Dictionary<string, string> getAdditionalFieldsData(Dictionary<string, string> i_AdditionalFieldsName)
        {
            Dictionary<string, string> additionalFieldsData = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> field in i_AdditionalFieldsName)
            {
                string fieldData = getFieldData(field.Value);
                additionalFieldsData.Add(field.Key, fieldData);
            }

            return additionalFieldsData;
        }

        private string getFieldData(string i_FieldName)
        {
            Console.Write(Messages.k_PleaseEnter);
            Console.WriteLine(i_FieldName);
            string fieldData = Console.ReadLine();
            fieldData = checkWhiteSpace(fieldData);
            return fieldData;
        }

        private string getVehicleModelFromUser()
        {
            Console.WriteLine(Messages.k_EnterVehicleModel);
            string nameOfModel = Console.ReadLine();

            return checkWhiteSpace(nameOfModel);
        }

        private int getVehicleTypeFromUser()
        {
            Console.WriteLine(Messages.k_ChooseVehicleType);
            string typeOfVehicle = Console.ReadLine();

            if (int.TryParse(typeOfVehicle, out int choice))
            {
                return choice;
            }
            else
            {
                Console.WriteLine(Messages.k_NotANumber);
                return getVehicleTypeFromUser();
            }
        }

        private void getWheelsDetails(Vehicle i_Vehicle)
        {
            bool inputCorrectly = true;

            Console.WriteLine(Messages.k_GetWheelManufactureName);
            string nameOfWheelManufacturer = Console.ReadLine();
            bool iscIsContainNumber = IsContainNumber(nameOfWheelManufacturer);

            while (iscIsContainNumber)
            {
                Console.WriteLine(Messages.k_ErrorTypeAgain);
                nameOfWheelManufacturer = Console.ReadLine();
                iscIsContainNumber = IsContainNumber(nameOfWheelManufacturer);
            }

            nameOfWheelManufacturer = checkWhiteSpace(nameOfWheelManufacturer);

            while (inputCorrectly)
            {
                try
                {
                    Console.WriteLine(Messages.k_EnterCurrentAirPressure + " (The maximum is- " + i_Vehicle.MaxAirPressureLevel + ")");
                    string airPressureLevelStr = Console.ReadLine();

                    inputCorrectly = float.TryParse(airPressureLevelStr, out float o_AirPressureLevel);
                    if (!inputCorrectly)
                    {
                        Console.WriteLine(Messages.k_IncorrectInput);
                    }
                    else
                    {
                        i_Vehicle.InitWheels(o_AirPressureLevel, nameOfWheelManufacturer);
                        inputCorrectly = false;
                    }
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine(Messages.k_AirPressureLevelOutOfRange);
                    inputCorrectly = true;
                }
                catch (Exception)
                {
                    Console.WriteLine(Messages.k_IncorrectInput);
                }
            }
        }

        private void getTimeInHoursAndMinute(float i_Number, out int o_Hours, out int o_Minutes)
        {
            o_Hours = (int)Math.Floor(i_Number);
            o_Minutes = (int)((i_Number * k_MinutesInOneHour) - (o_Hours * k_MinutesInOneHour));
        }

        // *checkInput* //
        private string checkSpace(string i_toCheck)
        {
            bool space = i_toCheck.Contains(" ");
            while (space)
            {
                Console.WriteLine(Messages.k_ErrorTypeAgain);
                i_toCheck = Console.ReadLine();
                space = i_toCheck.Contains(" ");
            }

            return i_toCheck;
        }

        private string checkWhiteSpace(string i_toCheck)
        {
            while (string.IsNullOrEmpty(i_toCheck))
            {
                Console.WriteLine(Messages.k_ErrorTypeAgain);
                i_toCheck = Console.ReadLine();
            }

            return i_toCheck;
        }

        public bool IsContainNumber(string i_String)
        {
            bool result = true;

            foreach (char ch in i_String)
            {
                if (char.IsDigit(ch))
                {
                    result = false;
                }
            }

            return !result;
        }

    }
}