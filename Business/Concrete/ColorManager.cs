using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Exceptions;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;
        private readonly ICarService _carService;



        public ColorManager(IColorDal colorDal, ICarService carService)
        {
            _colorDal = colorDal;
            _carService = carService;
        }

        public IResult<Color> Create(Color entity)
        {
            _colorDal.Create(entity);

            return new CreatedResult<Color>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage,entity);
        }

        public IResult<Color> Delete(int id)
        {
            var result = BusinessRules.Run(
                    ColorHasAnyCar(id)
            );

            if(result != null)
            {
                return result;
            }

            
            
            _colorDal.Delete(_colorDal.Get(c => c.ColorId == id));

            return new NoContentResult<Color>();
        }

        public IResult<Color> GetById(int id)
        {
            return new SuccessResult<Color>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, _colorDal.Get(c => c.ColorId == id));
        }

        public IResult<List<Color>> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return new SuccessResult<List<Color>>(OperationMessages.SuccessTitle,OperationMessages.SuccessMessage,_colorDal.GetAll(filter));
        }

        public IResult<Color> Update(Color entity)
        {
            _colorDal.Update(entity);

            return new SuccessResult<Color>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, entity);
        }



        private IResult<Color> ColorHasAnyCar(int colorId)
        {
            var car = _carService.GetByColorAndBrand(colorId,0);


            if (car.data.Count == 0)
            {
                return new NoContentResult<Color>();
            }
            else
            {
                throw new ConflictException("This color using by Cars. Please first change car's color.");
            }
        }
    }
}
