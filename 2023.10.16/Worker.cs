using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class Worker : Entity
    {
        public string Speciality { get; set; }
       
        public Worker(string name, string speciality):base(name)
        {
           this.Speciality = speciality;
            
        }
        public override string GetDescription()
        {
            return $"Id: {Id} Name: {Name} speciality: {Speciality}";
        }

    }
}
