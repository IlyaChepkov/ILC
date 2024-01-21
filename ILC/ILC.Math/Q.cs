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
            {
                down = new N(inputArray[1]);
                if (down.IsZero())
                    throw new ArgumentException("на ноль делить нельзя!!!");
            }
            Red();
        }

        private Q(Z up, N down)
        {
            this.up = up;
            this.down = down;
            Red();
        }

        public override string ToString() => 
            up.ToString() + "/" + down.ToString();

        public Q Clone() => new Q(up.Clone(), down.Clone());

        public static byte Compare(Q first, Q second)
            => Z.Compare(first.up * second.down, second.up * first.down);

        public bool IsZero() => up.IsZero();

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

        public bool IsZ() => N.Compare(down, new N("1")) == 0;

        public Q Abs() => new Q(up.Abs(), down.Clone());

        public byte IsPositive() => up.IsPositive();

        public Q ChangeSign() => new Q(up.ChangeSign(), down.Clone());

        public static explicit operator Z(Q param)
        {
            if (!param.IsZ())
                throw new ArgumentException();
            return param.up.Clone();
        }

        public static implicit operator Q(Z param) =>
            new Q(param.Clone(), new N("1"));

        public static Q operator +(Q first, Q second)
        {
            Q result = new Q(first.up * second.down + second.up * first.down,
                second.down * first.down);
            result.Red();
            return result;
        }

        public static Q operator -(Q first, Q second) => first + second.ChangeSign();

        public static Q operator *(Q first, Q second)
        {
            Q result = new Q(first.up * second.up, first.down * second.down);
            result.Red();
            return result;
        }

        public static Q operator /(Q first, Q second)
        {
            Q result = new Q(first.up * second.down, first.down * (N)second.up.Abs());
            result.Red();
            if (second.IsPositive() == 1) 
                result = result.ChangeSign();
            return result;
        }
    }
}
