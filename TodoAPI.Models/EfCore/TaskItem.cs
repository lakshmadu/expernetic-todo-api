using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAPI.Models.EfCore
{
    public class TaskItem
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public bool IsComplete { get; set; }
    }
}
