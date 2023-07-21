// Code written by Gabriel Mailhot, 22/04/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

#endregion

namespace LogRaamJousting
{
   public class Logger
   {
      public void ShowMessage(string msg, Color? color = null)
      {
         if (color == null) color = Color.White;

         InformationManager.DisplayMessage(new InformationMessage(msg, color.Value));
      }


      public void ShowNotification(TextObject message, int priority = 0, BasicCharacterObject charObj = null, string soundEventPath = "")
      {
         MBInformationManager.AddQuickInformation(message, 0, charObj, soundEventPath);
      }
   }
}