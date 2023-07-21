// Code written by Gabriel Mailhot, 23/04/2023.

#region

using LogRaamJousting.Options;

#endregion

namespace LogRaamJousting.Configuration
{
   public class Config : IConfig
   {
      private readonly IConfigLoader _loader;
      private readonly IOptions _options;

      public Config(IOptions cultureOptions, IConfigLoader loader)
      {
         _options = cultureOptions;
         _loader = loader;
      }

      public Config()
      {
         _options = new CultureOptions();
         _loader = new ConfigLoader();
      }

      public ICultureOption GetSpecificOptionsFor(string culture)
      {
         return culture.ToUpper() switch {
            "EMPIRE" => new EmpireOptions(_options),
            "STURGIA" => new SturgiaOptions(_options),
            "ASERAI" => new AseraiOptions(_options),
            "VLANDIA" => new VlandiaOptions(_options),
            "KHUZAIT" => new KhuzaitOptions(_options),
            "BATTANIA" => new BattaniaOptions(_options),
            "BYZANTINE" => new ByzantineOptions(_options),
            "AYYUBID" => new AyyubidOptions(_options),
            var _ => new EmpireOptions(_options)
         };
      }

      public bool HostShouldProvideArmors(string hostCulture)
      {
         return GetSpecificOptionsFor(hostCulture).ShouldProvideArmors(_loader.RetrieveConfigDetails());
      }

      public bool HostShouldProvideWeapons(string hostCulture)
      {
         return GetSpecificOptionsFor(hostCulture).ShouldProvideWeapons(_loader.RetrieveConfigDetails());
      }


      public bool IsHostEnforcingHisCulture(string hostCulture)
      {
         return ShouldApplyModForThisMatch(hostCulture) && GetSpecificOptionsFor(hostCulture).ShouldUseHostCulture(_loader.RetrieveConfigDetails());
      }

      public bool IsPlayerMayShouldGainRenownWhenWinningTournament()
      {
         return new ConsequenceOptions(_options, _loader).PlayerShouldGainRenownPoints(_loader.RetrieveConfigDetails());
      }

      public bool IsPlayerShouldGainExtraRenownWhenNaked()
      {
         return new ConsequenceOptions(_options, _loader).PlayerShouldGainExtraRenownPointsWhenNude(_loader.RetrieveConfigDetails());
      }

      public bool IsPlayerShouldLosesRenownWhenLosingTournament()
      {
         return new ConsequenceOptions(_options, _loader).PlayerShouldLosesRenownPoints(_loader.RetrieveConfigDetails());
      }

      public bool ParticipantsUsesTheirOwnEquipments(string hostCulture)
      {
         return GetSpecificOptionsFor(hostCulture).ParticipantShouldUseItsOwnEquipment(_loader.RetrieveConfigDetails());
      }

      public bool ShouldApplyModForThisMatch(string hostCulture)
      {
         return GetSpecificOptionsFor(hostCulture).ShouldHappens(_loader.RetrieveConfigDetails());
      }

      public bool ShouldBeNaked(string hostCulture)
      {
         return ShouldApplyModForThisMatch(hostCulture) && GetSpecificOptionsFor(hostCulture).ShouldBeNaked(_loader.RetrieveConfigDetails());
      }
   }
}