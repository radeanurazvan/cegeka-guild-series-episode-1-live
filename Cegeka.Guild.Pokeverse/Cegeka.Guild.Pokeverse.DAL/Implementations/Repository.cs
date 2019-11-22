using System;
using System.Collections.Generic;
using System.Linq;
using Cegeka.Guild.Pokeverse.DAL.Abstracts;
using Cegeka.Guild.Pokeverse.DAL.Entities;

namespace Cegeka.Guild.Pokeverse.DAL.Implementations
{
    internal class Repository<T> : IRepository<T> 
        where T : Entity
    {
        private readonly ICollection<T> entities = new List<T>();

        public IReadOnlyCollection<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetById(Guid id)
        {
            return entities.FirstOrDefault(x => x.Id == id);
        }

        public void Add(T entity)
        {
            entities.Add(entity);
        }
    }
}