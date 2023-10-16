using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class BuildingManager
    {
        List<FarmBuilding> listOfFarmBuildings = new List<FarmBuilding>();

        
        public void BuildingMenu()
        {
            bool status = true;
            while (status)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do: \n\n" +
                                  "1. View Buildings\n" +
                                  "2. AddBuilding\n" +
                                  "3. Remove Building\n" +
                                  "4. Quit buildings - menu\n");
                try
                {
                    int answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            Console.Clear();
                            ViewBuildings();
                            Console.WriteLine("Click to continue...");
                            Console.ReadLine();
                            break;
                        case 2:
                            AddBuilding();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("What Building would you like to remove?\n");
                            ViewBuildings();
                            int answer2 = int.Parse(Console.ReadLine());
                            RemoveBuilding(answer2);
                            break;
                        case 4:
                            Console.Clear();
                            status = false;
                            break;
                        default:
                            Console.WriteLine("Please write a number between 1 - 4.");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Please write a number between 1 - 4.");
                }
            }

        }

        private void ViewBuildings()
        {
            foreach (FarmBuilding building in listOfFarmBuildings)
            {
                Console.WriteLine(building.GetDescription());
            }
        }

        private void AddBuilding()
        {
            Console.Clear();
            Console.WriteLine("What is the name of the building you want to add?");
            string name = Console.ReadLine();
            Console.WriteLine("What is the capacity of the building?");
            int capacity = int.Parse(Console.ReadLine());
            listOfFarmBuildings.Add(new FarmBuilding(capacity, name));
            Console.WriteLine("Click to continue...");
            Console.ReadLine();
        }

        private bool RemoveBuilding(int num)
        {
            foreach (FarmBuilding building in listOfFarmBuildings)
            {
                if (building.Id == num)
                {
                    listOfFarmBuildings.Remove(building);
                    return true;
                }
            }
            return false;
        }

        public List<FarmBuilding> GetBuildings()
        {
            return new List<FarmBuilding>();
        }
    }
}
