using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lr4_Db_MVC_1_.Models
{
    public class Character
    {
        public long ID { get; set; }
        public string CharacterName { get; set; }
         
        public virtual ICollection<Anime> Anime { get; set; }
        public Character()
        {
            Anime = new List<Anime>();
        }

        public long VoiceActorId { get; set; }
        public virtual VoiceActor VoiceActor { get; set; }
    }
}