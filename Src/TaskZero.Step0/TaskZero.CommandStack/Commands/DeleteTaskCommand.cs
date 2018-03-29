using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskZero.CommandStack.Commands
{
    public class DeleteTaskCommand : NotifyCommand { public DeleteTaskCommand(Guid id, string connectionId) : base(connectionId) { TaskId = id; } public Guid TaskId { get; set; } }
}
