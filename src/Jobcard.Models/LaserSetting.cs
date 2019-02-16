namespace Jobcard.Models
{
    public class LaserSetting : ModelBase
    {
        public string Color { get; set; }
        public int Order { get; set; }
        public LayerKind LayerKind { get; set; }
    }
}
