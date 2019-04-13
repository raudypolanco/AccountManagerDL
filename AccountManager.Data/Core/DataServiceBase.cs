﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AccountManager.Data.Core
{
    public abstract class DataServiceBase<TEntity, TContext>
         where TEntity : class
         where TContext : DbContext
    {
        protected DataServiceBase(IMapper mapper, TContext context)
        {
            Context = Context;
            Mapper = mapper;
        }

        protected TContext Context { get; set; }
        protected IMapper Mapper { get; set; }

        public IQueryable<TDto> GeTAll<TDto>()
        {
            DbSet<TEntity> table = Context.Set<TEntity>();

            return Mapper.ProjectTo<TDto>(table);

        }

        public IQueryable<TDto> GeTAll<TDto>(Expression<Func<TEntity, bool>> filter)
        {
            DbSet<TEntity> table = Context.Set<TEntity>();

            return Mapper.ProjectTo<TDto>(table.Where(filter));

        }




    }
}