﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lr4_Db_MVC_1_.Models
{
    public class CharacterList
    {
        public long ID { get; set; } 

        public long CharacterId { get; set; }
        public Character Character { get; set; }

        public long AnimeID { get; set; }
        public Anime Anime { get; set; }
    }
}