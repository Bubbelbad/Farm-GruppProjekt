using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class Entity
    {
        public int Id { get; set; }
        protected string Name { get; set; }



        public void GetDescription()
        {
            Console.WriteLine($"Id: {Id} Name: {Name}");
        }
    }
}
