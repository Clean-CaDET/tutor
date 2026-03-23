using AutoMapper;
using Tutor.Courses.API.Dtos.TokenWallet;
using Tutor.Courses.Core.Domain.TokenWallet;

namespace Tutor.Courses.Core.Mappers;

public class TokenWalletProfile : Profile
{
    public TokenWalletProfile()
    {
        CreateMap<Wallet, TokenWalletDto>();
        
        CreateMap<TokenSpendingRequestDto, TokenSpendingRequest>()
            .ForMember(dest => dest.FeatureType, opt => opt.MapFrom(src => Enum.Parse<AiFeatureType>(src.FeatureType)));
    }
}
