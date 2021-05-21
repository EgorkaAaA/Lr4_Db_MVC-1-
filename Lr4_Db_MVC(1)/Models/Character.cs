using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lr4_Db_MVC_1_.Models
{
    public class Character
    {
        public long ID { get; set; }
        [Display(Name = "Имя")]
        //[Required(ErrorMessage = "Поле должно быть установлено")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string CharacterName { get; set; }
         
        public virtual ICollection<Anime> Anime { get; set; }
        public Character()
        {
            Anime = new List<Anime>();
        }

        [Display(Name = "Имя Сэй ю")]
        public long VoiceActorId { get; set; }
        public virtual VoiceActor VoiceActor { get; set; }
    }
}