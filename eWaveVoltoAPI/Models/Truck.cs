
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eWaveVolvoAPI.Models
{
    [Table(name: "Truck")]
    public class Truck
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(2)]
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int ProdYear { get; set; }
        public float MaxLenght { get; set; }
        public float GrossWeight { get; set; }
        public int Axes { get; set; }
        public float LoadCapac { get; set; }

    }
}
