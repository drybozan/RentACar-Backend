using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            { new Car{car_id=1,brand_id=1,color_id=2,model_year=2020,daily_price=15000,car_name="son model araba"},
              new Car{car_id=2,brand_id=2,color_id=3,model_year=1995,daily_price=500000,car_name="son model araba"},
                     

            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);       
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.car_id == car.car_id );
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsByBrands(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsByBrandsAndColours(int brandId, int colourId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsByColors(int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.car_id == car.car_id);
            carToUpdate.car_id = car.car_id;
            carToUpdate.brand_id = car.brand_id;
            carToUpdate.color_id = car.color_id;
            carToUpdate.daily_price = car.daily_price;
            carToUpdate.car_name = car.car_name;
        }
    }
}
