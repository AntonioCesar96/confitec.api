using System;

namespace Confitec.Domain.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthDateFormat => BirthDate.ToString("dd/MM/yyyy");
        public int SchoolingId { get; set; }
        public string SchoolingDescription { get; set; }
    }
}
