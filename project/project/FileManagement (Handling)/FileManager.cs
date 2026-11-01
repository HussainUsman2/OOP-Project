using System;
using System.Collections.Generic;
using System.IO;

namespace InternationalPortManagement
{
    public class FileManager
    {
        private string filePath = @"C:\Users\LENOVO\Desktop\project oop\project\project\FileManagement (Handling)\ships.txt";



        // Save all ships into file
        public void SaveAll(List<Ship> ships)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Ship ship in ships)
                    {
                        string line =
                            ship.ShipId + "|" +
                            ship.ShipName + "|" +
                            ship.ShipCountry + "|" +
                            ship.ShipRegion + "|" +
                            ship.ShipCaptain + "|" +
                            ship.ShipType + "|" +
                            ship.ShipOwnership + "|" +
                            ship.CargoType + "|" +
                            ship.CargoQuantity + "|" +
                            ship.ShipStatus + "|" +
                            ship.SuspiciousShip + "|" +
                            ship.Crews + "|" +
                            ship.Tariff;

                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Saving Data: " + ex.Message);
            }
        }

        // Load all ships from file
        public List<Ship> LoadAll()
        {
            List<Ship> ships = new List<Ship>();

            try
            {
                if (!File.Exists(filePath))
                {
                    return ships;
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split('|');

                        Ship ship = new Ship(
                            data[0],
                            data[1],
                            data[2],
                            data[3],
                            data[4],
                            data[5],
                            data[6],
                            data[7],
                            int.Parse(data[8]),
                            int.Parse(data[9]),
                            int.Parse(data[10]),
                            int.Parse(data[11]),
                            float.Parse(data[12])
                        );

                        ships.Add(ship);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Loading Data: " + ex.Message);
            }

            return ships;
        }
    }
}