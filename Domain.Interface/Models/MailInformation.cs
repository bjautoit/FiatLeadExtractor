namespace Domain.Interface.Models
{
    public class MailInformation
    {
        public MailInformation(string receiver, string body)
        {
            Receiver = receiver;
            Body = body;
        }

        public string Receiver { get; }
        public string Body { get; }
    }
}