using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class AnimalManager
    {
        public List<Animal> listOfAnimals = new List<Animal>();

        public AnimalManager()
        {

        }


        public void AnimalMenu(List<FarmBuilding> farmList, List<Worker> workerList, List<Crop> cropList)
        {

            bool status = true;
            int answer = 0;
            while (status) //The menu that is looping until the dirty deeds are done:
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?\n\n" +
                                  "1. View Animals\n" +
                                  "2. Add Animal\n" +
                                  "3. SwitchBuilding\n" +
                                  "4. Remove Animal\n" +
                                  "5. Feed Animals\n" +
                                  "6. Back to Menu");
                try
                {
                    answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {   
                        //Function to see all animals:
                        case 1:          
                            ViewAnimals();
                            break;


                        //Function to add a new animal:
                        case 2:
                            Console.Clear();
                            if (farmList.Count == 0)
                            {
                                Console.WriteLine("There are no farms to put your animal into. \n" +
                                                  "First you need to add a farm from buildings menu!\n\n" +
                                                  "Click to continue...");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("What farmbuilding do you want to add the animal to?\n" +
                                              "Enter farm Id: \n");
                                foreach (FarmBuilding farm in farmList) //Showing the available farms
                                {
                                    Console.WriteLine(farm.GetDescription());
                                }

                                bool status2 = false;
                                while (!status2)
                                {
                                    try
                                    {
                                        int farmId = int.Parse(Console.ReadLine());
                                        foreach (FarmBuilding farm in farmList) //If the choice by Id exists, we go to function AddAnimal()
                                        {
                                            if (farm.Id == farmId)
                                            {
                                                AddAnimal(farm);
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Please enter a number of existing farm Id's");
                                    }
                                }
                            }
                            break;


                        //Function to switch, put animal in another building:
                        case 3:
                            Console.WriteLine("What animal do you want to switch building?\n"); //To choose animal
                            ViewAnimals();
                            int id = int.Parse(Console.ReadLine());
                            Animal animalChoice = null;
                            foreach(Animal animal in listOfAnimals)
                            {
                                if (animal.Id == id)
                                {
                                    animalChoice = animal;

                                    foreach (FarmBuilding building in farmList)                /*To remove animal from current building. 
                                                                                                 Here is one problem! I do not know if the next 
                                                                                                 Farm has any space, and if not the animal is still removed. */
                                    {
                                        if (building.animalList.Contains(animalChoice))
                                        {
                                            building.animalList.Remove(animalChoice);
                                        }
                                    }
                                }
                            }

                            Console.Clear();
                            Console.WriteLine("What building do you want the animal to go into?\n\n"); //To choose building
                            foreach (FarmBuilding farm in farmList)
                            {
                                Console.WriteLine(farm.GetDescription());
                            }
                            int id2 = int.Parse(Console.ReadLine());
                            FarmBuilding farmChoice2 = null;
                            foreach (FarmBuilding farm in farmList)
                            {
                                if (farm.Id == id2)
                                {
                                    farmChoice2 = farm;
                                }
                            }


                            bool change = SwitchBuilding(animalChoice, farmChoice2); //To do the deed, changing the building
                            if (change)
                            {
                                Console.WriteLine($"The desired animal of Id: {animalChoice.Id} has switched to the building of Id: {farmChoice2.Id}\n");
                                Console.WriteLine("Click to continue...");
                                Console.ReadLine();
                            }
                            else if (!change)
                            {
                                Console.WriteLine($"The farm with Id: {farmChoice2.Id} is full\n" +
                                                  $"Please remove relocate or remove animals before trying again.\n");
                                Console.WriteLine("Click to continue...");
                                Console.ReadLine();
                            }
                            break;


                        //Function to remove an animal:
                        case 4:
                            Console.Clear();
                            Console.WriteLine("What animal would you like to remove?\n");
                            ViewAnimals();
                            try
                            {
                                int choice = int.Parse(Console.ReadLine());
                                Animal animal1 = null;
                                foreach(Animal animal in listOfAnimals)
                                {
                                    if (animal.Id == choice)
                                    {
                                        animal1 = animal;
                                    }
                                }
                                foreach(FarmBuilding farm in farmList)
                                {
                                    if (farm.animalList.Contains(animal1))
                                    {
                                        farm.animalList.Remove(animal1);
                                        RemoveAnimal(choice);
                                    }
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Please write a number...");
                            }
                            break;


                        //Function to feed an animal:
                        case 5:
                            Console.Clear();
                            Console.WriteLine("What kind of animal do you want to feed?");  //To choose species of animal
                            string species = Console.ReadLine();
                            foreach (Animal animal in listOfAnimals)
                            {
                                if (animal.Species == species)
                                {
                                    foreach (Crop crop in cropList)
                                    {
                                        Console.WriteLine(crop.GetDescription());
                                    }
                                }
                                Console.Clear();
                                Console.WriteLine("What kind of crop do you want to feed the animal? (Choose by name)\n"); //To choose crop type
                                foreach (Crop crop in cropList)
                                {
                                    Console.WriteLine(crop.GetDescription());
                                }
                                string cropName = Console.ReadLine();
                                Crop crop1 = null;
                                foreach (Crop crop in cropList)
                                {
                                    if (cropName == crop.CropTyp)
                                    {
                                        crop1 = crop;
                                    }
                                }

                                Console.Clear();
                                Console.WriteLine("What worker should obey and feed the animal? (Choose by Id)\n"); //To choose worker
                                Worker worker1 = null;
                                foreach (Worker worker in workerList)
                                {
                                    Console.WriteLine(worker.GetDescription());
                                }
                                int workerChoice = int.Parse(Console.ReadLine());
                                foreach (Worker worker in workerList)
                                {
                                    if (workerChoice == worker.Id)
                                    {
                                        worker1 = worker;
                                    }
                                }
                                FeedAnimals(cropName, worker1, crop1); //Actually feeding the animal
                                
                            }
                            break;


                        //Return to animal main menu:
                        case 6:  
                            status = false;
                            Console.Clear();
                            break;


                        //Fail safe, just in case user can spell a single digit:
                        default:   
                            Console.WriteLine("Please write a number between 1 - 5");
                            break;
                    }
                }
                catch //another fail safe
                {
                    Console.WriteLine("Please write a number between 1 - 5");
                }
            }
        }



        private void ViewAnimals() //Iterating through the list and showing all the animals.
        {
            if (listOfAnimals.Count == 0)
            {
                Console.WriteLine(">> There are no animals to view - try adding some!\n");
            }
            else
            {
                for (int i = 0; i < listOfAnimals.Count; i++)
                {
                    Console.WriteLine(listOfAnimals[i].GetDescription());
                }
            }
        }


        private bool AddAnimal(FarmBuilding farmbuilding)  //Function to add an animal to the list
        {

            Console.WriteLine("What species of animal do you want to add?");
            string species = Console.ReadLine();

            Console.WriteLine("What is the animals name?");
            string name = Console.ReadLine();

            listOfAnimals.Add(new Animal(species, name));
            int index = listOfAnimals.Count - 1; //Finding the animal that was just added to listOfAnimals
            farmbuilding.AddAnimal(listOfAnimals[index]); //Adding it to the farmbuilding. 

            Console.WriteLine($"{name} has been added to farm with Id {farmbuilding.Id}\n");
            Console.WriteLine("Click to continue...");
            Console.ReadLine();

            return true;
        }


        private bool SwitchBuilding(Animal animal, FarmBuilding farmbuilding) //SwitchBuilding tar Id't av vilket djur skall
                                                                              //byta byggnad och Id't från byggnaden djuret ska till.
        {
            Console.Clear();
            if (!farmbuilding.IsFull())
            {
                farmbuilding.AddAnimal(animal);
                return true;
            }
            else
            {
                return false;
            }
        }


        private void RemoveAnimal(int num) //Function to remove an animal 
        {
            foreach (Animal animal in listOfAnimals)
            {
                if (animal.Id == num)
                {
                    listOfAnimals.Remove(animal);
                    Console.WriteLine("The animal was removed.");
                    Console.WriteLine("Click to continue...");
                    Console.ReadLine();
                }
            }

        }


        //Funtion to feed animal - this is not done yet!
        //Still need improvement and integration to crop...
        private void FeedAnimals(string species, Worker worker, Crop crop)
        {
            foreach (Animal animal in listOfAnimals)
            {
                if (animal.Species == species)
                {
                    animal.Feed(crop);
                }
            }
            Console.WriteLine("Just to make sure we get here...");
            Console.WriteLine("Click to continue...");
            Console.ReadLine();
        }

    }
}
