using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class Crop : Entity
    {

        public string CropTyp { get; set; }
        private int quantity { get; set; }
        public Crop(string name, string CropTyp, int quantit) : base(name)
        {
            this.CropTyp = CropTyp;
            this.quantity = quantit;
        }
        public override string GetDescription()
        {
            return $"Id: {Id} crop: {CropTyp} quantity: {quantity}";
        }

        

       
        public void AddCrop(int cropQuantity)
        {
           
                quantity = quantity + cropQuantity;
            
 
        }
        List<Crop> listOfCrops = new List<Crop>();


        public bool TakeCrop(int num) 
        {
            foreach (Crop crop in listOfCrops)
            {
                Console.WriteLine(crop.GetDescription());
                if (num == crop.Id)
                {
                    Console.WriteLine("This Crop exist");
                    Console.WriteLine("How much crop do you need?");
                    int num1 = int.Parse(crop.CropTyp);
                    if (num1 <= crop.quantity) 
                    {
                        Console.WriteLine("you get this much crop " + num1);
                        return true;
                    }
                    else if (num1 > crop.quantity)
                    {
                        Console.WriteLine(num1 + " this much crop thos not exist");
                        return false;
                    }
                    return true;

                }
                else
                {
                    Console.WriteLine("this id thos not exist");
                }

            }
            return false;
        }
    }
}
