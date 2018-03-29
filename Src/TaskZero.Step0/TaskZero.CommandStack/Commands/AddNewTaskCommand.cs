using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskZero.Shared;

namespace TaskZero.CommandStack.Commands
{
   public class AddNewTaskCommand : NotifyCommand
    {
        public AddNewTaskCommand(string title, string description, DateTime? dueDate, Priority priority, string connectionId) : base(connectionId)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Priority Priority { get; set; }
    }
}
