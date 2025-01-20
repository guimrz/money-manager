using AutoMapper;
using MoneyManager.Services.Assets.Application.Objects.Responses;
using MoneyManager.Services.Assets.Domain;

namespace MoneyManager.Services.Assets.Application.Mapping
{
    public class AssetMapProfile : Profile
    {
        public AssetMapProfile()
        {
            CreateMap<Asset, AssetResponse>()
                .ForMember(target => target.Id, map => map.MapFrom(source => source.Id))
                .ForMember(target => target.Name, map => map.MapFrom(source => source.Name))
                .ForMember(target => target.CurrencyId, map => map.MapFrom(source => source.CurrencyId));
        }
    }
}
