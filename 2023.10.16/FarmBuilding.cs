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

        public override string GetDescription() //Funktion som visar djurets information. 
        {
            return $"Id: {Id} \nName: {Name} \nCapacity: {Capacity}\n";
        }

        //Denna är inte klar ännu...
        public bool IsFull()
        {
            if (animalList.Count >= Capacity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void ListAnimals() //Funktion som listar alla djur i animalList
        {
            foreach (Animal animal in animalList)
            {
                Console.WriteLine(animal.GetDescription()); 
            }
        }

        public void AddAnimal(Animal animal) //Lägger till djur i listan. 
        {
            animalList.Add(animal);
        }

        public void RemoveAnimal(int num) 
        {

        }

        //Är denna klar? Inte helt säker ännu. Kanske.
        public bool IsEmpty()
        {
            if (animalList.Count == 0)
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
