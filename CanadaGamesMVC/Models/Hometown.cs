using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGamesMVC.Models
{
    public class Hometown
    {

        public int ID { get; set; }
        public Hometown()
        {
            this.Athletes = new HashSet<Athlete>();
        }

        [Display(Name = "Hometown")]
        public string Summary
        {
            get { return Name + ", "+ Contingent.Code; }
           
        }


        [Display(Name = "Name")]
        [Required(ErrorMessage ="Hometown must have a name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "You must select a contingent.")]
        [Display(Name = "Contingent")]
        public int ContingentID { get; set; }
        public Contingent Contingent { get; set; }

        public ICollection<Athlete> Athletes { get; set; }
    }
}
