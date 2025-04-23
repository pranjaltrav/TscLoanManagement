namespace TscLoanManagement.TSCDB.Application.DTOs
{
    public class SecurityDepositDetailsDto
    {
        public int Id { get; set; }
        public int DealerId { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public string UTRNumber { get; set; }
        public DateTime? DateReceived { get; set; }
        public DateTime? DateRefunded { get; set; }
        public string AttachmentUrl { get; set; }
        public string Remarks { get; set; }
    }
}
