using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace casestudy_devops.Entities
{
    public class Monster
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }

        public virtual ICollection<Move> Moves { get; set; }
    }
}