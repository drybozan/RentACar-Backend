using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
        //    // CarTest1();
        //    //GetCarsByBrandId();
        //    // GetById();
        //    // GetCarsByColorId();
        //    // CarAdd();
        //    // CarDelete();
        //    //CarUpdate();
        //    //GetCarsDetails();
        //    // UserAdd();
        //    //CustomerDetailandAdd();

        //    RentalManager rentalManager = new RentalManager(new EfRentalDal());
        //    RentACarTest(rentalManager);
           

        //}
        //private static void RentACarTest(RentalManager rentalManager)
        //{
        //    var x = rentalManager.Add(new Rental { car_id = 1, customer_id = 3, rent_date = DateTime.Now  });
        //    Console.WriteLine("{0} ---> {1}", x.Success, x.Message);

        //}

        //private static void CustomerDetailandAdd()
        //{
        //    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        //    /*  customerManager.Add(new Customer
        //      {
        //          customer_id=1,
        //          user_id = 1,
        //          company_name="BTKi Company"

        //      }) ;*/

        //    foreach (var customer in customerManager.GetCustomerDetails().Data)
        //    {
        //        Console.WriteLine(customer.customer_id + "/" + customer.firstname + "/" + customer.lastname + "/" + customer.company_name);
        //    }
        //}

        //private static void UserAdd()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    userManager.Add(new User
        //    {
        //        firstname = "Derya",
        //        lastname = "Bozan",
        //        email = "deneme@12345",
        //        //password = "12345"

        //    });

        //    foreach (var user in userManager.GetAll().Data)
        //    {
        //        Console.WriteLine(user.firstname + " " + user.lastname);
        //    }
        //}

        //private static void GetCarsDetails()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetCarDetails().Data)
        //    {
        //        Console.WriteLine(car.car_name + "/" + car.brand_name + "/" + car.color_name);
        //    }
        //}

        //private static void CarUpdate()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    carManager.Update(new Car
        //    {
        //        car_id = 6,
        //        brand_id = 7,
        //        color_id = 2,
        //        car_name = "Chery",

        //    });

        //    foreach (var car in carManager.GetAll().Data)
        //    {
        //        Console.WriteLine(car.car_name);
        //    }
        //}

        //private static void CarDelete()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    carManager.Delete(new Car { car_id = 4 });
        //}

        //private static void CarAdd()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    carManager.Add(new Car
        //    {
        //       // car_id = 6,
        //        brand_id = 2,
        //        color_id = 4,
        //        car_name = "Via V15",
        //        daily_price = 400,
        //        model_year = 2014
        //    });

        //    foreach (var car in carManager.GetAll().Data)
        //    {
        //        Console.WriteLine(car.car_name);
        //    }
        //}

        //private static void GetCarsByColorId()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetCarsByColorId(1).Data)
        //    {
        //        Console.WriteLine(car.color_id);
        //    }
        //}

        //private static void GetById()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    Console.WriteLine(carManager.GetById(1).Data.car_name);
        //}

        //private static void GetCarsByBrandId()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetCarsByBrandId(1).Data)
        //    {
        //        Console.WriteLine(car.brand_id);
        //    }
        //}

        //private static void CarTest1()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    foreach (var car in carManager.GetAll().Data)
        //    {
        //        Console.WriteLine(car.car_name);
        //    }
        }
    }
}
