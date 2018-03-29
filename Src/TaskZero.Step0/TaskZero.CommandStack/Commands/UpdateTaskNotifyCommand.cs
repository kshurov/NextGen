using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskZero.CommandStack.Commands
{
    public class UpdateTaskNotifyCommand : NotifyCommand
    {
        public UpdateTaskNotifyCommand(string connectionId) : base(connectionId) { }
        public Guid TaskId { get; set; }
        public string Title { get; set; }
    }
}
