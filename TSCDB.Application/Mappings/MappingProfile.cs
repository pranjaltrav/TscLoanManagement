using static System.Runtime.InteropServices.JavaScript.JSType;
using TscLoanManagement.TSCDB.Application.DTOs;
using TscLoanManagement.TSCDB.Core.Domain.Authentication;
using TscLoanManagement.TSCDB.Core.Domain.Dealer;
using TscLoanManagement.TSCDB.Core.Domain.Loan;
using AutoMapper;

namespace TscLoanManagement.TSCDB.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User Mappings
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<RegisterRequestDto, User>();


            // Dealer Mappings
            CreateMap<DealerDto, Dealer>()
                        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                        .ReverseMap();

            // Loan Mappings
            CreateMap<LoanDto, Loan>()
                .ForMember(dest => dest.Attachments, opt => opt.Ignore())
                .ForMember(dest => dest.Dealer, opt => opt.Ignore());

            CreateMap<Loan, LoanDto>()
                .ForMember(dest => dest.DealerName, opt => opt.MapFrom(src => src.Dealer.Name))
                .ForMember(dest => dest.Attachments, opt => opt.Ignore());



            CreateMap<Loan, LoanDto>()
                .ForMember(dest => dest.DealerName, opt => opt.MapFrom(src => src.Dealer.Name))
                .ForMember(dest => dest.Attachments, opt => opt.MapFrom(src =>
                    src.Attachments.Select(a => a.FilePath)));

            // VehicleInfo Mappings
            CreateMap<VehicleInfo, VehicleInfoDto>();
            CreateMap<VehicleInfoDto, VehicleInfo>();

            // BuyerInfo Mappings
            CreateMap<BuyerInfo, BuyerInfoDto>();
            CreateMap<BuyerInfoDto, BuyerInfo>();
        }
    }
}
