using BusinessObject.Models;

namespace DataAccess.Repository
{
    public class CarRepository : ICar
    {
        NgoncAssignment1Context context;
        public void DeleteCar(int id)
        {
            Car car = this.GetById(id);
            if (car != null)
            {
                if (context == null)
                {
                    context = new NgoncAssignment1Context();
                }
                context.Cars.Remove(car);
                context.SaveChanges();
            } else
            {
                throw new Exception($"Car witd Id: {id} is not Existed !!!");
            }
        }

        public Car GetById(int id)
        {
            if (context == null)
            {
                context = new NgoncAssignment1Context();
            }
            Car car = context.Cars.Find(id);
            return car;
        }

        public List<Car> GetListOfCar()
        {
            if (context == null)
            {
                context = new NgoncAssignment1Context();
            }
            IEnumerable<Car> carList = context.Cars;
            return carList.ToList();
        }

        public void UpdateCar(Car car)
        {
            if (context == null)
            {
                context = new NgoncAssignment1Context();
            }
            context.Update(car);
            context.SaveChanges();
        }

        public void AddCar(Car car)
        {
            if(context == null)
            {
                context= new NgoncAssignment1Context();
            }
            context.Add(car);
            context.SaveChanges();
        }

    }
}
