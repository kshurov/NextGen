using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskZero.ReadStack.ReadModel;

namespace TaskZero.ReadStack.Repositories
{
    public class ProjectionManager : IDisposable {
        private readonly TaskContext _context = null;
        public ProjectionManager() {
            _context = new TaskContext();
            _context.Configuration.AutoDetectChangesEnabled = false;
        }
        public IQueryable<PendingTask> PendingTasks => _context.PendingTasks;
        public void Dispose() { _context?.Dispose(); }
        public PendingTask FindById(Guid id)
        {
            var task = (from t in PendingTasks where t.TaskId == id select t).SingleOrDefault();
            return task;
        }
    }
}
