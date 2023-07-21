// Code written by Gabriel Mailhot, 23/04/2023.

#region

using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using LogRaamJousting.Decoupling;
using LogRaamJousting.Factory;
using SandBox.Tournaments.MissionLogics;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.TournamentGames;

#endregion

namespace LogRaamJousting
{
   [HarmonyPatch(typeof(TournamentFightMissionController), "PrepareForMatch")]
   public class PrefixPatch
   {
      #region private

      private static bool Prefix(TournamentFightMissionController __instance, TournamentMatch ____match, CultureObject ____culture)
      {
         //if (new Config(new ConfigLoader()).ParticipantsUsesTheirOwnEquipments(culture.GetCultureCode().ToString())) return false;

         var matchParticipants = new List<Participant>();

         for (var t = 0; t < ____match.Teams.Count(); t++)
         {
            for (var i = 0; i < ____match.Teams.ToList()[t].Participants.Count(); i++)
            {
               var participant = ____match.Teams.ToList()[t].Participants.ToList()[i];
               matchParticipants.Add(new Participant(ref participant));
            }
         }

         new JoustMatch(new GameNetwork(),
            ____culture.GetCultureCode().ToString(),
            LogRaamRandom.EvalPercentage(10),
            ref matchParticipants,
            new DefaultSetup(),
            new DefaultKits()).Start();

         return false;
      }

      #endregion
   }
}