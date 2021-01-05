using System;

namespace Confitec.Domain.Dtos
{
    public class FilterUserDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? SchoolingId { get; set; }
        public int Page { get; set; }
        public int QuantityPerPage { get; set; }

        public FilterUserDto() 
        {
            Page = 1;
            QuantityPerPage = 5;
        }

        public int CountSkip 
        { 
            get 
            {
                var page = Page > 0 ? Page : 1;
                var countSkip = (page - 1) * QuantityPerPage;
                return countSkip;
            }
        }
    }
}
