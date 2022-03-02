using System;
using System.Collections.Generic;

namespace Screamplay_simple.Models
{
    public partial class RealWorldLocation
    {
        public RealWorldLocation()
        {
            Ids = new HashSet<Location>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string? Availability { get; set; }

        public virtual ICollection<Location> Ids { get; set; }
    }
}
