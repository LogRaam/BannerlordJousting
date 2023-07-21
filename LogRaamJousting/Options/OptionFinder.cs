// Code written by Gabriel Mailhot, 25/06/2023.

namespace LogRaamJousting.Options
{
   public class OptionFinder
   {
      public bool IsLineExistInStruct(string[] options, string lineToFind)
      {
         foreach (var option in options)
         {
            if (!option.Contains(lineToFind)) continue;

            return true;
         }

         return false;
      }
   }
}