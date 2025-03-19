namespace TscLoanManagement.TSCDB.Application.DTOs
{
    public class DealerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public decimal SanctionLimit { get; set; }
        public decimal ProcessingFee { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisteredDate { get; set; }
    }
}
