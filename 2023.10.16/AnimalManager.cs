using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class AnimalManager
    {
        List<Animal> listOfAnimals = new List<Animal>();

        public AnimalManager()
        {
            listOfAnimals.Add(new Animal("Sheep", "Rosita"));
            listOfAnimals.Add(new Animal("Cow", "Klarabella"));
        }


        public void AnimalMenu(List<FarmBuilding> farmBuilding)
        {

            bool status = true;
            int answer = 0;
            while (status)
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
                        case 1:
                            Console.Clear();
                            ViewAnimals();
                            Console.WriteLine("Click to continue...");
                            Console.ReadLine();
                            break;


                        case 2:
                            Console.Clear();
                            Console.WriteLine("What farmbuilding do you want to add the animal to?\n" +
                                              "Enter farm Id: \n");

                            foreach (FarmBuilding farm in farmBuilding) //Showing the available farms
                            {
                                Console.WriteLine(farm.GetDescription());
                            }

                            int farmId = int.Parse(Console.ReadLine());
                            FarmBuilding farmChoice = null;
                            foreach (FarmBuilding farm in farmBuilding) //If the choice by Id exists, we go to function AddAnimal()
                            {
                                if (farm.Id == farmId)
                                {
                                    farmChoice = farm;
                                    AddAnimal(farmChoice);
                                }
                            }
                            break;


                        case 3:
                            Console.WriteLine("What animal do you want to switch building?\n");
                            ViewAnimals();
                            int id = int.Parse(Console.ReadLine());
                            Animal animalChoice = null;
                            foreach(Animal animal in listOfAnimals)
                            {
                                if (animal.Id == id)
                                {
                                    animalChoice = animal;
                                }
                            }
                            Console.Clear();
                            Console.WriteLine("What building do you want the animal to go into?\n\n");
                            foreach (FarmBuilding farm in farmBuilding)
                            {
                                Console.WriteLine(farm.GetDescription());
                            }
                            int id2 = int.Parse(Console.ReadLine());
                            FarmBuilding farmChoice2 = null;
                            foreach (FarmBuilding farm in farmBuilding)
                            {
                                if (farm.Id == id2)
                                {
                                    farmChoice2 = farm;
                                }
                            }
                            SwitchBuilding(animalChoice, farmChoice2);

                            break;
                        case 4:
                         //   RemoveAnimal();
                            break;
                        case 5:
                           // FeedAnimals();
                            break;
                        case 6:
                            status = false;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Please write a number between 1 - 5");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Please write a number between 1 - 5");
                }
            }
        }



        private void ViewAnimals() //Iterating through the list and showing all the animals.
        {
            for (int i = 0; i < listOfAnimals.Count; i++)
            {
                Console.WriteLine(listOfAnimals[i].GetDescription()); 
            }
        }




        private bool AddAnimal(FarmBuilding farmbuilding)
        {

            Console.WriteLine("What species of animal do you want to add?");
            string species = Console.ReadLine();
            Console.WriteLine("What is the animals name?");
            string name = Console.ReadLine();
            listOfAnimals.Add(new Animal(species, name));
            farmbuilding.AddAnimal(listOfAnimals[-1]);
            return true;

        }


        //This function need to check if the building s full or not! 
        //Still have some implementation to do here. 
        private bool SwitchBuilding(Animal animal, FarmBuilding farmbuiding) //SwitchBuilding tar Id't av vilket djur skall byta byggnad och Id't från byggnaden djuret ska till.
        {
            Console.Clear();
            Console.WriteLine($"The desired animal of Id: {animal.Id} has switched to the building of Id: {farmbuiding.Id}\n");
            Console.WriteLine("Click to continue...");
            Console.ReadLine();
            return true;
        }



        private void RemoveAnimal(int num)
        {
            ViewAnimals();

        }



        private void FeedAnimals(string food, Crop crop)
        {

        }

    }
}
