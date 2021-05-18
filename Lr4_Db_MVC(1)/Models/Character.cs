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
         
        public long CharactersId { get; set; }
        public virtual List<CharacterList> Characters { get; set; }

        public long VoiceActorId { get; set; }
        public virtual VoiceActor VoiceActor { get; set; }
    }
}