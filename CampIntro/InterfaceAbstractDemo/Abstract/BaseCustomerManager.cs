using InterfaceAbstractDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAbstractDemo.Abstract
{
    public abstract class BaseCustomerManager : ICustomerService
    {
        public virtual void Save(Customer customer) //override yapabilmek için virtual dedik.
        {
            Console.WriteLine("Saved to db: {0} {1}",customer.FirstName,customer.LastName);
        }
    }
}
