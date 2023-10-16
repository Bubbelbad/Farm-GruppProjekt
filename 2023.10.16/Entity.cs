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


        public virtual string GetDescription()
        {
            return $"Id: {Id} Name: {Name}";
        }
    }
}
