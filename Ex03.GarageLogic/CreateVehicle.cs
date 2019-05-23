using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class CreateVehicle
    {
        public enum eVehicleTypes
        {
            FuelMotorCycle,
            ElectricMotorCycle,
            FuelCar,
            ElectricCar,
            FuelTruck
        }

        public static Vehicle Create(eVehicleTypes i_VehicleType, string i_NameOfModel, string i_LicenseNumber,string i_NameOfWheelManufacturer, float i_AirPressureLevel)
        {
            Vehicle newVehicle = null;
            switch (i_VehicleType)
            {
                case eVehicleTypes.FuelMotorCycle:
                    {
                        newVehicle = new MotorCycle(eFuelType.Octan95, i_NameOfModel, i_LicenseNumber, i_NameOfWheelManufacturer, i_AirPressureLevel);
                        break;
                    }
                case eVehicleTypes.ElectricMotorCycle:
                    {
                        newVehicle = new MotorCycle(eFuelType.Electricity, i_NameOfModel, i_LicenseNumber, i_NameOfWheelManufacturer, i_AirPressureLevel);
                        break;
                    }
                case eVehicleTypes.FuelCar:
                    {
                        newVehicle = new Car(eFuelType.Octan96, i_NameOfModel, i_LicenseNumber, i_NameOfWheelManufacturer, i_AirPressureLevel);
                        break;
                    }
                case eVehicleTypes.ElectricCar:
                    {
                        newVehicle = new Car(eFuelType.Electricity, i_NameOfModel, i_LicenseNumber, i_NameOfWheelManufacturer, i_AirPressureLevel);
                        break;
                    }
                case eVehicleTypes.FuelTruck:
                    {
                        newVehicle = new Truck(eFuelType.Soler, i_NameOfModel, i_LicenseNumber, i_NameOfWheelManufacturer, i_AirPressureLevel);
                        break;
                    }
            }
            return newVehicle;
        }

    }
}