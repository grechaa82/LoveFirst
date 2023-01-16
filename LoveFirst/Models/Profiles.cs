using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoveFirst.Models
{
    public class Profiles
    {
        [Key]
        public int ProfileId { get; set; }

        [Required(ErrorMessage = "Please write Login")]
        [MaxLength(32, ErrorMessage = "{0} can have a max of {1} characters")]
        public string Login { get; set; }

        [Required()]
        [MaxLength(64)]
        public string PasswordHash { get; set; }

        public virtual ICollection<Counters> Counters { get; set; }
    }
}
