using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTest.Src.dummy
{
    static class Data
    {
        private readonly static int MAX_INVOICE_AMOUNT = 100;
        private readonly static int MAX_PAYMENT_AMOUNT = 150;

        private static Random RandomObj = new Random();
        public static Customer CreateTestCustomer(string firstName, string lastName, string email, bool isActive, int invocesNumber, int paymentsNumber)
        {
            Customer customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = email,
                isActive = isActive,
            };
            customer.Invoices = GenerateInvoicesList(invocesNumber);
            customer.Payments = GeneratePaymentsList(paymentsNumber);

            customer.Balance = customer.isActive ? (customer.Invoices.Sum(a => a.Amount) - customer.Payments.Sum(a => a.Amount)) : 0;

            return customer;
        }

        private static ObservableCollection<Invoice> GenerateInvoicesList(int invoicesNumber)
        {
            var invoicesList = new ObservableCollection<Invoice>();
   
            for (int i = 0; i < invoicesNumber; i++)
            {
                invoicesList.Add(new Invoice() { Amount = RandomObj.Next(MAX_INVOICE_AMOUNT) });
            }

            return invoicesList;
        }

        private static ObservableCollection<Payment> GeneratePaymentsList(int paymentsNumber)
        {
            var paymentsList = new ObservableCollection<Payment>();
    
            for (int i = 0; i < paymentsNumber; i++)
            {
                paymentsList.Add(new Payment() { Amount = RandomObj.Next(MAX_PAYMENT_AMOUNT) });
            }

            return paymentsList;
        }

        public static ObservableCollection<Customer> CreateCustomersList()
        {
            var customerList = new ObservableCollection<Customer>();

            var customer1 = CreateTestCustomer("John", "Smith", "JohnSmith2015@aol.com", true, 3, 2);
            customer1.MailingAddress = new Address()
            {
                Address1 = "309 Harbor Pointe dr",
                Zipcode = "29464",
                City = "Charleston",
                State = "SC"
            };

            customer1.HomeAddress = new Address()
            {
                Address1 = "309 Harbor Pointe dr",
                Zipcode = "29464",
                City = "Charleston",
                State = "SC"
            };

            customerList.Add(customer1);

            var customer2 = CreateTestCustomer("Ricky", "CEARNAL", "RickyCEARNAL2015@gmail.com", false, 2, 3);
            customer2.MailingAddress = new Address()
            {
                Address1 = "354 Sugar Cane Way",
                Zipcode = "29464",
                City = "Mt.Pleasant",
                State = "SC"
            };

            customer2.HomeAddress = new Address()
            {
                Address1 = "712 5th St",
                Zipcode = "29464",
                City = "Mt.Pleasant",
                State = "SC"
            };

            customerList.Add(customer2);

            var customer3 = CreateTestCustomer("Alec", "RAATZ", "Alec.RAATZ@gmail.com", true, 2, 2);
            customer3.MailingAddress = new Address()
            {
                Address1 = "951 Summers Dr",
                Zipcode = "29472",
                City = "Summerville",
                State = "SC"
            };

            customer3.HomeAddress = new Address()
            {
                Address1 = "1124 Parkway Dr",
                Zipcode = "29464",
                City = "Mt.Pleasant",
                State = "SC"
            };


            customerList.Add(customer3);

            return customerList;
        }

    }
}
