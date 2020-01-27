using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class FirstnameParseTest
    {
        private FirstnameParser _firstNameParser;

        [TestInitialize]
        public void TestInitialize()
        {
            _firstNameParser = new FirstnameParser();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _firstNameParser.Parse("Du har modtaget et nyt lead. Når du kontakter leaded er der i nedenstående angivet en PIN-kode," +
                                   " som skal benyttes når du ringer til Freespee på tlf. 70303322\r\n\r\nNavn: sarah\r\n");
        }
    }
}
