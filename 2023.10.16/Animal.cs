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

        public override string GetDescription()
        {
            return $"Id: {Id}\nSpecies: {Species} \nName: {Name} \n";
        }

        public void Feed(Crop crop)
        {
            foreach (string acceptableCrop in AcceptableCropTypes)
            {
                if (crop.cropTyp == acceptableCrop)
                {

                }
            }
            
        }
    }
}
