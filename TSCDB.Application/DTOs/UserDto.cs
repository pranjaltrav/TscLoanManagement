namespace TscLoanManagement.TSCDB.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserType { get; set; }
        public bool IsActive { get; set; }
    }
}
