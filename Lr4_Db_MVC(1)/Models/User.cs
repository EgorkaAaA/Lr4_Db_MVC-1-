using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lr4_Db_MVC_1_.Models
{
    public class User
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public long animeListsId { get; set; }
        public virtual List<animeList> animeLists { get; set; }
    }
}