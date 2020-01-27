using System.Collections.Generic;
using Domain.Interface.Models;

namespace Domain.Interface
{
    public interface IMailbox
    {
        IEnumerable<MailInformation> GetMails();
    }
}