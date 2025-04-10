namespace TscLoanManagement.TSCDB.Application.DTOs
{
    public class LoanDto
    {
        public int Id { get; set; }
        public string LoanNumber { get; set; }
        public DateTime DateOfWithdraw { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string UtrNumber { get; set; }
        public decimal ProcessingFee { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public VehicleInfoDto VehicleInfo { get; set; }
        public BuyerInfoDto BuyerInfo { get; set; }
        public List<LoanAttachmentDto>? Attachments { get; set; }
    }
}

public class LoanAttachmentDto
{
    public string FilePath { get; set; }
    public string FileType { get; set; } // e.g., "pdf", "jpg", etc.
}