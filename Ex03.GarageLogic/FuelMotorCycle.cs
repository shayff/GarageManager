using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    enum eLicenseType {A,A1,A2,B};
    public class FuelMotorCycle : MotorCycle
    {
        int m_EngineCapacity;
        eLicenseType m_LicenseType;
        
        public FuelMotorCycle() : base(new FuelTank(eFuelType.Octan95,8))
        {
               
        }
    }
}