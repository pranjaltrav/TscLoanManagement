namespace TscLoanManagement.TSCDB.Application.DTOs
{
    public class DocumentUploadDto
    {
        public int? DealerId { get; set; }
        public int? BorrowerDetailsId { get; set; }   // ✅ match entity
        public int? GuarantorDetailsId { get; set; }  // ✅ match entity
        public string DocumentType { get; set; }
        public string FilePath { get; set; }
    }
}
