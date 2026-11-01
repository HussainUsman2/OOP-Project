using System;
using System.Collections.Generic;
using System.IO;

namespace InternationalPortManagement
{
    public class FileManager
    {
        private string filePath = "ships.txt";

        // Encode data into Base64
        private string Encode(string text)
        {
            return Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(text)
            );
        }

        // Decode Base64 data
        private string Decode(string text)
        {
            return System.Text.Encoding.UTF8.GetString(
                Convert.FromBase64String(text)
            );
        }

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
                            Encode(ship.ShipId) + "|" +
                            Encode(ship.ShipName) + "|" +
                            Encode(ship.ShipCountry) + "|" +
                            Encode(ship.ShipRegion) + "|" +
                            Encode(ship.ShipCaptain) + "|" +
                            Encode(ship.ShipType) + "|" +
                            Encode(ship.ShipOwnership) + "|" +
                            Encode(ship.CargoType) + "|" +
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
                            Decode(data[0]),
                            Decode(data[1]),
                            Decode(data[2]),
                            Decode(data[3]),
                            Decode(data[4]),
                            Decode(data[5]),
                            Decode(data[6]),
                            Decode(data[7]),
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