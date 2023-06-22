using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepsitoryBase<User, Context>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using(var context = new Context())
            {
                var result = from operationClaims in context.OperationClaims
                             join userOperationClaims in context.UserOperationClaims

                             on operationClaims.Id equals userOperationClaims.OperationClaimId

                             where userOperationClaims.UserId == user.Id

                             select new OperationClaim { Id = operationClaims.Id, Name = operationClaims.Name };


                return result.ToList();

            }
        }
    }
}
