// Code written by Gabriel Mailhot, 01/03/2023.

namespace LogRaamJousting.Options
{
   public class BaseOptions : IOptions
   {
      public bool ShouldHappens(string[] options, string lineToFind)
      {
         foreach (string option in options)
         {
            if (!option.Contains(lineToFind)) continue;

            int percentageSymbolIndex = option.IndexOf('%');

            if (percentageSymbolIndex == -1) continue;

            string percentageString = option.Substring(percentageSymbolIndex - 3, 3).Trim();

            if (!int.TryParse(percentageString, out int percentage)) continue;

            if (LogRaamRandom.EvalPercentage(percentage)) return true;
         }

         return false;
      }

      protected bool ShouldBeNaked(string[] options, string lineToFind)
      {
         foreach (string option in options)
         {
            if (!option.Contains(lineToFind)) continue;

            return true;
         }

         return false;
      }

      protected bool ShouldUseHostCulture(string[] options, string lineToFind)
      {
         foreach (string option in options)
         {
            if (!option.Contains(lineToFind)) continue;

            return true;
         }

         return false;
      }
   }
}