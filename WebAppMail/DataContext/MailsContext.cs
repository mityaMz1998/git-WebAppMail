using Microsoft.EntityFrameworkCore;
using WebAppMail.Models;
namespace WebAppMail.DataContext
{
    public class MailsContext : DbContext
    {
        /// <summary>
        /// The Letter database table
        /// </summary>
        //public DbSet<Letter> Letters { get; set; }
        /// <summary>
        /// The Mail database table
        /// </summary>
        public DbSet<Mail> Mails { get; set; }
        /// <summary>
        /// The Recipient database table
        /// </summary>
        public DbSet<Recipient> Recipients { get; set; }
        public MailsContext(DbContextOptions<MailsContext> options): base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
    }
}
