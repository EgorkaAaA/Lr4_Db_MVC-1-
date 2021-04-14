using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lr4_Db_MVC_1_.Models
{
    public class animeList
    {
        public long ID { get; set; } 

        public long UserId { get; set; }
        public User User { get; set; } 

        public long AnimeId { get; set; }
        public Anime Anime { get; set; }
    }
}