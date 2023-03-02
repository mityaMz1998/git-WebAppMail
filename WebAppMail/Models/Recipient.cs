using Newtonsoft.Json;
namespace WebAppMail.Models
{
    public class Recipient
    {
        //[JsonIgnore]
        public int Id { get; set; }
        //[JsonProperty("recipient")]
        public string RecipientEmail { get; set; }
        //[JsonIgnore]
        public int MailId { get; set; }
        //[JsonIgnore]
        public Mail Mail { get; set; }
    }
}
