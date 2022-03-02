using System;
using System.Collections.Generic;

namespace Screamplay_simple.Models
{
    public partial class Location
    {
        public Location()
        {
            IdCharacters = new HashSet<Character>();
            IdRealWorldLocations = new HashSet<RealWorldLocation>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int IdScreenplay { get; set; }

        public virtual Screenplay IdScreenplayNavigation { get; set; } = null!;

        public virtual ICollection<Character> IdCharacters { get; set; }
        public virtual ICollection<RealWorldLocation> IdRealWorldLocations { get; set; }
    }
}
