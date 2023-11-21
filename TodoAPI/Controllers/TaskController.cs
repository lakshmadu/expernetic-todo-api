using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Mappers;
using TodoAPI.Models.InputJson;
using TodoAPI.Models.ResultJson;
using TodoAPI.Services.TaskItems;
using dbCore = TodoAPI.Models.EfCore;

namespace TodoAPI.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository taskRepository;

        private readonly IMapper mapper;
        public TaskController(ITaskRepository taskRepository, IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById([FromRoute(Name ="id")] int id)
        {
            var result = await taskRepository.FindByIdAsync(id);
            return Ok(mapper.Map<TaskItemResultJson>(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTask()
        {
            var result = await taskRepository.ListAllTaskItem();

            var mappedResult = mapper.Map<IEnumerable<TaskItemResultJson>>(result);

            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskItemInputJson taskItemInputJson)
        {
            var taskItem = mapper.Map<dbCore.TaskItem>(taskItemInputJson);
            var result = await taskRepository.CreateTask(taskItem);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask([FromRoute(Name = "id")] int id, [FromBody] TaskItemInputJson taskItemInputJson)
        {
            var taskItem = mapper.Map<dbCore.TaskItem>(taskItemInputJson);
            await taskRepository.UpdateTask(id, taskItem);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute(Name ="id")] int id)
        {
            await taskRepository.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}
