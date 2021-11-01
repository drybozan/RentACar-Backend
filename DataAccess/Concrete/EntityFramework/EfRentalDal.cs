using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalsDto()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.rentals
                             join c in context.cars
                                 on r.car_id equals c.car_id
                             join cu in context.customers
                                 on r.customer_id equals cu.customer_id
                            join br in context.brands
                                 on c.brand_id equals br.brand_id
                             join u in context.userss
                               on cu.user_id equals u.userss_id
                             select new RentalDetailDto
                             {
                                 rental_id = r.car_id,
                                 brand_name=br.brand_name,
                                 customer_name = u.firstname + " " + u.lastname,
                                 rent_date = r.rent_date.Value,
                                 return_date = r.return_date.Value,
                                 daily_price = c.daily_price,
                                 
                             };
                return result.ToList();
            }
        }
    }
}
