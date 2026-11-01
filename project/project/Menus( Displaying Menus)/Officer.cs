using System;

namespace InternationalPortManagement
{
    public class Officer
    {
        private PortManager portManager;

        // Constructor
        public Officer(PortManager manager)
        {
            portManager = manager;
        }

        // Officer Menu
        public void ShowMenu()
        {
            string choice = "";

            while (choice != "8")
            {
                Console.Clear();

                Console.WriteLine("========== OFFICER MENU ==========");
                Console.WriteLine("1. View All Ships");
                Console.WriteLine("2. Search Ship");
                Console.WriteLine("3. Update Ship Status");
                Console.WriteLine("4. Mark Ship as Suspicious");
                Console.WriteLine("5. View Suspicious Ships");
                Console.WriteLine("6. View Approved Ships");
                Console.WriteLine("7. View Rejected Ships");
                Console.WriteLine("8. Logout");

                Console.Write("\nEnter Your Choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        portManager.ShowAllShips();
                        Pause();
                        break;

                    case "2":
                        SearchShip();
                        break;

                    case "3":
                        UpdateShipStatus();
                        break;

                    case "4":
                        MarkSuspicious();
                        break;

                    case "5":
                        Console.Clear();
                        portManager.GetSuspiciousShips();
                        Pause();
                        break;

                    case "6":
                        Console.Clear();
                        portManager.GetApprovedShips();
                        Pause();
                        break;

                    case "7":
                        Console.Clear();
                        portManager.GetRejectedShips();
                        Pause();
                        break;

                    case "8":
                        Console.WriteLine("Officer Logged Out!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        Pause();
                        break;
                }
            }
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

            Console.WriteLine("\nSelect New Status:");
            Console.WriteLine("1. Pending");
            Console.WriteLine("2. Approved");
            Console.WriteLine("3. Rejected");

            Console.Write("Enter Choice: ");
            string option = Console.ReadLine();

            if (option == "1" || option == "2" || option == "3")
            {
                int status = int.Parse(option) - 1;

                portManager.UpdateShipStatus(id, status);

                Console.WriteLine("Ship Status Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Status!");
            }

            Pause();
        }

        // Mark Ship as Suspicious
        private void MarkSuspicious()
        {
            Console.Clear();

            Console.Write("Enter Ship ID: ");
            string id = Console.ReadLine();

            bool result = portManager.MarkSuspicious(id);

            if (result)
            {
                Console.WriteLine("Ship Marked as Suspicious!");
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