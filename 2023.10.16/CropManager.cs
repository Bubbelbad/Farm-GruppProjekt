using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class CropManager
    {
        List<Crop> listOfCrops = new List<Crop>();


        

        public CropManager() 
        {
            listOfCrops.Add(new Crop("Grass", "Grass", 500));
            listOfCrops.Add(new Crop("Leaves", "Leaves", 600));
            listOfCrops.Add(new Crop("Potatoes", "Potatoes", 400));
            listOfCrops.Add(new Crop("Cheeseballs", "Cheeseballs", 300));
        }

       
        public void CropMany(List<Worker> workerList)
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
                    Console.WriteLine("Click to continue...");
                    Console.ReadLine();
                    break;

                case "2":
                    foreach(Worker worker in workerList)
                    {
                        Console.WriteLine(worker.GetDescription());
                    }

                    Console.WriteLine("Write a id number of worker you want to use");
                    int idWorker = int.Parse(Console.ReadLine());
                    Console.WriteLine("Write a name of Crop you want to add");
                    string cropName = Console.ReadLine();
                    Console.WriteLine("Write a typ of crop you want to add");
                    string cropTyp = Console.ReadLine();
                    Console.WriteLine("Write a quantity of crop");
                    int cropQuantity = int.Parse(Console.ReadLine());
                    foreach(Crop crop in listOfCrops)
                    {
                        if (cropTyp == crop.CropTyp)
                        {
                            foreach(Worker worker in workerList)
                            {
                                if (worker.Speciality == cropTyp)
                                {
                                    crop.AddCrop(cropQuantity * 2);
                                    break;
                                }
                            }
                            crop.AddCrop(cropQuantity);
                            break;
                        }

                        else 
                        {
                            listOfCrops.Add(new Crop(cropName, cropTyp, cropQuantity)); 
                        }
                    }
                    break;
                case "3":
                    viewCrops();
                    try
                    {
                        Console.WriteLine("Write id number of crop you want to remove: ");
                        int inputId = int.Parse(Console.ReadLine());
                        removeCrop(inputId);
                        
                        break;
                    }
                    catch
                    {
                        
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
                Console.WriteLine(crop.GetDescription() + "\n");
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
        private void AddCrop(Worker worker)
        {
            foreach(Crop crop in listOfCrops) 
            {
                if (crop.CropTyp == worker.Speciality)
                {

                }
            }

        }
         
        
        public List<Crop> GetCrops()
        {
            
            return listOfCrops;
        }
        
    }
}
