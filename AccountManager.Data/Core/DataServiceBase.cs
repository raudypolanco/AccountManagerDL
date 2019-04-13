using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AccountManager.Data.Core
{
    public abstract class DataServiceBase<TEntity,TId, TContext>
         where TId: IEquatable<TId>
         where TEntity : ModelBase<TId>
         where TContext : DbContext
    {
        protected DataServiceBase(IMapper mapper, TContext context)
        {
            Context = Context;
            Mapper = mapper;
        }

        protected TContext Context { get; set; }
        protected IMapper Mapper { get; set; }

        public void Update<TDto>(TDto model)
        {
            TEntity entity = Mapper.Map<TEntity>(model);
            if (!BeforeAddOrupdate(entity))
                throw new Exception("Error de validacion");
            if(entity.IsNewModel())
            {
                Context.Add(entity);
            }

            else
            {
                TEntity originalEntity = Context.Find<TEntity>(entity.Id);
                originalEntity = Mapper.Map(model, originalEntity);

            }

            Context.SaveChanges();
        }

        public virtual bool BeforeAddOrupdate(TEntity entity)
        {
            return true;
        }

        public IQueryable<TDto> GetAll<TDto>()
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