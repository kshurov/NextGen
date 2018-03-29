using Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskZero.CommandStack.Commands
{
    public class NotifyCommand : Command
    {
        public NotifyCommand(string connectionId = "")
        {
            SignalrConnectionId = connectionId;
        }
        public string SignalrConnectionId { get; }
    }
}
