using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Screamplay_simple.Models
{
    public partial class Character
    {
        public Character()
        {
            Ids = new HashSet<Location>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is needed")]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "This field is needed")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public int IdScreenplay { get; set; } 

        public virtual Screenplay? IdScreenplayNavigation { get; set; } = null!;

        public virtual ICollection<Location> Ids { get; set; }
    }
}
