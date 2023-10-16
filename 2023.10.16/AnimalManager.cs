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


        public void AnimalMenu()
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
                         //  AddAnimal
                            string farmBuilding = Console.ReadLine();
                            break;
                        case 3:
                         //   SwitchBuilding();
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

        private void ViewAnimals()
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

        private bool SwitchBuilding(Animal animal, FarmBuilding farmbuiding)
        {
            return true;
        }

        private void RemoveAnimal(int num)
        {

        }

        private void FeedAnimals(string food, Crop crop)
        {

        }

    }
}
