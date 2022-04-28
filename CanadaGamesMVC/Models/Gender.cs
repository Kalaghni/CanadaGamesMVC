using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGamesMVC.Models
{
    public class Gender
    {
        public Gender()
        {
            this.Athletes = new HashSet<Athlete>();
        }
        public int ID { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "You cannot leave the code blank.")]
        [StringLength(1, ErrorMessage = "Code cannot be more than 1 characters long.")]
        public string Code { get; set; }     

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You cannot leave the name blank.")]
        [StringLength(10, ErrorMessage = "Name cannot be more than 10 characters long.")]
        public string Name { get; set; }

        public ICollection<Athlete> Athletes { get; set; }
    }
}
