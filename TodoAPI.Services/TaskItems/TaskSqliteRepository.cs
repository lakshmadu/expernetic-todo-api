using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.DataAccess;
using TodoAPI.Models.EfCore;
using TodoAPI.Services.Exception;
using TodoAPI.Services.Production;

namespace TodoAPI.Services.TaskItems
{
    public class TaskSqliteRepository : AbstractLogic, ITaskRepository
    {
        public TaskSqliteRepository(TodoDbContext todoDbContext) : base(todoDbContext)
        {
        }

        public async Task<IEnumerable<TaskItem>> ListAllTaskItem()
        {
            return await todoDbContext.TaskItems.ToArrayAsync();
        }

        public async Task<TaskItem> CreateTask(TaskItem taskItem)
        {
            taskItem.CreatedDateTime = DateTime.Now;
            taskItem.UpdatedDateTime = DateTime.Now;
            taskItem.IsComplete= false;

            await todoDbContext.TaskItems.AddAsync(taskItem);
            await todoDbContext.SaveChangesAsync();

            return taskItem;
        }

        public async Task UpdateTask(int id, TaskItem taskItem)
        {
            var existingTask = await todoDbContext.TaskItems.Where(x=>x.Id== id).FirstOrDefaultAsync();

            if (existingTask == null) 
            {
                throw new NotFoundException();
            }

            existingTask.Name = taskItem.Name;
            existingTask.Description = taskItem.Description;
            existingTask.UpdatedDateTime = DateTime.Now;
            taskItem.IsComplete = taskItem.IsComplete;

            todoDbContext.TaskItems.Update(existingTask);
            await todoDbContext.SaveChangesAsync();
        }

        public async Task<TaskItem> FindByIdAsync(int id)
        {
            var existingTask = await todoDbContext.TaskItems.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingTask == null)
            {
                throw new NotFoundException();
            }

            return existingTask;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var existingTask = await todoDbContext.TaskItems.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingTask == null)
            {
                throw new NotFoundException();
            }

            todoDbContext.TaskItems.Remove(existingTask);
            await todoDbContext.SaveChangesAsync();
        }
    }
}
