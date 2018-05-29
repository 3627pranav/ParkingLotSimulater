using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public class Slot
    {
        public int Id { get; set; }

        public VehicleType VehicleType { get; set; }

        public bool IsAvailable { get; set; }

        public Vehicle Vehicle { get; set; }

        public Slot(int id, VehicleType type)
        {
            this.Id = id;
            this.VehicleType = type;
            this.IsAvailable = true;
            this.Vehicle = null;
        }
    }
}
