using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class CropManager
    {
        List<Crop> listOfCrops = new List<Crop>();




        public CropManager()
        {
            listOfCrops.Add(new Crop("Grass", "Greens", 500));
            listOfCrops.Add(new Crop("Leaves", "Greens", 600));
            listOfCrops.Add(new Crop("Chia", "Seeds", 400));
            listOfCrops.Add(new Crop("Sesam", "Seeds", 400));
            listOfCrops.Add(new Crop("Cheeseballs", "Snacks", 300));
            listOfCrops.Add(new Crop("Coffee", "Snacks", 300));
        }


        public void CropMany(List<Worker> workerList)
        {
            bool quit = false;
            while (quit == false)
            {
                Console.Clear();
                Console.WriteLine("Welcam to corp manager what do you like to do?");
                Console.WriteLine("Press 1 if you want to see all corps");
                Console.WriteLine("Press 2 if you want to add new corp");
                Console.WriteLine("Press 3 if you want to remov corp");
                Console.WriteLine("press 4 if you want to go back to farm menu");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        ViewCrops();
                        Console.WriteLine("Click to continue...");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Write a id number of worker you want to use");
                        foreach (Worker worker in workerList)
                        {
                            Console.WriteLine(worker.GetDescription());
                        }
                        int idWorker = int.Parse(Console.ReadLine());
                        Worker worker1 = null;
                        bool exist = false;
                        foreach (Worker worker in workerList)
                        {
                            if (worker.Id == idWorker)
                            {
                                worker1 = worker;
                                Console.WriteLine("You use worker with ID number: " + worker1.Id);
                                AddCrop(worker1);
                                Console.WriteLine("Crop was successfuli added to crop list");
                                Console.WriteLine("Press enter to continue...");
                                Console.ReadLine();
                                exist = true;
                            }
                        }
                        if (exist == false)
                        {
                            Console.WriteLine("Worker with ID: " + idWorker + " those not exist");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                            break;
                        }

                        break;
                    case "3":
                        Console.Clear();
                        ViewCrops();
                        try
                        {
                            Console.WriteLine("Write id number of crop you want to remove: ");
                            int inputId = int.Parse(Console.ReadLine());

                            RemoveCrop(inputId);

                        }
                        catch
                        {
                            Console.WriteLine("#ERROR# Write a number please");
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();

                        }
                        break;
                    case "4":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;

                }
            }

          
        }
        private void ViewCrops()
        {
            foreach (Crop crop in listOfCrops)
            {
                Console.WriteLine(crop.GetDescription() + "\n");
            }
        }
        private void RemoveCrop(int number)
        {
            foreach (Crop crop in listOfCrops)
            {
                if (crop.Id == number)
                {
                    listOfCrops.Remove(crop);
                    Console.WriteLine($"You have removed crop with id { number}");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    return;
                    
                }
                
            }
            Console.WriteLine("Crop with ID: " + number + " those not exist");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            return;
        }
        private void AddCrop(Worker worker)
        {
            Console.WriteLine("Write a typ of crop you want to add");
            string cropTyp = Console.ReadLine();
            Console.WriteLine("Write a quantity of crop");
            int cropQuantity = int.Parse(Console.ReadLine());
            bool faund = false;
            foreach (Crop crop in listOfCrops)
            {
                if (cropTyp == crop.CropTyp && worker.Speciality == crop.CropTyp)
                {

                    crop.AddCrop(cropQuantity * 2);
                    faund = true;
                }
                else if (cropTyp == crop.CropTyp && worker.Speciality != crop.CropTyp)
                {
                    crop.AddCrop(cropQuantity);
                   faund= true;
                }
            }
            if (faund == false)
            {
                
                listOfCrops.Add(new Crop(cropTyp, cropTyp, cropQuantity));

            }

        }


        public List<Crop> GetCrops()
        {   
            return listOfCrops;
        }

    }
}
