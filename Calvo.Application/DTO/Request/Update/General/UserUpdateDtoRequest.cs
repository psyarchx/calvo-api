namespace Calvo.Application.DTO.Request.Update.General
{
    public class UserUpdateDtoRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
