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
   [HarmonyPatch]
   public class JopustingPrepareEquipment
   {
      #region private

      private static void Postfix()
      {
         JoustingEquipParticipant.Arrows = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.Arrows)
            .Where(x => x.StringId == "tournament_arrows" ||
                        x.StringId == "blunt_arrows")
            .ToList();

         JoustingEquipParticipant.Bolts = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.Bolts)
            .Where(x => x.StringId == "tournament_bolts")
            .ToList();

         JoustingEquipParticipant.Mounts = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.Horse)
            .Where(x => x.StringId.Contains("tournament") &&
                        !x.StringId.Contains("camel"))
            .ToList();

         JoustingEquipParticipant.Saddles = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.HorseHarness)
            .Where(x => x.StringId == "light_harness")
            .ToList();

         JoustingEquipParticipant.OneHanded = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.OneHandedWeapon)
            .Where(x => x.StringId == "peasant_hammer_2_t1" ||
                        x.StringId == "wooden_sword_t1" ||
                        x.StringId == "wooden_sword_t2")
            .ToList();

         JoustingEquipParticipant.TwoHanded = ItemObject
            .All
            .Where(x => x.StringId == "sledgehammer" ||
                        x.StringId == "wooden_2hsword_t1" ||
                        x.StringId == "peasant_maul_t1")
            .ToList();


         JoustingEquipParticipant.Polearm = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.Polearm)
            .Where(x => x.StringId == "bo_staff" ||
                        x.StringId == "billhook_polearm_t2_blunt" ||
                        x.StringId == "practice_spear_t1")
            .ToList();

         JoustingEquipParticipant.ThrownWeapon = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.Thrown)
            .Where(x => x.StringId == "throwing_stone" ||
                        x.StringId == "woodland_throwing_axe_1_t1" ||
                        x.StringId == "northern_throwing_axe_1_t1" ||
                        x.StringId == "western_throwing_axe_1_t1")
            .ToList();

         JoustingEquipParticipant.Shield = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.Shield)
            .Where(x => x.StringId.Contains("jousting") ||
                        x.StringId.Contains("sparring"))
            .ToList();

         JoustingEquipParticipant.Bow = ItemObject
            .All
            .Where(x => x.ItemType == ItemObject.ItemTypeEnum.Bow)
            .Where(x => x.StringId.Contains("training"))
            .ToList();

         JoustingEquipParticipant.BodyArmor = ItemObject
            .All
            .Where(n => n.StringId == "armor_pict_b" ||
                        n.StringId == "armor_roman_military_tunic" ||
                        n.StringId == "armor_roman_padded_leather_shirt" ||
                        n.StringId == "bandit_1_a" ||
                        n.StringId == "bandit_1_b" ||
                        n.StringId == "bandit_1_c" ||
                        n.StringId == "bandit_1_d" ||
                        n.StringId == "bandit_11" ||
                        n.StringId == "bandit_envelope_dress_v1" ||
                        n.StringId == "bandit_envelope_dress_v2" ||
                        n.StringId == "bandit_fur_a" ||
                        n.StringId == "bandit_fur_b" ||
                        n.StringId == "bandit_gambeson" ||
                        n.StringId == "battania_civil_b" ||
                        n.StringId == "battania_cloth_armor_a" ||
                        n.StringId == "battanian_savage_armor" ||
                        n.StringId == "khuzait_belt_leather" ||
                        n.StringId == "khuzait_leather_stitch_akhuzait_leather_armor" ||
                        n.StringId == "khuzait_suede_leather" ||
                        n.StringId == "leather_armor_kilt" ||
                        n.StringId == "leather_coat" ||
                        n.StringId.Contains("mongol") ||
                        n.StringId == "padded_coat_a" ||
                        n.StringId == "padded_coat_b" ||
                        n.StringId == "padded_coat_c" ||
                        n.StringId == "padded_coat_d" ||
                        n.StringId.Contains("roman_cloth") ||
                        n.StringId == "roman_cloth_tunic_b" ||
                        n.StringId == "sarranid_gambeson_v1" ||
                        n.StringId == "sarranid_gambeson_v2" ||
                        n.StringId == "sarranid_gambeson_v3" ||
                        n.StringId == "sturgia_fortified_armor" ||
                        n.StringId.Contains("sturgian_costume") ||
                        n.StringId == "walker_costume_b" ||
                        n.StringId == "aserai_fabric_armor" ||
                        n.StringId == "fur_vaegir_c" ||
                        n.StringId == "fur_vaegir_f" ||
                        n.StringId == "fur-vaegir_half_tunic" ||
                        n.StringId == "empire_warrior_padded_armor_a" ||
                        n.StringId == "empire_warrior_padded_armor_b" ||
                        n.StringId == "empire_warrior_padded_armor_c" ||
                        n.StringId == "empire_warrior_padded_armor_e" ||
                        n.StringId == "empire_warrior_padded_armor_f" ||
                        n.StringId == "empire_warrior_padded_armor_d" ||
                        n.StringId == "empire_warrior_padded_armor_g" ||
                        n.StringId == "vlandia_bandit_a" ||
                        n.StringId == "vlandia_bandit_b" ||
                        n.StringId == "armor_hemp_tunic" ||
                        n.StringId == "armor_hun_a" ||
                        n.StringId == "armor_leather_chain_a" ||
                        n.StringId == "armor_tunic_with_rolled_cloth" ||
                        n.StringId.Contains("wool") && n.StringId.Contains("tunic") ||
                        n.StringId.Contains("underwear"))
            .ToList();

         JoustingEquipParticipant.HeadArmor = ItemObject
            .All
            .Where(n => n.StringId == "aserai_helmet_c" ||
                        n.StringId == "aserai_helmet_d" ||
                        n.StringId == "aserai_helmet_h" ||
                        n.StringId == "aserai_helmet_j" ||
                        n.StringId == "aserai_helmet_m" ||
                        n.StringId == "aserai_helmet_o" ||
                        n.StringId == "battania_helmet_a" ||
                        n.StringId == "battania_helmet_b" ||
                        n.StringId == "battania_helmet_k" ||
                        n.StringId == "battania_helmet_k_a" ||
                        n.StringId == "khuzait_helmet_d" ||
                        n.StringId == "khuzait_helmet_p" ||
                        n.StringId == "leather_cap_a" ||
                        n.StringId == "vlandia_bandit_cape_a" ||
                        n.StringId == "vlandia_bandit_cape_b" ||
                        n.StringId == "vlandia_helmet_b" ||
                        n.StringId == "vlandia_helmet_c" ||
                        n.StringId == "vlandia_helmet_d" ||
                        n.StringId == "vlandia_helmet_e" ||
                        n.StringId == "vlandia_helmet_f" ||
                        n.StringId == "vlandia_helmet_n_d" ||
                        n.StringId == "vlandia_helmet_n_e" ||
                        n.StringId == "vlandia_helmet_n_f" ||
                        n.StringId == "vlandia_helmet_v" ||
                        n.StringId == "vlandia_helmet_y" ||
                        n.StringId == "shoulder_padding_cape")
            .ToList();

         JoustingEquipParticipant.Boots = ItemObject
            .All
            .Where(n => n.StringId.Contains("boots") ||
                        n.StringId == "battania_fur_boot_a" ||
                        n.StringId == "battania_leather_boots_a" ||
                        n.StringId == "khuzait_leather_boots" ||
                        n.StringId == "khuzait_suede_leather_foot" ||
                        n.StringId == "strapped_shoes" ||
                        n.StringId == "wrapped_shoes")
            .ToList();
      }


      private static IEnumerable<MethodBase> TargetMethods()
      {
         yield return AccessTools.Method(typeof(MBGameManager), "OnCampaignStart");
         yield return AccessTools.Method(typeof(MapScreen), "OnInitialize");
      }

      #endregion
   }
}