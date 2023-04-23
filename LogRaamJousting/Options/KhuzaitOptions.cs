// Code written by Gabriel Mailhot, 01/03/2023.

#region

#endregion

namespace LogRaamJousting.Options
{
   internal class KhuzaitOptions : BaseOptions
   {
      private const string ShouldBeNakedLineToFind = "[X] Undressed Khuzait";
      private const string ShouldHappensLineToFind = "[X] Apply to Khuzait";
      private const string ShouldUseHostCultureLineToFind = "[X] Khuzait enforce its culture during tournaments";

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