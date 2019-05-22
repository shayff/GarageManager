using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 12;
        private const float k_MaxAirPressure = 26f;

        private bool m_IsDriveDangerousCargo;
        private float m_CargoCapacity;

        //*Properties*//
        public bool IsDriveDangerousCargo
        {
            set { m_IsDriveDangerousCargo = value; }
            get { return m_IsDriveDangerousCargo; }
        }
        public float CargoCapacity
        {
            set { m_CargoCapacity = value; }
            get { return m_CargoCapacity; }
        }
  
       //*ctor**/
        public Truck(eEngineType i_EnergySource, bool i_IsDriveDangerousCargo, float i_CargoCapacity) :base(k_NumberOfWheels, k_MaxAirPressure, i_EnergySource)
        {
           m_IsDriveDangerousCargo = i_IsDriveDangerousCargo;
           m_CargoCapacity = i_CargoCapacity;
        }
    }
}