using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Models.EfCore;

namespace TodoAPI.Services.TaskItems
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> ListAllTaskItem();

        Task<TaskItem> CreateTask(TaskItem taskItem);

        Task UpdateTask(int id,TaskItem taskItem);

        Task<TaskItem> FindByIdAsync(int id);

        Task DeleteByIdAsync(int id);
    }
}
