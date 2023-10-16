using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class AnimalManager
    {
        List<Animal> animals = new List<Animal>();

        public void AnimalMenu(Crop[], Worker[], FarmBuilding[])
        {
            bool status = true;
            int answer = 0;
            while (status)
            {
                Console.WriteLine("Vad vill du välja?" +
                                  "1. View Animals" +
                                  "2. Add Animal" +
                                  "3. SwitchBuilding " +
                                  "4. Remove Animal" +
                                  "5. Feed Animals");
                try
                {
                    answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            ViewAnimals();
                            break;
                        case 2:
                            AddAnimal();
                            break;
                        case 3:
                            SwitchBuilding();
                            break;
                        case 4:
                            RemoveAnimal();
                            break;
                        case 5:
                            FeedAnimals();
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
            for (int i = 0; i < animals.Count; i++)
            {
                animals[i].GetDescription();
            }
        }

      //  private bool AddAnimal(FarmBuilding farmbuilding)
      //  {
      //      if (farmbuilding. == null)
      //      animals.Add(Animal)
      //  }

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
