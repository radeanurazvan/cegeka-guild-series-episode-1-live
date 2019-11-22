using System;

namespace Cegeka.Guild.Pokeverse.BLL.Abstracts
{
    public interface IBattleService
    {
        void StartBattle(Guid attackerId, Guid defenderId);
    }
}