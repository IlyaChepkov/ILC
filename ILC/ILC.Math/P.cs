using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Math
{
    internal class P
    {
        public P(string input) => throw new NotImplementedException();

        public override string ToString() => throw new NotImplementedException();

        public P Clone() => throw new NotImplementedException();

        public static byte Compare(P first, P second) => throw new NotImplementedException();

        public bool IsZero() => throw new NotImplementedException();

        public bool IsQ() => throw new NotImplementedException();

        public P ChangeSign()
        {
            throw new NotImplementedException();
        }

        public P MulQ(Q number) => throw new NotImplementedException();
        public P MulXk(Z number) => throw new NotImplementedException();

        public Q Led() => throw new NotImplementedException();

        public Z Deg() => throw new NotImplementedException();

        public P Fac() => throw new NotImplementedException();

        public P GCF() => throw new NotImplementedException();

        public P DER() => throw new NotImplementedException();

        public P NMR() => throw new NotImplementedException();

        public static explicit operator Q(P param)
        {
            throw new NotImplementedException();
        }

        public static implicit operator P(Q param)
        {
            throw new NotImplementedException();
        }

        public static P operator +(P first, P second)
        {
            throw new NotImplementedException();
        }

        public static P operator -(P first, P second)
        {
            throw new NotImplementedException();
        }

        public static P operator *(P first, P second)
        {
            throw new NotImplementedException();
        }

        public static P operator /(P first, P second)
        {
            throw new NotImplementedException();
        }

        public static P operator %(P first, P second)
        {
            throw new NotImplementedException();
        }
    }
}
