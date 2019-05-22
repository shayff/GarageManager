﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleTicket
    {
        public enum eVehicleStatus { InRepair, Repaired, Paid }

        private eVehicleStatus m_VehicleStatus = eVehicleStatus.InRepair;
        private string m_OwnerName;
        private string m_PhoneNumber;

        /*Properties*/
        public eVehicleStatus VehicleStatus
        {
            set { m_VehicleStatus = value; }
            get { return m_VehicleStatus; }
        }
    }
}