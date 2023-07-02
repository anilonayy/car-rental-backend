using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public ICustomResult<User> Create(User entity)
        {
            _userDal.Create(entity);
            return new SuccessResult<User>(201, entity);
        }

        public ICustomResult<User> Delete(int id)
        {
            _userDal.Delete(_userDal.Get(u => u.Id == id));
            return new SuccessResult<User>(204);
        }

        public ICustomResult<User> GetById(int id)
        {
            return new SuccessResult<User>(200, _userDal.Get(u => u.Id == id));
        }

        public ICustomResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return new SuccessResult<List<User>>(200, _userDal.GetAll(filter));
        }

        public ICustomResult<User> Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult<User>(204, entity);
        }

        public ICustomResult<User> GetByMail(string email)
        {
            var user = _userDal.Get(u => u.Email == email);
            if (user == null)
            {
                return new ErrorResult<User>(200, Messages.UserNotFound);
            }
            else
            {
                return new SuccessResult<User>(200, user);
            }
        }

        public ICustomResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessResult<List<OperationClaim>>(200, _userDal.GetClaims(user));
        }

        public ICustomResult<User> Add(User user)
        {
            _userDal.Create(user);
            return new SuccessResult<User>(200);
        }
    }
}
