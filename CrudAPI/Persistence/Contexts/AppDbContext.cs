using CrudAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(c => c.Id);
            builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>()
                .HasMany(c => c.Animes)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);

            builder.Entity<Category>().HasData
            (
                //seeding the category
                new Category { Id = 1, Name = "Fantasy" }, 
                new Category { Id = 2, Name = "Martial Arts" }
            );

            builder.Entity<Anime>().ToTable("Animes");
            builder.Entity<Anime>().HasKey(a => a.Id); //sets up primary key
            builder.Entity<Anime>().Property(a=> a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Anime>().Property(a => a.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Anime>().Property(a => a.Producer).IsRequired().HasMaxLength(50);
            builder.Entity<Anime>().Property(a => a.Thumbnail).IsRequired().HasMaxLength(200);
            builder.Entity<Anime>().Property(a => a.ReleaseDate).IsRequired();
            builder.Entity<Anime>().Property(a => a.Istreaming).IsRequired();


            builder.Entity<Anime>().HasData
   (
       new Anime
       {
           Id = 1,
           Name = "Attacks on Titan",
           Description = "Centuries ago, mankind was slaughtered to near extinction by monstrous humanoid creatures called titans," +
           " forcing humans to hide in fear behind enormous concentric walls." +
           " What makes these giants truly terrifying is that their taste for human flesh is not born out of hunger" +
           " but what appears to be out of pleasure. To ensure their survival, the remnants of humanity began living within defensive barriers," +
           " resulting in one hundred years without a single titan encounter. However, that fragile calm is soon shattered " +
           "when a colossal titan manages to breach the supposedly impregnable outer wall, reigniting the fight for survival against the man-eating abominations." +
           " After witnessing a horrific personal loss at the hands of the invading creatures, Eren Yeager dedicates his life to their eradication by enlisting into the Survey Corps, " +
           "an elite military unit that combats the merciless humanoids outside the protection of the walls. " +
           "Based on Hajime Isayama's award-winning manga, Shingeki no Kyojin follows Eren, " +
           "along with his adopted sister Mikasa Ackerman and his childhood friend Armin Arlert, " +
           "as they join the brutal war against the titans and race to discover a way of defeating them before the last walls are breached.",
           Producer = "Wit Studio",
           Thumbnail = "pictures",
           Istreaming =true,
           ReleaseDate = new DateTime(2013,04,20, 0, 0, 0, 0),
           CategoryId = 1,

       },
       new Anime
       {
           Id = 2,
           Name = "Case Closed; Detective Conan",
           Description = "Shinichi Kudou, a high school student of astounding talent in detective work, is well known for having solved several challenging cases. One day, when Shinichi spots two suspicious men and decides to follow them, he inadvertently becomes witness to a disturbing illegal activity. Unfortunately, he is caught in the act, so the men dose him with an experimental drug formulated by their criminal organization, leaving him to his death. However, to his own astonishment, Shinichi lives to see another day, but now in the body of a seven-year-old child. Perfectly preserving his original intelligence, he hides his real identity from everyone, including his childhood friend Ran Mouri and her father, private detective Kogorou Mouri. To this end, he takes on the alias of Conan Edogawa, inspired by the mystery writers Arthur Conan Doyle and Ranpo Edogawa.Detective Conan follows Shinichi who, as Conan, starts secretly solving the senior Mouri's cases from behind the scenes with his still exceptional sleuthing skills, while covertly investigating the organization responsible for his current state, hoping to reverse the drug's effects someday",
           Producer = "TMS Entertainment",
           Thumbnail = "https://ytvcontents.com/ytv/open/open-tv-program!image?tid=64&imageNumber=1",
           Istreaming = true,
           ReleaseDate = new DateTime(1996, 01, 08, 0, 0, 0, 0),
           CategoryId = 2,

       }

   );
        }
    }
}
