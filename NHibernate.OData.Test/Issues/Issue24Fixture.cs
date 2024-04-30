using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.OData.Test.Domain;
using NHibernate.OData.Test.Support;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace NHibernate.OData.Test.Issues
{
    [TestFixture]
    internal class Issue24Fixture : DomainTestFixture
    {
        [Test]
        public void CountWithoutFilter()
        {
            var actual = Session.ODataQuery<Parent>("$count=true").List();

            ClassicAssert.AreEqual(1, actual.Count);
            ClassicAssert.AreEqual(11, actual[0]);
        }

        [Test]
        public void CountWithFilter()
        {
            var actual = Session.ODataQuery<Parent>("$filter=Id eq 1&$count=true").List();

            ClassicAssert.AreEqual(1, actual.Count);
            ClassicAssert.AreEqual(1, actual[0]);
        }

        [Test]
        public void CountIgnoresTopSkip()
        {
            var actual = Session.ODataQuery<Parent>("$count=true&$top=1&$skip=1").List();

            ClassicAssert.AreEqual(1, actual.Count);
            ClassicAssert.AreEqual(11, actual[0]);
        }
    }
}
