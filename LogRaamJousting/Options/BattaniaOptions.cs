// Code written by Gabriel Mailhot, 01/03/2023.

#region

#endregion

namespace LogRaamJousting.Options
{
   internal class BattaniaOptions : BaseOptions
   {
      private const string ShouldBeNakedLineToFind = "[X] Undressed Battania";
      private const string ShouldHappensLineToFind = "[X] Apply to Battania";
      private const string ShouldUseHostCultureLineToFind = "[X] Battania enforce its culture during tournaments";

      public bool ShouldBeNaked(string[] options)
      {
         return base.ShouldBeNaked(options, ShouldBeNakedLineToFind);
      }

      public bool ShouldHappens(string[] options)
      {
         return base.ShouldHappens(options, ShouldHappensLineToFind);
      }

      public bool ShouldUseHostCulture(string[] options)
      {
         return base.ShouldUseHostCulture(options, ShouldUseHostCultureLineToFind);
      }
   }
}