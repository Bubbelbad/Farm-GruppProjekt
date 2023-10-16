using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class Crop : Entity
    {

        public string cropTyp { get; set; }
        private int quantity { get; set; }
        public Crop(string cropTyp, int quantit)
        {
            this.cropTyp = cropTyp;
            this.quantity = quantit;
        }
        public override string GetDescription()
        {
            return base.GetDescription();
        }
        public int addCrop()
        {
            return quantity;
        }
        public int takeCrop()
        {
            return quantity;
        }
    }
}
