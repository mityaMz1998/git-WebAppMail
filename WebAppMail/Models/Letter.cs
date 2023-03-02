using System.Collections.Generic;
namespace WebAppMail.Models
{
    public class Letter
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> Recipients { get; set; }
    }
}
