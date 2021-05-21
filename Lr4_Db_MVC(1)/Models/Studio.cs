using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lr4_Db_MVC_1_.Models
{
    public class Studio
    {
        public long Id { get; set; }
        //[Required(ErrorMessage = "Поле должно быть установлено")]
        //[StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Название студии")]
        public string StudioName { get; set; }

        public virtual ICollection<Anime> Animes { get; set; }
        public Studio()
        {
            Animes = new List<Anime>();
        }
    }
}