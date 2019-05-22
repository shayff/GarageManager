using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eEnergyType { Fuel, Electricity };
    public enum eFuelType { Octan98, Octan96, Octan95, Soler, Electricity };


    public class Engine
    {
        private eFuelType m_FuelType;

        public  void FillEnergy(eFuelType i_FuelTypeToAdd , float i_AmountToAdd)
        {
            if(i_FuelTypeToAdd == m_FuelType)
            {

            }
            else
            {
                //throw not same
            }
        }
    }
}
