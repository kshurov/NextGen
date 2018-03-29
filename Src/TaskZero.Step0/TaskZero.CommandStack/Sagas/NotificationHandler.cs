using Memento.Messaging.Postie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskZero.CommandStack.Commands;
using TaskZero.Shared;

namespace TaskZero.CommandStack.Sagas
{
    public class NotificationHandler : IHandleMessages<AddNewTaskNotifyCommand>, IHandleMessages<UpdateTaskNotifyCommand>
    {
        public void Handle(AddNewTaskNotifyCommand message)
        {
            // Notify back 
            var hub = new TaskZeroHub(message.SignalrConnectionId);
            hub.NotifyResultOfAddNewTask(message.TaskId, message.Title);
        }

        public void Handle(UpdateTaskNotifyCommand message)
        {
            // Notify back 
            var hub = new TaskZeroHub(message.SignalrConnectionId);
            hub.NotifyResultOfUpdateTask(message.TaskId, message.Title);
        }
    }

}
