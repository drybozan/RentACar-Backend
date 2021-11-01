using Business.Abstract;
using Business.Constanst;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class UserManager:IUserService
    {
        IUserDal iUserDal;

        public UserManager(IUserDal iUserDal)
        {
            this.iUserDal = iUserDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            iUserDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        [ValidationAspect(typeof(UserValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            iUserDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(iUserDal.GetAll(),Messages.UsersListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(iUserDal.Get(u => u.userss_id == userId),Messages.UserListed);
        }

        [ValidationAspect(typeof(UserValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User user)
        {
            iUserDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(iUserDal.Get(u => u.email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(iUserDal.GetClaims(user));
        }

        public IDataResult<UserDetailDto> GetUserDetailsByEmail(string email)
        {
            return new SuccessDataResult<UserDetailDto>(iUserDal.GetUserDetailsByEmail(email));
        }

        public IDataResult<List<OperationClaim>> GetClaimsByUserId(int userId)
        {
            User user = iUserDal.Get(u => u.userss_id == userId);
            return new SuccessDataResult<List<OperationClaim>>(iUserDal.GetClaims(user));
        }
    }
}
