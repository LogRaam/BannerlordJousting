// Code written by Gabriel Mailhot, 01/03/2023.

namespace LogRaamJousting.Options
{
   public interface IOptions
   {
      bool ShouldHappens(string[] options, string lineToFind);
   }
}