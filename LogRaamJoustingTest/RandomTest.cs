// Code written by Gabriel Mailhot, 22/04/2023.

#region

using LogRaamJousting;
using NUnit.Framework;

#endregion

namespace LogRaamJoustingTest
{
   [TestFixture]
   public class RandomTest
   {
      [Test]
      public void TestingRandom()
      {
         var expectedResult = true;
         var actualResult = false;

         for (var i = 0; i < 10; i++)
            if (LogRaamRandom.GenerateRandomNumber(3) > 0)
               actualResult = true;

         Assert.AreEqual(expectedResult, actualResult);
      }
   }
}