using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Messages;
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

        public IResult<User> Create(User entity)
        {
            _userDal.Create(entity);
            return new CreatedResult<User>(OperationMessages.SuccessMessage,OperationMessages.SuccessMessage, entity);
        }

        public IResult<User> Delete(int id)
        {
            _userDal.Delete(_userDal.Get(u => u.Id == id));
            return new NoContentResult<User>();
        }

        public IResult<User> GetById(int id)
        {
            return new SuccessResult<User>(OperationMessages.SuccessMessage, OperationMessages.SuccessMessage, _userDal.Get(u => u.Id == id));
        }

        public IResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return new SuccessResult<List<User>>(OperationMessages.SuccessMessage,OperationMessages.SuccessMessage, _userDal.GetAll(filter));
        }

        public IResult<User> Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult<User>(OperationMessages.SuccessMessage, OperationMessages.SuccessMessage, entity);
        }

        public IResult<User> GetByMail(string email)
        {
            var user = _userDal.Get(u => u.Email == email);
            if (user == null)
            {
                return new ErrorResult<User>(OperationMessages.ErrorTitle, Messages.UserNotFound);
            }
            else
            {
                return new SuccessResult<User>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, user);
            }
        }

        public IResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessResult<List<OperationClaim>>(OperationMessages.SuccessMessage, OperationMessages.SuccessMessage, _userDal.GetClaims(user));
        }

        public IResult<User> Add(User user)
        {
            _userDal.Create(user);
            return new CreatedResult<User>(OperationMessages.SuccessMessage, OperationMessages.SuccessMessage,user);
        }
    }
}
