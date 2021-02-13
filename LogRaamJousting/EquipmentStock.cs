// Code written by Gabriel Mailhot, 23/01/2021.

#region

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using SandBox.View.Map;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

#endregion

namespace LogRaamJousting
{
   public class EquipmentStock
   {
      public List<ItemObject> Arrows;

      public List<ItemObject> AseraiBodyArmors;
      public List<ItemObject> AseraiHeadArmors;
      public List<ItemObject> AseraiMounts;

      public List<ItemObject> BattaniaBodyArmors;
      public List<ItemObject> BattaniaHeadArmors;
      public List<ItemObject> BattaniaMounts;
      public List<ItemObject> Boots;
      public List<ItemObject> Bow;


      public List<ItemObject> EmpireBodyArmors;
      public List<ItemObject> EmpireHeadArmors;
      public List<ItemObject> EmpireMounts;

      public List<ItemObject> KhuzaitBodyArmors;
      public List<ItemObject> KhuzaitHeadArmors;
      public List<ItemObject> KhuzaitMounts;
      public List<ItemObject> OneHanded;
      public List<ItemObject> Polearm;
      public List<ItemObject> Saddles;
      public List<ItemObject> Shield;


      public List<ItemObject> SturgiaBodyArmors;
      public List<ItemObject> SturgiaHeadArmors;
      public List<ItemObject> SturgiaMounts;
      public List<ItemObject> ThrownWeapon;
      public List<ItemObject> TwoHanded;

      public List<ItemObject> VlandiaBodyArmors;
      public List<ItemObject> VlandiaHeadArmors;
      public List<ItemObject> VlandiaMounts;


      public EquipmentStock()
      {
         PrepareBodyArmors();
         PrepareHeadArmors();
         PrepareMounts();
         PrepareGears();
      }

      #region private

      private static IEnumerable<MethodBase> TargetMethods()
      {
         yield return AccessTools.Method(typeof(MBGameManager), "OnCampaignStart");
         yield return AccessTools.Method(typeof(MapScreen), "OnInitialize");
      }

      private void PrepareBodyArmors()
      {
         List<ItemObject> t = ItemObject
            .All
            .Where(n => n.ItemType == ItemObject.ItemTypeEnum.BodyArmor)
            .Where(n => n.IsCivilian)
            .Where(n => !n.StringId.Contains("female"))
            .Where(n => !n.StringId.Contains("dress"))
            .ToList();


         EmpireBodyArmors = t
            .Where(n => n.Culture.GetCultureCode() == CultureCode.Empire)
            .ToList();


         SturgiaBodyArmors = t
            .Where(n => n.Culture.GetCultureCode() == CultureCode.Sturgia)
            .ToList();


         AseraiBodyArmors = t
            .Where(n => n.Culture.GetCultureCode() == CultureCode.Aserai)
            .ToList();


         VlandiaBodyArmors = t
            .Where(n => n.Culture.GetCultureCode() == CultureCode.Vlandia)
            .ToList();


         KhuzaitBodyArmors = t
            .Where(n => n.Culture.GetCultureCode() == CultureCode.Khuzait)
            .ToList();


         BattaniaBodyArmors = t
            .Where(n => n.Culture.GetCultureCode() == CultureCode.Battania)
            .ToList();
      }

      private void PrepareGears()
      {
         Arrows = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.Arrows)
            .Where(x => x.StringId == "tournament_arrows" ||
                        x.StringId == "blunt_arrows")
            .ToList();

         OneHanded = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.OneHandedWeapon)
            .Where(x => x.StringId == "peasant_hammer_2_t1" ||
                        x.StringId == "peasant_hammer_1_t1" ||
                        x.StringId == "wooden_sword_t1" ||
                        x.StringId == "wooden_sword_t2")
            .ToList();

         TwoHanded = ItemObject
            .All
            .Where(x => x.StringId == "sledgehammer" ||
                        (x.StringId == "wooden_2hsword_t1") |
                        (x.StringId == "peasant_maul_t1"))
            .ToList();


         Polearm = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.Polearm)
            .Where(x => x.StringId == "bo_staff" ||
                        x.StringId == "practice_spear_t1" ||
                        x.StringId == "military_fork_t2" ||
                        x.StringId == "simple_pike_t2")
            .ToList();

         ThrownWeapon = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.Thrown)
            .Where(x => x.StringId == "throwing_stone" ||
                        x.StringId == "woodland_throwing_axe_1_t1" ||
                        x.StringId == "northern_throwing_axe_1_t1" ||
                        x.StringId == "western_throwing_axe_1_t1")
            .ToList();

         Shield = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.Shield)
            .Where(x => x.StringId.Contains("jousting") ||
                        x.StringId.Contains("sparring"))
            .ToList();

         Bow = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.Bow)
            .Where(x => x.StringId.Contains("training"))
            .ToList();

         Boots = ItemObject
            .All
            .Where(n => n.ItemType == ItemObject.ItemTypeEnum.LegArmor)
            .Where(n => n.IsCivilian)
            .Where(n => !n.StringId.Contains("female"))
            .Where(n => !n.StringId.Contains("woman"))
            .ToList();


         Saddles = ItemObject
            .All
            .Where(n => n.ItemType == ItemObject.ItemTypeEnum.HorseHarness)
            .Where(x => x.StringId == "light_harness" ||
                        x.StringId.Contains("camel"))
            .ToList();
      }

      private void PrepareHeadArmors()
      {
         List<ItemObject> t = ItemObject
            .All
            .Where(n => n.ItemType == ItemObject.ItemTypeEnum.HeadArmor)
            .Where(n => n.IsCivilian)
            .Where(n => !n.StringId.Contains("female"))
            .Where(n => !n.StringId.Contains("woman"))
            .ToList();


         EmpireHeadArmors = t
            .Where(n => n.Culture.GetCultureCode() != CultureCode.Sturgia &&
                        n.Culture.GetCultureCode() != CultureCode.Aserai &&
                        n.Culture.GetCultureCode() != CultureCode.Vlandia &&
                        n.Culture.GetCultureCode() != CultureCode.Khuzait &&
                        n.Culture.GetCultureCode() != CultureCode.Battania)
            .ToList();


         SturgiaHeadArmors = t
            .Where(n => n.Culture.GetCultureCode() != CultureCode.Empire &&
                        n.Culture.GetCultureCode() != CultureCode.Aserai &&
                        n.Culture.GetCultureCode() != CultureCode.Vlandia &&
                        n.Culture.GetCultureCode() != CultureCode.Khuzait &&
                        n.Culture.GetCultureCode() != CultureCode.Battania)
            .ToList();


         AseraiHeadArmors = t
            .Where(n => n.Culture.GetCultureCode() != CultureCode.Sturgia &&
                        n.Culture.GetCultureCode() != CultureCode.Empire &&
                        n.Culture.GetCultureCode() != CultureCode.Vlandia &&
                        n.Culture.GetCultureCode() != CultureCode.Khuzait &&
                        n.Culture.GetCultureCode() != CultureCode.Battania)
            .ToList();


         VlandiaHeadArmors = t
            .Where(n => n.Culture.GetCultureCode() != CultureCode.Sturgia &&
                        n.Culture.GetCultureCode() != CultureCode.Aserai &&
                        n.Culture.GetCultureCode() != CultureCode.Empire &&
                        n.Culture.GetCultureCode() != CultureCode.Khuzait &&
                        n.Culture.GetCultureCode() != CultureCode.Battania)
            .ToList();


         KhuzaitHeadArmors = t
            .Where(n => n.Culture.GetCultureCode() != CultureCode.Sturgia &&
                        n.Culture.GetCultureCode() != CultureCode.Aserai &&
                        n.Culture.GetCultureCode() != CultureCode.Vlandia &&
                        n.Culture.GetCultureCode() != CultureCode.Empire &&
                        n.Culture.GetCultureCode() != CultureCode.Battania)
            .ToList();


         BattaniaHeadArmors = t
            .Where(n => n.Culture.GetCultureCode() != CultureCode.Sturgia &&
                        n.Culture.GetCultureCode() != CultureCode.Aserai &&
                        n.Culture.GetCultureCode() != CultureCode.Vlandia &&
                        n.Culture.GetCultureCode() != CultureCode.Khuzait &&
                        n.Culture.GetCultureCode() != CultureCode.Empire)
            .ToList();
      }


      private void PrepareMounts()
      {
         List<ItemObject> t = ItemObject
            .All
            .Where(n => n.ItemType == ItemObject.ItemTypeEnum.Horse)
            .Where(n => n.StringId.Contains("tournament"))
            .ToList();

         EmpireMounts = t
            .Where(n => !n.StringId.Contains("camel"))
            .Where(n => n.Culture.GetCultureCode() == CultureCode.Empire)
            .ToList();

         SturgiaMounts = t
            .Where(n => !n.StringId.Contains("camel"))
            .Where(n => n.Culture.GetCultureCode() == CultureCode.Sturgia)
            .ToList();

         AseraiMounts = t
            .Where(n => n.StringId.Contains("camel"))
            .ToList();


         VlandiaMounts = t
            .Where(n => !n.StringId.Contains("camel"))
            .Where(n => n.Culture.GetCultureCode() == CultureCode.Vlandia)
            .ToList();


         KhuzaitMounts = t
            .Where(n => !n.StringId.Contains("camel"))
            .Where(n => n.Culture.GetCultureCode() == CultureCode.Khuzait)
            .ToList();


         BattaniaMounts = t
            .Where(n => !n.StringId.Contains("camel"))
            .Where(n => n.Culture.GetCultureCode() == CultureCode.Battania)
            .ToList();
      }

      #endregion
   }
}