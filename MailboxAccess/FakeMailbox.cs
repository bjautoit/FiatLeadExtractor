using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interface;
using Domain.Interface.Models;

namespace MailboxAccess
{
    public class FakeMailbox : IMailbox
    {
        private readonly string _fakeLeadText;
        public FakeMailbox()
        {
            _fakeLeadText =
                "Du har modtaget et nyt lead. Når du kontakter leaded er der i nedenstående angivet en PIN-kode," +
                " som skal benyttes når du ringer til Freespee på tlf. 70303322\r\n\r\nNavn: sarah\r\nEfternavn: syberg\r\n" +
                "By: København Ø\r\nMærke: 00\r\nNuværende bil: \r\nModel af interesse: 500L Wagon\r\nKampagnenavn: Standard\r\n" +
                "Oprindelse: Web Corporate\r\nType: Test Drive\r\nForhandler: SIGRUNSVEJ 1 - HILLERØD\r\nOprettet: 12/04/2019 09:00\r\n" +
                "Tildelt sælger: 12/04/2019 09:00\r\nPIN-kode: 3740#-12026258#\r\nELINK ID: 15021227\r\nBemærk: CVR : Nej \r\n";
        }

        public IEnumerable<MailInformation> GetMails()
        {
            return new List<MailInformation>
            {
                new MailInformation("3857_fcaleads@autoit.dk", _fakeLeadText)
            };
        }
    }
}
