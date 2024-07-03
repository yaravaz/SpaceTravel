using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace spacetravel.Models.Data
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Admin> Admins { get; set; } = null!;
        public DbSet<Mission> Missions { get; set; } = null!;
        public DbSet<Spaceship> Spaceships { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Tour> Tours { get; set; } = null!;
        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            /*Database.EnsureCreated();
            string desciis = "Dragon spacecraft is capable of carrying up to 6,000 kgs / 13,228 lbs of cargo to the Station and returning 3,000 kgs / 6,614 lbs of cargo back to Earth. To date, Dragon has made over 20 trips to the orbiting laboratory.";
            string descorbit = "Experience Earth’s wonders from space—from the Great Barrier Reef, Himalayas, Amazon River, and Giza’s Pyramids by day, to the glow of city lights, lightning storms, and the Aurora Borealis by night. Dragon fully orbits the Earth every 90 minutes, making a highly customized flight path possible. Fly over your hometown, famous landmarks and other places meaningful to you";
            string descmoon = "The Moon is one of Earth’s closest habitable neighbors and provides an opportunity to gain valuable experience for missions to Mars and beyond.";
            string descmars = "At an average distance of 140 million miles, Mars is one of Earth's closest habitable neighbors. Mars is about half again as far from the Sun as Earth is, so it still has decent sunlight. It is a little cold, but we can warm it up. Its atmosphere is primarily CO2 with some nitrogen and argon and a few other trace elements, which means that we can grow plants on Mars just by compressing the atmosphere. Furthermore, the day is remarkably close to that of Earth.";
            string descship = "Starship spacecraft and Super Heavy rocket – collectively referred to as Starship – represent a fully reusable transportation system designed to carry both crew and cargo to Earth orbit, the Moon, Mars and beyond. Starship is the world’s most powerful launch vehicle ever developed, capable of carrying up to 150 metric tonnes fully reusable and 250 metric tonnes expendable.";
            string descdragon = "The Dragon spacecraft is capable of carrying up to 7 passengers to and from Earth orbit and beyond. The pressurized section of the capsule is designed to carry both people and environmentally sensitive cargo. Toward the base of the capsule and contained within the nosecone are the Draco thrusters, which allow for orbital maneuvering.";
            Spaceship starship = new Spaceship("Starship", descship, 12, 121, 9, 125000);
            Spaceship dragon = new Spaceship("Dragon", descdragon, 7, 8.1f, 4, 6000);

            Spaceships.Add(starship);
            Spaceships.Add(dragon);
            Missions.Add(new Models.Mission
            {
                Name = "ISS",
                Description = desciis,
                Duration = 10,
                Altitude = 400,
                Price = 300000,
                Spaceship = dragon
            });
            Missions.Add(new Models.Mission
            {
                Name = "Orbit",
                Description = descorbit,
                Duration = 6,
                Altitude = 400,
                Price = 370000,
                Spaceship = dragon
            });
            Missions.Add(new Models.Mission
            {
                Name = "Mars",
                Description = descmars,
                Duration = 20,
                Altitude = 55,
                Price = 3610000,
                Spaceship = starship
            });
            Missions.Add(new Models.Mission
            {
                Name = "Moon",
                Description = descmoon,
                Duration = 7,
                Altitude = 38440,
                Price = 1520000,
                Spaceship = starship
            });
            string login = "admin";
            string password = "admin1234";
            string email = "adminmail";
            Admin admin = new Admin(login, password,email)
            {
                Login = "admin",
                Password = "admin1234",
                Email = "admin",
            };
            Admins.Add(admin);*/

            SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("D:\\course_prog\\spacetravel\\spacetravel\\appsettings.json")
                    .Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("defaultConnection"));
            }
        }
        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .Select(e => e.Entity);

            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext, validateAllProperties: true);
            }

            return base.SaveChanges();
        }
    }
}
