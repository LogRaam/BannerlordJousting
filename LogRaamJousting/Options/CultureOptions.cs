// Code written by Gabriel Mailhot, 25/06/2023.

#region

using LogRaamJousting.Configuration;

#endregion

namespace LogRaamJousting.Options
{
   public class CultureOptions : IOptions
   {
      private readonly IConfigLoader _loader;

      public CultureOptions()
      {
         _loader = new ConfigLoader();
      }

      public CultureOptions(IConfigLoader loader)
      {
         _loader = loader;
      }

      public string[] GetOptionsDetail => _loader.RetrieveConfigDetails();


      public bool ShouldBeNaked(string[] options, string lineToFind)
      {
         return ShouldUseHostCulture(options, lineToFind);
      }

      public bool ShouldBeNaked(string lineToFind)
      {
         return ShouldBeNaked(GetOptionsDetail, lineToFind);
      }

      public bool ShouldHappens(string[] options, string lineToFind)
      {
         foreach (var option in options)
         {
            if (!option.Contains(lineToFind)) continue;

            var percentageSymbolIndex = option.IndexOf('%');

            if (percentageSymbolIndex == -1) continue;

            var percentageString = option.Substring(percentageSymbolIndex - 3, 3).Trim();

            if (!int.TryParse(percentageString, out var percentage)) continue;

            if (LogRaamRandom.EvalPercentage(percentage)) return true;
         }

         return false;
      }

      public bool ShouldHappens(string lineToFind)
      {
         return ShouldHappens(GetOptionsDetail, lineToFind);
      }

      public bool ShouldProvideArmors(string[] options, string lineToFind)
      {
         return _loader.IsLineExistInStruct(options, lineToFind);
      }

      public bool ShouldProvideWeapons(string[] options, string lineToFind)
      {
         return _loader.IsLineExistInStruct(options, lineToFind);
      }

      public bool ShouldUseHostCulture(string[] options, string lineToFind)
      {
         return new OptionFinder().IsLineExistInStruct(options, lineToFind);
      }

      public bool ShouldUseHostCulture(string lineToFind)
      {
         return ShouldUseHostCulture(GetOptionsDetail, lineToFind);
      }


      public bool ShouldUseTheirEquipment(string[] options, string lineToFind)
      {
         return _loader.IsLineExistInStruct(options, lineToFind);
      }
   }
}