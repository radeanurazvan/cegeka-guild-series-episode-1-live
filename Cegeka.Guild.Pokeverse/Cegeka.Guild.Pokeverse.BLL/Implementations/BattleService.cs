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

        public void UseAbility(Guid battleId, Guid participantId, Guid abilityId)
        {
            var battle = this.battleRepository.GetById(battleId);
            if (battle == null)
            {
                throw new InvalidOperationException("The battle does not exist!");
            }

            if (battle.Winner != null)
            {
                throw new InvalidOperationException("The battle has already ended!");
            }

            if (participantId != battle.ActivePlayerId)
            {
                throw new InvalidOperationException("It is not your turn yet!");
            }

            var pokemonToDealDamage = this.pokemonsRepository.GetById(participantId);
            var ability = pokemonToDealDamage.Definition.Abilities.FirstOrDefault(a => a.Id == abilityId);
            if (ability == null)
            {
                throw new InvalidOperationException("You cannot use an undefined ability");
            }

            if (ability.RequiredLevel > pokemonToDealDamage.Level)
            {
                throw new InvalidOperationException("You haven't learned this ability yet!'");
            }

            var pokemonToTakeDamage = battle.Defender;
            if (participantId != battle.AttackerId)
            {
                pokemonToTakeDamage = battle.Attacker;
            }

            pokemonToTakeDamage.Health -= ability.Damage;
            battle.ActivePlayerId = pokemonToTakeDamage.Id;

            if (pokemonToTakeDamage.Health <= 0)
            {
                battle.Winner = pokemonToDealDamage;
                battle.Loser = pokemonToTakeDamage;
            }
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