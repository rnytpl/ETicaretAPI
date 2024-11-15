namespace ETicaretAPI.Application.DTOs.User
{
    public class CreateUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
    }
}
