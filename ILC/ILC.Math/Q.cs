using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Math
{
    public class Q
    {

        public Q(string input) => throw new NotImplementedException();

        public override string ToString() => throw new NotImplementedException();

        public Q Clone() => throw new NotImplementedException();

        public static byte Compare(Q first, Q second) => throw new NotImplementedException();

        public bool IsZero() => throw new NotImplementedException();

        /// <summary>
        /// Сокращение дроби
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Red() => throw new NotImplementedException();

        public bool IsZ() => throw new NotImplementedException();

        public Z Abs()
        {
            throw new NotImplementedException();
        }

        public byte IsPositive()
        {
            throw new NotImplementedException();
        }

        public Z ChangeSign()
        {
            throw new NotImplementedException();
        }

        public static explicit operator Z(Q param)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Q(Z param)
        {
            throw new NotImplementedException();
        }

        public static Q operator +(Q first, Q second)
        {
            throw new NotImplementedException();
        }

        public static Q operator -(Q first, Q second)
        {
            throw new NotImplementedException();
        }

        public static Q operator *(Q first, Q second)
        {
            throw new NotImplementedException();
        }

        public static Q operator /(Q first, Q second)
        {
            throw new NotImplementedException();
        }
    }
}
