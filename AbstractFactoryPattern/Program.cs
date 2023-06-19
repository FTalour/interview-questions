using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public static class Customer
    {
        public static VehicleType GetVehicleType(string customerID)
        {
            return VehicleType.CAR;
        }
    }

    public class Journey
    {
        public IVehicle rentedVehicle;
        public Journey(string customerID)
        {
            VehicleType vType = Customer.GetVehicleType(customerID);
            /*Here is the late binding. Compiler doesn't know the type of the object except that it implements the IVehicle interface*/
            rentedVehicle = VehicleSupplier.GetVehicle(vType);
        }
        //Method for beginning the journey
        public void BeginJourney()
        {
            if (rentedVehicle != null)
            {
                rentedVehicle.Drive();
            }
        }
        //Method for parking the vehicle
        public void ParkTheVehicle()
        {
            if (rentedVehicle != null)
            {
                rentedVehicle.Park();
            }
        }
    }

    //enum of the vehicle types
    public enum VehicleType { CAR = 1, TRUCK, BIKE };

    //The class which returns the new vehicle instance depending on the //vehicle type
    public class VehicleSupplier
    {
        public static IVehicle GetVehicle(VehicleType vType)
        {
            switch (vType)
            {
                case VehicleType.CAR:
                    return new Car();
                case VehicleType.TRUCK:
                    return new Truck();
                case VehicleType.BIKE:
                    return new Bike();
            }
            return null;
        }
    }
    //The interface which will be implemented by Car, Truck and Bike //classes
    public interface IVehicle
    {
        void Drive();
        void Park();
    }
    public class Car : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("I am driving a car");
        }

        public void Park()
        {
            Console.WriteLine("I am parking a car");
        }
    }
    public class Truck : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("I am driving a truck");
        }

        public void Park()
        {
            Console.WriteLine("I am parking a truck");
        }
    }
    public class Bike : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("I am driving a bike");
        }

        public void Park()
        {
            Console.WriteLine("I am parking a bike");
        }
    }
}
