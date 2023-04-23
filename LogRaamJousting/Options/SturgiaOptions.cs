// Code written by Gabriel Mailhot, 01/03/2023.

#region

#endregion

namespace LogRaamJousting.Options
{
   internal class SturgiaOptions : BaseOptions
   {
      private const string ShouldBeNakedLineToFind = "[X] Undressed Sturgia";
      private const string ShouldHappensLineToFind = "[X] Apply to Sturgia";
      private const string ShouldUseHostCultureLineToFind = "[X] Sturgia enforce its culture during tournaments";

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