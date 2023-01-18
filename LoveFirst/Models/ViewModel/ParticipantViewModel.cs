using System.ComponentModel.DataAnnotations;

namespace LoveFirst.Models.ViewModel
{
    public class ParticipantViewModel
    {
        [Required]
        public int ParticipantId { get; set; }
        [Required]
        public int CounterId { get; set; }
    }
}
