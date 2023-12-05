using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThump.Models
{
    public class Instruction
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("instructions")]
        public string InstructionText { get; set; } = null!;

        [Column("plant_id")]
        public int PlantId { get; set; }
        public Plant Plant { get; set; } = null!;
    }
}
