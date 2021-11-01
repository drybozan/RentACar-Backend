using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarsByBrandsAndColours(int brandId, int colourId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId);
        IDataResult< Car> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();



    }
}
