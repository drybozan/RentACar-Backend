using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetRentalById(int rentalId);
        IDataResult<List<Rental>> GetCanBeRented();
        IDataResult<List<RentalDetailDto>> GetRentalsDetails();
        IDataResult<List<Rental>> GetByCustomerId(int customerId);
        IDataResult<List<Rental>> GetByCarId(int carId);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
    }
}
