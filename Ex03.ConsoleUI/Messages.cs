using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public static class Messages
    {
        public const string k_MainMenu = "1. Put a new car into the garage\n" +
                              "2. View the list of vehicle license numbers in the garage\n" +
                              "3. Change the condition of a car in the garage\n" +
                              "4. Inflate the air in the wheels of a vehicle to the maximum\n" +
                              "5. T0 Fuel a fuel vehicle\n" +
                              "6. To charge an electric vehicle\n" +
                              "7. View full data of a vehicle by license number\n" +
                              "8. Exit";

        public const string k_NotANumber = "Please type a number";
        public const string k_TooMuchCapacity = "You tried to fill to much capacity";
        public const string k_EnergyDetails = "Enter How many minutes will you charge (Battery time remaining in: {0} Hours {1} Minutes,\nMaximum battery time in: {2} Hours {3} Minutes)";
        public const string k_FuelToAdd = "Enter How many liters to fill (Current fuel quantity: {0},\nMaximum quantity of fuel: {1})";
        public const string k_ThereWasErrorWith = "There was error with:";
        public const string k_EnterLicenseNumber = "Insert owner name please: ";
        public const string k_InsertOwnerName = "Enter a license number";
        public const string k_EnterPhoneNumber = "Enter a phone number of owner (For example 0541234567)";
        public const string k_EnterVehicleModel = "Enter a vehicle model";
        public const string k_GetWheelManufactureName = "Enter The manufacturer's name of the wheels";
        public const string k_EnterCurrentAirPressure = "Enter the current air pressure in the wheels";
        public const string k_WelcomeGarage = "Welcome to garage of Shay and Nelly!\n";
        public const string k_IncorrectInput = "Incorrect input";
        public const string k_LicenseNumberNotFound = "Couldn't find This Car In Garage";
        public const string k_CarAlreadyInGarage = "The car is already in the garage ";
        public const string k_VehicleHasEnterToGarage = "Vehicle sucssefully enter to garage";
        public const string k_ThereAreNoVehicleInGarage = "There are no vehicles in the garage";
        public const string k_AirPressureLevelOutOfRange = "Air Pressure Level was out of Range, please try again:";
        public const string k_WrongOption = "Wrong Option";
        public const string k_ErrorTypeAgain = "Error, type again";
        public const string k_PleaseEnter = "Please enter ";
        public const string k_Error = "Error";
        public const string k_ChooseVehicleStatus = "Enter a Vehicle Status:\n" +
                              "0. for Repaired\n" +
                              "1. for InRepair\n" +
                              "2. for Paid";

        public const string k_ChooseVehicleType = "Insert a car type:\n" +
                              "0. Fuel MotorCycle\n" +
                              "1. Electric motorcycle\n" +
                              "2. Fuel Car\n" +
                              "3. Electric car\n" +
                              "4. Fuel truck";

        public const string k_ChooseVehicleStatusToSee = "How would you like the list?\n" +
                              "0. only InRepair\n" +
                              "1. only Repaired \n" +
                              "2. only Paid\n" +
                              "3. All Status";

        public const string k_ChooseFuelType = "Enter a Fuel type:\n" +
                                                  "0. for Octan95\n" +
                                                  "1. for Octan96\n" +
                                                  "2. for Octan98\n" +
                                                  "3. for Soler";
    }
}
