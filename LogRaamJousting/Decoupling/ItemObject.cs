// Code written by Gabriel Mailhot, 30/04/2023.

#region

using TaleWorlds.Core;
using TaleWorlds.ObjectSystem;

#endregion

namespace LogRaamJousting.Decoupling
{
   public class ItemObject : MBObjectBase
   {
      private readonly TaleWorlds.Core.ItemObject _itemObject;
      private BasicCultureObject _culture;
      private TaleWorlds.Core.ItemObject.ItemTypeEnum _itemType;
      private string _stringId;
      private TaleWorlds.Core.ItemObject.ItemTiers _tier;

      public ItemObject(TaleWorlds.Core.ItemObject itemObject)
      {
         _itemObject = itemObject;
         if (_itemObject.Culture != null) _culture = _itemObject.Culture;
         _tier = _itemObject.Tier;
         _stringId = itemObject.StringId;
         _itemType = _itemObject.ItemType;
      }

      public ItemObject(MBObjectBase itemObject)
      {
         _itemObject = (TaleWorlds.Core.ItemObject) itemObject;
      }

      public BasicCultureObject Culture
      {
         get
         {
            var state = new CampaignState();

            if (state.GameStarted() || state.CampaignStarted()) return _itemObject.Culture;

            return _culture;
         }
         set => _culture = value;
      }

      public TaleWorlds.Core.ItemObject.ItemTypeEnum ItemType
      {
         get
         {
            var state = new CampaignState();

            if (state.GameStarted() || state.CampaignStarted()) return _itemObject.ItemType;

            return _itemType;
         }
         set => _itemType = value;
      }

      public string StringId
      {
         get
         {
            var state = new CampaignState();

            if (state.GameStarted() || state.CampaignStarted()) return _itemObject.StringId;

            return _stringId;
         }
         set => _stringId = value;
      }

      public TaleWorlds.Core.ItemObject.ItemTiers Tier
      {
         get
         {
            var state = new CampaignState();

            if (state.GameStarted() || state.CampaignStarted()) return _itemObject.Tier;

            return _tier;
         }
         set => _tier = value;
      }

      public TaleWorlds.Core.ItemObject ToEquipmentElement()
      {
         return _itemObject;
      }
   }
}