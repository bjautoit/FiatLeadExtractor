using System;
using System.Collections.Generic;
using Domain.Interface;
using Domain.Interface.Models;
using EAGetMail;

namespace MailboxAccess
{
    public class OutlookMailbox : IMailbox
    {
        private const string Server = "outlook.office365.com";
        private readonly MailServer _mailServer;
        private readonly MailClient _mailClient;
        private bool _hasConnectedOnce;
        private readonly FiatMailParser _fiatMailParser;

        public OutlookMailbox(string userEmail, string userPassword)
        {
            _fiatMailParser = new FiatMailParser();
            _hasConnectedOnce = false;
            _mailServer = new MailServer(Server, userEmail, userPassword, ServerProtocol.Imap4) {SSLConnection = true, Port = 993};
            _mailClient = new MailClient("TryIt");
            _mailClient.OnIdle += MailClientOnOnIdle;
            _mailClient.OnQuit += MailClientOnOnQuit;
        }

        private void Connect()
        {
            try
            {
                if (_hasConnectedOnce)
                    _mailClient.ReConnect();
                else
                {
                    _mailClient.Connect(_mailServer);
                    _hasConnectedOnce = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public IEnumerable<MailInformation> GetMails()
        {
            RefreshConnection();

            foreach (var mail in _mailClient.FetchMails(false))
            {
                yield return _fiatMailParser.Parse(mail);
            }
        }

        private void RefreshConnection()
        {
            if (!_mailClient.Connected)
                Connect();
        }

        private void MailClientOnOnQuit(object sender, ref bool cancel)
        {
            _mailClient.OnIdle -= MailClientOnOnIdle;
        }

        private void MailClientOnOnIdle(object sender, ref bool cancel)
        {
            Connect();
        }
    }
}
