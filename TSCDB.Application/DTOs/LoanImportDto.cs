namespace TscLoanManagement.TSCDB.Application.DTOs
{
    public class LoanImportDto
    {
        public string? LoanNumber { get; set; }
        public DateTime DateOfWithdraw { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int DealerId { get; set; }
        public string? UtrNumber { get; set; }
        public decimal ProcessingFee { get; set; }
        public DateTime DueDate { get; set; }

        // Vehicle Information
        public string? VehicleMake { get; set; }
        public string? VehicleModel { get; set; }
        public string? VehicleRegistrationNumber { get; set; }
        public int VehicleYear { get; set; }
        public string? VehicleChassisNumber { get; set; }
        public string? VehicleEngineNumber { get; set; }
        public decimal VehicleValue { get; set; }

        // Buyer Information
        public string? BuyerName { get; set; }
        public string? BuyerPhoneNumber { get; set; }
        public string? BuyerEmail { get; set; }
        public string? BuyerAddress { get; set; }
        public string? BuyerIdentificationType { get; set; }
        public string? BuyerIdentificationNumber { get; set; }
        public string? BuyerSource { get; set; }
    }
}
