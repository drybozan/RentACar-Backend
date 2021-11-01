using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            //join işlemi
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.cars
                             join b in context.brands on c.brand_id equals b.brand_id
                             join co in context.colours on c.color_id equals co.color_id

                             select new CarDetailDto
                             {
                                 car_id= c.car_id,
                                 car_name = c.car_name,
                                 brand_name = b.brand_name,
                                 color_name = co.color_name,
                                 daily_price = c.daily_price,
                                 model_year = c.model_year
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            var details = GetCarDetails();
            return details.Where(x => x.car_id == carId).ToList();
        }

        public List<CarDetailDto> GetCarsByBrands(int brandId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.cars
                             join b in context.brands on c.brand_id equals b.brand_id
                             join co in context.colours on c.color_id equals co.color_id
                             where b.brand_id==brandId
                             select new CarDetailDto
                             {
                                 
                                 car_name = c.car_name,
                                 brand_name = b.brand_name,
                                 color_name = co.color_name,
                                 daily_price = c.daily_price,
                                 model_year = c.model_year
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsByBrandsAndColours(int brandId, int colourId)
        {
            var carResult = GetAll(x => x.color_id == colourId && x.brand_id == brandId);

            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in carResult
                             join colour in context.colours on car.color_id equals colour.color_id
                             join brand in context.brands on car.brand_id equals brand.brand_id
                             select new CarDetailDto()
                             {
                                 car_id = car.car_id,
                                 brand_name = brand.brand_name,
                                 car_name = car.car_name,
                                 color_name = colour.color_name,
                                 daily_price = car.daily_price,
                                  model_year = car.model_year
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsByColors(int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.cars
                             join b in context.brands on c.brand_id equals b.brand_id
                             join co in context.colours on c.color_id equals co.color_id
                             where co.color_id == colorId
                             select new CarDetailDto
                             {

                                 car_name = c.car_name,
                                 brand_name = b.brand_name,
                                 color_name = co.color_name,
                                 daily_price = c.daily_price,
                                 model_year = c.model_year
                             };
                return result.ToList();
            }
        }
    }
}
