﻿using System;
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

        public static void test()
        {
            /*
            Vehicle test_FuelMotor = new MotorCycle(eEngineType.Fuel);
            Vehicle test_ElectricMotor = new MotorCycle(eEngineType.Electricity);
            Vehicle test_FuelCar = new Car(eEngineType.Fuel);
            Vehicle test_ElectricCar = new Car(eEngineType.Electricity);
            Vehicle test_Truck = new Truck(eEngineType.Fuel);
            */
        }

        public static Vehicle Create(eVehicleTypes i_VehicleType, string i_NameOfModel, string i_LicenseNumber)
        {
            Vehicle newVehicle = null;
            switch (i_VehicleType)
            {
                case eVehicleTypes.FuelMotorCycle:
                    {
                        newVehicle = new MotorCycle(eEnergyType.Fuel, i_NameOfModel, i_LicenseNumber);
                        break;
                    }
                case eVehicleTypes.ElectricMotorCycle:
                    {
                        newVehicle = new MotorCycle(eEnergyType.Electricity, i_NameOfModel, i_LicenseNumber);
                        break;
                    }
                case eVehicleTypes.FuelCar:
                    {
                        newVehicle = new Car(eEnergyType.Fuel, i_NameOfModel, i_LicenseNumber);
                        break;
                    }
                case eVehicleTypes.ElectricCar:
                    {
                        newVehicle = new Car(eEnergyType.Electricity, i_NameOfModel, i_LicenseNumber);
                        break;
                    }
                case eVehicleTypes.FuelTruck:
                    {
                        newVehicle = new Truck(eEnergyType.Fuel, i_NameOfModel, i_LicenseNumber);
                        break;
                    }
            }
            return newVehicle;
        }

    }
}