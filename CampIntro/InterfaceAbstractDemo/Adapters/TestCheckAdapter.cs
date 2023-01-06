using InterfaceAbstractDemo.Abstract;
using InterfaceAbstractDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAbstractDemo.Adapters
{
    public class TestCheckAdapter : ICustomerCheckService
    {
        public bool CheckIfRealPerson(Customer customer)
        {
            if (customer.NationalityId.Length == 11)
                return true;
            return false;
        }
    }
}
