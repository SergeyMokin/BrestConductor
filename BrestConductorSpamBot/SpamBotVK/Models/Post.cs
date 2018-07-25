using System;

namespace SpamBotVK.Models
{
    public class Post
    {
        public long? Id { get; set; }
        public DateTime? Date { get; set; }
        public string Message { get; set; }
        public DateTime? LastConfirmDate { get; set; }
    }
}