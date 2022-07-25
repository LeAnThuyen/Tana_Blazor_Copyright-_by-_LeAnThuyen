using API_Blazor.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using Task = API_Blazor.Entities.Task;

namespace API_Blazor.Respositories
{
    public class TaskRepostoty : ITaskRepositoty
    {
        private readonly DatabaseContext _context;
        public TaskRepostoty(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Entities.Task> CreateTask(Entities.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<string> DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return "done";
        }

        public async Task<Entities.Task> GetById(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<Entities.Task>> GetTaskList(TaskListSearch taskListSearch)
        {
            var query = _context.Tasks.AsQueryable();
            if (!String.IsNullOrEmpty(taskListSearch.Name))
            {
                query = query.Where(c => c.Name.Contains(taskListSearch.Name));
            }
            return await query.ToListAsync();

        }

        public async Task<Entities.Task> UpdateTask(Entities.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }


    }
}
