using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoveFirst.Models
{
    public class Operations
    {
        [Key]
        public int OperationId { get; set; }
        public int CounterId { get; set; }
        public int ParticipantId { get; set; }
        public int Score { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateOperation { get; set; }

        public virtual Counters Counters { get; set; }
    }
}
