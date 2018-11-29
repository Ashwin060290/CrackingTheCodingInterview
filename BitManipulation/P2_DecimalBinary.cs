using NUnit.Framework;

namespace BitManipulation
{
    public class P2_DecimalBinary
    {
        public string GetBinary(double num)
        {
            if (num < 0 | num > 1)
                return "ERROR";

            string answer = "0.";
            while(num >0)
            {
                if(answer.Length > 34)
                {
                    return "ERROR";
                }

                double n = num * 2;

                if (n >= 1)
                {
                    answer += "1";
                    num = n - 1;
                }
                else
                {
                    answer += "0";
                    num = n;
                }

                
            }

            return answer;
        }
    }

    [TestFixture]
    public class TestDecimalBinary
    {
        [Test]
        public void GetBinary_WithNumGreaterThan1_ShouldReturnError()
        {
            double num = 1.1;
            string expected = "ERROR";
            P2_DecimalBinary decimalBinary = new P2_DecimalBinary();

            string actual = decimalBinary.GetBinary(num);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetBinary_WithNumLessThan0_ShouldReturnError()
        {
            double num = -0.01;
            string expected = "ERROR";
            P2_DecimalBinary decimalBinary = new P2_DecimalBinary();

            string actual = decimalBinary.GetBinary(num);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetBinary_WithAnswerBinaryMoreThan32_ShouldReturnError()
        {
            double num = 0.0000000000078;
            string expected = "ERROR";
            P2_DecimalBinary decimalBinary = new P2_DecimalBinary();

            string actual = decimalBinary.GetBinary(num);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetBinary_WithcorrectNum_ShouldReturnValidAnswerBinaryString()
        {
            double num = 0.625;
            string expected = "0.101";
            P2_DecimalBinary decimalBinary = new P2_DecimalBinary();

            string actual = decimalBinary.GetBinary(num);

            Assert.AreEqual(expected, actual);
        }
    }
}
