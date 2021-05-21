using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lr4_Db_MVC_1_.Models
{
    public class VoiceActor
    {
        public long ID { get; set; }
        [Display(Name = "Имя Сэй ю")]
        //[Required(ErrorMessage = "Поле должно быть установлено")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string VoiceActorName { get; set; }

        public List<Character> Character { get; set; }
    }
}