using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoveFirst.Models
{
    public class Participants
    {
        [Key]
        public int ParticipantId { get; set; }
        public int CounterId { get; set; }

        [Required(ErrorMessage = "Please write name participant")]
        [MaxLength(24, ErrorMessage = "{0} can have a max of {1} characters")]
        public string NameParticipant { get; set; }
        public int NumberScore { get; set; }

        public virtual Counters Counters { get; set; }
    }
}
