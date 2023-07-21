// Code written by Gabriel Mailhot, 28/04/2023.

#region

using TaleWorlds.CampaignSystem;
using TaleWorlds.MountAndBlade;

#endregion

namespace LogRaamJousting
{
   public class CampaignState
   {
      public bool CampaignStarted()
      {
         return Campaign.Current != null
                && (Campaign.Current.GameStarted || Campaign.Current.CampaignGameLoadingType == Campaign.GameLoadingType.NewCampaign);
      }

      public bool GameStarted()
      {
         return MBGameManager.Current != null && MBGameManager.Current.IsLoaded;
      }
   }
}