// Code written by Gabriel Mailhot, 24/04/2023.

namespace LogRaamJousting.Options
{
   public interface ICultureOption
   {
      string Culture { get; }
      bool ParticipantShouldUseItsOwnEquipment(string[] options);
      bool ShouldBeNaked(string[] options);
      bool ShouldBeNaked(string lineToFind);
      bool ShouldHappens(string[] options);
      bool ShouldProvideArmors(string[] retrieveConfigDetails);
      bool ShouldProvideWeapons(string[] retrieveConfigDetails);
      bool ShouldUseHostCulture(string[] options);
      bool ShouldUseHostCulture(string lineToFind);
   }
}