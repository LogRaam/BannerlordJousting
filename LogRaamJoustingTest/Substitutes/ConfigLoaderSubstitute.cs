// Code written by Gabriel Mailhot, 25/06/2023.

#region

using LogRaamJousting.Configuration;
using LogRaamJousting.Options;

#endregion

namespace LogRaamJoustingTest.Substitutes
{
   public class ConfigLoaderSubstitute : IConfigLoader, IOptions
   {
      public bool _shouldBeNaked;

      public bool _shouldUseTheirEquipment;

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

      public bool IsLineExistInStruct(string[] options, string lineToFind)
      {
         throw new NotImplementedException();
      }

      public string[] RetrieveConfigDetails()
      {
         return Content;
      }

      public bool ShouldBeNaked(string[] options, string lineToFind)
      {
         throw new NotImplementedException();
      }

      public bool ShouldBeNaked(string lineToFind)
      {
         return _shouldBeNaked;
      }

      public bool ShouldHappens(string[] options, string lineToFind)
      {
         throw new NotImplementedException();
      }

      public bool ShouldHappens(string lineToFind)
      {
         throw new NotImplementedException();
      }

      public bool ShouldProvideArmors(string[] options, string shouldProvideArmorsLineToFind)
      {
         throw new NotImplementedException();
      }

      public bool ShouldProvideWeapons(string[] options, string shouldProvideWeaponsLineToFind)
      {
         throw new NotImplementedException();
      }

      public bool ShouldUseHostCulture(string[] options, string lineToFind)
      {
         throw new NotImplementedException();
      }

      public bool ShouldUseHostCulture(string lineToFind)
      {
         throw new NotImplementedException();
      }

      public bool ShouldUseTheirEquipment(string[] options, string xAseraiTournamentSParticipantsMustBringTheirOwnEquipment)
      {
         return _shouldUseTheirEquipment;
      }
   }
}