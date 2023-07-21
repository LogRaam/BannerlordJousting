// Code written by Gabriel Mailhot, 10/03/2023.

#region

using System;
using System.IO;
using TaleWorlds.CampaignSystem.TournamentGames;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting
{
   public class JoustLogger
   {
      public DirectoryInfo LogPath;


      public JoustLogger(DirectoryInfo logPath)
      {
         LogPath = logPath;
      }

      public void LogEquipmentToFile(ItemObject a, ItemObject b, ItemObject c)
      {
         File.AppendAllText(LogPath.FullName, "--- EQUIPMENT ---" + Environment.NewLine);
         File.AppendAllText(LogPath.FullName, a.Name + Environment.NewLine);
         File.AppendAllText(LogPath.FullName, b.Name + Environment.NewLine);
         File.AppendAllText(LogPath.FullName, c.Name + Environment.NewLine);
         File.AppendAllText(LogPath.FullName, "-----------------" + Environment.NewLine);
      }

      public void LogHeaderInfoToFile(CultureCode tournamentCulture, TournamentParticipant participant)
      {
         File.AppendAllText(LogPath.FullName, "+++" + Environment.NewLine);
         File.AppendAllText(LogPath.FullName, "Host culture = " + tournamentCulture + Environment.NewLine);
         File.AppendAllText(LogPath.FullName, "Participant culture = " + participant.Character.Culture.GetCultureCode() + Environment.NewLine);
      }

      public void LogToFile(string message)
      {
         File.AppendAllText(LogPath.FullName, message + Environment.NewLine);
      }
   }
}