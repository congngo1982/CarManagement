// See https://aka.ms/new-console-template for more information
using BusinessObject.Models;
using DataAccess;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Ngo!");
            getList();
            deleteCar();
            getList();
        }

        static void getList()
        {
            CarDAO carDAO = new CarDAO();
            var list = carDAO.GetAllCar();
            foreach (var car in list)
            {
                Console.WriteLine($"Id {car.Id} Name {car.Name} Brand {car.Brand}");
            }
        }
        static void getCar()
        {
            CarDAO carDAO = new CarDAO();
            Car car = carDAO.GetCarById(1);
            Console.WriteLine($"Name {car.Name} Brand {car.Brand} Manu {car.Manufacture}");
        }

        static void updateCar()
        {
            CarDAO carDAO = new CarDAO();
            Car car = carDAO.GetCarById(4);
            car.Name = "Car Test";
            carDAO.UpdateCar(car);
        }

        static void deleteCar()
        {
            CarDAO carDAO = new CarDAO();
            carDAO.DeleteCar(4);
        }

        static void addCar()
        {
            //CarDAO carDAO = new CarDAO();
            //Car car = new Car();
            //car.Name = "Test";
            //car.Brand = "Test";
            //car.Color = "Test";
            //car.Manufacture = "Test";
            //car.Category = 2;
            //carDAO.AddCar(car);
        }
    }
}
