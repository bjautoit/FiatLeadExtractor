using System.Collections.Generic;
using System.Linq;
using Domain.Interface.Models;
using EAGetMail;

namespace MailboxAccess
{
    public class FiatMailParser
    {
        public MailInformation Parse(Mail mail)
        {
            return new MailInformation(mail.To[0].Address, mail.TextBody);
        }

        public IEnumerable<MailInformation> Parse(IEnumerable<Mail> mails)
        {
            return mails.Select(Parse);
        }
    }
}