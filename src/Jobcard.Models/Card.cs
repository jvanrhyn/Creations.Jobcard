using System;
using System.Collections.Generic;

namespace Jobcard.Models
{
    public class Card : ModelBase
    {
        public Customer Customer { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateCompleted { get; set; }
        public List<JobFile> JobFiles { get; set; }
        public List<LaserSetting> LaserSettings { get; set; }
    }
}
