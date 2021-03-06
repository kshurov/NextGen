﻿using Memento;
using Memento.Messaging.Postie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskZero.CommandStack.Commands;
using TaskZero.ReadStack.Repositories;
using TaskZero.Server.Models.Task;

namespace TaskZero.Server.Application
{
    public class TaskService : ApplicationServiceBase
    {
        public TaskService(IBus bus) : base(bus) { }
        #region QUERY methods 
        public TaskViewModel GetDefaultTask() { var model = new TaskViewModel(); return model; }
        #endregion

        private readonly ProjectionManager _manager = new ProjectionManager();

        #region COMMAND methods 
        #region COMMAND methods 
        public void QueueAddOrSaveTask(TaskInputModel input)
        {
            Command command; var isNewTask = (input.TaskId == Guid.Empty);
            int r = new Random().Next(10);
            if (r % 2 == 0)
            {
                SendCommand(new ErrorNotifyCommand(input.TaskId, "Ooopss!!", input.SignalrConnectionId));
                return;
            }

            if (isNewTask)
            {
                command = new AddNewTaskCommand(input.Title, input.Description, input.DueDate, input.Priority, input.SignalrConnectionId);
            }
            else
            {
                command = new UpdateTaskCommand(input.TaskId, input.Title, input.Description, input.DueDate, input.Priority, input.Status, input.SignalrConnectionId);
            }
            SendCommand(command);
        }

        private void SendCommand(Command command)
        {
            
            

            Bus.Send(command);
        }
        #endregion
        #endregion

        public TaskViewModel GetTask(Guid id)
        {
            var model = new TaskViewModel { Task = _manager.FindById(id) };
            return model;
        }

        public void QueueDeleteTask(Guid id, string signalrConnectionId)
        {
            var command = new DeleteTaskCommand(id, signalrConnectionId);
            SendCommand(command);
        }

        

        internal void QueueCompleteTask(Guid id, string signalrConnectionId)
        {
            var command = new MarkCompletedTask(id, signalrConnectionId);
            SendCommand(command);
        }
    }
}