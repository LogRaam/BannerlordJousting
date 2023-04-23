// Code written by Gabriel Mailhot, 09/02/2021.

#region

using System.IO;
using TaleWorlds.CampaignSystem.TournamentGames;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting
{
   public class JoustParticipant
   {
      internal void EquipParticipant(CultureCode tournamentCulture, TournamentParticipant participant)
      {
         participant.MatchEquipment = new Armoury {
            Logger = new JoustLogger {
               LogPath = new DirectoryInfo("S:\\JoustingLog.txt")
            }
         }.RequestEquipmentFor(tournamentCulture, participant);
      }
   }
}