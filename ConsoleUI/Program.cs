using System;
using System.Threading.Channels;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarMethod();
            //BrandManager();
            //CustomerMerhod();
            //UserMethod();

            Console.ReadLine();
        }       

        //private static void CustomerMerhod()
        //{
        //    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        //    customerManager.Add(new Customer { UserId = 2, CompanyName = "Udemy" });
        //    foreach (var customer in customerManager.GetAll().Data)
        //    {
        //        Console.WriteLine(customer.CompanyName);
        //    }
        //}

        private static void BrandManager()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " + brand.Name);
            }
        }

        private static void CarMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { BrandId = 3, ColorId = 3, DailyPrice = 1000, Description = "105", ModelYear = 2020 });


            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description + " " + car.BrandId + " " + car.ColorId + " " + car.DailyPrice + " " + car.ModelYear +
                                  " " + car.DailyPrice);
            }

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName);
            }
        }
    }
}