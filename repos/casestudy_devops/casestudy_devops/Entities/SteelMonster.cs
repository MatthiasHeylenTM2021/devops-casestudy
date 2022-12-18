using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casestudy_devops.Entities
{
    public class SteelMonster : Monster
    {
        public SteelMonster(Monster monster)
        {
            // Initialize the properties of the FireMonster object using the values of the Monster object
            Id = monster.Id;
            Name = monster.Name;
            HP = monster.HP;
            Attack = monster.Attack;
            Defense = monster.Defense;
            TypeId = monster.TypeId;
            Type = monster.Type;
            Moves = monster.Moves;

        }
        public double effectivenessMultiplier()
        {
            return 1.10;
        }

    }
}
