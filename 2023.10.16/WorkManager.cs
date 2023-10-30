using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class WorkManager
    {
        public List<Worker> listOfWorkers = new List<Worker>();
        public WorkManager() 
        {
            listOfWorkers.Add(new Worker("Branislav", "Grass"));
            listOfWorkers.Add(new Worker("Viktor", "Leaves"));
            listOfWorkers.Add(new Worker("Niklas", "Potatoes"));
            listOfWorkers.Add(new Worker("Bob", "Cheeseballs"));

        }
        public void WorkMany()
        {
            bool quit = false;
            while (quit == false)
            {
                Console.Clear();
                Console.WriteLine("Welcam to work manager what do you like to do?");
                Console.WriteLine("Press 1 if you want to see all workers");
                Console.WriteLine("Press 2 if you want to add new worker");
                Console.WriteLine("Press 3 if you want to remov worker");
                Console.WriteLine("press 4 if you want to go back to farm menu");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        viewWorkers();
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        addNewWorker();

                        break;
                    case "3":
                        Console.Clear();
                        viewWorkers();

                        try
                        {
                            Console.WriteLine("Write id number of worker you want to remove: ");
                            int inputId = int.Parse(Console.ReadLine());
                            removeWorker(inputId);
                            break;

                        }
                        catch
                        {
                            Console.WriteLine("##ERROR## \n you have to write a number please!!!");
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
        private void viewWorkers()
        {
            foreach(Worker worker in listOfWorkers)
            {
                Console.WriteLine(worker.GetDescription());
            }
        }
        private void addNewWorker()
        {
            Console.WriteLine("Write name of new worker: ");
            string name = Console.ReadLine();
            Console.WriteLine("Write speciality of new worker");
            string speciality = Console.ReadLine();
            foreach(Worker worker in listOfWorkers)
            {
                if (speciality == worker.Speciality)
                {
                    Console.WriteLine("Worker with that speciality already exist");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    return;
                }
            }
            listOfWorkers.Add(new Worker(name, speciality));
            Console.WriteLine("you added new worker!!!");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();

        } 
        private void removeWorker(int num)
        {
            bool faund = false;  
            foreach (Worker worker in listOfWorkers)
            {
                if (worker.Id == num)
                {
                   
                    listOfWorkers.Remove(worker);
                    Console.WriteLine("You have removed worker with Id " + num);
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    faund = true;
                    return;
                }
            }
            if (faund == false)
            {
                Console.WriteLine("Worker with id: " + num + " those not exist");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                return;
            }
            
        }

        
        public List<Worker> GetWorkers()
        {
            return  listOfWorkers;
        }
    }
}
