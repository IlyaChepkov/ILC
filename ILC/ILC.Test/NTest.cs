namespace ILC.Test
{
    [TestClass]
    public class NTest
    {
        [TestMethod]
        public void BuildOuput()
        {
            for (int i = 0; i < 1000; i++)
            {
                string s = i.ToString();
                N number = new N(s);
                Assert.AreEqual(s, number.ToString());
            }
        }

        [TestMethod]
        public void Clone()
        {
            for (int i = 0; i < 1000; i++)
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
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
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
            for (int i = 0; i < 1000; i++)
            {
                N value = new N(i.ToString());
                bool res = value.IsZero();
                Assert.AreEqual(i == 0, res);
            }
        }

        [TestMethod]
        public void Increment()
        {
            for (int i = 0; i < 1000; i++)
            {
                N value = new N(i.ToString());
                value++;
                Assert.AreEqual((i + 1).ToString(), value);
            }
        }
    }
}