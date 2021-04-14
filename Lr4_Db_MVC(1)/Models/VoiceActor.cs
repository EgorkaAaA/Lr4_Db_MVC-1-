using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lr4_Db_MVC_1_.Models
{
    public class VoiceActor
    {
        public long ID { get; set; }
        public string VoiceActorName { get; set; }

        public List<Character> Character { get; set; }
    }
}