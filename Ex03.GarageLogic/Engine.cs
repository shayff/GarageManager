﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eEnergyType { Fuel, Electricity };
    public enum eFuelType { Octan98, Octan96, Octan95, Soler, Electricity };


    public class Engine
    {
        const string k_ErrorTooMuchFuel = "You try to add to much fuel";
        const string k_ErrorWrongTypeOfFuel = "You try to add wrong type of fuel";

        private eFuelType m_FuelType;
        private float m_CurrentFuelCapacity;
        private readonly float r_MaxFuelCapacity;

        public  void FillEnergy(eFuelType i_FuelTypeToAdd , float i_AmountToAdd)
        {
            if(i_FuelTypeToAdd == m_FuelType)
            {
                if (i_AmountToAdd + m_CurrentFuelCapacity <= r_MaxFuelCapacity)
                {
                    m_CurrentFuelCapacity += i_AmountToAdd;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, r_MaxFuelCapacity, k_ErrorTooMuchFuel);
                }
            }
            else
            {
                throw new Exception(k_ErrorWrongTypeOfFuel);
            }
        }
    }
}