using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MailboxAccess;
using Microsoft.Extensions.Hosting;
using Configuration = Common.Configuration;

namespace FiatLeadImportService2
{
    public class LeadImportService : BackgroundService
    {
        public LeadImportService()
        {
            var userEmail = Configuration.GetConfiguration("UserEmail");
            var userPassword = Configuration.GetConfiguration("UserPassword");
            //var test = new TheStykEverythingSammenClass(new OutlookMailbox(userEmail, userPassword), new FiatAliasTranslateStrategy(), new FiatLeadParserStrategy());
            //var test = new TheStykEverythingSammenClass(new FakeMailbox(), new FiatAliasTranslateStrategy(), new FiatLeadParserStrategy());
            //test.DoWhatEverYouHaveToDo();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var test = new TheStykEverythingSammenClass(new FakeMailbox(), new FiatAliasTranslateStrategy(), new FiatLeadParserStrategy());
            return Task.Run(() => test.DoWhatEverYouHaveToDo(), stoppingToken); // Do Something
        }
    }
}
