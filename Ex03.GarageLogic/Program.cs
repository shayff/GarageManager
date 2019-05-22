using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle test_FuelCar = new Car(Car.eColor.Black, 2, eEngineType.Fuel);
            Vehicle test_ElectricityCar = new Car(Car.eColor.Blue, 2, eEngineType.Electricity);

        }
    }
}
