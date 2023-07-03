using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Functions;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.RentalDTOs;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        readonly IRentalDal _rentalDal;
        private IMapper _mapper;

        public RentalManager(IRentalDal rentalDal, IMapper mapper)
        {
            _rentalDal = rentalDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult<Rental> Create(RentalCreateDto dto)
        {
            var isCarAvailable = _rentalDal.Get(r => r.CarId == dto.CarId && r.ReturnDate == null && r.IsPaid == 1);


            // If car is not available right now
            if (isCarAvailable != null)
                return new ErrorResult<Rental>(OperationMessages.ErrorTitle, "Car is not available right now.");


            var entity = _mapper.Map<Rental>(dto);

            _rentalDal.Create(entity);
            return new CreatedResult<Rental>(OperationMessages.SuccessTitle,OperationMessages.SuccessMessage, entity);

        }

        public IResult<Rental> Delete(int id)
        {
            _rentalDal.Delete(_rentalDal.Get(r => r.Id == id));
            return new NoContentResult<Rental>();
        }

        public IResult<Rental> GetById(int id)
        {
            return new SuccessResult<Rental>(OperationMessages.SuccessTitle,OperationMessages.SuccessTitle, _rentalDal.Get(r => r.Id == id));
        }

        public IResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessResult<List<Rental>>(OperationMessages.SuccessTitle,OperationMessages.SuccessTitle, _rentalDal.GetAll(filter));
        }

        public IResult<Rental> Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult<Rental>(OperationMessages.SuccessTitle,OperationMessages.SuccessMessage, entity);
        }

        public IResult<List<RentalDetailDto>> GetRentalsWithDetail()
        {
            return new SuccessResult<List<RentalDetailDto>>(OperationMessages.SuccessTitle,OperationMessages.SuccessTitle, _rentalDal.GetRentalsWithDetail());
        }

        public IResult<RentalDetailDto> GetRentalWithDetail(int rentalId)
        {
            var data = _rentalDal.GetRentalWithDetail(rentalId);

            var mapped = _mapper.Map<RentalDetailDto>(data);

            var days = DateFunctions.DateDifferentByString(mapped.RentDate, mapped.PlannedReturnDate).Days;

            mapped.Price = days * mapped.Car.DailyPrice;

            return new SuccessResult<RentalDetailDto>(OperationMessages.SuccessTitle,OperationMessages.SuccessTitle, mapped);
        }
    }
}
