using System;

namespace Cegeka.Guild.Pokeverse.DAL.Entities
{
    public class Battle : Entity
    {
        public Pokemon Attacker { get; set; }

        public Guid AttackerId { get; set; }

        public Pokemon Defender { get; set; }

        public Guid DefenderId { get; set; }
    }
}