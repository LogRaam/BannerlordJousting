// Code written by Gabriel Mailhot, 01/03/2023.

namespace LogRaamJousting.Options
{
   public interface IOptions
   {
      bool ShouldBeNaked(string[] options, string lineToFind);
      bool ShouldBeNaked(string lineToFind);
      bool ShouldHappens(string[] options, string lineToFind);
      bool ShouldHappens(string lineToFind);
      bool ShouldProvideArmors(string[] options, string shouldProvideArmorsLineToFind);
      bool ShouldProvideWeapons(string[] options, string shouldProvideWeaponsLineToFind);
      bool ShouldUseHostCulture(string[] options, string lineToFind);
      bool ShouldUseHostCulture(string lineToFind);
      bool ShouldUseTheirEquipment(string[] options, string xAseraiTournamentSParticipantsMustBringTheirOwnEquipment);
   }
}