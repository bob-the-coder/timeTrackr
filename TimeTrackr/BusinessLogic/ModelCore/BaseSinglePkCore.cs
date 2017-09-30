using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.TypeManagement;
using DataLayer.Implementation;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using BusinessLogic.Interfaces;
using BusinessLogic.Workflow;

namespace BusinessLogic.ModelCore
{
    public abstract class BaseSinglePkCore<TRepo, TModel, TEntity> : BaseCore<TRepo, TModel, TEntity>
        where TRepo : BaseSinglePkRepository<TEntity>
        where TEntity : class, ISinglePkDataAccessObject, new()
        where TModel : class, ISinglePkModel, new()
    {

        public static async Task<TModel> GetAsync(Guid id, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetAsync(id, navigationProperties).ConfigureAwait(false);

                return entities.CopyTo<TModel>();
            }
        }

        public static async Task DeleteAsync(Guid id)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                await repository.DeleteAsync(id).ConfigureAwait(false);
            }
        }
    }
}