using Newtonsoft.Json.Linq;

namespace ILC.Test
{
    [TestClass]
    public class NTest
    {
        [TestMethod]
        public void BuildOuput()
        {
            for (int i = 0; i <= 1000; i++)
            {
                string s = i.ToString();
                N number = new N(s);
                Assert.AreEqual(s, number.ToString(), $"¬ходные данные s = {s}");
            }
        }

        [TestMethod]
        public void Clone()
        {
            for (int i = 0; i <= 1000; i++)
            {
                string s = i.ToString();
                N number = new N(s);
                N clone = number.Clone();
                Assert.AreEqual(number.ToString(), clone.ToString(), $"¬ходные данные i = {s}");
            }
        }

        [TestMethod]
        public void Compare()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {
                    N first = new N(i.ToString());
                    N second = new N(j.ToString());
                    byte res = N.Compare(first, second);
                    Assert.AreEqual(i > j ? 2 : i < j ? 1 : 0, res, $"¬ходные данные i = {i}, j = {j}");
                }
            }
        }

        [TestMethod]
        public void IsZero()
        {
            for (int i = 0; i <= 1000; i++)
            {
                N value = new N(i.ToString());
                bool res = value.IsZero();
                Assert.AreEqual(i == 0, res, $"¬ходные данные i = {i}");
            }
        }

        [TestMethod]
        public void Increment()
        {
            for (int i = 0; i <= 1000; i++)
            {
                N value = new N(i.ToString());
                value++;
                Assert.AreEqual((i + 1).ToString(), value.ToString(), $"¬ходные данные i = {i}");
            }
        }

        [TestMethod]
        public void Plus()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {
                    N first = new N(i.ToString());
                    N second = new N(j.ToString());
                    Assert.AreEqual((i + j).ToString(), (first + second).ToString(), $"¬ходные данные i = {i}, j = {j}");
                }
            }
        }

        [TestMethod]
        public void Minus()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {
                    N first = new N(i.ToString());
                    N second = new N(j.ToString());
                    Assert.AreEqual(System.Math.Abs(i - j).ToString(), (first - second).ToString(), $"¬ходные данные i = {i}, j = {j}");
                }
            }
        }

        [TestMethod]
        public void MulDighit()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (byte j = 0; j <= 9; j++)
                {
                    N first = new N(i.ToString());
                    Assert.AreEqual((i * j).ToString(), (first.MulDigit(j)).ToString(), $"¬ходные данные i = {i}, j = {j}");
                }
            }
        }

        [TestMethod]
        public void MulTen()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (byte j = 1; j <= 9; j++)
                {
                    N first = new N(i.ToString());
                    Assert.AreEqual((i * System.Math.Pow(10, j)).ToString(), (first.MulK(j)).ToString(), $"¬ходные данные i = {i}, j = {j}");
                }
            }
        }

        [TestMethod]
        public void Mul()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {
                    N first = new N(i.ToString());
                    N second = new N(j.ToString());
                    Assert.AreEqual((i * j).ToString(), (first * second).ToString(), $"¬ходные данные i = {i}, j = {j}");
                }
            }
        }

        [TestMethod]
        public void SubMullable()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {
                    for (byte k = 0; k <= 9; k++)
                    {
                        if (i >= j * k)
                        {
                            N first = new N(i.ToString());
                            N second = new N(j.ToString());
                            Assert.AreEqual((i - j * k).ToString(), N.SubMul(first, second, k).ToString(), $"¬ходные данные i = {i}, j = {j}, k = {k}");
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void FirstDivid()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    int k;
                    N first = new N(i.ToString());
                    N second = new N(j.ToString());
                    Assert.AreEqual(byte.Parse((i / j).ToString()[0].ToString()), N.FirstDiv(first, second, out k), $"¬ходные данные i = {i}, j = {j}");
                    Assert.IsTrue(i >= byte.Parse((i / j).ToString()[0].ToString()) * j * System.Math.Pow(10, k));
                    Assert.IsTrue(i < byte.Parse((i / j).ToString()[0].ToString()) * j * System.Math.Pow(10, k + 1));
                }
            }
        }

        [TestMethod]
        public void Div()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    N first = new N(i.ToString());
                    N second = new N(j.ToString());
                    Assert.AreEqual((i / j).ToString(), (first / second).ToString(), $"¬ходные данные i = {i}, j = {j}");
                }
            }
        }

        [TestMethod]
        public void Mod()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    N first = new N(i.ToString());
                    N second = new N(j.ToString());
                    Assert.AreEqual((i % j).ToString(), (first % second).ToString(), $"¬ходные данные i = {i}, j = {j}");
                }
            }
        }

        [TestMethod]
        public void GCF ()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = i; j <= 1000; j++)
                {
                    if (i != j || i != 0)
                    {
                        N first = new N(i.ToString());
                        N second = new N(j.ToString());
                        N gcf1 = N.GCF(first, second);
                        N gcf2 = N.GCF(second, first);
                        Assert.AreEqual(gcf1.ToString(), gcf2.ToString(), $"¬ходные данные i = {i}, j = {j}");
                        int value = int.Parse(gcf1.ToString());
                        Assert.IsTrue(value <= i, $"¬ходные данные i = {i}, j = {j}");
                        Assert.AreEqual(0, i % value, $"¬ходные данные i = {i}, j = {j}");
                        Assert.AreEqual(0, j % value, $"¬ходные данные i = {i}, j = {j}");
                        for (int k = value + 1; k <= i; k++)
                        {
                            Assert.IsTrue(i % k != 0 || j % k != 0, $"¬ходные данные i = {i}, j = {j}");
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void LCM()
        {

            for (int i = 0; i <= 1000; i++)
            {
                for (int j = i; j <= 1000; j++)
                {
                    if (i != j || i != 0)
                    {
                        N first = new N(i.ToString());
                        N second = new N(j.ToString());
                        N lcm1 = N.LCM(first, second);
                        N lcm2 = N.LCM(second, first);
                        Assert.AreEqual(lcm1.ToString(), lcm2.ToString(), $"¬ходные данные i = {i}, j = {j}");
                        int value = int.Parse(lcm1.ToString());
                        Assert.IsTrue(value >= j, $"¬ходные данные i = {i}, j = {j}");
                        Assert.AreEqual(0, value % i, $"¬ходные данные i = {i}, j = {j}");
                        Assert.AreEqual(0, value % j, $"¬ходные данные i = {i}, j = {j}");
                        for (int k = value - 1; k >= j; k--)
                        {
                            Assert.IsTrue(k % i != 0 || k % j != 0, $"¬ходные данные i = {i}, j = {j}");
                        }
                    }
                }
            }
        }
    }
}