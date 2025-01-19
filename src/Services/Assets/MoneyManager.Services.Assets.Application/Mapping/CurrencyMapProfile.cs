using AutoMapper;
using MoneyManager.Services.Assets.Application.Objects.Responses;
using MoneyManager.Services.Assets.Domain;

namespace MoneyManager.Services.Assets.Application.Mapping
{
    public class CurrencyMapProfile : Profile
    {
        public CurrencyMapProfile()
        {
            CreateMap<Currency, CurrencyResponse>()
                .ForMember(target => target.Id, map => map.MapFrom(source => source.Id))
                .ForMember(target => target.Code, map => map.MapFrom(source => source.Code))
                .ForMember(target => target.Name, map => map.MapFrom(source => source.Name))
                .ForMember(target => target.Symbol, map => map.MapFrom(source => source.Symbol));
        }
    }
}
