using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = GetCustomers();
            foreach( Customer customer in customers)
            {
                Console.WriteLine(customer.FirstName.ToString());
            }

            var customerNames = GetCustomerNames();
            foreach (string customerName in customerNames)
            {
                Console.WriteLine(customerName);
            }
            Console.ReadLine();
        }

        static List<Customer> GetCustomers()
        {
            using (var db = new AdventureWorksEntities())
            {
                return db.Customers.ToList();
            }
        }

        static List<string> GetCustomerNames()
        {
            using (var db = new AdventureWorksEntities())
            {
                var names = new List<string> { };
                var customers = db.Customers;
                foreach( Customer customer in customers)
                {
                    names.Add($"{customer.FirstName} {customer.LastName}");
                }

                return names;
            }
        }
        
        static List<Customer> GetTopNCustomersSortedByLastName(int n)
        {
            using (var db = new AdventureWorksEntities())
            {
                return db.Customers.OrderBy(customer => customer.LastName).ThenBy(customer => customer.FirstName).Take(n).ToList();
            }
        }
    }
}
