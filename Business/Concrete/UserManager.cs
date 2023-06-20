using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
            return new SuccessResult<User>(201,entity);
        }

        public ICustomResult<User> Delete(int id)
        {
            _userDal.Delete( _userDal.Get(u => u.Id ==id) );
            return new SuccessResult<User>(204);
        }

        public ICustomResult<User> GetById(int id)
        {
            return new SuccessResult<User>(200,_userDal.Get(u => u.Id==id));
        }

        public ICustomResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return new SuccessResult<List<User>>(200,_userDal.GetAll(filter));
        }

        public ICustomResult<User> Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult<User>(204,entity);
        }
    }
}
