using Memento;
using Memento.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskZero.Shared;
using TaskZero.Shared.Events;

namespace TaskZero.CommandStack.Model
{
     public class Task : Aggregate, 
        IApplyEvent<TaskCreatedEvent>, 
        IApplyEvent<TaskUpdatedEvent>, 
        IApplyEvent<TaskDeletedEvent>,
        IApplyEvent<TaskCompletedEvent>
    {
        public Task()
        {
            Priority = Priority.Normal;
            Status = Status.ToDo;
            Enabled = true;
            Deleted = Completed = false;
        }
        // COMMON PROPERTIES 
        public bool Deleted { get; set; }
        public bool Enabled { get; set; }
        // SPECIFIC PROPERTIES 
        public Guid TaskId { get; set; }
        public string Title { get; set; }

        internal void MarkAsCompleted()
        {
            { var completed = new TaskCompletedEvent(TaskId); RaiseEvent(completed); }
        }

        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public bool Completed { get; set; }

        public void ApplyEvent( [AggregateId("TaskId")] TaskCreatedEvent theEvent)
        {
            TaskId = theEvent.TaskId;
            Title = theEvent.Title;
            Description = theEvent.Description;
            DueDate = theEvent.DueDate;
            Priority = theEvent.Priority;
        }

        public void ApplyEvent([AggregateId("TaskId")] TaskUpdatedEvent theEvent)
        { // No need to change TaskId 
          // Copy values over 
            Title = theEvent.Title;
            Description = theEvent.Description;
            DueDate = theEvent.DueDate;
            Priority = theEvent.Priority;
            Status = theEvent.Status; 
        }

        public void ApplyEvent([AggregateId("TaskId")] TaskDeletedEvent theEvent) { Deleted = true; }
        public void UpdateModel(string title, string description, DateTime? dueDate, Priority priority, Status status)
        {
            DomainEvent updated = null;
            if (this.Title == title && this.Description == description && this.DueDate == dueDate.Value.ToUniversalTime() && this.Priority == priority && this.Status == status)
                updated = new TaskNoUpdatedEvent(TaskId, title, description, dueDate, priority, status); 
            else
                updated = new TaskUpdatedEvent(TaskId, title, description, dueDate, priority, status); 

            RaiseEvent(updated);

        }

        public void MarkAsDeleted() { var deleted = new TaskDeletedEvent(TaskId); RaiseEvent(deleted); }

        public void ApplyEvent([AggregateId("TaskId")] TaskCompletedEvent theEvent) { Completed = true; }

        public static class Factory {
            public static Task NewTaskFrom(string title, string descrition, DateTime? dueDate = null, Priority priority = Priority.Normal)
            {
                var task = new Task();
                var created = new TaskCreatedEvent(Guid.NewGuid(), title, descrition, dueDate, priority);
                task.RaiseEvent(created); return task;
            }
        }
    }

}
