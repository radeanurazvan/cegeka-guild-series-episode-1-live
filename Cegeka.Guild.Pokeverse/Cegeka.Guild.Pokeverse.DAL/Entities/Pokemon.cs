namespace Cegeka.Guild.Pokeverse.DAL.Entities
{
    public class Pokemon : Entity
    {
        public Pokemon(PokemonDefinition definition)
        {
            Definition = definition;
        }

        public PokemonDefinition Definition { get; set; }

        public int Health { get; set; }

        public int BaseDamage { get; set; }

        public float CriticalStrikeChance { get; set; }

        public int Experience { get; set; }

        public int Level { get; set; }

    }
}