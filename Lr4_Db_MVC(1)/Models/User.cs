using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lr4_Db_MVC_1_.Models
{
    public class User
    {
        public long ID { get; set; }
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }
        [Display(Name = "Пароль")]
        public string UserPassword { get; set; }

        [Display(Name = "Список аниме")]
        public virtual ICollection<Anime> Animes { get; set; }
        public User()
        {
            Animes = new List<Anime>();
        }
    }
}