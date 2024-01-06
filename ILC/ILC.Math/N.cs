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
            RemoveZeroes();
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
            byte add = 0;
            for (int i = 0; i < result.value.Count; i++)
            {
                if (result.value[i] * digit + add >= 10)
                {
                    byte bufer = (byte)(result.value[i] * digit + add);
                    result.value[i] = (byte)(bufer % 10);
                    add = (byte)(bufer / 10);
                }
                else
                {
                    result.value[i] = (byte)(result.value[i] * digit + add);
                }
            }
            if (add == 0)
            {
                result.RemoveZeroes();
                return result; 
            }
            result.value.Add(add);
            result.RemoveZeroes();
            return result;
        }

        public N MulK(uint k)
        {
            N result = Clone();
            for (uint i = 0; i < k; i++)
            {
                result.value.Insert(0, 0);
            }
            result.RemoveZeroes();
            return result;
        }

        public static N GCF(N first, N second)
        {
            throw new NotImplementedException();
        }

        public static N LCM(N first, N second)
        {
            throw new NotImplementedException();
        }

        public static N SubMul(N first, N second, byte digit)
        {
            throw new NotImplementedException();
        }

        public static byte FirstDiv(N first, N second)
        {
            throw new NotImplementedException();
        }

        private void RemoveZeroes()
        {
            while (value[^1] == 0 && value.Count > 1)
                value.RemoveAt(value.Count - 1);
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
                    result.value[i] = (byte)(result.value[i] + second.value[i] + one - 10);
                    one = 1;
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
                    result.value[i] = (byte)(result.value[i] - second.value[i] - one + 10);
                    one = 1;
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
                    result.RemoveZeroes();
                    return result;
                }
            }
            result.value.RemoveAt(result.value.Count - 1);
            result.RemoveZeroes();
            return result;
        }

         public static N operator *(N first, N second)
         {
            throw new NotImplementedException();
         }

        public static N operator /(N first, N second)
        {
            throw new NotImplementedException();
        }

        public static N operator %(N first, N second)
        {
            throw new NotImplementedException();
        }
    }
}