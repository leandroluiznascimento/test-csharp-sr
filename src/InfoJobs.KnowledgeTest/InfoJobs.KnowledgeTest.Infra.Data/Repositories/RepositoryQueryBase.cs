﻿using InfoJobs.KnowledgeTest.Domain.Core.Entities;
using InfoJobs.KnowledgeTest.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfoJobs.KnowledgeTest.Infra.Data.Repositories
{
    public class RepositoryQueryBase<TEntity, TContext> : IRepositoryQueryBase<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        protected readonly TContext _context;

        public RepositoryQueryBase(TContext context)
        {
            _context = context;
        }

        public TEntity ById(int id)
        {
            return _context.Set<TEntity>().FirstOrDefault(p => p.Id.Equals(id));
        }

        public virtual IEnumerable<TEntity> List()
        {
            return _context.Set<TEntity>().AsQueryable();
        }
    }
}