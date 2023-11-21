using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TodoAPI.Models.ResultJson
{
    public class TaskItemResultJson
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("created_date_time")]
        public DateTime CreatedDateTime { get; set; }

        [JsonPropertyName("updated_date_time")]
        public DateTime UpdatedDateTime { get; set; }

        [JsonPropertyName("is_completed")]
        public bool IsComplete { get; set; }
    }
}
