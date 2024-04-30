using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace NHibernate.OData.Test.SupportFixtures
{
    [TestFixture]
    internal class TypeUtil
    {
        [Test]
        public void CollectionTypes()
        {
            ClassicAssert.AreEqual(typeof(int), OData.TypeUtil.TryGetCollectionItemType(typeof(List<int>)));
            ClassicAssert.AreEqual(typeof(int), OData.TypeUtil.TryGetCollectionItemType(typeof(ISet<int>)));
            ClassicAssert.AreEqual(null, OData.TypeUtil.TryGetCollectionItemType(typeof(IEnumerable)));
        }
    }
}
