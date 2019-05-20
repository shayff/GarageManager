using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorCycle : MotorCycle
    {

     public ElectricMotorCycle(): base(new Battery(2))
    }
}