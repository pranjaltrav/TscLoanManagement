namespace TscLoanManagement.TSCDB.Application.DTOs
{
    public class TokenResponseDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string UserType { get; set; }
        public int UserId { get; set; }
    }
}
