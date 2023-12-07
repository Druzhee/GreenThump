using GreenThump.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThump.Database
{
	public class GreenThumbDb : DbContext
	{
		public GreenThumbDb()
		{

		}
		public DbSet<Plant> Plants { get; set; }
		public DbSet<Instruction> instructions { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumb;Trusted_Connection=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seeda Data
			modelBuilder.Entity<Plant>().HasData(new Plant()
			{
				Id = 1,
				Name = "Rose",
				Description = "Known for its beautiful and fragrant flowers."

			},
			new Plant()
			{
				Id = 2,
				Name = "Sunflower",
				Description = "Known for its large, yellow flowers."
			},
			new Plant()
			{
				Id = 3,
				Name = "Lavender ",
				Description = " A fragrant herb with purple flowers."
			},
			new Plant()
			{
				Id = 4,
				Name = "Snake Plant ",
				Description = "known as Mother in law's Tongue."
			},
			new Plant()
			{
				Id = 5,
				Name = "Maple Tree",
				Description = "These deciduous trees are well-known for their distinctive."
			},
			new Plant()
			{
				Id = 6,
				Name = "Tulip",
				Description = "A bulbous plant with vibrant, cup-shaped flowers."
			},
			new Plant()
			{
				Id = 7,
				Name = "Bamboo",
				Description = "A fast-growing grass that forms tall, woody stems."
			},
			new Plant()
			{
				Id = 8,
				Name = "Cactus ",
				Description = "Adapted to arid environments, cacti are known for their water-storing capabilities and unique."
			});
			modelBuilder.Entity<Instruction>().HasData(new Instruction()
			{
				Id = 1,
				InstructionText = "Well-drained soil.",
				PlantId = 1,
			},
			new Instruction()
			{
				Id = 2,
				InstructionText = "Sunlight.",
				PlantId = 1
			},
			new Instruction()
			{
				Id = 3,
				InstructionText = "Keep soil moist.",
				PlantId = 2,
			},
			new Instruction()
			{
				Id = 4,
				InstructionText = "Shade.",
				PlantId = 2,
			},
			new Instruction()
			{
				Id = 5,
				InstructionText = "Full sun.",
				PlantId = 3,
			},
			new Instruction()
			{
				Id = 6,
				InstructionText = "Regular water.",
				PlantId = 3
			},
			new Instruction()
			{
				Id = 7,
				InstructionText = " Full sun",
				PlantId = 4,
			},
			new Instruction()
			{
				Id = 8,
				InstructionText = "Well-drained soil.",
				PlantId = 4,
			},
			new Instruction()
			{
				Id = 9,
				InstructionText = "Low light.",
				PlantId = 5,
			},
			new Instruction()
			{
				Id = 10,
				InstructionText = "Infrequent water",
				PlantId = 5,
			},
			new Instruction()
			{
				Id = 11,
				InstructionText = "Full Sun",
				PlantId = 6,
			},
			new Instruction()
			{
				Id = 12,
				InstructionText = "Acidic soil.",
				PlantId = 6
			},
			new Instruction()
			{
				Id = 13,
				InstructionText = "Full Sun.",
				PlantId = 7,
			},
			new Instruction()
			{
				Id = 14,
				InstructionText = "Sparse water.",
				PlantId = 7,
			},
			new Instruction()
			{
				Id = 15,
				InstructionText = "Full Sun.",
				PlantId = 8,
			},
			new Instruction()
			{
				Id = 16,
				InstructionText = "Minimal Water.",
				PlantId = 8,
			});
		}
	}
}
