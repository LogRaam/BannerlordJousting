// Code written by Gabriel Mailhot, 23/04/2023.

namespace LogRaamJousting.Options
{
   internal class AyyubidOptions : BaseOptions
   {
      private const string ShouldBeNakedLineToFind = "[X] Undressed Ayyubid";
      private const string ShouldHappensLineToFind = "[X] Apply to Ayyubid";
      private const string ShouldUseHostCultureLineToFind = "[X] Ayyubid enforce its culture during tournaments";

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