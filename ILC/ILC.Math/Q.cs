using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Math
{
    public class Q
    {
        private Z up;
        private N down;

        public Q(string input) 
        {
            string[] inputArray = input.Split('/');
            if (inputArray.Length > 2) 
                throw new ArgumentException("не число");
            up = new Z(inputArray[0]);
            if (inputArray.Length == 1)
                down = new N("1");
            else
                down = new N(inputArray[1]);
        }

        public override string ToString() 
        {
            return up.ToString() + "/" + down.ToString();
        }

        public Q Clone() => throw new NotImplementedException();

        public static byte Compare(Q first, Q second) => throw new NotImplementedException();

        public bool IsZero() => throw new NotImplementedException();

        /// <summary>
        /// Сокращение дроби
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Red()
        {
            N gsf = N.GCF((N)up.Abs(), down);
            up /= gsf;
            down /= gsf;
        }

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
