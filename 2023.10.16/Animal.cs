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



        public Animal(string species, string name) : base(name)
        {
            this.Species = species;
        }




        public override string GetDescription() //To return a description of the Animal
        {
            return $"Id: {Id}\nSpecies: {Species} \nName: {Name} \n";
        }


        //Hur ska jag få med in hur många av crop jag ska skörda här? Eftersom jag bara har Crop i parametern. 
        //This is not done yet! To be continued.
        public void Feed(Crop crop) //To feed Corpses to the Animal.
        {
            foreach (string acceptableCrop in AcceptableCropTypes)
            {
                if (acceptableCrop == crop.CropTyp)
                {
                    crop.TakeCrop(1);    
                }
                else if (acceptableCrop != crop.CropTyp)
                {
                    Console.WriteLine("The animal refuses this kind of food. Unacceptable. ");
                }
            }
            //I need to get a way to print the stuff if the animal doesnt have this in acceptable CropTypes.. How? 
        }
    }
}
