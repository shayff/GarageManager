using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eEnergySource { Fuel, Electricity };
    public class EnergySource
    {
        public virtual void FillEnergy(float i_EnergyToAdd)
        {

        }
    }
}