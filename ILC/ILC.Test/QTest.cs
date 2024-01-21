using ILC.Math;

namespace ILC.Test
{
    [TestClass]
    public class QTest
    {
        [TestMethod]
        public void BuildOuput()
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    Q number = new Q(i.ToString() + '/' + j.ToString());
                    int gcf = int.Parse(Z.GCF(new Z(i.ToString()), new Z(j.ToString())).ToString());
                    Assert.AreEqual((i / gcf).ToString() + '/' + (j / gcf), number.ToString(), $"¬ходные данные i = {i}/{j}");
                }
            }
        }

        [TestMethod]
        public void Clone()
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    string s = i.ToString() + '/' + j.ToString();
                    Q number = new Q(s);
                    Q clone = number.Clone();
                    Assert.AreEqual(number.ToString(), clone.ToString(), $"¬ходные данные i = {s}");
                }
            }
        }

        [TestMethod]
        public void Compare()
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    for (int k = -100; k <= 100; k++)
                    {
                        for (int z = 1; z <= 100; z++)
                        {
                            Q first = new Q(i.ToString() + '/' + j.ToString());
                            Q second = new Q(k.ToString() + '/' + z.ToString());
                            byte res = Q.Compare(first, second);
                            Assert.AreEqual((double)(i) / j > (double)(k)/z ? 2 : (double)(i) / j < (double)(k) / z ? 1 : 0, res, $"¬ходные данные i = {i}/{j}, j = {k}/{z}");
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void IsZero()
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    Q value = new Q(i.ToString());
                    bool res = value.IsZero();
                    Assert.AreEqual(i == 0, res, $"¬ходные данные i = {i}");
                }
            }
        }

        [TestMethod]
        public void Plus()
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    for (int k = -100; k <= 100; k++)
                    {
                        for (int z = 1; z <= 100; z++)
                        {
                            Q first = new Q(i.ToString() + '/' + j.ToString());
                            Q second = new Q(k.ToString() + '/' + z.ToString());
                            i *= z;
                            k *= j;
                            int res = i + k;
                            int gcf = int.Parse(Z.GCF(new Z(res.ToString()), new Z((j * z).ToString())).ToString());
                            Assert.AreEqual(res / gcf + "/" + (j * z / gcf), (first + second).ToString(), $"¬ходные данные i = {i}/{j}, j = {k}/{z}");
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void Minus()
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    for (int k = -100; k <= 100; k++)
                    {
                        for (int z = 1; z <= 100; z++)
                        {
                            Q first = new Q(i.ToString() + '/' + j.ToString());
                            Q second = new Q(k.ToString() + '/' + z.ToString());
                            i *= z;
                            k *= j;
                            int res = i - k;
                            int gcf = int.Parse(Z.GCF(new Z(res.ToString()), new Z((j * z).ToString())).ToString());
                            Assert.AreEqual(res / gcf + "/" + (j * z / gcf), (first - second).ToString(), $"¬ходные данные i = {i}/{j}, j = {k}/{z}");
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void Mul()
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    for (int k = -100; k <= 100; k++)
                    {
                        for (int z = 1; z <= 100; z++)
                        {
                            Q first = new Q(i.ToString() + '/' + j.ToString());
                            Q second = new Q(k.ToString() + '/' + z.ToString());
                            int res = i * k;
                            int gcf = int.Parse(Z.GCF(new Z(res.ToString()), new Z((j * z).ToString())).ToString());
                            Assert.AreEqual(res / gcf + "/" + (j * z / gcf), (first * second).ToString(), $"¬ходные данные i = {i}/{j}, j = {k}/{z}");
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void Div()
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    for (int k = -100; k <= 100; k++)
                    {
                        for (int z = 1; z <= 100; z++)
                        {
                            Q first = new Q(i.ToString() + '/' + j.ToString());
                            Q second = new Q(k.ToString() + '/' + z.ToString());
                            int res = i * z;
                            int gcf = int.Parse(Z.GCF(new Z(res.ToString()), new Z((j * k).ToString())).ToString());
                            Assert.AreEqual(res / gcf + "/" + (j * k / gcf), (first / second).ToString(), $"¬ходные данные i = {i}/{j}, j = {k}/{z}");

                        }
                    }
                }
            }
        }

        [TestMethod]
        public void ZToQ()
        {
            for (int i = -100; i <= 100; i++)
            {
                Q first = new Z(i.ToString());
                Assert.AreEqual(i.ToString() + "/1", first.ToString(), $"¬ходные данные i = {i}");
            }
        }

        [TestMethod]
        public void QToZ()
        {
            for (int i = -100; i <= 100; i++)
            {
                Z first = (Z)new Q(i.ToString() + "/1");
                Assert.AreEqual(i.ToString(), first.ToString(), $"¬ходные данные i = {i}");
            }
        }

        [TestMethod]
        public void ABS()
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    Q first = new Q(i.ToString() + '/' + j.ToString());
                    int gcf = int.Parse(Z.GCF(new Z(i.ToString()), new Z(j.ToString())).ToString());
                    Assert.AreEqual(System.Math.Abs(i / gcf) + '/' + (j / gcf), first.Abs().ToString(), $"¬ходные данные i = {i}");
                }
            }
        }

        [TestMethod]
        public void IsPositive()
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    Q first = new Q(i.ToString() + '/' + j.ToString());
                    Assert.AreEqual(i == 0 ? 0 : i > 0 ? 2 : 1, first.IsPositive(), $"¬ходные данные i = {i}");
                }
            }
        }

        [TestMethod]
        public void ChangeSign()
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    Q first = new Q(i.ToString() + '/' + j.ToString());
                    int gcf = int.Parse(Z.GCF(new Z(i.ToString()), new Z(j.ToString())).ToString());
                    Assert.AreEqual((-i / gcf).ToString() + '/' + (j / gcf).ToString(), first.ChangeSign().ToString(), $"¬ходные данные i = {i}");
                }
            }
        }

        [TestMethod]
        public void IsZ()
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    Q first = new Q(i.ToString() + '/' + j.ToString());
                    Assert.AreEqual(j == 1, first.IsZ(), $"¬ходные данные i = {i}");
                }
            }
        }

        [TestMethod]
        public void Red()
        {
            for (int i = -100; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    Q first = new Q(i + "/" + j);
                    first.Red();
                    int gcf = int.Parse(Z.GCF(new Z(i.ToString()), new Z(j.ToString())).ToString());
                    Assert.AreEqual((i / gcf) + "/" + (j / gcf), first.ToString(), $"¬ходные данные i = {i}, ");
                }
            }
        }

    }
}