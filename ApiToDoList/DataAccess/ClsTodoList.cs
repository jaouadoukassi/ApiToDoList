using ApiToDoList.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiToDoList.DataAccess
{
    public class ClsTodoList: DbContext
    {
        public ClsTodoList(DbContextOptions<ClsTodoList> options): base(options)
        {

        }
        public DbSet<ClsBaseEntity> TasksTable { get; set; }
        
    }
}
