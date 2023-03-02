using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAppMail.Models;
using WebAppMail.DataContext;

namespace WebAppMail.Repository
{
    public class MailRepository<TEntity> : IMailRepository<TEntity> where TEntity : Mail
    {
        private MailsContext Context { get; set; }
        public MailRepository(MailsContext context)
        {
            Context = context;
        }
        public List<TEntity> GetAll()
        {
            try
            {
                return Context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<TEntity>();
            }
        }
        public TEntity Create(TEntity mail)
        {
            Context.Set<TEntity>().Add(mail);
            Context.SaveChanges();
            return mail;
        }
        public void Delete(int id)
        {
            var toDelete = Context.Set<TEntity>().FirstOrDefault(m => m.Id == id);
            Context.Set<TEntity>().Remove(toDelete);
            Context.SaveChanges();
        }
        public TEntity Update(TEntity model)
        {
            var toUpdate = Context.Set<TEntity>().FirstOrDefault(m => m.Id == model.Id);
            if (toUpdate != null)
            {
                toUpdate = model;
            }
            Context.Update(toUpdate);
            Context.SaveChanges();
            return toUpdate;
        }
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().FirstOrDefault(m => m.Id == id);
        }
    }
}
