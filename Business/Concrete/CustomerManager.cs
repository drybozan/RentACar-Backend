using Business.Abstract;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal iCustomerDal;
        IRentalService _rentalService;

        public CustomerManager(ICustomerDal iCustomerDal, IRentalService rentalService)
        {
            this.iCustomerDal = iCustomerDal;
            _rentalService = rentalService;
        }

        
        [ValidationAspect(typeof(CustomerValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            iCustomerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer customer)
        {
            IResult result = BusinessRules.Run(
             CheckIfCustomerIdIsNotExists(customer.customer_id)
         );

            if (result != null)
            {
                return result;
            }

            _rentalService.GetByCustomerId(customer.customer_id).Data.ForEach(r => _rentalService.Delete(r));
            iCustomerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(iCustomerDal.GetAll(),Messages.CustomersListed);
        }

        [CacheAspect]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(iCustomerDal.Get(c => c.user_id == id),Messages.CustomerListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(iCustomerDal.GetCustomerDetails(),Messages.CustomersListed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            IResult result = BusinessRules.Run(
               CheckIfCustomerIdIsNotExists(customer.customer_id)
           );

            if (result != null)
            {
                return result;
            }
            iCustomerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        private IResult CheckIfCustomerIdIsNotExists(int customerId)
        {
            var result = iCustomerDal.Get(c => c.customer_id == customerId);
            if (result == null)
            {
                return new ErrorResult("Böyle bir müşteri yok.");
            }

            return new SuccessResult();
        }
    }
}
