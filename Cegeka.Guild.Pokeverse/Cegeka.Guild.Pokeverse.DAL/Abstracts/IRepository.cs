using System;
using System.Collections.Generic;
using Cegeka.Guild.Pokeverse.DAL.Entities;

namespace Cegeka.Guild.Pokeverse.DAL.Abstracts
{
    public interface IRepository<T>
        where T : Entity
    {
        IReadOnlyCollection<T> GetAll();

        T GetById(Guid id);

        void Add(T entity);

    }
}