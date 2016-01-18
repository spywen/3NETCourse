using NUnit.Framework;
using _3NET;

namespace UnitTests
{
    public class ExtensionMethodTests
    {
        [TestCase(" test test ", 8)]
        [TestCase("test", 4)]
        public void LengthWithoutSpace(string myString, int expectedLength)
        {
            Assert.AreEqual(expectedLength, myString.LengthWithoutSpace());
        }
    }
}
