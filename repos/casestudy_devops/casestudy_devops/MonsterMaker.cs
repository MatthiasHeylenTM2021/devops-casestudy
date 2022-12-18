using casestudy_devops.Entities;
using System;


namespace casestudy_devops
{
    public class MonsterMaker
    {
        private Monster monster;
        private MonsterDataContext context;

        public MonsterMaker(Monster monster, MonsterDataContext context)
        {
            this.monster = monster;
            this.context = context;
        }

        public Monster CreateMonster(int typeId)
        {
            var type = context.Types.Find(typeId);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid type ID");
            }

            // Create and return a new Monster object of the appropriate type
            if (typeId == 1)
            {
                return new FireMonster(monster);
            }
            else if (typeId == 2)
            {
                return new WaterMonster(monster);
            }
            else if (typeId == 3)
            {
                return new SteelMonster(monster);
            }
            else
            {
                throw new InvalidOperationException("Invalid type ID");
            }
        }
    }
}
