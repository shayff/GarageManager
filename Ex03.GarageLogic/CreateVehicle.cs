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

        private const float k_MaxEnergyCapacityFuelMotorCycle = 1.8f;
        private const float k_MaxEnergyCapacityElectricMotorCycle = 6f;
        private const float k_MaxEnergyCapacityFuelCar = 3.2f;
        private const float k_MaxEnergyCapacityElectricCar = 45f;
        private const float k_MaxEnergyCapacityFuelTruck = 115f;

        public static Vehicle Create(eVehicleTypes i_VehicleType, string i_NameOfModel, string i_LicenseNumber)
        {
            Vehicle newVehicle = null;
            switch (i_VehicleType)
            {
                case eVehicleTypes.FuelMotorCycle:
                    {
                        newVehicle = new MotorCycle(eFuelType.Octan95, k_MaxEnergyCapacityFuelMotorCycle);
                        break;
                    }
                case eVehicleTypes.ElectricMotorCycle:
                    {
                        newVehicle = new MotorCycle(eFuelType.Electricity, k_MaxEnergyCapacityElectricMotorCycle);
                        break;
                    }
                case eVehicleTypes.FuelCar:
                    {
                        newVehicle = new Car(eFuelType.Octan96, k_MaxEnergyCapacityFuelCar);
                        break;
                    }
                case eVehicleTypes.ElectricCar:
                    {
                        newVehicle = new Car(eFuelType.Electricity,k_MaxEnergyCapacityElectricCar);
                        break;
                    }
                case eVehicleTypes.FuelTruck:
                    {
                        newVehicle = new Truck(eFuelType.Soler, k_MaxEnergyCapacityFuelTruck);
                        break;
                    }
            }
            newVehicle.LicenseNumber = i_NameOfModel;
            newVehicle.NameOfModel = i_LicenseNumber;
            return newVehicle;
        }

    }
}