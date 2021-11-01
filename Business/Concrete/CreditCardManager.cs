using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    class CreditCardManager : ICreditCardService

    {

        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

       

        public IResult Add(CreditCard creditCard)
        {
            /*var creditCardOfCustomer = _creditCardDal.Get(cc => cc.customer_id == creditCard.customer_id && cc.card_number.Equals(creditCard.card_number));
            if (creditCardOfCustomer is null)
            {
                _creditCardDal.Add(creditCard);
                return new SuccessResult("Kredi Kartı Eklendi");
            }
            return new SuccessResult("Kredi Kartı Eklendi");*/
            _creditCardDal.Add(creditCard);
            return new SuccessResult("Kredi Kartı Eklendi");
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult("Kredi Kartı Silindi.");
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<List<CreditCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(cc => cc.customer_id == customerId).ToList());
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult("Kredi Kartınız Güncellendi");
        }
    }
}
