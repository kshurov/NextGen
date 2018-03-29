using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskZero.ReadStack.ReadModel;

namespace TaskZero.ReadStack.Repositories
{
    public class TaskContext : DbContext
    {
        public TaskContext() : base("MfxDemoDb") { }
        public DbSet<PendingTask> PendingTasks { get; set; }
    }
}
