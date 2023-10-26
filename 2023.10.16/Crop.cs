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

        public bool TakeCrop(int num) //<--- Jag tror att vi bara borde använda argumentet (int num) i TakeCrop()
        {


            Console.WriteLine("This Crop exist");            //Och vi behöver nog inte fråga efter quantity
            Console.WriteLine("How much crop do you need?"); //eftersom vi matar ett djur i taget. 
            num = int.Parse(Console.ReadLine());
            if (num <= quantity)
            {
                Console.WriteLine("you get this much crop " + num);
                return true;
            }
            else if (num > quantity)
            {
                Console.WriteLine(num + " this much crop thos not exist");
                return false;
            }
            return true;

            //Egentligen räcker det nog med if(num <= quantity) return true;
            //else { return false; } skulle jag tro. Men du får gärna säga vad du själv tror! 


        }
    }
}
