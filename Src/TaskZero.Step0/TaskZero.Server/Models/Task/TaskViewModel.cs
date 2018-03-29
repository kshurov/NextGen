using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskZero.ReadStack.ReadModel;

namespace TaskZero.Server.Models.Task
{
    public class TaskViewModel : ViewModelBase
    {
        public TaskViewModel() { Task = new PendingTask(); }
        public PendingTask Task { get; set; }
    }
}