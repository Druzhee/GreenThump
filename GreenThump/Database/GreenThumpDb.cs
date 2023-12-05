using GreenThump.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThump.Database
{
    public class GreenThumpDb : DbContext
    {
        public GreenThumpDb()
        {

        }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<Instruction> instructions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenTump;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeda Data
            modelBuilder.Entity<Plant>().HasData(new Plant()
            {
                Id = 1,
                Name = "Sansevieria",
                Description = "Sansevieria plants are characterized by their long, upright, and sword-shaped leaves"

            },
            new Plant()
            {
                Id = 2,
                Name = "Spathiphyllum",
                Description = "commonly known as peace lilies, is a genus of flowering plants in the family Araceae. "
            },
            new Plant()
            {
                Id = 3,
                Name = "Zamioculcas",
                Description = "is a popular and hardy indoor plant known for its tolerance of low light conditions"
            });
            modelBuilder.Entity<Instruction>().HasData(new Instruction()
            {
                Id = 1,
                InstructionText = "Let soil dry.",
                PlantId = 1,
            },
            new Instruction()
            {
                Id = 2,
                InstructionText = "Avoid overwatering.",
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
                InstructionText = "Water when top dry.",
                PlantId = 2,
            },
            new Instruction()
            {
                Id = 5,
                InstructionText = " Let soil dry then water.",
                PlantId = 3,
            },
            new Instruction()
            {
                Id = 6,
                InstructionText = "Water sparingly.",
                PlantId = 3
            });

        }

    }
}
