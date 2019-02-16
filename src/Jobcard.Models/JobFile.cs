namespace Jobcard.Models
{
    public class JobFile : ModelBase
    {
        public int CardId { get; set; }
        public string Name { get; set; }
        public FileKind Kind { get; set; }

    }
}
