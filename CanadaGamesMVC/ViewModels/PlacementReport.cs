using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGamesMVC.ViewModels
{
    public class PlacementReport
    {
        public int ID { get; set; }

        [Display(Name = "Athlete")]
        public string FormalName
        {
            get
            {
                return LastName + ", "
                    + FirstName
                    + (string.IsNullOrEmpty(MiddleName) ? " " :
                        (" " + (char?)MiddleName[0]).ToUpper());
            }
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Contingent")]
        public string Contingent { get; set; }

        [Display(Name = "Average Placement")]
        public int AveragePlacement { get; set; }

        [Display(Name = "Highest Placement")]
        public int HighestPlacement { get; set; }

        [Display(Name = "Lowest Placement")]
        public int LowestPlacement { get; set; }

        [Display(Name = "Total Events")]
        public int EventCount { get; set; }
    }
}
