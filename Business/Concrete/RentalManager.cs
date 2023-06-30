using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarDTOs;
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

        public ICustomResult<Rental> Create(RentalCreateDto dto)
        {
            var isCarAvailable = _rentalDal.Get(r => r.CarId == dto.CarId && r.ReturnDate == null);


            // If car is not available right now
            if(isCarAvailable != null)
                return new ErrorResult<Rental>(400,"Car is not available right now.");


            var entity = _mapper.Map<Rental>(dto);

            _rentalDal.Create(entity);
            return new SuccessResult<Rental>(201,entity);

        }

        public ICustomResult<Rental> Delete(int id)
        {
            _rentalDal.Delete( _rentalDal.Get(r => r.Id==id));
            return new SuccessResult<Rental>(204);
        }

        public ICustomResult<Rental> GetById(int id)
        {
            return new SuccessResult<Rental>(200,_rentalDal.Get(r => r.Id==id));
        }

        public ICustomResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessResult<List<Rental>>(200,_rentalDal.GetAll(filter));
        }

        public ICustomResult<Rental> Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult<Rental>(204,entity);
        }

        public ICustomResult<List<RentalDetailDto>> GetRentalsWithDetail()
        {
            return new SuccessResult<List<RentalDetailDto>>(200, _rentalDal.GetRentalsWithDetail());
        }

        public ICustomResult<RentalDetailDto> GetRentalWithDetail(int rentalId)
        {
            var data = _rentalDal.GetRentalWithDetail(rentalId);

            var mapped = _mapper.Map<RentalDetailDto>(data);

            return new SuccessResult<RentalDetailDto>(200,mapped);
        }
    }
}
