using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class CropManager
    {
        public List<Crop> listOfCrops = new List<Crop>();
        public CropManager() 
        {
            listOfCrops.Add(new Crop("Grass", "Grass", 500));
            listOfCrops.Add(new Crop("Leaves", "Leaves", 600));
            listOfCrops.Add(new Crop("Potatoes", "Potatoes", 400));
            listOfCrops.Add(new Crop("Cheeseballs", "Cheeseballs", 300));
        }

        public void cropManager()
        {
            Console.WriteLine("Welcam to corp manager what do you like to do?");
            Console.WriteLine("Press 1 if you want to see all corps");
            Console.WriteLine("Press 2 if you want to add new corp");
            Console.WriteLine("Press 3 if you want to remov corp");
            Console.WriteLine("press 4 if you want to go back to farm menu");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    viewCrops();
                    cropManager();
                break;

                case "2":

                break;

                case "3":
                    viewCrops();
                    try
                    {
                        Console.WriteLine("Write id number of crop you want to remove: ");
                        int inputId = int.Parse(Console.ReadLine());
                        removeCrop(inputId);
                        cropManager();
                        break;
                    }
                    catch
                    {
                        cropManager();
                    }
                    break;
                    
                case "4":

                break;

                default: 
                    Console.WriteLine("error");
                break;
            }
        }
        private void viewCrops()
        {
            foreach(Crop crop in listOfCrops)
            {
                Console.WriteLine(crop.GetDescription());
            }
        }
        private void removeCrop(int number)
        {
            foreach (Crop crop in listOfCrops)
            {
                if (crop.Id == number)
                {
                    listOfCrops.Remove(crop);
                    Console.WriteLine("You have removed crop with id " + number);
                }
            }
        }
    }
}
