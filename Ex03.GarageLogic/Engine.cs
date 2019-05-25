using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eFuelType { Octan95, Octan96, Octan98, Soler, Electricity };

    public class Engine
    {
        const string k_ErrorTooMuchFuel = "You try to add to much fuel";
        const string k_ErrorWrongTypeOfFuel = "You try to add wrong type of fuel";

        private eFuelType m_FuelType;
        private float m_CurrentEnergyCapacity;
        private readonly float r_MaxEnergyCapacity;

        public Engine(eFuelType i_EngineType, float i_MaxEnergyCapacity)
        {
            m_CurrentEnergyCapacity = 0;
            m_FuelType = i_EngineType;
            r_MaxEnergyCapacity = i_MaxEnergyCapacity;
        }

        public float CurrentEnergyCapacity
        {
            get
            {
                return m_CurrentEnergyCapacity;
            }
        }
        public float MaxEnergyCapacity
        {
            get { return r_MaxEnergyCapacity; }
        }

        public void FillEnergy(int i_FuelTypeToAdd, float i_AmountToAdd)
        {
            if (Enum.IsDefined(typeof(eFuelType), i_FuelTypeToAdd))
            {
                if ((eFuelType)i_FuelTypeToAdd == m_FuelType)
                {
                    if (i_AmountToAdd + m_CurrentEnergyCapacity <= r_MaxEnergyCapacity)
                    {
                        m_CurrentEnergyCapacity += i_AmountToAdd;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(0, r_MaxEnergyCapacity, k_ErrorTooMuchFuel);
                    }
                }
                else
                {
                    throw new ArgumentException(k_ErrorWrongTypeOfFuel);
                }
            }
            else
            {
                throw new ArgumentException("No such an option");
            }
        }

        private float fuelInPercent()
        {
            return m_CurrentEnergyCapacity / r_MaxEnergyCapacity * 100;
        }

        public override string ToString()
        {
            return String.Format("Fuel type: {0}\nCurrent Fuel Capacity: {1}%\n", m_FuelType, fuelInPercent());
        }

    }
}
