using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGamesMVC.Models
{
    public class Contingent
    {
        public Contingent()
        {
            this.Athletes = new HashSet<Athlete>();
            this.Hometowns = new HashSet<Hometown>();
        }
        public int ID { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "You cannot leave the code blank.")]
        [StringLength(2, ErrorMessage = "Code cannot be more than 2 characters long.")]
        public string Code { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You cannot leave the name blank.")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters long.")]
        public string Name { get; set; }

        public ICollection<Athlete> Athletes { get; set; }

        public ICollection<Hometown> Hometowns { get; set; }
    }
}
