using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public class Simulator
    {
        public static void Main()
        {
            //this is tesiting
            string[] vehicleTypes = Enum.GetNames(typeof(VehicleType));
            int[] vehicleCapacityByType = new int[vehicleTypes.Length];
            for (int i = 0; i < vehicleTypes.Length; i++)
            {
                Console.Write("\nIntialize the capacity for \"{0}\" type Vehicles : ", vehicleTypes[i]);
                int.TryParse(Console.ReadLine().Trim(), out vehicleCapacityByType[i]);
            }
            ParkingLotSimulater Simulator = new ParkingLotSimulater(vehicleCapacityByType);
            Simulator.StartSimulation();
            Console.ReadKey();
        }
    }
}
