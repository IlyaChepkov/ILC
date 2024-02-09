using System.Text;

namespace ILC.Math
{
    internal class P
    {
        List<(Q, Z)> value;
        public P(string input)
        {
            value = new List<(Q, Z)>();
            input = input.Replace(" ", "");
            input = input.Replace("^", "");
            input = input.Replace("-", "+-");
            string[] monomes = input.Split('+');
            for (int i = 0; i < monomes.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(monomes[i]))
                    continue;
                string[] monome = monomes[i].Split('x');
                (Q, Z) valueMonome;
                switch (monome.Length)
                {
                    case 1:
                        {
                            valueMonome = (new Q(monome[0]), new Z("0"));
                        }
                        break;

                    case 2:
                        {
                            Q q = monome[0].Length == 0 ? new Q("1") : new Q(monome[i]);
                            Z z = new Z(monome[1].Length == 0 ? "1" : monome[1]);
                            valueMonome = (q, z);
                        }
                        break;
                    default: throw new ArgumentException("не моном");
                }
                for (int j = 0; j < value.Count; j++)
                {
                    if (Z.Compare(valueMonome.Item2, value[j].Item2) == 0)
                    {
                        if ((valueMonome.Item1 + value[j].Item1).IsZero())
                            break;
                        value[j] = (valueMonome.Item1 + value[j].Item1, value[j].Item2);
                        break;
                    }
                    if (Z.Compare(valueMonome.Item2, value[j].Item2) == 1)
                    {
                        if (valueMonome.Item1.IsZero())
                            break;
                        value.Insert(j, valueMonome);
                        break;
                    }
                }
                if (Z.Compare(valueMonome.Item2, value[^1].Item2) == 2 &&
                    !(valueMonome.Item1.IsZero()))
                {
                    value.Add(valueMonome);
                }
            }
            if (value.Count == 0)
            {
                value.Add((new Q("0"), new Z("0")));
            }
        }

        private P(List<(Q, Z)> value)
        {
            for (int i = 0; i < value.Count; i++)
            {
                this.value.Add((value[i].Item1.Clone(), value[i].Item2.Clone()));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < value.Count; i++)
            {
                if (Q.Compare(value[i].Item1, new Q("1")) != 0)
                    sb.Append((i != 0 ? value[i].Item1.Abs() : value[i].Item1).ToString());
                if (value[i].Item2.IsZero())
                    continue;
                sb.Append('x');
                if (Z.Compare(value[i].Item2, new Z("1")) != 0)
                    sb.Append('^' + value[i].Item2.ToString());
                if (i + 1 != value.Count)
                {
                    sb.Append(' ');
                    if (value[i].Item2.IsPositive() == 2)
                        sb.Append('+');
                    else
                        sb.Append('-');
                    sb.Append(' ');
                }
            }
            return sb.ToString();
        }

        public P Clone() => new P(value);

        public static byte Compare(P first, P second)
        {
            int minCount = System.Math.Min(first.value.Count, second.value.Count);
            for (int i = 0; i < minCount; i++)
            {
                if (Z.Compare(first.value[^(i + 1)].Item2, second.value[^(i + 1)].Item2) == 2)
                    return 2;
                if (Z.Compare(first.value[^(i + 1)].Item2, second.value[^(i + 1)].Item2) == 1)
                    return 1;
                if (Q.Compare(first.value[^(i + 1)].Item1, second.value[^(i + 1)].Item1) == 2)
                    return 2;
                if (Q.Compare(first.value[^(i + 1)].Item1, second.value[^(i + 1)].Item1) == 1)
                    return 1;
            }
            if (first.value.Count > second.value.Count)
                return 2;
            else if (second.value.Count > first.value.Count)
                return 1;
            return 0;
        }

        public bool IsZero() => value.Count == 1 && value[0].Item1.IsZero();

        public bool IsQ() => value.Count == 1 && value[0].Item2.IsZero();

        public P ChangeSign()
        {
            P clawn = Clone();
            for (int i = 0; i < clawn.value.Count; i++)
                clawn.value[i] = (clawn.value[i].Item1.ChangeSign(), clawn.value[i].Item2);
            return clawn;
        }

        public P MulQ(Q number)
        {
            P clawn = Clone();
            for (int i = 0; i < clawn.value.Count; i++)
            {
                clawn.value[i] = (clawn.value[i].Item1 * number, clawn.value[i].Item2);
            }
            return clawn;
        }
        public P MulXk(Z number)
        {
            P clawn = Clone();
            for (int i = 0; i < clawn.value.Count; i++)
            {
                clawn.value[i] = (clawn.value[i].Item1, clawn.value[i].Item2 * number);
            }
            return clawn;
        }

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
