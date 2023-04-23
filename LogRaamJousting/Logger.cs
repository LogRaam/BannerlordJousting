// Code written by Gabriel Mailhot, 22/04/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

#endregion

namespace LogRaamJousting
{
   internal class Logger
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

      /*
      public static void LogDebugMessage(string msg)
      {
         if (TXPSettings.Instance.DebugMode)
         {
            LoggerExtensions.LogDebugAndDisplay(SubModule.Log, msg, Array.Empty<object>());
            return;
         }
         LoggerExtensions.LogDebug(SubModule.Log, msg, Array.Empty<object>());
      }

      
      public static void LogDebugMessage(string msg, Exception ex)
      {
         if (TXPSettings.Instance.DebugMode)
         {
            LoggerExtensions.LogDebugAndDisplay(SubModule.Log, ex, msg, Array.Empty<object>());
            return;
         }
         LoggerExtensions.LogDebug(SubModule.Log, ex, msg, Array.Empty<object>());
      }
      */
   }
}