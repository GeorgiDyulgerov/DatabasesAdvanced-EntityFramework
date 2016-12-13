using System;
using System.Data.Entity;
using System.Linq;
using SalesCodeFirst.Models;

namespace SalesCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SalesContext();

            #region //First Entry
            //Customer customer = new Customer
            //{
            //    Name = "Pesho",
            //    Email = "pe6ho@abv.bg",
            //    CreditCardNumber = "4561 4816 4642 4862"
            //};

            //Product product = new Product
            //{
            //    Name = "Coolgate",
            //    Price = 2.40m,
            //    Quantity = 200
            //};

            //StoreLocation store = new StoreLocation
            //{
            //    LocationName = "Pederastiko"
            //};


            //Sale sale = new Sale();
            //sale.Customer = customer;
            //sale.Product = product;
            //sale.StoreLocation = store;
            //sale.Date = DateTime.Now;

            //customer.SalesForCustomer.Add(sale);
            //product.SalesOfProducts.Add(sale);
            //store.SalesInStore.Add(sale);

            #endregion

            #region //Second Entry
            //Customer customer = context.Customers.First();

            //Product product = new Product
            //{
            //    Name = "TV-GL",
            //    Price = 2400m,
            //    Quantity = 50
            //};

            //StoreLocation store = context.StoreLocations.First();

            //Sale sale = new Sale();
            //sale.Customer = customer;
            //sale.Product = product;
            //sale.StoreLocation = store;
            //sale.Date = DateTime.Now;

            //customer.SalesForCustomer.Add(sale);
            //product.SalesOfProducts.Add(sale);
            //store.SalesInStore.Add(sale);

            //context.Entry(customer).State = EntityState.Modified;
            //context.Entry(store).State = EntityState.Modified;
            //context.Products.Add(product);
            //context.Sales.Add(sale);
            #endregion;

        }
    }
}
