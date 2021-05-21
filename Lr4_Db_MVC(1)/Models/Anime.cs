using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lr4_Db_MVC_1_.Models
{
    public class Anime
    {
        public long ID { get; set; }
        [Display(Name = "Название Аниме")]
        //[Required(ErrorMessage = "Поле должно быть установлено")]
        //[StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string AinmeName { get; set; }
        [Display(Name = "Рейтинг")]
        //[Required(ErrorMessage = "Поле должно быть установлено")]
        //[Range(0,10, ErrorMessage ="Рейтинг должен быть от 0 до 10")]
        public byte Rating { get; set; }
        [Display(Name = "Просмотры")]
        //[Range(0, 7674000000, ErrorMessage ="Не может быть такого числа!")]
        public int views { get; set; }

        [Display(Name = "Главные герои")]
        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public Anime()
        {
            Users = new List<User>();
            Characters = new List<Character>();
        }

        [Display(Name = "Название студии")]
        public long StudioId { get; set; }
        public virtual Studio Studio { get; set; }
    }
}