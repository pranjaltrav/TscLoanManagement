namespace TscLoanManagement.TSCDB.Core.Domain.Loan
{
    public class VehicleInfo
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public int Year { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public decimal Value { get; set; }
    }
}
