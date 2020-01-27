using Domain.Interface;

namespace Domain
{

    public class TheStykEverythingSammenClass
    {
        private readonly IMailbox _mailbox;
        private readonly IAliasTranslateStrategy _aliasTranslateStrategy;
        private readonly ILeadParserStrategy _leadParserStrategy;

        public TheStykEverythingSammenClass(IMailbox mailbox, IAliasTranslateStrategy aliasTranslateStrategy, ILeadParserStrategy leadParserStrategy)
        {
            _mailbox = mailbox;
            _aliasTranslateStrategy = aliasTranslateStrategy;
            _leadParserStrategy = leadParserStrategy;
        }

        public void DoWhatEverYouHaveToDo()
        {
            var mails = _mailbox.GetMails();
            foreach (var mailInformation in mails)
            {
                var aliasInformation = _aliasTranslateStrategy.Translate(mailInformation.Receiver);
                var leadInformation = _leadParserStrategy.Parse(mailInformation.Body);
            }

        }
    }
}