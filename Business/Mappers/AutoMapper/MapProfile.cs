using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs.BrandDTOs;
using Entities.DTOs.CarDTOs;
using Entities.DTOs.ColorDTOs;
using Entities.DTOs.CustomerDTOs;
using Entities.DTOs.PaymentDTOs;
using Entities.DTOs.RentalDTOs;
using Entities.DTOs.UserDTOs;

namespace Business.Mappers.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Car, CarCreateDto>();
            CreateMap<Car, CarUpdateDto>();
            CreateMap<Car, CarDetailDto>().ReverseMap();

            CreateMap<Brand, BrandCreateDto>();
            CreateMap<Brand, BrandUpdateDto>();

            CreateMap<Color, ColorCreateDto>();
            CreateMap<Color, ColorUpdateDto>();

            CreateMap<User, UserCreateDto>();
            CreateMap<User, UserUpdateDto>();

            CreateMap<Customer, CustomerCreateDto>();
            CreateMap<Customer, CustomerUpdateDto>();


            CreateMap<RentalCreateDto,Rental >();
            CreateMap<Rental, RentalUpdateDto>();
            CreateMap<Rental, RentalDetailDto>();


            CreateMap<Payment, PaymentCreateDto>().ReverseMap();



        }
    }
}
