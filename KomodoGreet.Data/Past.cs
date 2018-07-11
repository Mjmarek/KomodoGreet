using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreet.Data
{
    public class Past : Customer
    {
        public Past() { }

        public Past(string firstName, string lastName, string streetAddress,
            string city, string state, string zipCode, CustomerType customerType)
            : base(firstName, lastName, streetAddress, city, state, zipCode, customerType)
        {

        }
    }
}
