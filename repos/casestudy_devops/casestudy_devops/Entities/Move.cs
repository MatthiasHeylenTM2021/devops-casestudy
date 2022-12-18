using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casestudy_devops.Entities
{
    public class Move
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Damage { get; set; }

        public virtual ICollection<Monster> Monsters { get; set; }
    }
}
