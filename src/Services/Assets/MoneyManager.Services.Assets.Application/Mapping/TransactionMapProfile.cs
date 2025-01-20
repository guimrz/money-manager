using AutoMapper;
using MoneyManager.Services.Assets.Application.Objects.Responses;
using MoneyManager.Services.Assets.Domain;

namespace MoneyManager.Services.Assets.Application.Mapping
{
    public class TransactionMapProfile : Profile
    {
        public TransactionMapProfile()
        {
            CreateMap<Transaction, TransactionResponse>()
                .ForMember(target => target.Id, map => map.MapFrom(source => source.Id))
                .ForMember(target => target.Date, map => map.MapFrom(source => source.Date))
                .ForMember(target => target.Description, map => map.MapFrom(source => source.Description))
                .ForMember(target => target.Amount, map => map.MapFrom(source => source.Value));
        }
    }
}
