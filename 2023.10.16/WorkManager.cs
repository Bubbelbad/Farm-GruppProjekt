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
            listOfWorkers.Add(new Worker("Branislav", "speciality: work with animals"));
            listOfWorkers.Add(new Worker("Viktor", "speciality: work on crop"));

        }
        public void workManager()
        {
            
            Console.WriteLine("Welcam to work manager what do you like to do?");
            Console.WriteLine("Press 1 if you want to see all workers");
            Console.WriteLine("Press 2 if you want to add new worker");
            Console.WriteLine("Press 3 if you want to remov worker");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    viewWorkers();
                    break;
                case "2":
                    addNewWorker();
                    break;
                case "3":  
                  viewWorkers();
                 
                   try
                   {
                       Console.WriteLine("Write id of worker you want to remove:");
                       int inputId = int.Parse(Console.ReadLine());
                       Console.WriteLine("You have removed worker with Id " + inputId);
                        removeWorker(inputId);
                        workManager();
                        break;
                   }
                   catch
                   {
                       
                        workManager();
                        

                   }
                   
                 break;

                default: 
                    Console.WriteLine("error");
                    break;

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
            listOfWorkers.Add(new Worker(name, speciality));
            Console.WriteLine("you added new worker!!!");

        } 
        private int removeWorker(int num)
        {
               
            foreach (Worker worker in listOfWorkers)
            {
                if (worker.Id == num)
                {
                    listOfWorkers.Remove(worker);
                    
                }
               
            }
            return num;
        }
    }
}
