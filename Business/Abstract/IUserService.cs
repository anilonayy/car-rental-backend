using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        IResult<User> GetByMail(string email);
        IResult<List<OperationClaim>> GetClaims(User user);
        IResult<User> Add(User user);
    }
}
