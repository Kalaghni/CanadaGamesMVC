using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGamesMVC.Models
{
    public class Sport
    {
        public Sport()
        {
            Events = new HashSet<Event>();
            AthleteSports = new HashSet<AthleteSport>();
            Athletes = new HashSet<Athlete>();
        }

        public int ID { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "You cannot leave the code blank.")]
        [StringLength(3, ErrorMessage = "Code cannot be more than 3 characters long.")]
        public string Code { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You cannot leave the name blank.")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters long.")]
        public string Name { get; set; }

        public ICollection<AthleteSport> AthleteSports { get; set; }
        public ICollection<Athlete> Athletes { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
