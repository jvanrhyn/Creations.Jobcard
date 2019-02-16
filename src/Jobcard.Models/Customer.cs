using System;
using System.Collections.Generic;
using System.Text;

namespace Jobcard.Models
{
    public class Customer : ModelBase
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public List<Card> Cards { get; set; }
    }
}
