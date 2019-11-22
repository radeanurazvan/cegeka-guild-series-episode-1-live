namespace Cegeka.Guild.Pokeverse.DAL.Entities
{
    public class Battle : Entity
    {
        public Pokemon Attacker { get; set; }

        public Pokemon Defender { get; set; }
    }
}