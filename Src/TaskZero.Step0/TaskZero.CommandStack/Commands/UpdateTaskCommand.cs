using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskZero.Shared;

namespace TaskZero.CommandStack.Commands
{
    public class UpdateTaskCommand : NotifyCommand
    {
        public UpdateTaskCommand(Guid id, string title, string description, DateTime? dueDate, Priority priority,
                                    Status status, string connectionId) : base(connectionId)
        {
            TaskId = id; Title = title; Description = description; DueDate = dueDate; Priority = priority; Status = status;
        }

        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
