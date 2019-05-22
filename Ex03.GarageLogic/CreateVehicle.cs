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
            Vehicle test_FuelMotor = new MotorCycle(eEngineType.Fuel);
            Vehicle test_ElectricMotor = new MotorCycle(eEngineType.Electricity);
            Vehicle test_FuelCar = new Car(eEngineType.Fuel);
            Vehicle test_ElectricyCar = new Car(eEngineType.Electricity);
            Vehicle test_Truck = new Truck(eEngineType.Fuel);
        }


        public static Vehicle Create(eVehicleTypes i_VehicleType)
        {
            Vehicle newVehicle = null;
            switch (i_VehicleType)
            {
                case eVehicleTypes.FuelMotorCycle:
                    {
                        newVehicle = new MotorCycle(eEngineType.Fuel);
                        break;
                    }
                case eVehicleTypes.ElectricMotorCycle:
                    {
                        newVehicle = new MotorCycle(eEngineType.Electricity);
                        break;
                    }
                case eVehicleTypes.FuelCar:
                    {
                        newVehicle = new Car(eEngineType.Fuel);
                        break;
                    }
                case eVehicleTypes.ElectricCar:
                    {
                        newVehicle = new Car(eEngineType.Electricity);
                        break;
                    }
                case eVehicleTypes.FuelTruck:
                    {
                        newVehicle = new Truck(eEngineType.Fuel);
                        break;
                    }
            }
            return newVehicle;
        }

    }
}