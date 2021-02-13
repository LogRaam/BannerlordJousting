// Code written by Gabriel Mailhot, 24/01/2021.

#region

using System;

#endregion

namespace LogRaamJousting
{
   public static class LogRaamRandom
   {
      private static readonly object SyncObj = new object();
      private static Random _random;


      public static bool EvalPercentage(float value)
      {
         int r = GenerateRandomNumber(100);

         return r < value;
      }

      public static bool EvalPercentageRange(int min, int max)
      {
         return EvalPercentage(GenerateRandomNumber(min, max));
      }

      public static int GenerateRandomNumber(int max)
      {
         InitRandomNumber(Guid.NewGuid().GetHashCode());

         int n = max;
         if (n < 0) n = -n;

         lock (SyncObj)
         {
            _random ??= new Random();

            return max < 0
               ? -_random.Next(n)
               : _random.Next(n);
         }
      }

      public static decimal GenerateRandomNumber(decimal max)
      {
         InitRandomNumber(Guid.NewGuid().GetHashCode());

         int count = BitConverter.GetBytes(decimal.GetBits(max)[3])[2];

         if (count == 0) return GenerateRandomNumber((int) max);

         var n = (int) (max * count);
         if (n < 0) n = -n;

         lock (SyncObj)
         {
            _random ??= new Random();

            decimal result = max < 0
               ? -_random.Next(n)
               : _random.Next(n);

            return result / count;
         }
      }

      public static int GenerateRandomNumber(int min, int max)
      {
         int m = min;
         int n = max;

         if (m < 0 && n >= 0) throw new ApplicationException("Error trying to generate random number; min and max must be either negatives or positives.  This mod doesn't support randomize between negative min and positive max.");

         if (m < 0) m = -m;
         if (n < 0) n = -n;

         if (m > n)
         {
            int t = n;
            n = m;
            m = t;
         }

         lock (SyncObj)
         {
            _random ??= new Random();

            return max < 0
               ? -_random.Next(m, n)
               : _random.Next(m, n);
         }
      }

      #region private

      private static void InitRandomNumber(int seed)
      {
         lock (SyncObj)
         {
            _random = new Random(seed);
         }
      }

      #endregion
   }
}