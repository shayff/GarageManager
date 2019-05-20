﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eFuelType { Octan98, Octan96, Octan95, Soler };
    public class FuelTank : EnergySource
    {
        private float m_CurrentFuelCapacity;
        private float m_MaxFuelCapacity;
        private eFuelType m_FuelType;

        public FuelTank(eFuelType i_FuelType,float i_MaxFuelCapacity)
        {
            m_FuelType = i_FuelType;
            m_MaxFuelCapacity = i_MaxFuelCapacity;
        }
        public override void FillEnergy(float i_FuelLiterToAdd) //, eFuelType i_FuelType)
        {

        }
    }
}