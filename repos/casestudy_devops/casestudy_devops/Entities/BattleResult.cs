using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casestudy_devops.Entities
{
    public class BattleResult
    {
        public int Id { get; set; }
        public string Winner { get; set; }
        public DateTime Date { get; set; }
    }
}
