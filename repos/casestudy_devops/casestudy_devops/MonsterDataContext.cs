using casestudy_devops.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casestudy_devops
{
    public class MonsterDataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = DataFile.db");
        }

        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<BattleResult> BattleResults { get; set; }

    }
}
