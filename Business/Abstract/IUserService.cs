using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        ICustomResult<User> GetByMail(string email);
        ICustomResult<List<OperationClaim>> GetClaims(User user);
        ICustomResult<User> Add(User user);
    }
}
