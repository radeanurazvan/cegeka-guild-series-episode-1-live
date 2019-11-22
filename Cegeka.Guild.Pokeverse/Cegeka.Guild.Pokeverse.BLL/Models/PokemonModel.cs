using Cegeka.Guild.Pokeverse.DAL.Entities;

namespace Cegeka.Guild.Pokeverse.BLL.Models
{
    public class PokemonModel
    {
        private PokemonModel()
        {
        }

        public string Name { get; set; }

        public static PokemonModel From(Pokemon pokemon)
        {
            return new PokemonModel
            {
                Name = pokemon.Definition.Name
            };
        }
    }
}