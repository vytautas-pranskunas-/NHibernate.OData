using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.OData.Test.Domain;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Assert = NUnit.Framework.Assert;

namespace NHibernate.OData.Test.SupportFixtures
{
    [TestFixture]
    internal class HttpUtil
    {
        [Test]
        public void UriDecode()
        {
            ClassicAssert.AreEqual("abc", OData.HttpUtil.UriDecode("abc", false));
            ClassicAssert.AreEqual(" ", OData.HttpUtil.UriDecode("%20", false));
            ClassicAssert.AreEqual(" ", OData.HttpUtil.UriDecode("+", false));
            ClassicAssert.AreEqual("+", OData.HttpUtil.UriDecode("%2b", false));

            ClassicAssert.AreEqual("Я", OData.HttpUtil.UriDecode("%d0%af", true)); // UTF-8 encoded character
            ClassicAssert.AreEqual("+", OData.HttpUtil.UriDecode("%2b", true));

            ClassicAssert.IsFalse(OData.HttpUtil.IsHex('X'));
        }

        [Test]
        public void InvalidHex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                OData.HttpUtil.HexToInt('x');
            });
           
        }
    }
}
