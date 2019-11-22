using System.Collections.Generic;
using System.Linq;
using Cegeka.Guild.Pokeverse.DAL.Entities;

namespace Cegeka.Guild.Pokeverse.BLL.Models
{
    public class TrainerModel
    {
        private TrainerModel()
        {
        }

        public string Name { get; set; }

        public IReadOnlyCollection<PokemonModel> Pokemons { get; set; }

        public static TrainerModel From(Trainer trainer)
        {
            return new TrainerModel
            {
                Name = trainer.Name,
                Pokemons = trainer.Pokemons.Select(PokemonModel.From).ToList()
            };
        }
    }
}