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
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal iBrandDal;
        ICarService _carService;

        public BrandManager(IBrandDal iBrandDal,ICarService iCarService)
        {
            this.iBrandDal = iBrandDal;
            _carService = iCarService;
        }

        [ValidationAspect(typeof(BrandValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("admin")]
        public IResult Add(Brand brand)
        {
            IResult result = BusinessRules.Run(
                CheckIfBrandNameIsAlreadyExists(brand.brand_name)
                );

            if (result != null)
            {
                return result;
            }
            iBrandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [ValidationAspect(typeof(BrandValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(Brand brand)
        {
            IResult result = BusinessRules.Run(
                CheckIfBrandIdIsNotExists(brand.brand_id)
                );

            if (result != null)
            {
                return result;
            }

           // _carService.GetCarsByBrandId(brand.brand_id).Data.ForEach(c => _carService.Delete(c));
            iBrandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IDataResult< List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>> ( iBrandDal.GetAll(),Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult <Brand> (iBrandDal.Get(b => b.brand_id == id), Messages.BrandListed);
        }

        [ValidationAspect(typeof(BrandValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("admin")]
        public IResult Update(Brand brand)
        {
            IResult result = BusinessRules.Run(
               CheckIfBrandIdIsNotExists(brand.brand_id),
               CheckIfBrandNameIsAlreadyExists(brand.brand_name)
               );

            if (result != null)
            {
                return result;
            }
            iBrandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        private IResult CheckIfBrandIdIsNotExists(int brandId)
        {
            var result = iBrandDal.Get(b => b.brand_id == brandId);
            if (result == null)
            {
                return new ErrorResult("Böyle bir marka yok");
            }

            return new SuccessResult();
        }

        private IResult CheckIfBrandNameIsAlreadyExists(string brandName)
        {
            var result = iBrandDal.Get(b => b.brand_name == brandName);
            if (result != null)
            {
                return new ErrorResult("Marka Mevcut");
            }

            return new SuccessResult();
        }
    }
}
