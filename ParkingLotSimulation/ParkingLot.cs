using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public class ParkingLot
    {
        public List<Slot> Slots { get; set; }

        public List<Ticket> Tickets { get; set; }

        public ParkingLot()
        {
            this.Slots = new List<Slot>();
            this.Tickets = new List<Ticket>();
        }

        public void CreateSlots(int[] requiredSlots)
        {
            for (int i = 0; i < requiredSlots.Max(); i++)
            {
                if (i < requiredSlots[0])
                    this.Slots.Add(new Slot(Slots.Count+1, VehicleType.TwoWheelers));
                if (i < requiredSlots[1])
                    this.Slots.Add(new Slot(Slots.Count + 1, VehicleType.FourWheelers));
                if (i < requiredSlots[2])
                    this.Slots.Add(new Slot(Slots.Count + 1, VehicleType.HeavyVehicles));
            }
        }

        public bool[] GetParkingLotStatus(VehicleType vehicleType)
        {
            var Status = this.Slots
                        .Where(n => n.VehicleType == vehicleType)
                        .Select(n => n.IsAvailable)
                        .ToArray();
            return Status;
        }

        public bool IsSlotAvailable(VehicleType vehicleType)
        {
            var Count = this.Slots
                        .Where(n => n.VehicleType == vehicleType && n.IsAvailable == true)
                        .Count();
            if (Count > 0)
                return true;
            else
                return false;
        }

        public int GetAvailableSlotIdToPark(VehicleType vehicleType)
        {
            int slotId = this.Slots
                        .First(n => n.VehicleType == vehicleType && n.IsAvailable == true).Id;
            return slotId;
        }

        public int ParkVehicle(Vehicle vehicle, int slotId)
        {
            Slot s = this.Slots
                    .First(n => n.Id == slotId);
            s.Vehicle = vehicle;
            s.IsAvailable = false;
            Ticket t = new Ticket(Tickets.Count + 1, slotId, vehicle.VehicleNumber);
            this.Tickets.Add(t);
            return t.Id;
        }

        public bool UnparkVehicle(int ticketId)
        {
            Ticket ticket = this.GetTicket(ticketId);
            if(ticket != null)
            if (ticket.OutTime == null)
            {
                int slotId = this.Tickets
                            .First(n => n.Id == ticketId).SlotNumber;
                Slot s = this.Slots
                        .First(n => n.Id == slotId);
                s.Vehicle = null;
                s.IsAvailable = true;
                ticket.OutTime = DateTime.Now;
                return true;
            }
            return false;
        }

        public Ticket GetTicket(int ticketId)
        {
            try
            {
                var ticket = this.Tickets
                            .First(n => n.Id == ticketId);
                return ticket;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}