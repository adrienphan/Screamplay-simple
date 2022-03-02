using System;
using System.Collections.Generic;

namespace Screamplay_simple.Models
{
    public partial class Screenplay
    {
        public Screenplay()
        {
            Characters = new HashSet<Character>();
            Locations = new HashSet<Location>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Content { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
