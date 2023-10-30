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

        private List<string> AcceptableCropTypes = new List<string>();



        public Animal(string species, string name, string crop1, string crop2) : base(name)
        {
            this.Species = species;
            this.AcceptableCropTypes.Add(crop1);
            this.AcceptableCropTypes.Add(crop2);
        }




        public override string GetDescription() //To return a description of the Animal
        {
            return $"Id: {Id}\nSpecies: {Species} \nName: {Name} " +
                   $"\nFood 1: {AcceptableCropTypes[0]}\nFood 2: {AcceptableCropTypes[1]}\n";
        }




        public bool Feed(Crop crop) //To feed crop to the Animal.
        {

            bool cropStatus = crop.TakeCrop(1); //Checking if animal can eat the crop from AcceptableCropTypes 
            if (cropStatus && crop.CropTyp == AcceptableCropTypes[0] || cropStatus && crop.CropTyp == AcceptableCropTypes[1])
            {
                Console.Clear();
                Console.Write("The animal ate the food.");
                return true;
            }
            else if (cropStatus && crop.CropTyp != AcceptableCropTypes[0] && cropStatus && crop.CropTyp != AcceptableCropTypes[1])
            {
                Console.WriteLine($"\nThe animal cant eat that food. It's unacceptable for a {this.Species}!");
            }

            else if (!cropStatus) //In case we didnt have any crops
            {
                Console.WriteLine($"There was no food to feed the animal :(\nWe have run out of {crop.CropTyp}...");
            }
            return false;
        }
    }
}
