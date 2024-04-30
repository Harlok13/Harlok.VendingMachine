using AutoMapper;
using Harlok.VendingMachine.Contracts.Data;
using Harlok.VendingMachine.Contracts.Request;
using Harlok.VendingMachine.Contracts.Response;
using Harlok.VendingMachine.Domain.Primitives;

namespace Harlok.VendingMachine.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DrinkDto, GetAllDrinksResponse>();
        CreateMap<GetAllDrinksResponse, DrinkDto>();
        CreateMap<AddCoinRequest, Coin>();
    }
}