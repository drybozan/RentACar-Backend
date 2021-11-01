using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constanst;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal iCarDal;
        private IRentalService _rentalService;
        private ICarImageService _carImageService;

        public CarManager(ICarDal iCarDal, IRentalService rentalService, ICarImageService carImageService)
        {
            this.iCarDal = iCarDal;
            _rentalService = rentalService;
            _carImageService = carImageService;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
           /* IResult result = BusinessRules.Run(
               CheckIfCarIdIsNotExists(car.car_id)
           );


            if (result != null)
            {
                return result;
            }*/


            iCarDal.Add(car);
            return new SuccessResult(Messages.CarAdd);
            
            
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _rentalService.GetByCarId(car.car_id).Data.ForEach(r => _rentalService.Delete(r));
            _carImageService.GetCarImages(car.car_id).Data.ForEach(c => _carImageService.Delete(c.car_id));
            iCarDal.Delete(car);
            return new SuccessResult(Messages.CarDelete);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(iCarDal.GetAll(),Messages.CarList); //database'in getAll() fonksiyonunu çağırdık
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(iCarDal.Get(c => c.car_id == id));
        }

        public IDataResult < List<CarDetailDto> >GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(iCarDal.GetCarDetails(),Messages.CarList);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(iCarDal.GetCarDetailsByCarId(carId));
        }

        [CacheAspect]
        public IDataResult< List<CarDetailDto> >GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>( iCarDal.GetCarsByBrands(brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandsAndColours(int brandId, int colourId)
        {
            var result = iCarDal.GetCarsByBrandsAndColours(brandId, colourId);

            return new SuccessDataResult<List<CarDetailDto>>(iCarDal.GetCarsByBrandsAndColours(brandId, colourId));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>> (iCarDal.GetCarsByColors(colorId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            IResult result = BusinessRules.Run(
                CheckIfCarIdIsNotExists(car.car_id)
            );


            if (result != null)
            {
                return result;
            }
            iCarDal.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }

        private IResult CheckIfCarIdIsNotExists(int carId)
        {
            var result = iCarDal.Get(c => c.car_id == carId);
            if (result == null)
            {
                return new ErrorResult("Bu bilgilerde bir araç yok.");
            }

            return new SuccessResult();
        }
    }
}
