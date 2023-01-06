using InterfaceAbstractDemo.Abstract;
using InterfaceAbstractDemo.Concrete;
using InterfaceAbstractDemo.Entities;
using InterfaceAbstractDemo.Adapters;

public class Program
{
    public static void Main(string[] args)
    {
       BaseCustomerManager nCM = new NeroCustomerManager();
       BaseCustomerManager sCM1 = new StarbucksCustomerManager(new MernisServiceAdapter());
       BaseCustomerManager sCM2 = new StarbucksCustomerManager(new TestCheckAdapter());

        Customer furkan = new Customer()
        { FirstName = "Furkan", LastName = "Kahraman", NationalityId = "23045567391", DateOfBirth = new DateTime(1992,01,01) };

        sCM1.Save(furkan);
        sCM2.Save(furkan);
    }
}