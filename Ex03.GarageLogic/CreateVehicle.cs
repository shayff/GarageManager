using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class CreateVehicle
    {
        public enum eVehicleTypes { FuelMotorCycle, ElectricMotorCycle, FuelCar, ElectricCar, FuelTruck }

        private const float k_MaxEnergyCapacityFuelMotorCycle = 8f;
        private const float k_MaxEnergyCapacityElectricMotorCycle = 1.4f;
        private const float k_MaxEnergyCapacityFuelCar = 55f;
        private const float k_MaxEnergyCapacityElectricCar = 1.8f;
        private const float k_MaxEnergyCapacityFuelTruck = 110f;

        public static Vehicle Create(int i_IntVehicleType, string i_NameOfModel, string i_LicenseNumber)
        {
            Vehicle newVehicle = null;
            if (Enum.IsDefined(typeof(eVehicleTypes), i_IntVehicleType))
            {
                eVehicleTypes vehicleType = (eVehicleTypes)i_IntVehicleType;
                switch (vehicleType)
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
                            newVehicle = new Car(eFuelType.Electricity, k_MaxEnergyCapacityElectricCar);
                            break;
                        }
                    case eVehicleTypes.FuelTruck:
                        {
                            newVehicle = new Truck(eFuelType.Soler, k_MaxEnergyCapacityFuelTruck);
                            break;
                        }
                }
                //NT 2
                newVehicle.LicenseNumber = i_LicenseNumber;
                newVehicle.NameOfModel = i_NameOfModel;
            }
            else
            {
                throw new FormatException("There isn't such option of Vehicle");
            }
            return newVehicle;
        }

    }
}