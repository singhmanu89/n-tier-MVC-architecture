using System;
using System.Collections.Generic;
using TrueForm.BusinessObjects.Infrastructure;

namespace TrueForm.DataLayer.Infrastructure
{
    public interface IUnitOfWork : IDisposable, IPerWebRequestDependency
    {
        bool DisableAuditLog { get; set; }

        TrueFormDbContext Context { get; set; }

        TDestination GetAs<TModel, TDestination>(long id) where TModel : BaseEntity;
        TModel Get<TModel>(long id) where TModel : BaseEntity;
        TDestination To<TDestination>(Object source);


        void InsertRange<TModel>(IEnumerable<TModel> models) where TModel : BaseEntity;
        void Insert<TModel>(TModel model) where TModel : BaseEntity;

        void Update<TModel>(TModel model) where TModel : BaseEntity;

        void DeleteRange<TModel>(IEnumerable<TModel> models) where TModel : BaseEntity;
        void Delete<TModel>(TModel model) where TModel : BaseEntity;
        void Delete<TModel>(long id) where TModel : BaseEntity;

        void Rollback();
        void Commit();
    }
}