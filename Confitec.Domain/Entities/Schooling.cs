namespace Confitec.Domain.Entities
{
    public class Schooling : Entity
    {
        public string Description { get; set; }

        public Schooling() { }

        public Schooling(string description)
        {
            Description = description;
        }
    }
}
