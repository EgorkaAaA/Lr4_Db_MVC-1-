using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lr4_Db_MVC_1_.Models
{
    public class Context: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Anime> Anime { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Studio> Studio { get; set; }
        public DbSet<VoiceActor> VoiceActor { get; set; }

        public Context()
            : base("Context")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>().HasMany(c => c.Characters)
                .WithMany(s => s.Anime)
                .Map(t => t.MapLeftKey("AnimeId")
                .MapRightKey("CharacterId")
                .ToTable("AnimeCharacter"));
            modelBuilder.Entity<Anime>().HasMany(c => c.Users)
                .WithMany(s => s.Animes)
                .Map(t => t.MapLeftKey("AnimeId")
                .MapRightKey("UserId")
                .ToTable("AnimeList"));
        }
    }
}