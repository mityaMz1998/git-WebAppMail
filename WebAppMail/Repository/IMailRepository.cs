using System.Collections.Generic;
namespace WebAppMail.Repository
{
    /// <summary>
    /// Interface for implementing database context management
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IMailRepository<TEntity> where TEntity : class
    {
        public List<TEntity> GetAll();
        public TEntity Get(int id);
        public TEntity Create(TEntity model);
        public TEntity Update(TEntity model);
        public void Delete(int id);
    }
}
