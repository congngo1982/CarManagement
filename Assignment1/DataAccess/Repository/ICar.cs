using BusinessObject.Models;

namespace DataAccess.Repository
{
    public interface ICar
    {
        public List<Car> GetListOfCar();
        public Car GetById(int id);
        public void UpdateCar(Car car);
        public void DeleteCar(int id);
        public void AddCar(Car car);
    }
}
