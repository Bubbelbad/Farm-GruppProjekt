using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class WorkManager
    {
        List<Worker> listOfWorkers = new List<Worker>();
        public WorkManager() 
        {
            listOfWorkers.Add(new Worker("Branislav", "speciality is to work with animals"));
            listOfWorkers.Add(new Worker("Viktor", "speciality is to work on crop"));

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
                default: 
                    Console.WriteLine("error");
                    break;

            }
            
        }
        public void viewWorkers()
        {
            foreach(Worker worker in listOfWorkers)
            {
                Console.WriteLine(worker.GetDescription());
            }
        }
    }
}
