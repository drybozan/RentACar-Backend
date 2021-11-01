using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal iPaymentDal;
        ICreditCardDal iCreditCardDal;

        public PaymentManager(IPaymentDal iPaymentDal , ICreditCardDal iCreditCardDal)
        {
            this.iPaymentDal = iPaymentDal;
            this.iCreditCardDal = iCreditCardDal;
        }

        public IResult Pay(Payment payment)
        {
            iPaymentDal.Add(payment);
            return new SuccessResult("Ödeme işlemi başarılı");
        }

     
    }
}
