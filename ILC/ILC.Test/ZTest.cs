namespace ILC.Test
{
    [TestClass]
    public class ZTest
    {
        [TestMethod]
        public void BuildOuput()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                string s = i.ToString();
                Z number = new Z(s);
                Assert.AreEqual(s, number.ToString(), $"������� ������ s = {s}");
            }
        }

        [TestMethod]
        public void Clone()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                string s = i.ToString();
                Z number = new Z(s);
                Z clone = number.Clone();
                Assert.AreEqual(number.ToString(), clone.ToString(), $"������� ������ i = {s}");
            }
        }

        [TestMethod]
        public void Compare()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = -1000; j <= 1000; j++)
                {
                    Z first = new Z(i.ToString());
                    Z second = new Z(j.ToString());
                    byte res = Z.Compare(first, second);
                    Assert.AreEqual(i > j ? 2 : i < j ? 1 : 0, res, $"������� ������ i = {i}, j = {j}");
                }
            }
        }

        [TestMethod]
        public void IsZero()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                Z value = new Z(i.ToString());
                bool res = value.IsZero();
                Assert.AreEqual(i == 0, res, $"������� ������ i = {i}");
            }
        }

        [TestMethod]
        public void Plus()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = -1000; j <= 1000; j++)
                {
                    Z first = new Z(i.ToString());
                    Z second = new Z(j.ToString());
                    Assert.AreEqual((i + j).ToString(), (first + second).ToString(), $"������� ������ i = {i}, j = {j}");
                }
            }
        }

        [TestMethod]
        public void Minus()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = -1000; j <= 1000; j++)
                {
                    Z first = new Z(i.ToString());
                    Z second = new Z(j.ToString());
                    Assert.AreEqual(System.Math.Abs(i - j).ToString(), (first - second).ToString(), $"������� ������ i = {i}, j = {j}");
                }
            }
        }

        [TestMethod]
        public void Mul()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = -1000; j <= 1000; j++)
                {
                    Z first = new Z(i.ToString());
                    Z second = new Z(j.ToString());
                    Assert.AreEqual((i * j).ToString(), (first * second).ToString(), $"������� ������ i = {i}, j = {j}");
                }
            }
        }

        [TestMethod]
        public void Div()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = -1000; j <= 1000; j++)
                {
                    if (j != 0)
                    {
                        N first = new N(i.ToString());
                        N second = new N(j.ToString());
                        Assert.AreEqual((i / j).ToString(), (first / second).ToString(), $"������� ������ i = {i}, j = {j}");
                    }
                }
            }
        }

        [TestMethod]
        public void Mod()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = -1000; j <= 1000; j++)
                {
                    if (j != 0)
                    {
                        N first = new N(i.ToString());
                        N second = new N(j.ToString());
                        Assert.AreEqual((i % j).ToString(), (first % second).ToString(), $"������� ������ i = {i}, j = {j}");
                    }
                }
            }
        }

        [TestMethod]
        public void NToZ()
        {
            for (int i = 0; i <= 1000; i++)
            {
                Z first = new N(i.ToString());
                Assert.AreEqual(i.ToString(), first.ToString(), $"������� ������ i = {i}");
            }
        }

        [TestMethod]
        public void ZToN()
        {
            for (int i = 0; i <= 1000; i++)
            {
                N first = (N)new Z(i.ToString());
                Assert.AreEqual(i.ToString(), first.ToString(), $"������� ������ i = {i}");
            }
        }

        [TestMethod]
        public void ABS()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                Z first = new Z(i.ToString());
                Assert.AreEqual(System.Math.Abs(i).ToString(), first.Abs().ToString(), $"������� ������ i = {i}");
            }
        }

        [TestMethod]
        public void IsPositive()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                Z first = new Z(i.ToString());
                Assert.AreEqual(i == 0 ? 0 : i > 0 ? 2 : 1, first.IsPositive().ToString(), $"������� ������ i = {i}");
            }
        }

        [TestMethod]
        public void ChangeSign()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                Z first = new Z(i.ToString());
                Assert.AreEqual((-i).ToString(), first.ChangeSign().ToString(), $"������� ������ i = {i}");
            }
        }

        [TestMethod]
        public void GCF()
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = i; j <= 100; j++)
                {
                    if (i != j || i != 0)
                    {
                        N first = new N(i.ToString());
                        N second = new N(j.ToString());
                        N gcf1 = N.GCF(first, second);
                        N gcf2 = N.GCF(second, first);
                        Assert.AreEqual(gcf1.ToString(), gcf2.ToString(), $"������� ������ i = {i}, j = {j}");
                        int value = int.Parse(gcf1.ToString());
                        Assert.AreEqual(0, i % value, $"������� ������ i = {i}, j = {j}");
                        Assert.AreEqual(0, j % value, $"������� ������ i = {i}, j = {j}");
                        for (int k = value + 1; k <= i; k++)
                        {
                            Assert.IsTrue(i % k != 0 || j % k != 0, $"������� ������ i = {i}, j = {j}");
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void LCM()
        {

            for (int i = -100; i <= 100; i++)
            {
                for (int j = i; j <= 100; j++)
                {
                    N first = new N(i.ToString());
                    N second = new N(j.ToString());
                    N lcm1 = N.LCM(first, second);
                    N lcm2 = N.LCM(second, first);
                    Assert.AreEqual(lcm1.ToString(), lcm2.ToString(), $"������� ������ i = {i}, j = {j}");
                    int value = int.Parse(lcm1.ToString());
                    Assert.IsTrue(value >= j, $"������� ������ i = {i}, j = {j}");
                    Assert.AreEqual(0, value % i, $"������� ������ i = {i}, j = {j}");
                    Assert.AreEqual(0, value % j, $"������� ������ i = {i}, j = {j}");
                    for (int k = value - 1; k >= j; k--)
                    {
                        Assert.IsTrue(k % i != 0 || k % j != 0, $"������� ������ i = {i}, j = {j}");
                    }
                }
            }
        }
    }
}