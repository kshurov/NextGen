using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskZero.Shared;

namespace TaskZero.ReadStack.ReadModel
{
    public class PendingTask : Dto { public Guid TaskId { get; set; }
        public string Title { get; set; } public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? StartDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; } }
}
