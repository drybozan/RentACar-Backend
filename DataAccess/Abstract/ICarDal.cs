using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarsByBrands(int brandId);
        List<CarDetailDto> GetCarsByColors(int colorId);
        List<CarDetailDto> GetCarsByBrandsAndColours(int brandId, int colourId);
        List<CarDetailDto> GetCarDetailsByCarId(int carId);

    }
}
