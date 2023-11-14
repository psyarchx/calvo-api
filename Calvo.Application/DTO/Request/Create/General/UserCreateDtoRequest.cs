namespace Calvo.Application.DTO.Request.Create.General
{
    public class UserCreateDtoRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}