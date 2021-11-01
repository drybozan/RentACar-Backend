using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
        public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>, IUserDal
        {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentACarContext())
            {
                var result = from operationClaim in context.operation_claims
                             join userOperationClaim in context.user_operation_claims
                                 on operationClaim.claim_id equals userOperationClaim.operation_claim_id
                             where userOperationClaim.userss_id == user.userss_id
                             select new OperationClaim { claim_id = operationClaim.claim_id, claim_name = operationClaim.claim_name };
                return result.ToList();

            }
        }

        public UserDetailDto GetUserDetailsByEmail(string email)
        {
            using (var context = new RentACarContext())
            {
                var result = from user in context.userss.Where(u => u.email == email)
                             select new UserDetailDto
                             {
                                 userss_id = user.userss_id,
                                 firstname = user.firstname,
                                 lastname = user.lastname,
                                 email = user.email
                             };
                return result.FirstOrDefault();
            }
        }

    }
    
}
