﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class CreateVehicle
    {
        public enum eVehicleTypes
        {
            FuelMotorCycle, ElectricMotorCycle, FuelCar, ElectricCar, FuelTruck
        }

        private const float k_MaxEnergyCapacityFuelMotorCycle = 8f;
        private const float k_MaxEnergyCapacityElectricMotorCycle = 1.4f;
        private const float k_MaxEnergyCapacityFuelCar = 55f;
        private const float k_MaxEnergyCapacityElectricCar = 1.8f;
        private const float k_MaxEnergyCapacityFuelTruck = 110f;

        private const string k_NoSuchAnOption = "There isn't such option of Vehicle";

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
                            newVehicle = new MotorCycle(Engine.eFuelType.Octan95, k_MaxEnergyCapacityFuelMotorCycle);
                            break;
                        }

                    case eVehicleTypes.ElectricMotorCycle:
                        {
                               newVehicle = new MotorCycle(Engine.eFuelType.Electricity, k_MaxEnergyCapacityElectricMotorCycle);
                            break;
                        }

                    case eVehicleTypes.FuelCar:
                        {
                            newVehicle = new Car(Engine.eFuelType.Octan96, k_MaxEnergyCapacityFuelCar);
                            break;
                        }

                    case eVehicleTypes.ElectricCar:
                        {
                            newVehicle = new Car(Engine.eFuelType.Electricity, k_MaxEnergyCapacityElectricCar);
                            break;
                        }

                    case eVehicleTypes.FuelTruck:
                        {
                            newVehicle = new Truck(Engine.eFuelType.Soler, k_MaxEnergyCapacityFuelTruck);
                            break;
                        }
                }

                newVehicle.LicenseNumber = i_LicenseNumber;
                newVehicle.NameOfModel = i_NameOfModel;
            }
            else
            {
                throw new FormatException(k_NoSuchAnOption);
            }

            return newVehicle;
        }
    }
}