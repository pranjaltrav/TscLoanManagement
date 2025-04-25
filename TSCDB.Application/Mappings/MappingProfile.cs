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
            CreateMap<Dealer, DealerDto>().ReverseMap();
            CreateMap<Dealer, DealerDto>()
                .ForMember(dest => dest.ChequeDetails, opt => opt.MapFrom(src => src.ChequeDetails))
                .ForMember(dest => dest.BorrowerDetails, opt => opt.MapFrom(src => src.BorrowerDetails))
                .ForMember(dest => dest.GuarantorDetails, opt => opt.MapFrom(src => src.GuarantorDetails))
                .ForMember(dest => dest.SecurityDepositDetails, opt => opt.MapFrom(src => src.SecurityDepositDetails));



            CreateMap<BorrowerDetails, BorrowerDetailsDto>().ReverseMap();
            CreateMap<GuarantorDetails, GuarantorDetailsDto>().ReverseMap();
            CreateMap<ChequeDetails, ChequeDetailsDto>().ReverseMap();
            CreateMap<SecurityDepositDetails, SecurityDepositDetailsDto>().ReverseMap();
            CreateMap<DocumentUpload, DocumentUploadDto>().ReverseMap();





            // Loan Mappings
            CreateMap<LoanDto, Loan>()
                .ForMember(dest => dest.Attachments, opt => opt.Ignore())
                .ForMember(dest => dest.Dealer, opt => opt.Ignore());

            CreateMap<Loan, LoanDto>()
                .ForMember(dest => dest.DealerName, opt => opt.MapFrom(src => src.Dealer.DealershipName))
                .ForMember(dest => dest.Attachments, opt => opt.Ignore());



            CreateMap<Loan, LoanDto>()
                .ForMember(dest => dest.DealerName, opt => opt.MapFrom(src => src.Dealer.DealershipName))
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
