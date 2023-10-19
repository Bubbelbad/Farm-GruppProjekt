using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class Animal : Entity
    {
        public string Species { get; set; }

        private List<string> AcceptableCropTypes = new List<string> { "Grass", "Leaves", "Potatoes", "Cheeseballs" };


        //Constructor, inherited base from entity
        public Animal(string species, string name) : base(name) 
        {
            this.Species = species;
        }



        public override string GetDescription() //To return a description of the Animal
        {
            return $"Id: {Id}\nSpecies: {Species} \nName: {Name} \n";
        }



        //This is not done yet! To be continued.
        //Or is it? Not sure if the other function should do the rest...

        public void Feed(Crop crop) //To feed Crops to the Animal.
        {
            foreach (string acceptableCrop in AcceptableCropTypes)
            {
                if (acceptableCrop == crop.cropTyp)
                {
                    Console.WriteLine("The animal has been fed.");
                }
                else
                {
                    Console.WriteLine($"The animal does'nt like {crop.cropTyp}");
                }
            }
            
        }
    }
}
