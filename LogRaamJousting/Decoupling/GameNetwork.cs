// Code written by Gabriel Mailhot, 28/04/2023.

#region

#endregion

namespace LogRaamJousting.Decoupling
{
   public class GameNetwork
   {
      private bool _isClientOrReplay;

      public bool IsClientOrReplay
      {
         get
         {
            var state = new CampaignState();

            return state.GameStarted() || state.CampaignStarted()
               ? TaleWorlds.MountAndBlade.GameNetwork.IsClientOrReplay
               : _isClientOrReplay;
         }
         set => _isClientOrReplay = value;
      }
   }
}