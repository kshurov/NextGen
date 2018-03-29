using Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskZero.Shared.Events
{
    public class TaskDeletedEvent : DomainEvent { public TaskDeletedEvent(Guid id) { TaskId = id; } public Guid TaskId { get; set; } }
}
