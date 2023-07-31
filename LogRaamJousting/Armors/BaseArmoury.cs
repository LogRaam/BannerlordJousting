// Code written by Gabriel Mailhot, 23/04/2023.

#region

using System.Collections.Generic;
using LogRaamJousting.Decoupling;
using LogRaamJousting.Equipments;
using TaleWorlds.Core;
using ItemObject = TaleWorlds.Core.ItemObject;

#endregion

namespace LogRaamJousting.Armors
{
   public class BaseArmoury : IBaseArmoury
   {
      private readonly Items _bodyArmor;
      private readonly Items _headArmor;
      private readonly Items _legArmor;

      public BaseArmoury()
      {
         _bodyArmor = new Items();
         _headArmor = new Items();
         _legArmor = new Items();
      }


      public BaseArmoury(Items bodyArmor, Items headArmor, Items legArmor)
      {
         _bodyArmor = bodyArmor;
         _headArmor = headArmor;
         _legArmor = legArmor;
      }

      public (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) RequestArmorForLevel(string culture, ArmorTier occupation)
      {
         var bodyArmor = GetBodyArmorFor(culture, occupation);

         var headArmor = GetHeadArmorFor(culture, occupation);

         var legArmor = GetLegArmorFor(culture, occupation);

         return (bodyArmor, headArmor, legArmor);
      }

      protected List<ItemObject> FilterByCulture(string culture, List<Decoupling.ItemObject> items)
      {
         var result = new List<ItemObject>();

         foreach (var item in items)
         {
            if (item.Culture == null) continue;
            var t = item.Culture.Name.ToString().ToUpper();
            if (t == culture.ToUpper()) result.Add(item.ToEquipmentElement());
         }

         return result;
      }

      protected ItemObject.ItemTiers GetTierForLevel(ArmorTier occupation)
      {
         switch (occupation)
         {
            case ArmorTier.Soldier:
               return LogRaamRandom.EvalPercentage(50)
                  ? ItemObject.ItemTiers.Tier1
                  : ItemObject.ItemTiers.Tier2;
            case ArmorTier.Wanderer:
               return LogRaamRandom.EvalPercentage(50)
                  ? ItemObject.ItemTiers.Tier1
                  : ItemObject.ItemTiers.Tier2;
            case ArmorTier.Lord:
               return LogRaamRandom.EvalPercentage(50)
                  ? ItemObject.ItemTiers.Tier2
                  : ItemObject.ItemTiers.Tier3;
            case ArmorTier.FactionLeader:
               return ItemObject.ItemTiers.Tier4;
         }

         return ItemObject.ItemTiers.Tier1;
      }

      #region private

      private EquipmentElement GetBodyArmorFor(string culture, ArmorTier occupation)
      {
         var bodyItems = new Items();
         foreach (var item in _bodyArmor.All)
         {
            if (item.ItemType != ItemObject.ItemTypeEnum.BodyArmor) continue;
            if (item.StringId.Contains("dress")) continue;
            if (item.Tier != GetTierForLevel(occupation)) continue;

            bodyItems.AddItemToSelectedList(item);
         }

         List<ItemObject> items = FilterByCulture(culture, bodyItems.SelectedItems);

         if (items.Count == 0) return new EquipmentElement();
         var selectedItem = items.Count > 1
            ? items[LogRaamRandom.GenerateRandomNumber(items.Count)]
            : items[0];


         return new EquipmentElement(selectedItem);
      }

      private EquipmentElement GetHeadArmorFor(string culture, ArmorTier occupation)
      {
         var headItems = new Items();
         foreach (var item in _headArmor.All)
         {
            if (item.ItemType != ItemObject.ItemTypeEnum.HeadArmor) continue;
            if (item.Tier != GetTierForLevel(occupation)) continue;

            headItems.AddItemToSelectedList(item);
         }

         return new EquipmentElement(FilterByCulture(culture, headItems.SelectedItems).GetRandomElement());
      }

      private EquipmentElement GetLegArmorFor(string culture, ArmorTier occupation)
      {
         var bodyItems = new Items();
         foreach (var item in _legArmor.All)
         {
            if (item.ItemType != ItemObject.ItemTypeEnum.LegArmor) continue;
            if (item.Tier != GetTierForLevel(occupation)) continue;

            bodyItems.AddItemToSelectedList(item);
         }

         return new EquipmentElement(FilterByCulture(culture, bodyItems.SelectedItems).GetRandomElement());
      }

      #endregion
   }
}