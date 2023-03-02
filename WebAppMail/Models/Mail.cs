using System;
using System.Collections.Generic;
namespace WebAppMail.Models
{
    public class Mail
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public string FailedMessage { get; set; }
        public virtual List<Recipient> Recipients { get; set; }
        //public int RecipientId { get; set; }
        //public Recipient Recipient { get; set; }
    }
}
