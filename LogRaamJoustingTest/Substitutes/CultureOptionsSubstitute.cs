// Code written by Gabriel Mailhot, 25/06/2023.

#region

using LogRaamJousting.Options;

#endregion

namespace LogRaamJoustingTest.Substitutes
{
   internal class CultureOptionsSubstitute : IOptions
   {
      public bool ShouldBeNakedReturnValue { get; set; }
      public bool ShouldHappensReturnValue { get; set; }

      public bool ShouldProvideArmorsReturnValue { get; set; }
      public bool ShouldProvideWeaponsReturnValue { get; set; }
      public bool ShouldUseHostCultureReturnValue { get; set; }
      public bool ShouldUseTheirEquipmentReturnValue { get; set; }

      public bool ShouldBeNaked(string[] options, string lineToFind)
      {
         return ShouldBeNakedReturnValue;
      }

      public bool ShouldBeNaked(string lineToFind)
      {
         return ShouldBeNakedReturnValue;
      }

      public bool ShouldHappens(string[] options, string lineToFind)
      {
         return ShouldHappensReturnValue;
      }

      public bool ShouldHappens(string lineToFind)
      {
         return ShouldHappensReturnValue;
      }

      public bool ShouldProvideArmors(string[] options, string shouldProvideArmorsLineToFind)
      {
         return ShouldProvideArmorsReturnValue;
      }

      public bool ShouldProvideWeapons(string[] options, string shouldProvideWeaponsLineToFind)
      {
         return ShouldProvideWeaponsReturnValue;
      }

      public bool ShouldUseHostCulture(string[] options, string lineToFind)
      {
         return ShouldUseHostCultureReturnValue;
      }

      public bool ShouldUseHostCulture(string lineToFind)
      {
         return ShouldUseHostCultureReturnValue;
      }

      public bool ShouldUseTheirEquipment(string[] options, string xAseraiTournamentSParticipantsMustBringTheirOwnEquipment)
      {
         return ShouldUseTheirEquipmentReturnValue;
      }
   }
}