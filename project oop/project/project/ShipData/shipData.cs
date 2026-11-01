using System;

namespace InternationalPortManagement
{
    public class Ship
    {
        // Ship Information
        public string ShipId;
        public string ShipName;
        public string ShipCountry;
        public string ShipRegion;
        public string ShipCaptain;
        public string ShipType;
        public string ShipOwnership;

        // Cargo Information
        public string CargoType;
        public int CargoQuantity;

        // Ship Status
        public int ShipStatus;
        public int SuspiciousShip;

        // Crew Information
        public int Crews;

        // Financial Information
        public float Tariff;


        // Parameterized Constructor
        public Ship(
            string shipId,
            string shipName,
            string shipCountry,
            string shipRegion,
            string shipCaptain,
            string shipType,
            string shipOwnership,
            string cargoType,
            int cargoQuantity,
            int shipStatus,
            int suspiciousShip,
            int crews,
            float tariff)
        {
            ShipId = shipId;
            ShipName = shipName;
            ShipCountry = shipCountry;
            ShipRegion = shipRegion;
            ShipCaptain = shipCaptain;
            ShipType = shipType;
            ShipOwnership = shipOwnership;

            CargoType = cargoType;
            CargoQuantity = cargoQuantity;

            ShipStatus = shipStatus;
            SuspiciousShip = suspiciousShip;

            Crews = crews;
            Tariff = tariff;
        }


        // Display Ship Information
        public void Display()
        {
            Console.WriteLine("Ship ID: " + ShipId);
            Console.WriteLine("Ship Name: " + ShipName);
            Console.WriteLine("Country: " + ShipCountry);
            Console.WriteLine("Region: " + ShipRegion);
            Console.WriteLine("Captain: " + ShipCaptain);
            Console.WriteLine("Ship Type: " + ShipType);
            Console.WriteLine("Ownership: " + ShipOwnership);

            Console.WriteLine("Cargo Type: " + CargoType);
            Console.WriteLine("Cargo Quantity: " + CargoQuantity);

            Console.WriteLine("Ship Status: " + GetStatusText());

            Console.WriteLine("Suspicious: " + SuspiciousShip);
            Console.WriteLine("Crew Members: " + Crews);

            Console.WriteLine("Tariff: " + Tariff);
        }


        // Convert Numeric Status into Text
        public string GetStatusText()
        {
            if (ShipStatus == 0)
            {
                return "Pending";
            }
            else if (ShipStatus == 1)
            {
                return "Approved";
            }
            else if (ShipStatus == 2)
            {
                return "Rejected";
            }
            else
            {
                return "Unknown";
            }
        }
    }
}