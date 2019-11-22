using System;
using System.Collections.Generic;
using System.Linq;
using Cegeka.Guild.Pokeverse.BLL.Abstracts;
using Cegeka.Guild.Pokeverse.BLL.Models;
using Cegeka.Guild.Pokeverse.DAL.Abstracts;
using Cegeka.Guild.Pokeverse.DAL.Entities;

namespace Cegeka.Guild.Pokeverse.BLL.Implementations
{
    internal class TrainerService : ITrainerService
    {
        private const int RandomAssignedPokemonsCount = 2;
        private readonly IRepository<Trainer> trainerRepository;
        private readonly IRepository<PokemonDefinition> definitionsRepository;
        private readonly IRepository<Pokemon> pokemonRepository;

        public TrainerService(IRepository<Trainer> trainerRepository, IRepository<PokemonDefinition> definitionsRepository, IRepository<Pokemon> pokemonRepository)
        {
            this.trainerRepository = trainerRepository;
            this.definitionsRepository = definitionsRepository;
            this.pokemonRepository = pokemonRepository;
        }

        public void Register(string name)
        {
            if (string.IsNullOrEmpty(name.Trim()))
            {
                throw new InvalidOperationException("Invalid name!");
            }

            var definitions = definitionsRepository.GetAll();
            var random = new Random();
            var randomDefinitions = Enumerable.Range(0, RandomAssignedPokemonsCount)
                .Select(x => random.Next(0, definitions.Count))
                .Select(randomIndex => definitions.ElementAt(randomIndex));

            var trainer = new Trainer
            {
                Name = name,
            };
            trainer.Pokemons = randomDefinitions.Select(d => new Pokemon(d, trainer)).ToList();
            this.trainerRepository.Add(trainer);
            trainer.Pokemons.ToList().ForEach(pokemon => pokemonRepository.Add(pokemon));
        }

        public IReadOnlyCollection<TrainerModel> GetAll()
        {
            return trainerRepository
                .GetAll()
                .Select(TrainerModel.From)
                .ToList();
        }
    }
}