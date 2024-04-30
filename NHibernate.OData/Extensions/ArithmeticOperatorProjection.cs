using System.Text;
using System.Collections.Generic;
using System;
using NHibernate.Criterion;
using NHibernate.Type;
using NHibernate.SqlCommand;

namespace NHibernate.OData.Extensions
{
    // From http://savale.blogspot.com/2011/04/nhibernate-and-missing.html
    internal class ArithmeticOperatorProjection : OperatorProjection
    {
        public ArithmeticOperatorProjection(string op, IType returnType, params IProjection[] args)
            : base(op, returnType, args)
        {
            if (args.Length < 2)
                throw new ArgumentOutOfRangeException("args", args.Length, "Requires at least 2 projections");
        }

        public override string[] AllowedOperators
        {
            get { return new[] { "+", "-", "*", "/", "%" }; }
        }
    }
}
