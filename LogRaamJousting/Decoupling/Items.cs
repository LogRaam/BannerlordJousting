// Code written by Gabriel Mailhot, 30/04/2023.

#region

using System.Collections.Generic;
using TaleWorlds.Library;

#endregion

namespace LogRaamJousting.Decoupling
{
   public class Items
   {
      private List<ItemObject> _all = new List<ItemObject>();

      public List<ItemObject> All
      {
         get
         {
            var state = new CampaignState();

            if (state.GameStarted() || state.CampaignStarted()) return ToJoustItemList(TaleWorlds.CampaignSystem.Extensions.Items.All);

            return _all;
         }
         set => _all = value;
      }


      public List<ItemObject> SelectedItems { get; set; } = new List<ItemObject>();

      public void AddItemToSelectedList(ItemObject item)
      {
         SelectedItems.Add(item);
      }

      #region private

      private List<ItemObject> ToJoustItemList(MBReadOnlyList<TaleWorlds.Core.ItemObject> items)
      {
         var result = new List<ItemObject>();
         foreach (TaleWorlds.Core.ItemObject item in items) result.Add(new ItemObject(item));

         return result;
      }

      #endregion
   }
}