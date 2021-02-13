// Code written by Gabriel Mailhot, 02/02/2021.

#region

using HarmonyLib;
using SandBox;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.Source.TournamentGames;
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

         Runtime.HostCulture = ____culture.GetCultureCode();
         Runtime.IsCulturalEvent = LogRaamRandom.EvalPercentage(10);

         foreach (TournamentTeam tournamentTeam in ____match.Teams)
            foreach (TournamentParticipant participant in tournamentTeam.Participants)
               Runtime.Participant.EquipParticipant(participant);

         return false;
      }

      #endregion
   }
}