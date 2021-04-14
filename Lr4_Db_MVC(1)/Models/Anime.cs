using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lr4_Db_MVC_1_.Models
{
    public class Anime
    {
        public long ID { get; set; }
        public string AinmeName { get; set; }
        public byte Rating { get; set; }
        public int views;

        public List<CharacterList> Characters { get; set; }

        public long StudioId { get; set; }
        public Studio Studio { get; set; }
    }
}