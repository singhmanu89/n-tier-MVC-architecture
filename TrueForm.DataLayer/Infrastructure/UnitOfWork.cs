using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoMapper;
using TrueForm.BusinessObjects.Infrastructure;

namespace TrueForm.DataLayer.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        public TrueFormDbContext Context { get; set; }
        private bool Disposed { get; set; } 

        public bool DisableAuditLog { get; set; }

        public UnitOfWork(TrueFormDbContext context)
        {
            Context = context;
        }


        public TDestination GetAs<TModel, TDestination>(long id) where TModel : BaseEntity
        {
            return To<TDestination>(Get<TModel>(id));
        }

        public TModel Get<TModel>(long id) where TModel : BaseEntity
        {
            return Context.Set<TModel>().SingleOrDefault(model => model.Id == id);
        }
        public TDestination To<TDestination>(Object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public void InsertRange<TModel>(IEnumerable<TModel> models) where TModel : BaseEntity
        {
            Context.Set<TModel>().AddRange(models);
        }
        public void Insert<TModel>(TModel model) where TModel : BaseEntity
        {
            Context.Set<TModel>().Add(model);
        }

        public void Update<TModel>(TModel model) where TModel : BaseEntity
        {
            DbEntityEntry<TModel> entry = Context.ChangeTracker.Entries<TModel>().FirstOrDefault(local => local.Entity.Id == model.Id);
            if (entry != null)
                entry.CurrentValues.SetValues(model);
            else
                entry = Context.Entry(model);

            entry.State = EntityState.Modified;
        }

        public void DeleteRange<TModel>(IEnumerable<TModel> models) where TModel : BaseEntity
        {
            Context.Set<TModel>().RemoveRange(models);
        }
        public void Delete<TModel>(TModel model) where TModel : BaseEntity
        {
            Context.Set<TModel>().Remove(model);
        }

        public void Delete<TModel>(long id) where TModel : BaseEntity
        {
            Delete(Context.Set<TModel>().Find(id));
        }

        public void Rollback()
        {
            Context.Dispose();
            Context = Activator.CreateInstance(Context.GetType()) as TrueFormDbContext;
        }
        public void Commit()
        {
            

            Context.SaveChanges();
             
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (Disposed) return;
             

            Context.Dispose();

            Disposed = true;
        }
    }
}