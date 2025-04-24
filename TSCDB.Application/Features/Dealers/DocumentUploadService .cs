using AutoMapper;
using TscLoanManagement.TSCDB.Application.DTOs;
using TscLoanManagement.TSCDB.Application.Interfaces;
using TscLoanManagement.TSCDB.Core.Domain.Dealer;
using TscLoanManagement.TSCDB.Core.Interfaces.Repositories;

namespace TscLoanManagement.TSCDB.Application.Features.Dealers
{
    public class DocumentUploadService : IDocumentUploadService
    {
        private readonly IGenericRepository<DocumentUpload> _documentRepo;
        private readonly IMapper _mapper;

        public DocumentUploadService(IGenericRepository<DocumentUpload> documentRepo, IMapper mapper)
        {
            _documentRepo = documentRepo;
            _mapper = mapper;
        }

        public async Task<DocumentUploadDto> UploadDocumentAsync(DocumentUploadDto dto)
        {
            var entity = _mapper.Map<DocumentUpload>(dto);
            entity.UploadedOn = DateTime.UtcNow;
            await _documentRepo.AddAsync(entity);
            return _mapper.Map<DocumentUploadDto>(entity);
        }

        public async Task<DocumentUploadDto> GetByIdAsync(int id)
        {
            var entity = await _documentRepo.GetByIdAsync(id);
            return _mapper.Map<DocumentUploadDto>(entity);
        }

        public async Task<List<DocumentUploadDto>> GetByDealerIdAsync(int dealerId)
        {
            var entities = await _documentRepo.GetAllAsync(d => d.DealerId == dealerId);
            return _mapper.Map<List<DocumentUploadDto>>(entities);
        }

    }
}
