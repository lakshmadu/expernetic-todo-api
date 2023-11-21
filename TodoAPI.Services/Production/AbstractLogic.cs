using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.DataAccess;

namespace TodoAPI.Services.Production
{
    public class AbstractLogic
    {
        protected readonly TodoDbContext todoDbContext;
        public AbstractLogic(TodoDbContext todoDbContext) 
        {
            this.todoDbContext = todoDbContext;
        }
    }
}
