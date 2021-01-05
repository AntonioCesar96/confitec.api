using System;

namespace Confitec.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int SchoolingId { get; set; }
        public virtual Schooling Schooling { get; private set; }

        public User() { }

        public User(
            string name,
            string lastName,
            string email,
            DateTime birthDate,
            int schoolingId)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            SchoolingId = schoolingId;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateLastName(string lastName)
        {
            LastName = lastName;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdateBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
        }

        public void UpdateSchooling(int schoolingId)
        {
            SchoolingId = schoolingId;
        }
    }
}
