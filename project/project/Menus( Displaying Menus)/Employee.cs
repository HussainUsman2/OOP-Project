using System;

namespace InternationalPortManagement
{
    public class Employee
    {
        private PortManager portManager;

        // Constructor
        public Employee(PortManager manager)
        {
            portManager = manager;
        }

        // Employee Menu
        public void ShowMenu()
        {
            string choice = "";

            while (choice != "2")
            {
                Console.Clear();

                Console.WriteLine("========== EMPLOYEE MENU ==========");
                Console.WriteLine("1. Register New Ship");
                Console.WriteLine("2. Logout");

                Console.Write("\nEnter Your Choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddShip();
                        break;

                    case "2":
                        Console.WriteLine("Employee Logged Out!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        Pause();
                        break;
                }
            }
        }

        // Register New Ship
        private void AddShip()
        {
            Console.Clear();

            Console.WriteLine("========== SHIP REGISTRATION ==========");

            Console.Write("Enter Ship ID: ");
            string id = Console.ReadLine();

            // Check duplicate Ship ID
            if (portManager.FindById(id) != null)
            {
                Console.WriteLine("Ship ID Already Exists!");
                Pause();
                return;
            }

            Console.Write("Enter Ship Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Country: ");
            string country = Console.ReadLine();

            Console.Write("Enter Region: ");
            string region = Console.ReadLine();

            Console.Write("Enter Captain Name: ");
            string captain = Console.ReadLine();

            Console.Write("Enter Ship Type: ");
            string type = Console.ReadLine();

            Console.Write("Enter Ownership: ");
            string ownership = Console.ReadLine();

            Console.Write("Enter Cargo Type: ");
            string cargo = Console.ReadLine();

            Console.Write("Enter Cargo Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("Enter Number of Crews: ");
            int crews = int.Parse(Console.ReadLine());

            Console.Write("Enter Tariff: ");
            float tariff = float.Parse(Console.ReadLine());

            // Create Ship Object
            Ship ship = new Ship(
                id,
                name,
                country,
                region,
                captain,
                type,
                ownership,
                cargo,
                quantity,
                0,
                0,
                crews,
                tariff
            );

            // Add Ship through PortManager
            portManager.AddShip(ship);

            Console.WriteLine("\nShip Registered Successfully!");
            Console.WriteLine("Ship Status: Pending");

            Pause();
        }

        // Pause Screen
        private void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}