namespace TscLoanManagement.TSCDB.Application.DTOs
{
    public class GuarantorDetailsDto
    {
        public int Id { get; set; }
        public int DealerId { get; set; }
        public string Name { get; set; }
        public string PAN { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FatherName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string CIBILScore { get; set; }
        public string RelationshipWithBorrower { get; set; }
        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string AttachmentUrl { get; set; }
    }
}
