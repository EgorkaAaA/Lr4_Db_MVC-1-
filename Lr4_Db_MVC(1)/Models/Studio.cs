using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lr4_Db_MVC_1_.Models
{
    public class Studio
    {
        public long Id { get; set; }
        public string StudioName { get; set; }

        public List<Anime> Anime { get; set; }
    }
}