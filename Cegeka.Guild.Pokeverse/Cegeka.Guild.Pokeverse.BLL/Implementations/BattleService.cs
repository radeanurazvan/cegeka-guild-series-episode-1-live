using System;
using System.Collections.Generic;
using System.Linq;
using Cegeka.Guild.Pokeverse.BLL.Abstracts;
using Cegeka.Guild.Pokeverse.DAL.Abstracts;
using Cegeka.Guild.Pokeverse.DAL.Entities;

namespace Cegeka.Guild.Pokeverse.BLL.Implementations
{
    internal class BattleService : IBattleService
    {
        private readonly IRepository<Battle> battleRepository;
        private readonly IRepository<Pokemon> pokemonsRepository;

        public BattleService(IRepository<Battle> battleRepository)
        {
            this.battleRepository = battleRepository;
        }

        public void StartBattle(Guid attackerId, Guid defenderId)
        {
            Validate(attackerId, defenderId);

            var battle = new Battle
            {
                DefenderId = defenderId,
                AttackerId = attackerId
            };

            battleRepository.Add(battle);
        }

        private void Validate(Guid attackerId, Guid defenderId)
        {
            if (attackerId == defenderId)
            {
                throw new InvalidOperationException("Cannot attack itself");
            }

            var battleParticipants = new List<Guid> {attackerId, defenderId};
            var isAnyParticipantInBattle = battleRepository.GetAll()
                .Any(x => battleParticipants.Contains(x.Attacker.Id) || battleParticipants.Contains(x.Defender.Id));

            if (isAnyParticipantInBattle)
            {
                throw new InvalidOperationException("Ceva");
            }

            var pokemons = pokemonsRepository.GetAll().Where(x => battleParticipants.Contains(x.Id));

            if (pokemons.FirstOrDefault().Trainer.Id == pokemons.LastOrDefault().Trainer.Id)
            {
                throw new InvalidOperationException("Both pokemons have the same trainer!");
            }
        }
    }
}