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
                Assert.AreEqual(s, number.ToString());
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
                Assert.AreEqual(number.ToString(), clone.ToString());
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
                    Assert.AreEqual(i > j ? 2 : i < j ? 1 : 0, res);
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
                Assert.AreEqual(i == 0, res);
            }
        }

        [TestMethod]
        public void Increment()
        {
            for (int i = 0; i <= 1000; i++)
            {
                N value = new N(i.ToString());
                value++;
                Assert.AreEqual((i + 1).ToString(), value.ToString());
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
                    Assert.AreEqual((i + j).ToString(), (first + second).ToString());
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
                    Assert.AreEqual(System.Math.Abs(i - j).ToString(), (first - second).ToString());
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
                    Assert.AreEqual((i * j).ToString(), (first.MulDigit(j)).ToString());
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
                    Assert.AreEqual((i * System.Math.Pow(10, j)).ToString(), (first).ToString());
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
                    Assert.AreEqual((i * j).ToString(), (first/* * second*/).ToString());
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
                            Assert.AreEqual((i - j * k).ToString(), (first/* * second*/).ToString());
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
                for (int j = 0; j <= i; j++)
                {
                    N first = new N(i.ToString());
                    N second = new N(j.ToString());
                    Assert.AreEqual((i / j).ToString()[0].ToString(), (first/* * second*/).ToString());
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
                    Assert.AreEqual((i / j).ToString(), (first/* * second*/).ToString());
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
                    Assert.AreEqual((i % j).ToString(), (first/* * second*/).ToString());
                }
            }
        }

        [TestMethod]
        public void GCF ()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {
                    if (i != j || i != 0)
                    {
                        N first = new N(i.ToString());
                        N second = new N(j.ToString());
                        Assert.AreEqual((i % j).ToString(), (first/* * second*/).ToString());
                    }
                }
            }
        }

        [TestMethod]
        public void LCM()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {
                    if (i != j || i != 0)
                    {
                        N first = new N(i.ToString());
                        N second = new N(j.ToString());
                        Assert.AreEqual((i % j).ToString(), (first/* * second*/).ToString());
                    }
                }
            }
        }
    }
}