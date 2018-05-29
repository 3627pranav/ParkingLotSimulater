using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public enum VehicleType { TwoWheelers, FourWheelers, HeavyVehicles };

    public class ParkingLotSimulater
    {
        public ParkingLot ParkingLot { get; set; }

        public ParkingLotSimulater(params int[] VehicleCapacities)
        {
            this.ParkingLot = new ParkingLot();
            this.ParkingLot.CreateSlots(VehicleCapacities);
        }

        public void StartSimulation()
        {
            while (true)
            {
                Console.WriteLine("Select an Option Given Below : ");
                Console.WriteLine("1) Park Vehicle.");
                Console.WriteLine("2) Unpark Vehicle");
                int.TryParse(Console.ReadLine(), out int selectedOption);
                switch (selectedOption)
                {
                    case 1:
                        this.ParkVehicle();
                        break;
                    case 2:
                        this.UnparkVehicle();
                        break;
                    default:
                        Console.WriteLine("please enter correct option.");
                        break;
                }
            }
        }

        public void ParkVehicle()
        {
            Console.WriteLine("Select an Option Given Below");
            string[] vehicleTypes = Enum.GetNames(typeof(VehicleType));
            for (int i = 0; i < vehicleTypes.Length; i++)
            {
                Console.WriteLine("{0}) press {0} for {1}", i, vehicleTypes[i]);
            }

            int type = Convert.ToInt32(Console.ReadLine().Trim());
            if (type >= vehicleTypes.Count())
            {
                Console.WriteLine("\nSorry Slots are not available for your vehicle type.\n");
                return;
            }

            VehicleType vehicleType = (VehicleType)type;
            Console.WriteLine("Enter your Vehicle Number : ");
            String vehicleNumber = Console.ReadLine();

            bool[] parkingLotStatus = this.ParkingLot.GetParkingLotStatus(vehicleType);
            Console.WriteLine("Present Parking Lot Status is : ");
            int count = 0;

            foreach (var i in parkingLotStatus)
            {
                if (i)
                    Console.WriteLine("{0}) Free", ++count);
                else
                    Console.WriteLine("{0}) Occupied", ++count);
            }

            if (this.ParkingLot.IsSlotAvailable(vehicleType))
            {
                Vehicle vehicle = new Vehicle(vehicleNumber, vehicleType);
                int slotId = this.ParkingLot.GetAvailableSlotIdToPark(vehicleType);
                int ticketId = this.ParkingLot.ParkVehicle(vehicle, slotId);
                this.PrintTicket(ticketId);
            }
            else
            {
                Console.WriteLine("Sorry our Parking Lot is Full.");
            }
        }

        public void UnparkVehicle()
        {
            Console.WriteLine("Enter Your Ticket Number : ");
            int.TryParse(Console.ReadLine(), out int ticketId);
            if (this.ParkingLot.UnparkVehicle(ticketId))
            {
                this.PrintTicket(ticketId);
            }
            else
            {
                Console.WriteLine("This ticket is not valid.");
            }
        }

        public void PrintTicket(int ticketId)
        {
            Ticket ticket = this.ParkingLot.GetTicket(ticketId);
            Console.WriteLine("Your Parking Ticket is :");
            Console.WriteLine("Your Ticket Id is : {0}", ticket.Id);
            Console.WriteLine("Slot Number : {0}", ticket.SlotNumber);
            Console.WriteLine("Vehicle Number : {0}", ticket.VehicleNumber);
            Console.WriteLine("Check In Time : {0}", ticket.InTime);
            Console.WriteLine("Check Out Time : {0}", ticket.OutTime);
        }
    }
}
