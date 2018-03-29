using System;
using Memento;
namespace TaskZero.Shared.Events
{
    public class TaskNoUpdatedEvent : TaskUpdatedEvent
    {
        public TaskNoUpdatedEvent(Guid id, string title, string description, DateTime? dueDate, Priority priority, Status status): base(id, title, description, dueDate, priority, status)
        {
           
        }
        
    }
}