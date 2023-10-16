using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class Worker : Entity
    {
        public string speciality { get; set; }
        List<Worker> listOfWorkers = new List<Worker>();
        public Worker() { }
        public override string GetDescription()
        {
            return $"Id: {Id} Name: {Name}";
        }

    }
}
