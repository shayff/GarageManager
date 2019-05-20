using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    enum eLicneceType { A,A1,A2,B}
    public class MotorCycle : Vehicle
    {
        eLicneceType m_LicneceType;
        int m_EngineCapcity;

        public MotorCycle(eEnergySource i_EnergySource) :base(2,33,i_EnergySource)
        {

        }
    }
}