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
    public class ColourManager : IColourService
    {
        IColourDal iColourDal;
        ICarService _carService;

        public ColourManager(IColourDal iColourDal,ICarService iCarService)
        {
            this.iColourDal = iColourDal;
            _carService = iCarService;
        }

        [ValidationAspect(typeof(ColourValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("admin")]
        public IResult Add(Colour colour)
        {
            IResult result = BusinessRules.Run(
              CheckIfColourNameIsAlreadyExists(colour.color_name)
          );

            if (result != null)
            {
                return result;
            }
            iColourDal.Add(colour);
            return new SuccessResult(Messages.ColorAdded);
        }

        [ValidationAspect(typeof(ColourValidator))]
        [TransactionScopeAspect]
        [SecuredOperation("admin")]
        public IResult Delete(Colour colour)
        {
            IResult result = BusinessRules.Run(
               CheckIfColorIdIsNotExists(colour.color_id)
           );

            if (result != null)
            {
                return result;
            }
            //_carService.GetCarsByColorId(colour.color_id).Data.ForEach(c => _carService.Delete(c));
            iColourDal.Delete(colour);
            return new SuccessResult(Messages.ColorDeleted);
        }

        [CacheAspect]
        public IDataResult< List<Colour>> GetAll()
        {
            return new SuccessDataResult<List<Colour>> (iColourDal.GetAll(),Messages.ColorsListed);
        }

        [CacheAspect]
        public IDataResult<Colour> GetByName(string colorName)
        {
            return new SuccessDataResult<Colour>(iColourDal.Get(c => c.color_name == colorName));
        }

        [CacheAspect]
        public IDataResult<Colour> GetById(int id)
        {
            return new SuccessDataResult<Colour> ( iColourDal.Get(c => c.color_id == id),Messages.ColorListed);
        }

        [ValidationAspect(typeof(ColourValidator))]
        [TransactionScopeAspect]
        [SecuredOperation("admin")]
        public IResult Update(Colour colour)
        {
            IResult result = BusinessRules.Run(
                CheckIfColorIdIsNotExists(colour.color_id),
                CheckIfColourNameIsAlreadyExists(colour.color_name)
            );

            if (result != null)
            {
                return result;
            }

            iColourDal.Update(colour);
            return new SuccessResult(Messages.ColorUpdated);
        }

        private IResult CheckIfColorIdIsNotExists(int colorId)
        {
            var result = iColourDal.Get(c => c.color_id == colorId);
            if (result == null)
            {
                return new ErrorResult("Böyle bir renk yok");
            }

            return new SuccessResult();
        }

        private IResult CheckIfColourNameIsAlreadyExists(string colorName)
        {
            var result = iColourDal.Get(b => b.color_name == colorName);
            if (result != null)
            {
                return new ErrorResult("Renk Mevcut");
            }

            return new SuccessResult();
        }
    }
}
