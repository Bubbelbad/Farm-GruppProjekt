using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class Farm
    {

        public BuildingManager buildingManager = new BuildingManager();
        public AnimalManager animalManager = new AnimalManager();
        public WorkManager workManager = new WorkManager();
        public CropManager cropManager = new CropManager();
        public Farm()
        {
            MainMenu();
        }

        public void MainMenu() //Main menu for the whole program to enter the different manager menus
        {
            bool status = true;
            while (status)
            {
                Console.Clear();
                Console.WriteLine("Choose one of the following menus: \n\n" +
                                  "1. Building Menu\n" +
                                  "2. Worker Menu\n" +
                                  "3. Crop Menu\n" +
                                  "4. Animal Menu");

                try
                {
                    int answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            buildingManager.BuildingMenu();
                            break;
                        case 2:
                            workManager.workManager();
                            break;
                        case 3:
                            cropManager.cropManager();
                            break;
                        case 4:
                            animalManager.AnimalMenu(buildingManager.listOfFarmBuildings, workManager.listOfWorkers, cropManager.GetCrops());
                            break;
                        default:
                            Console.WriteLine("Vänligen skriv en siffra mellan 1 - 4");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Please write a number between 1 - 4");
                }
            }
        }
    }
}
