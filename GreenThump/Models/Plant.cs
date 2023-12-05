using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThump.Models
{
    public class Plant
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("description")]
        public string? Description { get; set; }

        public List<Instruction> Instructions { get; set; } = new();
        public Plant()
        {

        }
    }
}
