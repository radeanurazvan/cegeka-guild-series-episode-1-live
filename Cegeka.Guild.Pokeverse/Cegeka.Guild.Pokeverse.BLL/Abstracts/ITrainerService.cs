using System.Collections.Generic;
using Cegeka.Guild.Pokeverse.BLL.Models;
using Cegeka.Guild.Pokeverse.DAL.Entities;

namespace Cegeka.Guild.Pokeverse.BLL.Abstracts
{
    public interface ITrainerService
    {
        void Register(string name);
        IReadOnlyCollection<TrainerModel> GetAll();
    }
}