// Code written by Gabriel Mailhot, 01/03/2023.

#region

#endregion

namespace LogRaamJousting.Options
{
   internal class EmpireOptions : BaseOptions
   {
      private const string ShouldBeNakedLineToFind = "[X] Undressed Empire";
      private const string ShouldHappensLineToFind = "[X] Apply to Empire";
      private const string ShouldUseHostCultureLineToFind = "[X] Empire enforce its culture during tournaments";

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