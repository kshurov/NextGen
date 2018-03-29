using Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskZero.Shared.Events
{
    public class TaskCreatedEvent : DomainEvent

    {
        public TaskCreatedEvent(Guid id, string title, string description, DateTime? dueDate, Priority priority)
        {
            TaskId = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
        }
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        public Priority Priority { get; set; }
    }

}
