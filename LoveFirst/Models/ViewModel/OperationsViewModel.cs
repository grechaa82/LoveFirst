using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoveFirst.Models.ViewModel
{
    public class OperationsViewModel
    {
        public int OperationId { get; set; }
        public int CounterId { get; set; }
        public string NameParticipant { get; set; }
        public int Score { get; set; }
        public DateTime DateOperation { get; set; }
    }
}
