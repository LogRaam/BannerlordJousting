// Code written by Gabriel Mailhot, 22/04/2023.

#region

using System.Linq;
using LogRaamJousting.Factory;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;

#endregion

namespace LogRaamJousting
{
   public class JoustingBehavior : CampaignBehaviorBase
   {
      private readonly ISetup _get = new DefaultSetup();

      public void OnTournamentFinished(CharacterObject winner, MBReadOnlyList<CharacterObject> participants, Town town, ItemObject arg4)
      {
         if (!participants.Exists(n => n.IsPlayerCharacter)) return;
         if (!winner.IsHero) return;

         ApplyRenownConsequence(winner, participants, town);


         //if (hero.IsHumanPlayerCharacter) MBInformationManager.AddQuickInformation(new TextObject($"{hero.Name} earned +{num} renown points for winning tournament."), 0, hero.CharacterObject);
      }

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

      #region private

      private void ApplyRenownConsequence(CharacterObject winner, MBReadOnlyList<CharacterObject> participants, Town town)
      {
         var c = _get.Configuration.IsHostEnforcingHisCulture(town.Culture.GetCultureCode().ToString())
            ? town.Culture.GetCultureCode()
            : winner.Culture.GetCultureCode();


         if (!winner.IsPlayerCharacter)
            if (_get.Configuration.IsPlayerShouldLosesRenownWhenLosingTournament())
            {
               var player = participants.FirstOrDefault(n => n.IsPlayerCharacter);

               if (player == null) return;

               LosesRenown(player);
            }


         if (_get.Configuration.ShouldBeNaked(c.ToString()))
         {
            if (_get.Configuration.IsPlayerShouldGainExtraRenownWhenNaked())
               GainsExtraRenown(winner);
         }
         else MayGainRenown(winner);
      }

      private void GainsExtraRenown(CharacterObject winner)
      {
         var bonus = 1 + LogRaamRandom.GenerateRandomNumber(1, 3);
         new Renown().GiveBonusRenown(winner.HeroObject, bonus);
         InformationManager.DisplayMessage(new InformationMessage($"{winner.HeroObject.Name} gains {bonus} renown for fighting naked in the tournament.", Colors.Green));
      }

      private void LosesRenown(CharacterObject player)
      {
         var bonus = -LogRaamRandom.GenerateRandomNumber(1, 3);

         new Renown().GiveBonusRenown(player.HeroObject, bonus);
         InformationManager.DisplayMessage(new InformationMessage($"{player.Name} loses {bonus} renown for losing at the tournament.", Colors.Red));
      }

      private void MayGainRenown(CharacterObject winner)
      {
         if (!_get.Configuration.IsPlayerMayShouldGainRenownWhenWinningTournament()) return;
         var bonus = LogRaamRandom.GenerateRandomNumber(0, 1);

         if (bonus <= 0) return;
         new Renown().GiveBonusRenown(winner.HeroObject, bonus);
         InformationManager.DisplayMessage(new InformationMessage($"{winner.HeroObject.Name} gains {bonus} renown for winning at the tournament.", Colors.White));
      }

      #endregion
   }
}