using AutoMapper;
using TodoAPI.Models.EfCore;
using TodoAPI.Models.InputJson;
using TodoAPI.Models.ResultJson;

namespace TodoAPI.Mappers
{
    public class TaskRelatedMapper: Profile
    {
        public TaskRelatedMapper()
        {
            CreateMap<TaskItemInputJson, TaskItem>();
            CreateMap<TaskItem, TaskItemResultJson>();
        }
    }
}
