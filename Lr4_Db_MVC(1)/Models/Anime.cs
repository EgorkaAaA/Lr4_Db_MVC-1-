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
        public int views { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public Anime()
        {
            Users = new List<User>();
            Characters = new List<Character>();
        }

        public long StudioId { get; set; }
        public virtual Studio Studio { get; set; }
    }
}