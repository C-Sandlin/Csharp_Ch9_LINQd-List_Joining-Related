using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQd_List_joinging_related
{
    public class Program
    {
        /*
            TASK:
            As in the previous exercise, you're going to output the millionaires,
            but you will also display the full name of the bank. You also need
            to sort the millionaires' names, ascending by their LAST name.

            Example output:
                Tina Fey at Citibank
                Joe Landy at Wells Fargo
                Sarah Ng at First Tennessee
                Les Paul at Wells Fargo
                Peg Vale at Bank of America
        */
        public static void Main()
        {
            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };

            // Create some customers and store in a List
            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            // var q = 
            // from c in categories 
            // join p in products on c equals p.Category into ps 
            // select new { Category = c, Products = ps }; 
            
            //Method syntax - to build list of millionaires
            // IEnumerable<Customer> MillionairesClub = customers.Where(customer => customer.Balance >= 1000000);

            var millionaireReport =
            from customer in customers
            where customer.Balance >= 1000000.00
            join bank in banks on customer.Bank equals bank.Symbol
            select new { Bank = bank.Name, Customer = customer };

            //Query syntax
            IEnumerable<IGrouping<string, Customer>> MillionairesPerBank = from millionaire in MillionairesClub
                group millionaire by millionaire.Bank into bankGroup
                select bankGroup;
            
            Console.WriteLine ("The Millionaires Per Bank:");
            foreach (IGrouping<string, Customer> m in MillionairesPerBank)
            {
                Console.WriteLine ($"{m.Key} {m.Count()}");

                foreach (Customer c in m)
                {
                    Console.WriteLine (c.Name);
                }
            }

            foreach (var item in millionaireReport)
            {
                Console.WriteLine($"{item.Customer.Name} at {item.Bank}");
            }
        }
    }
}
