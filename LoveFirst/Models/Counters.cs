using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoveFirst.Models
{
    public class Counters
    {
        [Key]
        public int CounterId { get; set; }
        public int ProfileId { get; set; }
        public int TotalScores { get; set; }
        
        public virtual Profiles Profiles { get; set; }

        public virtual ICollection<Participants> Participants { get; set; }
        public virtual ICollection<Operations> Operations { get; set; }
    }
}
