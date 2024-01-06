using System.Text;

namespace ILC.Math
{
    public class N
    {
        private List<byte> value;

        public N(string input)
        {
            if (input.Any(t => !char.IsDigit(t)))
                throw new ArgumentException("не число");
            value = new List<byte>();
            for (int i = 0; i < input.Length; i++)
            {
                value.Add((byte)(input[^(i + 1)] - '0'));
            }
            while (value[^1] == 0 && value.Count > 1)
                value.RemoveAt(value.Count - 1);
        }

        private N(List<byte> value)
        {
            this.value = new List<byte>();
            for (int i = 0; i < value.Count; i++)
                this.value.Add(value[i]);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < value.Count; i++)
            {
                var s = value[^(i + 1)].ToString();
                result.Append(s);
            }
            return result.ToString();
        }
        /// <summary>
        /// Создает полную копию объекта
        /// </summary>
        /// <returns></returns>
        public N Clone() => new N(value);

        /// <summary>
        /// Сравнение натуральных чисел: 2 - если первое больше второго, 0, если равно, 1 иначе
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static byte Compare(N first, N second)
        {
            if (first.value.Count > second.value.Count)
                return 2;
            else if (first.value.Count < second.value.Count)
                return 1;
            else
            {
                for (int i = 1; i <= first.value.Count; i++)
                {
                    if (first.value[^i] > second.value[^i])
                        return 2;
                    else if (first.value[^i] < second.value[^i])
                        return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// возвращает true, если число равно 0 и false, если не равно 0
        /// </summary>
        /// <returns></returns>
        /// 
        public bool IsZero() => value.Count == 1 && value[0] == 0;

        public N MulDigit(byte digit)
        {
            N result = Clone();

            return result;
        }

        public static N operator ++(N n)
        {
            N result = n.Clone();
            for (int i = 0; i < result.value.Count; i++)
            {
                if (result.value[i] + 1 >= 10)
                {
                    result.value[i] = 0;
                }
                else
                {
                    result.value[i]++;
                    return result;
                }
            }
            result.value.Add(1);
            return result;
        }

        public static N operator +(N first, N second)
        {
            if (Compare(first, second) == 1)
            {
                N bufer = second;
                second = first;
                first = bufer;
            }
            N result = first.Clone();
            byte one = 0;
            for (int i = 0; i < second.value.Count; i++)
            {
                if (result.value[i] + second.value[i] + one >= 10)
                {
                    one = 1;
                    result.value[i] = (byte)(result.value[i] + second.value[i] + one - 10);
                }
                else
                {
                    result.value[i] = (byte)(result.value[i] + second.value[i] + one);
                    one = 0;
                }
            }
            if (one == 0) return result;
            for (int i = second.value.Count; i < result.value.Count; i++)
            {
                if (result.value[i] + 1 >= 10)
                {
                    result.value[i] = 0;
                }
                else
                {
                    result.value[i]++;
                    return result;
                }
            }
            result.value.Add(1);
            return result;
        }

        public static N operator -(N first, N second)
        {
            if (Compare(first, second) == 1)
            {
                N bufer = second;
                second = first;
                first = bufer;
            }
            N result = first.Clone();
            byte one = 0;
            for (int i = 0; i < second.value.Count; i++)
            {
                if (result.value[i] - second.value[i] - one < 0)
                {
                    one = 1;
                    result.value[i] = (byte)(result.value[i] - second.value[i] - one + 10);
                }
                else
                {
                    result.value[i] = (byte)(result.value[i] - second.value[i] - one);
                    one = 0;
                }
            }
            if (one == 0) return result;
            for (int i = second.value.Count; i < result.value.Count; i++)
            {
                if (result.value[i] - 1 < 0)
                {
                    result.value[i] = 9;
                }
                else
                {
                    result.value[i]--;
                    return result;
                }
            }
            result.value.RemoveAt(result.value.Count - 1);
            return result;
        }

       /* public static N operator *(N first, N second)
        {
            return;
        } */
    }
}