using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("3e8cc177-361a-4ff0-80ae-f0e630e23102"),
                    Name = "Easy"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("5fe1a4a8-ed09-4d56-b9fd-85dc5e2658c6"),
                    Name = "Meduim"
                },

                 new Difficulty()
                {
                    Id = Guid.Parse("5941638f-d849-4065-9741-17c865f40231"),
                    Name = "Hard"
                }
            };
            // seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);



            var regions = new List<Region>()
            {

                new Region()
                {
                    Id = Guid.Parse("822f3b53-46f5-4a00-bdf1-667bc4ccaa29"),
                    Code = "AKL",
                    Name = "Auckland",
                    RegionImageUrl = "auk.png"
                },

                new Region()
                {
                    Id = Guid.Parse("4fdc6c58-b84f-4ba8-88fa-1ff862f77695"),
                    Code = "NTL",
                    Name = "Northland",
                    RegionImageUrl = "northland.png"
                },

                new Region()
                {
                    Id = Guid.Parse("3e8be49a-4dfb-444c-b4e3-27ec0e24b899"),
                    Code = "BOP",
                    Name = "Bay of Plenty",
                    RegionImageUrl = null
                },

                new Region()
                {
                    Id = Guid.Parse("47963b04-60d3-4711-958b-b3f85c834578"),
                    Code = "WGN",
                    Name = "Wellington",
                    RegionImageUrl = "Welligton.jpg"
                },

                 new Region()
                 {
                    Id = Guid.Parse("6fd79b96-a7ca-49d0-b5c0-c0561069265e"),
                    Code = "NSN",
                    Name = "Nelson",
                    RegionImageUrl = "nelson.jpg"
                 },

                 new Region()
                 {
                     Id = Guid.Parse("d082fb6d-9be6-4090-ad8a-13c991106cb3"),
                     Code = "STL",
                     Name = "Southland",
                     RegionImageUrl = null
                 }

            };
            // seed difficulties to the database
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
