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
        public CropManager cropManager = new CropManager();
        public WorkManager workManager = new WorkManager();

        public void MainMenu()
        {
            bool status = true;
            while (status)
            {
                Console.WriteLine("Choose one of the following: \n\n" +
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
                            
                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        default:
                            Console.WriteLine("Vänligen skriv en siffra mellan 1 - 3");
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
