namespace Jobcard.Models
{
    public class LayerKindDefault : ModelBase
    {
        public string Name { get; set; }
        public LayerType LayerType { get; set; }
        public int Speed { get; set; }
        public int Corner { get; set; }
        public int Acceleration { get; set; }
        public int Power1 { get; set; }
        public int Power1Min { get; set; }
        public int Power2 { get; set; }
        public int Power2Min { get; set; }
        public decimal ScanGap { get; set; } = 0.065m;
        public bool Blower { get; set; } = true;
    }
}
