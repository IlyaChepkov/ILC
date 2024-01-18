namespace ILC.Test
{
    [TestClass]
    public class QTest
    {
        [TestMethod]
        public void BuildOuput()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    string s = i.ToString() + '/' + j.ToString();
                    Q number = new Q(s);
                    Assert.AreEqual(s, number.ToString(), $"������� ������ s = {s}");
                }
            }
        }

        [TestMethod]
        public void Clone()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    string s = i.ToString() + '/' + j.ToString();
                    Q number = new Q(s);
                    Q clone = number.Clone();
                    Assert.AreEqual(number.ToString(), clone.ToString(), $"������� ������ i = {s}");
                }
            }
        }

        [TestMethod]
        public void Compare()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    for (int k = -1000; k <= 1000; k++)
                    {
                        for (int z = 1; z <= 1000; z++)
                        {
                            Q first = new Q(i.ToString() + '/' + j.ToString());
                            Q second = new Q(k.ToString() + '/' + z.ToString());
                            byte res = Q.Compare(first, second);
                            Assert.AreEqual(i > j ? 2 : i < j ? 1 : 0, res, $"������� ������ i = {i}/{j}, j = {k}/{z}");
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void IsZero()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    Q value = new Q(i.ToString());
                    bool res = value.IsZero();
                    Assert.AreEqual(i == 0, res, $"������� ������ i = {i}");
                }
            }
        }

        [TestMethod]
        public void Plus()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    for (int k = -1000; k <= 1000; k++)
                    {
                        for (int z = 1; z <= 1000; z++)
                        {
                            Q first = new Q(i.ToString() + '/' + j.ToString());
                            Q second = new Q(k.ToString() + '/' + z.ToString());
                            i *= z;
                            k *= j;
                            int res = i + k;
                            int gcf = int.Parse(Z.GCF(new Z(res.ToString()), new Z((j * z).ToString())).ToString());
                            Assert.AreEqual(res / gcf + "/" + (j * z / gcf), (first + second).ToString(), $"������� ������ i = {i}/{j}, j = {k}/{z}");
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void Minus()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    for (int k = -1000; k <= 1000; k++)
                    {
                        for (int z = 1; z <= 1000; z++)
                        {
                            Q first = new Q(i.ToString() + '/' + j.ToString());
                            Q second = new Q(k.ToString() + '/' + z.ToString());
                            i *= z;
                            k *= j;
                            int res = i - k;
                            int gcf = int.Parse(Z.GCF(new Z(res.ToString()), new Z((j * z).ToString())).ToString());
                            Assert.AreEqual(res / gcf + "/" + (j * z / gcf), (first - second).ToString(), $"������� ������ i = {i}/{j}, j = {k}/{z}");
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void Mul()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    for (int k = -1000; k <= 1000; k++)
                    {
                        for (int z = 1; z <= 1000; z++)
                        {
                            Q first = new Q(i.ToString() + '/' + j.ToString());
                            Q second = new Q(k.ToString() + '/' + z.ToString());
                            int res = i * k;
                            int gcf = int.Parse(Z.GCF(new Z(res.ToString()), new Z((j * z).ToString())).ToString());
                            Assert.AreEqual(res / gcf + "/" + (j * z / gcf), (first * second).ToString(), $"������� ������ i = {i}/{j}, j = {k}/{z}");
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void Div()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    for (int k = -1000; k <= 1000; k++)
                    {
                        for (int z = 1; z <= 1000; z++)
                        {
                            Q first = new Q(i.ToString() + '/' + j.ToString());
                            Q second = new Q(k.ToString() + '/' + z.ToString());
                            int res = i * z;
                            int gcf = int.Parse(Z.GCF(new Z(res.ToString()), new Z((j * k).ToString())).ToString());
                            Assert.AreEqual(res / gcf + "/" + (j * k / gcf), (first / second).ToString(), $"������� ������ i = {i}/{j}, j = {k}/{z}");

                        }
                    }
                }
            }
        }

        [TestMethod]
        public void ZToQ()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                Q first = new Z(i.ToString());
                Assert.AreEqual(i.ToString() + "/1", first.ToString(), $"������� ������ i = {i}");
            }
        }

        [TestMethod]
        public void QToZ()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                Z first = (Z)new Q(i.ToString() + "/1");
                Assert.AreEqual(i.ToString(), first.ToString(), $"������� ������ i = {i}");
            }
        }

        [TestMethod]
        public void ABS()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    Q first = new Q(i.ToString() + '/' + j.ToString());
                    Assert.AreEqual(System.Math.Abs(i) + '/' + j, first.Abs().ToString(), $"������� ������ i = {i}");
                }
            }
        }

        [TestMethod]
        public void IsPositive()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    Q first = new Q(i.ToString() + '/' + j.ToString());
                    Assert.AreEqual(i == 0 ? 0 : i > 0 ? 2 : 1, first.IsPositive(), $"������� ������ i = {i}");
                }
            }
        }

        [TestMethod]
        public void ChangeSign()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    Q first = new Q(i.ToString() + '/' + j.ToString());
                    Assert.AreEqual((-i).ToString() + '/' + j.ToString(), first.ChangeSign().ToString(), $"������� ������ i = {i}");
                }
            }
        }

        [TestMethod]
        public void IsZ()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    Q first = new Q(i.ToString() + '/' + j.ToString());
                    Assert.AreEqual(j == 1, first.IsZ(), $"������� ������ i = {i}");
                }
            }
        }

        [TestMethod]
        public void Red()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                for (int j = 1; j <= 1000; j++)
                {
                    Q first = new Q(i.ToString() + '/' + j.ToString());
                    first.Red();
                    int gcf = int.Parse(Z.GCF(new Z(i.ToString()), new Z(j.ToString())).ToString());
                    Assert.AreEqual((i / gcf) + '/' + (j / gcf), first.ToString(), $"������� ������ i = {i}");
                }
            }
        }

    }
}