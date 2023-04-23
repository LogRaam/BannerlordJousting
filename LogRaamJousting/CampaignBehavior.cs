// Code written by Gabriel Mailhot, 22/04/2023.

#region

using System.Linq;
using LogRaamJousting.Configuration;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;

#endregion

namespace LogRaamJousting
{
   public class JoustingBehavior : CampaignBehaviorBase
   {
      public override void RegisterEvents()
      {
         //CampaignEvents.OnNewGameCreatedEvent.AddNonSerializedListener(this, OnAfterNewGameCreated);
         //CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnAfterNewGameCreated);
         //CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
         CampaignEvents.TournamentFinished.AddNonSerializedListener(this, OnTournamentFinished);
         //CampaignEvents.OnAfterSessionLaunchedEvent.AddNonSerializedListener(this, OnAfterSessionLaunched);
         //CampaignEvents.TournamentStarted.AddNonSerializedListener(this, OnTournamentStarted);
      }

      public override void SyncData(IDataStore dataStore) { }

      internal void OnTournamentFinished(CharacterObject winner, MBReadOnlyList<CharacterObject> participants, Town town, ItemObject arg4)
      {
         if (!participants.Exists(n => n.IsPlayerCharacter)) return;
         if (!winner.IsHero) return;

         var config = new Config(new ConfigLoader());
         CultureCode c = config.ShouldUseHostCulture(town.Culture.GetCultureCode())
            ? town.Culture.GetCultureCode()
            : winner.Culture.GetCultureCode();

         if (!winner.IsPlayerCharacter)
         {
            CharacterObject player = participants.FirstOrDefault(n => n.IsPlayerCharacter);

            if (player == null) return;

            LosesRenown(player);
         }

         if (config.ShouldBeNaked(c)) GainsExtraRenown(winner);
         else MayGainRenown(winner);


         //if (hero.IsHumanPlayerCharacter) MBInformationManager.AddQuickInformation(new TextObject($"{hero.Name} earned +{num} renown points for winning tournament."), 0, hero.CharacterObject);
      }

      #region private

      private static void GainsExtraRenown(CharacterObject winner)
      {
         int bonus = 1 + LogRaamRandom.GenerateRandomNumber(1, 3);
         new Renown().GiveBonusRenown(winner.HeroObject, bonus);
         InformationManager.DisplayMessage(new InformationMessage($"{winner.HeroObject.Name} gains {bonus} renown for fighting naked in the tournament.", Colors.Green));
      }

      private static void LosesRenown(CharacterObject player)
      {
         int bonus = -LogRaamRandom.GenerateRandomNumber(1, 3);

         new Renown().GiveBonusRenown(player.HeroObject, bonus);
         InformationManager.DisplayMessage(new InformationMessage($"{player.Name} loses {bonus} renown for losing at the tournament.", Colors.Red));
      }

      private static void MayGainRenown(CharacterObject winner)
      {
         int bonus = LogRaamRandom.GenerateRandomNumber(0, 1);

         if (bonus <= 0) return;
         new Renown().GiveBonusRenown(winner.HeroObject, bonus);
         InformationManager.DisplayMessage(new InformationMessage($"{winner.HeroObject.Name} gains {bonus} renown for winning at the tournament.", Colors.White));
      }

      #endregion
   }
}