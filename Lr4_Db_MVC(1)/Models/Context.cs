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
        public DbSet<animeList> AnimeList { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<CharacterList> CharacterList { get; set; }
        public DbSet<Studio> Studio { get; set; }
        public DbSet<VoiceActor> VoiceActor { get; set; }

        public Context()
            : base("Context")
        {
        }
    }
}