using System.Collections.Generic;

namespace Cegeka.Guild.Pokeverse.DAL.Entities
{
    public class Pokemon : Entity
    {
        public int Health { get; set; }

        public int BaseDamage { get; set; }

        public float CriticalStrikeChance { get; set; }

        public string Name { get; set; }

        public int Experience { get; set; }

        public int Level { get; set; }

        public ICollection<Ability> Abilities { get; set; }
    }
}