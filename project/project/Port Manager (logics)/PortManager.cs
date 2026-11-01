using System;
using System.Collections.Generic;

namespace InternationalPortManagement
{
    public class PortManager
    {
        // List to store all ships
        public List<Ship> Ships;

        // FileManager object
        private FileManager fileManager;


        // Constructor
        public PortManager()
        {
            Ships = new List<Ship>();

            fileManager = new FileManager();

            // Load previously saved ships
            Ships = fileManager.LoadAll();
        }


        // Save ships into file
        public void Save()
        {
            fileManager.SaveAll(Ships);
        }


        // CREATE: Add new ship
        public void AddShip(Ship ship)
        {
            Ships.Add(ship);

            Save();

            Console.WriteLine("Ship Added Successfully!");
        }


        // READ: Find ship by ID
        public Ship FindById(string id)
        {
            foreach (Ship ship in Ships)
            {
                if (ship.ShipId == id)
                {
                    return ship;
                }
            }

            return null;
        }


        // READ: Find ship by Name
        public Ship FindByName(string name)
        {
            foreach (Ship ship in Ships)
            {
                if (ship.ShipName.Equals(
                    name,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return ship;
                }
            }

            return null;
        }


        // DELETE: Delete ship by ID
        public bool DeleteShip(string id)
        {
            Ship ship = FindById(id);

            if (ship != null)
            {
                Ships.Remove(ship);

                Save();

                return true;
            }

            return false;
        }


        // UPDATE: Update ship status
        public bool UpdateShipStatus(string id, int status)
        {
            Ship ship = FindById(id);

            if (ship != null)
            {
                ship.ShipStatus = status;

                Save();

                return true;
            }

            return false;
        }


        // Mark ship as suspicious
        public bool MarkSuspicious(string id)
        {
            Ship ship = FindById(id);

            if (ship != null)
            {
                ship.SuspiciousShip = 1;

                Save();

                return true;
            }

            return false;
        }


        // View all ships
        public void ShowAllShips()
        {
            if (Ships.Count == 0)
            {
                Console.WriteLine("No Ships Found!");
                return;
            }

            foreach (Ship ship in Ships)
            {
                ship.Display();

                Console.WriteLine("-------------------------");
            }
        }


        // View suspicious ships
        public void GetSuspiciousShips()
        {
            bool found = false;

            foreach (Ship ship in Ships)
            {
                if (ship.SuspiciousShip == 1)
                {
                    ship.Display();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No Suspicious Ships Found!");
            }
        }


        // View approved ships
        public void GetApprovedShips()
        {
            foreach (Ship ship in Ships)
            {
                if (ship.ShipStatus == 1)
                {
                    ship.Display();
                }
            }
        }


        // View rejected ships
        public void GetRejectedShips()
        {
            foreach (Ship ship in Ships)
            {
                if (ship.ShipStatus == 2)
                {
                    ship.Display();
                }
            }
        }
    }
}