using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public class Vehicle
    {
        public String VehicleNumber { get; set; }

        public VehicleType VehicleType { get; set; }

        public Vehicle(String vehicleNumber, VehicleType vehicleType)
        {
            this.VehicleNumber = vehicleNumber;
            this.VehicleType = vehicleType;
        }
    }
}
