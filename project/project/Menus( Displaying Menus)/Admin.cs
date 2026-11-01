using System;

namespace InternationalPortManagement
{
    public class Admin
    {
        private PortManager portManager;

        // Constructor
        public Admin(PortManager manager)
        {
            portManager = manager;
        }

        // Admin Menu
        public void ShowMenu()
        {
            string choice = "";

            while (choice != "8")
            {
                Console.Clear();

                Console.WriteLine("========== ADMIN MENU ==========");
                Console.WriteLine("1. Add New Ship");
                Console.WriteLine("2. View All Ships");
                Console.WriteLine("3. Search Ship");
                Console.WriteLine("4. Update Ship Status");
                Console.WriteLine("5. Delete Ship");
                Console.WriteLine("6. View Suspicious Ships");
                Console.WriteLine("7. View Approved Ships");
                Console.WriteLine("8. Logout");

                Console.Write("\nEnter Your Choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddShip();
                        break;

                    case "2":
                        Console.Clear();
                        portManager.ShowAllShips();
                        Pause();
                        break;

                    case "3":
                        SearchShip();
                        break;

                    case "4":
                        UpdateShipStatus();
                        break;

                    case "5":
                        DeleteShip();
                        break;

                    case "6":
                        Console.Clear();
                        portManager.GetSuspiciousShips();
                        Pause();
                        break;

                    case "7":
                        Console.Clear();
                        portManager.GetApprovedShips();
                        Pause();
                        break;

                    case "8":
                        Console.WriteLine("Logging Out...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        Pause();
                        break;
                }
            }
        }

        // Add Ship
        private void AddShip()
        {
            Console.Clear();

            Console.Write("Enter Ship ID: ");
            string id = Console.ReadLine();

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

            portManager.AddShip(ship);

            Pause();
        }

        // Search Ship
        private void SearchShip()
        {
            Console.Clear();

            Console.Write("Enter Ship ID: ");
            string id = Console.ReadLine();

            Ship ship = portManager.FindById(id);

            if (ship != null)
            {
                ship.Display();
            }
            else
            {
                Console.WriteLine("Ship Not Found!");
            }

            Pause();
        }

        // Update Ship Status
        private void UpdateShipStatus()
        {
            Console.Clear();

            Console.Write("Enter Ship ID: ");
            string id = Console.ReadLine();

            Ship ship = portManager.FindById(id);

            if (ship == null)
            {
                Console.WriteLine("Ship Not Found!");
                Pause();
                return;
            }

            Console.WriteLine("1. Pending");
            Console.WriteLine("2. Approved");
            Console.WriteLine("3. Rejected");

            Console.Write("Select New Status: ");
            string option = Console.ReadLine();

            if (option == "1" || option == "2" || option == "3")
            {
                int status = int.Parse(option) - 1;

                portManager.UpdateShipStatus(id, status);

                Console.WriteLine("Ship Status Updated!");
            }
            else
            {
                Console.WriteLine("Invalid Status!");
            }

            Pause();
        }

        // Delete Ship
        private void DeleteShip()
        {
            Console.Clear();

            Console.Write("Enter Ship ID to Delete: ");
            string id = Console.ReadLine();

            bool deleted = portManager.DeleteShip(id);

            if (deleted)
            {
                Console.WriteLine("Ship Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Ship Not Found!");
            }

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