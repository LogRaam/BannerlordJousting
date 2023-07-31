// Code written by Gabriel Mailhot, 25/06/2023.

#region

using LogRaamJousting.Configuration;
using LogRaamJousting.Options;

#endregion

namespace LogRaamJoustingTest.Substitutes
{
   internal class ConfigurationSubstitute : IConfig
   {
      internal bool _hostShouldProvideArmors;
      internal bool _shouldBeNaked;
      private bool _hostShouldProvideWeapons;
      private bool _isHostEnforcingHisCulture;
      private bool _isPlayerMayShouldGainRenownWhenWinningTournament;
      private bool _participantsUsesTheirOwnEquipments;

      public ICultureOption GetSpecificOptionsFor(string culture)
      {
         throw new NotImplementedException();
      }

      public bool HostShouldProvideArmors(string hostCulture)
      {
         return _hostShouldProvideArmors;
      }

      public bool HostShouldProvideWeapons(string hostCulture)
      {
         return _hostShouldProvideWeapons;
      }

      public bool IsHostEnforcingHisCulture(string hostCulture)
      {
         return _isHostEnforcingHisCulture;
      }

      public bool IsPlayerMayShouldGainRenownWhenWinningTournament()
      {
         return _isPlayerMayShouldGainRenownWhenWinningTournament;
      }

      public bool IsPlayerShouldGainExtraRenownWhenNaked()
      {
         throw new NotImplementedException();
      }

      public bool IsPlayerShouldLosesRenownWhenLosingTournament()
      {
         throw new NotImplementedException();
      }

      public bool ParticipantsUsesTheirOwnEquipments(string hostCulture)
      {
         return _participantsUsesTheirOwnEquipments;
      }

      public bool ShouldApplyModForThisMatch(string hostCulture)
      {
         throw new NotImplementedException();
      }

      public bool ShouldBeNaked(string hostCulture)
      {
         return _shouldBeNaked;
      }
   }
}