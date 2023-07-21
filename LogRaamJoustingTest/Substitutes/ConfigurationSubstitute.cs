using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogRaamJousting.Configuration;
using LogRaamJousting.Options;

namespace LogRaamJoustingTest.Substitutes
{
    internal class ConfigurationSubstitute : IConfig
    {
       public ICultureOption GetSpecificOptionsFor(string culture)
       {
          throw new NotImplementedException();
       }

       public bool HostShouldProvideArmors(string hostCulture)
       {
          throw new NotImplementedException();
       }

       public bool HostShouldProvideWeapons(string hostCulture)
       {
          throw new NotImplementedException();
       }

       public bool IsHostEnforcingHisCulture(string hostCulture)
       {
          throw new NotImplementedException();
       }

       public bool IsPlayerMayShouldGainRenownWhenWinningTournament()
       {
          throw new NotImplementedException();
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
          throw new NotImplementedException();
       }

       public bool ShouldApplyModForThisMatch(string hostCulture)
       {
          throw new NotImplementedException();
       }

       public bool ShouldBeNaked(string hostCulture)
       {
          throw new NotImplementedException();
       }
    }
}
