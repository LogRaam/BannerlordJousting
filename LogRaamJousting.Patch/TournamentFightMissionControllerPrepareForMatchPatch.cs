// Code written by Gabriel Mailhot, 23/01/2021.

#region

using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.Source.TournamentGames;
using TaleWorlds.MountAndBlade;

#endregion

namespace FRACAS.Patches
{
   [HarmonyPatch(typeof(TournamentFightMissionController), "PrepareForMatch")]
   public class TournamentFightMissionControllerPrepareForMatchPatch
   {
      #region private

      private static bool Prefix(TournamentFightMissionController __instance, TournamentMatch ____match, CultureObject ____culture)
      {
         if (GameNetwork.IsClientOrReplay) return false;

         var dictionary = new Dictionary<TournamentTeam, float>();
         var mountMap = new Dictionary<TournamentTeam, int>();

         using (IEnumerator<TournamentTeam> enumerator1 = ____match.get_Teams().GetEnumerator())
         {
            while (enumerator1.MoveNext())
            {
               TournamentTeam current1 = enumerator1.Current;
               if (!Mod.ModSettings.TournamentBalance)
               {
                  using (IEnumerator<TournamentParticipant> enumerator2 = current1.get_Participants().GetEnumerator())
                  {
                     while (enumerator2.MoveNext())
                     {
                        TournamentParticipant current2 = enumerator2.Current;
                        Helpers.EquipParticipant(__instance, ____culture, current1, mountMap, current2);
                     }
                  }
               }
               else
               {
                  mountMap.Add(current1, 0);
                  using (IEnumerator<TournamentParticipant> enumerator2 = current1.get_Participants().GetEnumerator())
                  {
                     while (enumerator2.MoveNext())
                     {
                        TournamentParticipant current2 = enumerator2.Current;
                        Helpers.EquipParticipant(__instance, ____culture, current1, mountMap, current2);
                     }
                  }

                  dictionary.Add(current1, Helpers.SumTeamEquipmentValue(current1));
                  if (dictionary.Keys.Count > 1)
                     while (Math.Abs(dictionary.Values.ElementAt(0) - dictionary[current1]) > (double) Mod.ModSettings.DifferenceThreshold || mountMap.Values.ElementAt(0) != mountMap[current1])
                     {
                        Mod.Log((object) "RE-ROLLING TEAM");
                        mountMap[current1] = 0;
                        using (IEnumerator<TournamentParticipant> enumerator2 = current1.get_Participants().GetEnumerator())
                        {
                           while (enumerator2.MoveNext())
                           {
                              TournamentParticipant current2 = enumerator2.Current;
                              Helpers.EquipParticipant(__instance, ____culture, current1, mountMap, current2);
                           }
                        }

                        dictionary[current1] = Helpers.SumTeamEquipmentValue(current1);
                     }
               }
            }
         }

         return false;
      }

      #endregion
   }
}