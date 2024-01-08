using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Math
{
    public class Z
    {
        private N value;
        private bool isPositive;

        public Z(string input)
        {
            if (input[0] == '-')
            {
                isPositive = false;
                input = input.Remove(0, 1);
            }
            else isPositive = true;
            value = new N(input);
        }

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
        public static Z GCF(Z first, Z second)
        {
            throw new NotImplementedException();
        }

        public static implicit operator N(Z param)
        {
            throw new NotImplementedException();
        }

        public static explicit operator Z(N param)
        {
            throw new NotImplementedException();
        }

        public static Z operator +(Z first, Z second)
        {
            throw new NotImplementedException();
        }

        public static Z operator -(Z first, Z second)
        {
            throw new NotImplementedException();
        }

        public static Z operator *(Z first, Z second)
        {
            throw new NotImplementedException();
        }

        public static Z operator /(Z first, Z second)
        {
            throw new NotImplementedException();
        }

        public static Z operator %(Z first, Z second)
        {
            throw new NotImplementedException();
        }
    }
}
