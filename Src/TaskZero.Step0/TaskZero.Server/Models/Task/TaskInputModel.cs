using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskZero.Shared;

namespace TaskZero.Server.Models.Task
{
    public class TaskInputModel {
        public TaskInputModel()
        {
            DueDate = null;
            Priority = Priority.NotSet;
            Status = Status.ToDo;
        }
        public Guid TaskId
        { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public string SignalrConnectionId { get; set; }
    }
}
