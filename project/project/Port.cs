using System;

namespace InternationalPortManagement
{
    public class Port
    {
        // Objects of other classes
        private PortManager portManager;
        private Admin admin;
        private Officer officer;
        private Employee employee;


        // Constructor
        public Port()
        {
            // Create PortManager object
            portManager = new PortManager();

            // Pass same PortManager object to all menus
            admin = new Admin(portManager);
            officer = new Officer(portManager);
            employee = new Employee(portManager);
        }


        // Start Port Management System
        public void Start()
        {
            DisplayMainMenu();
        }


        // Main Menu
        private void DisplayMainMenu()
        {
            string choice = "";

            while (choice != "4")
            {
                Console.Clear();

                Console.WriteLine("======================================");
                Console.WriteLine(" INTERNATIONAL PORT MANAGEMENT SYSTEM");
                Console.WriteLine("======================================");

                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Officer");
                Console.WriteLine("3. Employee");
                Console.WriteLine("4. Exit");

                Console.Write("\nSelect Your Role: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        admin.ShowMenu();
                        break;

                    case "2":
                        officer.ShowMenu();
                        break;

                    case "3":
                        employee.ShowMenu();
                        break;

                    case "4":
                        Console.WriteLine("\nThank You for Using Port Management System!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}