using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using TestPerformanceLinQ.BackEnd;


public static class Driver
{
   
    static void Main(string[] args)
    {
       
        CustomerEntityDataContext context = new CustomerEntityDataContext(ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString);

        context.Log = Console.Out;
        var query = context.Customers;
        IEnumerable<Customer> wCustomerList =
            from cust in context.Customers where cust.CustomerID < 10 select cust;

        ObjectDumper.Write(wCustomerList);
    }

}