using System.Collections.Generic;

namespace Confitec.Domain.Dtos
{
    public class QueryResultDto
    {
        public int NumberOfRecords { get; set; }
        public int Page { get; set; }
        public int QuantityPerPage { get; set; }
        public IEnumerable<object> List { get; set; }
    }
}
