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

        public List<string> AcceptableCropTypes = new List<string>();



        public Animal(string species, string name, string crop1, string crop2) : base(name)
        {
            this.Species = species;
            this.AcceptableCropTypes.Add(crop1);
            this.AcceptableCropTypes.Add(crop2);
        }




        public override string GetDescription() //To return a description of the Animal
        {
            return $"Id: {Id}\nSpecies: {Species} \nName: {Name} " +
                   $"\nFood 1: {AcceptableCropTypes[0]}\nFood 2: {AcceptableCropTypes[1]}";
        }


        //Hur ska jag få med in hur många av crop jag ska skörda här? Eftersom jag bara har Crop i parametern. 
        //This is not done yet! To be continued.

        public void Feed(Crop crop) //To feed Corpses to the Animal.
        {
            crop.TakeCrop(1);     
        }
    }
}
