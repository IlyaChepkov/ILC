namespace ILC.Math
{
    public class Z
    {
        private N value;
        private bool isPositive;

        public Z(string input)
        {
            if (input =="-0")
            {
                isPositive = true;
                value = new N(input);
            }
            if (input[0] == '-')
            {
                isPositive = false;
                input = input.Remove(0, 1);
            }
            else isPositive = true;
            value = new N(input);
        }

        private Z(N value, bool isPositive)
        {
            this.value = value;
            this.isPositive = isPositive;
        }

        public override string ToString() =>
            isPositive == false ? "-" + value.ToString() : "" + value.ToString();

        public Z Clone() => new Z(value, isPositive);

        public static byte Compare(Z first, Z second)
        {
            if (first.isPositive == second.isPositive && N.Compare(first.value, second.value) == 0)
                return 0;
            if (first.isPositive && !second.isPositive)
                return 2;
            else if (!first.isPositive && second.isPositive)
                return 1;
            else
            {
                if (!first.isPositive)
                {
                    if (N.Compare(first.value, second.value) == 1)
                        return 2;
                    else
                        return 1;
                }
                else
                {
                    return N.Compare(first.value, second.value);
                }
            }
        }

        public bool IsZero() => value.IsZero();


        public Z Abs()
        {
            Z result = Clone();
            result.isPositive = true;
            return result;
        }

        public byte IsPositive()
        {
            if (isPositive)
                return IsZero() ? (byte)0 : (byte)2;
            else
                return 1;
        }

        public Z ChangeSign()
        {
            Z result = Clone();
            if (result.value.ToString() == "0")
                return result;
            if (result.isPositive)
                result.isPositive = false;
            else
                result.isPositive = true;
            return result;
        }
        public static Z GCF(Z first, Z second)
        {
            Z result = N.GCF(first.value, second.value);
            return result;
        }

        public static Z LCM(Z first, Z second)
        {
            return N.LCM(first.value, second.value);
        }

        public static explicit operator N(Z param)
        {
            if (!param.isPositive)
                throw new ArgumentException();
            return param.value;
        }

        public static implicit operator Z(N param)
        {
            return new Z(param.ToString());
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
