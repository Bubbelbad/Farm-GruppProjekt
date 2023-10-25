using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class AnimalManager
    {
        List<Animal> listOfAnimals = new List<Animal>();

      
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
                            Console.Clear();
                            ViewAnimals();
                            Console.WriteLine("\nClick to continue...");
                            Console.ReadLine();
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
                                        Console.Clear();
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

                        //This function doesnt work properly... Have a look again!
                        //Neeeds a failsafe in case farm of choice doesnt exist.
                        //Function to switch, put animal in another building:
                        case 3:
                            Console.Clear();
                            bool status3 = false;
                            Animal animalChoice = null;
                            FarmBuilding newFarmChoice = null;
                            FarmBuilding oldFarm = null;
                            while (!status3)
                            {
                                Console.WriteLine("What animal do you want to switch building?\n"); //To choose animal
                                ViewAnimals();
                                int id = int.Parse(Console.ReadLine());
                                try
                                {
                                    foreach (Animal animal in listOfAnimals)
                                    {
                                        if (animal.Id == id)
                                        {
                                            animalChoice = animal;

                                            foreach (FarmBuilding building in farmList)           
                                                                                                 
                                                                                                 
                                            {
                                                if (building.animalList.Contains(animalChoice))
                                                {
                                                    building.animalList.Remove(animalChoice);
                                                    oldFarm = building;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("There is no animal with that Id...");
                                        }
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Please write an Id of the animal.");
                                }

                                Console.Clear();   //Somtehing goes wrong here if you chose a farm that doesnt exist! Fix it. 
                                Console.WriteLine("What building do you want the animal to go into?\n\n"); //To choose building
                                foreach (FarmBuilding farm in farmList)
                                {
                                    Console.WriteLine(farm.GetDescription());
                                }
                                try
                                {
                                    int id2 = int.Parse(Console.ReadLine());
                                    foreach (FarmBuilding farm in farmList)
                                    {
                                        if (farm.Id == id2)
                                        {
                                            newFarmChoice = farm;
                                        }
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("There is no farm with that Id...try again!");
                                }


                                bool change = SwitchBuilding(animalChoice, newFarmChoice); //To do the deed, changing the building
                                if (change)
                                {
                                    Console.WriteLine($"The desired animal of Id: {animalChoice.Id} has switched from building with Id: {oldFarm.Id} to the building of Id: {newFarmChoice.Id}\n");
                                    Console.WriteLine("Click to continue...");
                                    Console.ReadLine();
                                    status3 = true;
                                }
                                else if (!change)
                                {
                                    Console.WriteLine($"The farm with Id: {newFarmChoice.Id} is full\n" +
                                                      $"Please remove relocate or remove animals before trying again.\n");
                                    Console.WriteLine("Click to continue...");
                                    Console.ReadLine();
                                    status3 = true;
                                }
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
                            Console.WriteLine("List of existing species:\n");
                            foreach (Animal animal in listOfAnimals)
                            {
                                Console.WriteLine("- " + animal.Species);
                            }
                            Console.WriteLine("What kind of animal do you want to feed?");  //To choose species of animal
                            string species = Console.ReadLine();
                            Animal animal2 = null;
                            Console.Clear();

                            foreach (Animal animal in listOfAnimals)
                            {
                                if (animal.Species == species)
                                {
                                    Console.WriteLine("You have chosen an existing species.");
                                    animal2 = animal;
                                }
                                else if (animal.Species != species)
                                {
                                    Console.WriteLine("Please choose an existing specie...");
                                }
                            }

                            Console.WriteLine("What kind of crop do you want to feed the animal? (Choose by name)\n"); //To choose crop type
                            foreach (Crop crop in cropList)
                            {
                                    Console.WriteLine(crop.GetDescription());
                            }
                            int cropId = int.Parse(Console.ReadLine());
                            Crop crop1 = null;
                            foreach (Crop crop in cropList)
                            {
                                if (cropId == crop.Id)
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
                            FeedAnimals(species, worker1, crop1); //Actually feeding the animal
                                
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
                Console.WriteLine("List of available Animals: \n");
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

            Console.WriteLine("What is the animals favourite food?");
            string food1 = Console.ReadLine();

            Console.WriteLine("What is the animals second favourite food?");
            string food2 = Console.ReadLine();

            listOfAnimals.Add(new Animal(species, name, food1, food2));
            int index = listOfAnimals.Count - 1; //Finding the animal that was just added to listOfAnimals
            farmbuilding.AddAnimal(listOfAnimals[index]); //Adding it to the farmbuilding. 

            Console.WriteLine($"\n>> {name} has been added to farm with Id {farmbuilding.Id}\n");
            Console.WriteLine("Click to continue...");
            Console.ReadLine();

            return true;
        }


        //Something might be wrong here.. Have a look again to be sure.
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


        //Not sure if this is done or working properly.. need to have a look later again.
        private void FeedAnimals(string species, Worker worker, Crop crop) //Function to feed the animals.
        {
            Animal animal3 = null;
            foreach (Animal animal in listOfAnimals)
            {
                if (animal.Species == species)
                {
                   animal3 = animal;
                }
            }
            
            if (worker.Speciality == crop.CropTyp) //Checking if it's the workers speciality to add a fitting end.
            {
                animal3.Feed(crop); Console.Write(" was the workers speciality!");
            }
            else
            {
                animal3.Feed(crop); Console.Write(" gets to live another day. Mediocre taste tho :|");
            }
          
            Console.WriteLine("\n\nClick to continue...");
            Console.ReadLine();
        }

    }
}
