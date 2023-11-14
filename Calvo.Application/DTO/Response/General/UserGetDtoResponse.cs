namespace Calvo.Application.DTO.Response.General
{
    public class UserGetDtoResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}