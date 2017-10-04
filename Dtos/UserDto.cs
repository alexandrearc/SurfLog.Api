namespace SurfLog.Api.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string Password { get; set; }
        public string access_token { get; set; }
        public string id_token { get; set; }
    }
}