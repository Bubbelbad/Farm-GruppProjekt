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

        public Farm()
        {

            MainMenu();
        }

        public void MainMenu()
        {
            bool status = true;
            while (status)
            {
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

                            break;
                        case 4:
                            animalManager.AnimalMenu(buildingManager.listOfFarmBuildings); 
                            break;
                        default:
                            Console.WriteLine("Vänligen skriv en siffra mellan 1 - 4");
                            break;
                    }
                }
                catch
                {

                }
            }
        }
    }
}
