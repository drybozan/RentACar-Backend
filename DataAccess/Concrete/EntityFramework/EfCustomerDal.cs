using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.customers
                             join u in context.userss
                             on c.user_id equals u.userss_id

                             select new CustomerDetailDto
                             {
                                 customer_id = c.customer_id,
                                 firstname = u.firstname,
                                 lastname = u.lastname,
                                 email=u.email,
                                 company_name = c.company_name
                             };
                return result.ToList();
            }
        }
    }
}
