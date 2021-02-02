using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using Extensions = System.Xml.Linq.Extensions;

namespace LogRaamJousting.Patch
{
   public class AgentEquipItemsFromSpawnEquipmentPatch
      {
         private static readonly AccessTools.FieldRef<MissionEquipment, MissionWeapon[]> MissionWeaponRef = (AccessTools.FieldRef<MissionEquipment, MissionWeapon[]>) AccessTools.FieldRefAccess<MissionEquipment, MissionWeapon[]>("_weaponSlots");

         internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator ilg)
         {
            if (!Mod.ModSettings.ArmyMode)
               return instructions;
            List<CodeInstruction> list = instructions.ToList<CodeInstruction>();
            int index1 = list.FindIndex((Predicate<CodeInstruction>) (c => (OpCode) c.opcode == OpCodes.Call && (MethodInfo) c.operand == AccessTools.Method(typeof(MissionWeapon), "GetWeaponData", (Type[]) null, (Type[]) null))) - 7;
            for (int index2 = index1; index2 < index1 + 34; ++index2)
            {
               list[index2].opcode = (__Null) OpCodes.Nop;
               list[index2].operand = null;
            }

            ilg.DeclareLocal(typeof(MissionWeapon));
            List<CodeInstruction> codeInstructionList1 = new List<CodeInstruction>();
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Ldloc_1, (object) null));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Ldarg_0, (object) null));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Call, (object) AccessTools.Method(typeof(AgentPatches.AgentEquipItemsFromSpawnEquipmentPatch), "GetMissionWeapon", (Type[]) null, (Type[]) null)));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Dup, (object) null));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Stloc_S, (object) 10));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Call, (object) AccessTools.Method(typeof(AgentPatches.AgentEquipItemsFromSpawnEquipmentPatch), "GetWeaponData", (Type[]) null, (Type[]) null)));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Stloc_2, (object) null));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Ldloc_S, (object) 10));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Call, (object) AccessTools.Method(typeof(AgentPatches.AgentEquipItemsFromSpawnEquipmentPatch), "GetWeaponStatsData", (Type[]) null, (Type[]) null)));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Stloc_3, (object) null));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Ldloc_S, (object) 10));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Call, (object) AccessTools.Method(typeof(AgentPatches.AgentEquipItemsFromSpawnEquipmentPatch), "GetAmmoWeaponData", (Type[]) null, (Type[]) null)));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Stloc_S, (object) 4));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Ldloc_S, (object) 10));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Call, (object) AccessTools.Method(typeof(AgentPatches.AgentEquipItemsFromSpawnEquipmentPatch), "GetAmmoWeaponStatsData", (Type[]) null, (Type[]) null)));
            codeInstructionList1.Add(new CodeInstruction(OpCodes.Stloc_S, (object) 5));
            List<CodeInstruction> codeInstructionList2 = codeInstructionList1;
            list.InsertRange(index1, (IEnumerable<CodeInstruction>) codeInstructionList2);

            return ((IEnumerable<CodeInstruction>) list).AsEnumerable<CodeInstruction>();
         }

         private static MissionWeapon GetMissionWeapon(int index, Agent agent)
         {
            int num1;
            if (agent != null)
            {
               if (!agent.get_IsHero())
               {
                  MissionWeapon missionWeapon = agent.get_Equipment().get_Item(3);
                  num1 = ((MissionWeapon) ref missionWeapon).get_IsEmpty()
                     ? 0
                     : (index == 3
                        ? 1
                        : 0);
               }
               else
                  num1 = 1;
            }
            else
               num1 = 0;

            if (num1 != 0)
               return agent.get_Equipment().get_Item(index);
            bool hasShield = false;
            bool hasBow = false;
            AgentPatches.AgentEquipItemsFromSpawnEquipmentPatch.CheckForBowsOrShields(agent, ref hasBow, ref hasShield);
            FormationClass? formationClass1 = (FormationClass?) agent.get_Character()?.GetFormationClass(agent.get_Origin().get_BattleCombatant());
            int index1 = index;
            Agent agent1 = agent;
            int num2 = hasBow
               ? 1
               : 0;
            int num3 = hasShield
               ? 1
               : 0;
            FormationClass? nullable = formationClass1;
            FormationClass formationClass2 = (FormationClass) 1;
            int num4;
            if (!(nullable.GetValueOrDefault() == formationClass2 & nullable.HasValue))
            {
               nullable = formationClass1;
               FormationClass formationClass3 = (FormationClass) 4;
               num4 = nullable.GetValueOrDefault() == formationClass3 & nullable.HasValue
                  ? 1
                  : 0;
            }
            else
               num4 = 1;

            nullable = formationClass1;
            FormationClass formationClass4 = (FormationClass) 3;
            int num5 = nullable.GetValueOrDefault() == formationClass4 & nullable.HasValue
               ? 1
               : 0;
            ItemObject itemObject = AgentPatches.AgentEquipItemsFromSpawnEquipmentPatch.SelectValidItem(index1, agent1, num2 != 0, num3 != 0, num4 != 0, num5 != 0);
            MissionWeapon missionWeapon1;
            ((MissionWeapon) ref missionWeapon1).\u002Ector(itemObject, agent.get_Origin().get_Banner());
            AgentPatches.AgentEquipItemsFromSpawnEquipmentPatch.MissionWeaponRef.Invoke(agent.get_Equipment())[index] = missionWeapon1;

            return missionWeapon1;
         }

         private static ItemObject SelectValidItem(
            int index,
            Agent agent,
            bool hasBow,
            bool hasShield,
            bool isArcher,
            bool isHorseArcher)
         {
            ItemObject itemObject = (ItemObject) null;
            try
            {
               if (isArcher | isHorseArcher && !hasBow)
               {
                  hasBow = true;
                  MissionWeapon missionWeapon;
                  if (Helpers.Rng.Next(0, 2) == 0 | isHorseArcher)
                  {
                     itemObject = (ItemObject) Extensions.GetRandomElement<ItemObject>((IEnumerable<M0>) ((IEnumerable<ItemObject>) Helpers.EquipmentItems).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() == 8)));
                     ((MissionWeapon) ref missionWeapon).\u002Ector(itemObject, agent.get_Origin().get_Banner());
                  }
                  else
                  {
                     itemObject = (ItemObject) Extensions.GetRandomElement<ItemObject>((IEnumerable<M0>) ((IEnumerable<ItemObject>) Helpers.EquipmentItems).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() == 9)));
                     ((MissionWeapon) ref missionWeapon).\u002Ector(itemObject, agent.get_Origin().get_Banner());
                  }

                  AgentPatches.AgentEquipItemsFromSpawnEquipmentPatch.AddAmmo(agent, missionWeapon);
               }
               else
                  itemObject = (ItemObject) Extensions.GetRandomElement<ItemObject>((IEnumerable<M0>) ((IEnumerable<ItemObject>) Helpers.EquipmentItems).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() != 8 && x.get_ItemType() != 9)));

               if (itemObject.get_ItemType() == 7 & hasShield)
               {
                  IEnumerable<ItemObject> source = ((IEnumerable<ItemObject>) Helpers.EquipmentItems).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() != 7));
                  if (hasBow || index > 2)
                     source = source.Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() != 8 && x.get_ItemType() != 9));
                  itemObject = (ItemObject) Extensions.GetRandomElement<ItemObject>((IEnumerable<M0>) source);
               }
            }
            catch (Exception ex)
            {
               Mod.Log((object) ex);
            }

            return itemObject;
         }

         private static void AddAmmo(Agent agent, MissionWeapon missionWeapon)
         {
            if (((MissionWeapon) ref missionWeapon ).get_PrimaryItem().get_ItemType() == 8)
            {
               Mod.Log((object) "Adding arrows");
               MissionWeapon missionWeapon1;
               ((MissionWeapon) ref missionWeapon1).\u002Ector((ItemObject) Extensions.GetRandomElement<ItemObject>((IEnumerable<M0>) Helpers.Arrows), agent.get_Origin().get_Banner());
               ((Traverse<MissionWeapon[]>) Traverse.Create((object) agent.get_Equipment()).Field<MissionWeapon[]>("_weaponSlots")).get_Value()[3] = missionWeapon1;
            }
            else
            {
               Mod.Log((object) "Adding bolts");
               MissionWeapon missionWeapon1;
               ((MissionWeapon) ref missionWeapon1).\u002Ector((ItemObject) Extensions.GetRandomElement<ItemObject>((IEnumerable<M0>) Helpers.Bolts), agent.get_Origin().get_Banner());
               ((Traverse<MissionWeapon[]>) Traverse.Create((object) agent.get_Equipment()).Field<MissionWeapon[]>("_weaponSlots")).get_Value()[3] = missionWeapon1;
            }
         }

         private static void CheckForBowsOrShields(Agent agent, ref bool hasBow, ref bool hasShield)
         {
            for (int index = 0; index < 4; ++index)
            {
               MissionWeapon missionWeapon1 = agent.get_Equipment().get_Item(index);
               if (((MissionWeapon) ref missionWeapon1 ).get_IsEmpty())

               break;
               MissionWeapon missionWeapon2 = agent.get_Equipment().get_Item(index);
               ItemObject.ItemTypeEnum itemType = ((MissionWeapon) ref missionWeapon2 ).get_PrimaryItem().get_ItemType();
               if (itemType == 8 || itemType == 9)
                  hasBow = true;
               else if (itemType == 7)
                  hasShield = true;
            }
         }

         private static WeaponData GetWeaponData(MissionWeapon missionWeapon) => ((MissionWeapon) ref missionWeapon).GetWeaponData(false);

         private static WeaponStatsData[] GetWeaponStatsData(MissionWeapon missionWeapon) => ((MissionWeapon) ref missionWeapon).GetWeaponStatsData();

         private static WeaponData GetAmmoWeaponData(MissionWeapon missionWeapon) => ((MissionWeapon) ref missionWeapon).GetAmmoWeaponData(false);

         private static WeaponStatsData[] GetAmmoWeaponStatsData(
            MissionWeapon missionWeapon)
         {
            return ((MissionWeapon) ref missionWeapon ).GetWeaponStatsData();
         }
      }

}