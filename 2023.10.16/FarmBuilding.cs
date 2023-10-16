using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class FarmBuilding : Entity
    {
        List<Animal> animalList = new List<Animal>();  

        private int Capacity { get; set; }

        public FarmBuilding(int capacity, string name) : base(name)
        {
            this.Capacity = capacity;
        }

        public override string GetDescription()
        {
            return $"Id: {Id} \nName: {Name} \nCapacity: {Capacity}\n";
        }

        public bool IsFull()
        {
            if (Capacity >= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      //  public void ListAnimals()
      //  {
      //      foreach (Animal animal in animalList)
      //  }

        public void AddAnimal(Animal animal)
        {
            animalList.Add(animal);
        }

        public void RemoveAnimal(int num)
        {

        }

        public bool IsEmpty()
        {
            if (Capacity == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
