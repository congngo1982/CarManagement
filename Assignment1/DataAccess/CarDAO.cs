using DataAccess.Repository;
using BusinessObject.Models;

namespace DataAccess
{
    public class CarDAO
    {
        private ICar car;
        public CarDAO()
        {
            car = new CarRepository();
        }

        public List<Car> GetAllCar()
        {
            return car.GetListOfCar();
        }

        public Car GetCarById(int id)
        {
            return car.GetById(id);
        }

        public void AddCar(Car newCar)
        {
            car.AddCar(newCar);
        }

        public void UpdateCar(Car carUpdate)
        {
            car.UpdateCar(carUpdate);
        }

        public void DeleteCar(int id)
        {
            car.DeleteCar(id);
        }

    }
}
