﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace NHibernate.OData.Test.Support
{
    internal class LexerTestFixture
    {
        protected void Verify(string source, params object[] values)
        {
            var tokens = new List<Token>();

            foreach (var value in values)
            {
                if (value is Token)
                    tokens.Add((Token)value);
                else
                    tokens.Add(new LiteralToken(value));
            }

            Verify(source, tokens.ToArray());
        }

        protected void Verify(string source, params Token[] tokens)
        {
            ClassicAssert.AreEqual(tokens, new OData.Lexer(source).ToList().ToArray());
        }

        protected void VerifyThrows(string source)
        {
            VerifyThrows(source, typeof(ODataException));
        }

        protected void VerifyThrows(string source, System.Type exceptionType)
        {
            try
            {
                Verify(source, new Token[] { });

                Assert.Fail("Expected exception");
            }
            catch (AssertionException)
            {
                throw;
            }
            catch (Exception ex)
            {
                ClassicAssert.AreEqual(exceptionType, ex.GetType());
            }
        }
    }
}
