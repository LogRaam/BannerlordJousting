// Code written by Gabriel Mailhot, 25/06/2023.

#region

using LogRaamJousting.Options;

#endregion

namespace LogRaamJousting.Configuration
{
   public interface IConfig
   {
      public ICultureOption GetSpecificOptionsFor(string culture);
      public bool HostShouldProvideArmors(string hostCulture);
      public bool HostShouldProvideWeapons(string hostCulture);
      public bool IsHostEnforcingHisCulture(string hostCulture);
      public bool IsPlayerMayShouldGainRenownWhenWinningTournament();
      public bool IsPlayerShouldGainExtraRenownWhenNaked();
      public bool IsPlayerShouldLosesRenownWhenLosingTournament();
      public bool ParticipantsUsesTheirOwnEquipments(string hostCulture);
      public bool ShouldApplyModForThisMatch(string hostCulture);
      public bool ShouldBeNaked(string hostCulture);
   }
}