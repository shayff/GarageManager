using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eEnergyType { Fuel, Electricity };

    public abstract class EnergySource
    {
        public abstract eEnergyType GetEnergyType();
        public abstract void FillEnergy(float i_EnergyToAdd);

    }
}