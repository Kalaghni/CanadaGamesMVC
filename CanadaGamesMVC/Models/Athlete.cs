using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGamesMVC.Models
{
    public class Athlete : IValidatableObject
    {
        public int ID { get; set; }

        public Athlete()
        {
            AthleteSports = new HashSet<AthleteSport>();
            AthleteDocuments = new HashSet<AthleteDocument>();
            Placements = new HashSet<Placement>();
        }

        [Display(Name = "Athlete")]
        public string FullName
        {
            get
            {
                return FirstName
                    + (string.IsNullOrEmpty(MiddleName) ? " " :
                        (" " + (char?)MiddleName[0] + ". ").ToUpper())
                    + LastName;
            }
        }

        public string FormalName
        {
            get
            {
                return LastName +
                    ", " + FirstName 
                    + (string.IsNullOrEmpty(MiddleName) ? " " :
                      (" " + (char?)MiddleName[0] + ". ").ToUpper());
            }
        }

        public string Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int? a = today.Year - DOB.Year
                    - ((today.Month < DOB.Month || (today.Month == DOB.Month && today.Day < DOB.Day) ? 1 : 0));
                return a?.ToString();
            }
        }

        public bool HasPlacements
        {
            get { return Placements.Any(); }
        }

        public int AveragePlacement
        {
            get
            {
                if (HasPlacements)
                {
                    return (int)Math.Round(Placements.Average(p => p.Place));
                }
                else
                {
                    return 0;
                }               
            }
        }

        public int HighestPlacement
        {
            get
            {
                if (HasPlacements)
                {
                    return Placements.Max(p => p.Place);
                }
                else
                {
                    return 0;
                }
                
            }
        }

        public int LowestPlacement
        {
            get
            {
                if (HasPlacements)
                {
                    return Placements.Min(p => p.Place);
                }
                else
                {
                    return 0;
                }
                
            }
        }

        public int EventCount
        {
            get
            {
                return Placements.Count();
            }
        }

        public string HasCoach
        {
            get
            {
                return CoachID.HasValue ? "Yes" : "No";
            }
        }

        [Required(ErrorMessage = "You cannot leave the Code blank.")]
        [RegularExpression("^\\d{7}$", ErrorMessage = "The athlete code must be exactly 7 numeric digits.")]
        [StringLength(7)]
        public string AthleteCode { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(50, ErrorMessage = "Middle name cannot be more than 50 characters long.")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(100, ErrorMessage = "Last name cannot be more than 100 characters long.")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You cannot leave the date of birth blank.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; } 

        [Display(Name = "Height(cm)")]
        [Required(ErrorMessage = "You cannot leave the height blank.")]
        [Range(61, 245)]
        public int Height { get; set; }

        [Display(Name = "Weight(kg)")]
        [Required(ErrorMessage = "You cannot leave the weight blank.")]
        [Range(18, 180)]
        public int Weight { get; set; }

        [Display(Name = "Years in Sport")]
        [Required(ErrorMessage = "You cannot leave years in sport blank.")]
        public int YearsInSport { get; set; }

        [Display(Name = "Affiliation")]
        [Required(ErrorMessage = "You cannot leave affiliation blank.")]
        [StringLength(255, ErrorMessage = "Affiliation cannot be more than 255 characters long.")]
        public string Affiliation { get; set; }

        [Display(Name = "Goals")]
        [Required(ErrorMessage = "You cannot leave goals blank.")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Goals cannot be more than 255 characters long.")]
        public string Goals { get; set; }

        [Display(Name = "Position")]
        [StringLength(50, ErrorMessage = "Position cannot be more than 50 characters long.")]
        public string Position { get; set; }

        [Display(Name = "Role Model")]
        [StringLength(100, ErrorMessage = "Role model cannot be more than 100 characters long.")]
        public string RoleModel { get; set; }

        [Display(Name = "Media Info")]
        [Required(ErrorMessage = "You cannot leave media info blank.")]
        [StringLength(2000, ErrorMessage = "Media info cannot be more than 2000 characters long.")]
        public string MediaInfo { get; set; }

        [Required(ErrorMessage = "You must select a contingent.")]
        [Display(Name = "Contingent")]
        public int ContingentID { get; set; }

        public Contingent Contingent { get; set; } 


        [Required(ErrorMessage = "You must select a sport.")]
        [Display(Name = "Sport")]
        public int SportID { get; set; }

        public Sport Sport { get; set; } 

        [Required(ErrorMessage = "You must select a gender.")]
        [Display(Name = "Gender")]
        public int GenderID { get; set; }

        public Gender Gender { get; set; }  

        [Display(Name = "Coach")]
        public int? CoachID { get; set; }  

        public Coach Coach { get; set; }

        [Display(Name = "Sports")]
        public ICollection<AthleteSport> AthleteSports { get; set; }

        [Display(Name ="Hometown")]
        public int? HometownID { get; set; }
        public Hometown Hometown { get; set; }

        [Display(Name = "Documents")] 
        public ICollection<AthleteDocument> AthleteDocuments { get; set; }

        public AthletePhoto AthletePhoto { get; set; }
        public AthleteThumbnail AthleteThumbnail { get; set; }

        [Display(Name = "Placements")]
        public ICollection<Placement> Placements { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            double BMI = Weight / (Height * Height);
            if (BMI > 15 && BMI < 40)
            {
                results.Add(new ValidationResult("BMI must be above 15 and below 40"));
            }

            return results;
        }        
    }
}
