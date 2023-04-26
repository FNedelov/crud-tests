namespace CRUD.Common.DTOs
{
    public record AuthenticationRequestDto
    {
        public string? UserName { get; set; }
        //public string? Password { get; set; } If you don't use windows authentication, you could use user-pwd pair
    }
}