using Business.Abstract;
using Business.Constanst;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{

    public class RentalManager : IRentalService
    {
        IRentalDal iRentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            iRentalDal = rentalDal;
        }
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(iRentalDal.GetAll(), Messages.RentalsListed);
        }

        [CacheAspect]
        public IDataResult<Rental> GetRentalById(int rentalId)
        {
            return new SuccessDataResult<Rental>(iRentalDal.Get(r => r.rental_id == rentalId), Messages.RentalListed);
        }
        [CacheAspect]
        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(iRentalDal.GetAll(r => r.car_id == carId));
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(iRentalDal.GetAll(r => r.customer_id == customerId));
        }

        public IDataResult<List<Rental>> GetCanBeRented()
        {
            return new SuccessDataResult<List<Rental>>(iRentalDal.GetAll(r => r.return_date < DateTime.Now.Date),
                Messages.RentalsListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(iRentalDal.GetRentalsDto(), Messages.RentalsListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            if (!IsCarAvailable(rental.car_id))
            {

                return new ErrorResult(Messages.RentalCarNotAvailable);
            }
            iRentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            iRentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            iRentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private bool IsCarAvailable(int id)
        {
            var carRentalHistory = iRentalDal.Get(r => r.car_id == id && r.return_date == null);
            if (carRentalHistory == null)
            {
                return true;
            }
            return false;
        }
    }
}
