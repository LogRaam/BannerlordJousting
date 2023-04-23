// Code written by Gabriel Mailhot, 23/04/2023.

#region

using HarmonyLib;
using LogRaamJousting.Configuration;
using SandBox.Tournaments.MissionLogics;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.TournamentGames;
using TaleWorlds.MountAndBlade;

#endregion

namespace LogRaamJousting
{
   [HarmonyPatch(typeof(TournamentFightMissionController), "PrepareForMatch")]
   public class PrefixPatch
   {
      #region private

      private static bool Prefix(TournamentFightMissionController __instance, TournamentMatch ____match, CultureObject ____culture)
      {
         if (GameNetwork.IsClientOrReplay) return false;
         if (!new Config(new ConfigLoader()).HaveToApplyModFor(____culture.GetCultureCode())) return false;

         Runtime.HostCulture = ____culture.GetCultureCode();
         Runtime.IsCulturalEvent = LogRaamRandom.EvalPercentage(10);

         foreach (TournamentTeam tournamentTeam in ____match.Teams)
            foreach (TournamentParticipant participant in tournamentTeam.Participants)
               Runtime.Participant.EquipParticipant(____culture.GetCultureCode(), participant);


         return false;
      }

      #endregion
   }
}