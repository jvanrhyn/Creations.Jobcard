using System;

namespace Jobcard.Models
{
    public class ModelBase
    {
        public int Id { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
