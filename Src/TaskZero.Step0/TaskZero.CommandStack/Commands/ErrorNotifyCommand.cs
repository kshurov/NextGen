using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskZero.CommandStack.Commands
{
    public class ErrorNotifyCommand : NotifyCommand
    {
        public ErrorNotifyCommand(Guid id, string errorMessage, string connectionId) : base(connectionId)
        {
            TaskId = id; Error = errorMessage;
        }

        public string Error { get; set; }
        public Guid TaskId { get; set; }
    }
}
