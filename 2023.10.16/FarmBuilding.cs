using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class FarmBuilding : Entity
    {
        Animal animal = new Animal();

        private int Capacity { get; set; }

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

        public void ListAnimals()
        {

        }

        public void AddAnimal(Animal)
        {

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
