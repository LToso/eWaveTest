namespace eWaveVolvoAPI.Models.Entities
{
    public class TruckObj
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int ProdYear { get; set; }
        public float MaxLenght { get; set; }
        public float GrossWeight { get; set; }
        public int Axes { get; set; }
        public float LoadCapac { get; set; }
    }
}
