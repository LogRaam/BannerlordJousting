// Code written by Gabriel Mailhot, 02/03/2023.

#region

using LogRaamJousting.Configuration;

#endregion

namespace LogRaamJoustingTest
{
   internal class ConfigLoaderSubstitute : IConfigLoader
   {
      public string[] Content = {
         "",
         "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   ",
         "Select the cultures that should apply this mod, as well as the percentage of chance to happens",
         "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  ",
         "[X] Apply to Empire   at 100%",
         "[X] Apply to Sturgia  at 100%",
         "[X] Apply to Aserai   at 100%",
         "[X] Apply to Vlandia  at 100%",
         "[X] Apply to Khuzait  at 100%",
         "[X] Apply to Battania at 100%"
      };

      public string[] RetrieveConfigDetails()
      {
         return Content;
      }
   }
}