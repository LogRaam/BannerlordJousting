// Code written by Gabriel Mailhot, 23/01/2021.

#region

using System.Reflection;
using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

#endregion

namespace LogRaamJousting
{
   public class IntegratedLoaderSubModule : MBSubModuleBase
   {
      private readonly Harmony _harmony = new Harmony("LogRaamJousting");


      protected override void OnBeforeInitialModuleScreenSetAsRoot()
      {
         base.OnBeforeInitialModuleScreenSetAsRoot();
         InformationManager.DisplayMessage(new InformationMessage("LogRaam's Jousting is ready", Colors.Yellow));
      }


      protected override void OnSubModuleLoad()
      {
         base.OnSubModuleLoad();
         _harmony.PatchAll(Assembly.GetExecutingAssembly());
      }
   }
}