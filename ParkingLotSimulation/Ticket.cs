using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public class Ticket
    {
        public int Id { get; set; }

        public String VehicleNumber { get; set; }

        public int SlotNumber { get; set; }

        public DateTime InTime { get; set; }

        public DateTime? OutTime { get; set; }

        public Ticket(int id, int slotNumber, String vehicleNumber)
        {
            this.Id = id;
            this.VehicleNumber = vehicleNumber;
            this.SlotNumber = slotNumber;
            this.InTime = DateTime.Now;
            this.OutTime = null;
        }
    }
}
