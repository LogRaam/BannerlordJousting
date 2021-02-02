// Code written by Gabriel Mailhot, 23/01/2021.

#region

#endregion

namespace LogRaamJousting
{
   /*public class AgentEquipItemsFromSpawnEquipmentPatch
    {
       private static readonly AccessTools.FieldRef<MissionEquipment, MissionWeapon[]> MissionWeaponRef = AccessTools.FieldRefAccess<MissionEquipment, MissionWeapon[]>("_weaponSlots");
 
       internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator ilg)
       {
          List<CodeInstruction> list = instructions.ToList();
          int index1 = list.FindIndex(c => c.opcode == OpCodes.Call && (MethodInfo) c.operand == AccessTools.Method(typeof(MissionWeapon), "GetWeaponData")) - 7;
 
          for (int index2 = index1; index2 < index1 + 34; ++index2)
          {
             list[index2].opcode = OpCodes.Nop;
             list[index2].operand = null;
          }
 
          ilg.DeclareLocal(typeof(MissionWeapon));
          var codeInstructionList1 = new List<CodeInstruction> {
             new CodeInstruction(OpCodes.Ldloc_1),
             new CodeInstruction(OpCodes.Ldarg_0),
             new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(AgentEquipItemsFromSpawnEquipmentPatch), "GetMissionWeapon")),
             new CodeInstruction(OpCodes.Dup),
             new CodeInstruction(OpCodes.Stloc_S, 10),
             new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(AgentEquipItemsFromSpawnEquipmentPatch), "GetWeaponData")),
             new CodeInstruction(OpCodes.Stloc_2),
             new CodeInstruction(OpCodes.Ldloc_S, 10),
             new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(AgentEquipItemsFromSpawnEquipmentPatch), "GetWeaponStatsData")),
             new CodeInstruction(OpCodes.Stloc_3),
             new CodeInstruction(OpCodes.Ldloc_S, 10),
             new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(AgentEquipItemsFromSpawnEquipmentPatch), "GetAmmoWeaponData")),
             new CodeInstruction(OpCodes.Stloc_S, 4),
             new CodeInstruction(OpCodes.Ldloc_S, 10),
             new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(AgentEquipItemsFromSpawnEquipmentPatch), "GetAmmoWeaponStatsData")),
             new CodeInstruction(OpCodes.Stloc_S, 5)
          };
 
          List<CodeInstruction> codeInstructionList2 = codeInstructionList1;
          list.InsertRange(index1, codeInstructionList2);
 
          return list.AsEnumerable();
       }
 
       #region private
 
       private static void AddAmmo(Agent agent, MissionWeapon missionWeapon)
       {
          if (missionWeapon.Item.ItemType == ItemObject.ItemTypeEnum.Bow) AddingArrows(agent);
          else AddingBolts(agent);
       }
 
       private static void AddingArrows(Agent agent)
       {
          var missionWeapon1 = new MissionWeapon(JoustingEquipment.Arrows.GetRandomElement(), agent.WieldedWeapon.ItemModifier, agent.Origin.Banner);
          Traverse.Create(agent.Equipment).Field<MissionWeapon[]>("_weaponSlots").Value[3] = missionWeapon1;
       }
 
       private static void AddingBolts(Agent agent)
       {
          var missionWeapon1 = new MissionWeapon(JoustingEquipment.Bolts.GetRandomElement(), agent.WieldedWeapon.ItemModifier, agent.Origin.Banner);
          Traverse.Create(agent.Equipment).Field<MissionWeapon[]>("_weaponSlots").Value[3] = missionWeapon1;
       }
 
       private static void CheckForBowsOrShields(Agent agent, ref bool hasBow, ref bool hasShield)
       {
          for (var index = 0; index < 4; ++index)
          {
             MissionWeapon missionWeapon1 = agent.Equipment[index];
 
             if (missionWeapon1.IsEmpty) break;
 
             MissionWeapon missionWeapon2 = agent.Equipment[index];
 
             ItemObject.ItemTypeEnum itemType = missionWeapon2.Item.ItemType;
 
             if (itemType == ItemObject.ItemTypeEnum.Bow || itemType == ItemObject.ItemTypeEnum.Crossbow) hasBow = true;
             else if (itemType == ItemObject.ItemTypeEnum.Shield) hasShield = true;
          }
       }
 
       private static WeaponData GetAmmoWeaponData(MissionWeapon missionWeapon)
       {
          return missionWeapon.GetAmmoWeaponData(false);
       }
 
       private static WeaponStatsData[] GetAmmoWeaponStatsData(MissionWeapon missionWeapon)
       {
          return missionWeapon.GetWeaponStatsData();
       }
 
       private static MissionWeapon GetMissionWeapon(int index, Agent agent)
       {
          int num1;
          if (agent != null)
          {
             if (!agent.IsHero)
             {
                MissionWeapon missionWeapon = agent.Equipment[3];
                num1 = missionWeapon.IsEmpty
                   ? 0
                   : index == 3
                      ? 1
                      : 0;
             }
             else
             {
                num1 = 1;
             }
          }
          else
          {
             num1 = 0;
          }
 
          if (num1 != 0) return agent.Equipment[index];
 
          var hasShield = false;
          var hasBow = false;
 
          CheckForBowsOrShields(agent, ref hasBow, ref hasShield);
          FormationClass? formationClass1 = agent.Character?.GetFormationClass(agent.Origin.BattleCombatant);
          int index1 = index;
 
          int num2 = hasBow
             ? 1
             : 0;
          int num3 = hasShield
             ? 1
             : 0;
          FormationClass? nullable = formationClass1;
          var formationClass2 = (FormationClass) 1;
          int num4;
          if (!((nullable.GetValueOrDefault() == formationClass2) & nullable.HasValue))
          {
             nullable = formationClass1;
             var formationClass3 = (FormationClass) 4;
             num4 = (nullable.GetValueOrDefault() == formationClass3) & nullable.HasValue
                ? 1
                : 0;
          }
          else
          {
             num4 = 1;
          }
 
          nullable = formationClass1;
          var formationClass4 = (FormationClass) 3;
          int num5 = (nullable.GetValueOrDefault() == formationClass4) & nullable.HasValue
             ? 1
             : 0;
 
          Agent agent1 = agent;
          ItemObject itemObject = SelectValidItem(index1, agent1, num2 != 0, num3 != 0, num4 != 0, num5 != 0);
 
          var missionWeapon1 = new MissionWeapon(itemObject, agent.WieldedWeapon.ItemModifier, agent.Origin.Banner);
 
          MissionWeaponRef.Invoke(agent.Equipment)[index] = missionWeapon1;
 
          return missionWeapon1;
       }
 
       private static WeaponData GetWeaponData(MissionWeapon missionWeapon)
       {
          return missionWeapon.GetWeaponData(false);
       }
 
       private static WeaponStatsData[] GetWeaponStatsData(MissionWeapon missionWeapon)
       {
          return missionWeapon.GetWeaponStatsData();
       }
 
       private static ItemObject SelectValidItem(
          int index,
          Agent agent,
          bool hasBow,
          bool hasShield,
          bool isArcher,
          bool isHorseArcher)
       {
          ItemObject itemObject = null;
 
          if (isArcher | isHorseArcher && !hasBow)
          {
             hasBow = true;
             MissionWeapon missionWeapon;
             if ((JoustingEquipment.Rng.Next(0, 2) == 0) | isHorseArcher)
             {
                itemObject = JoustingEquipment.Bow.GetRandomElement();
                missionWeapon = new MissionWeapon(itemObject, agent.WieldedWeapon.ItemModifier, agent.Origin.Banner);
             }
             else
             {
                itemObject = JoustingEquipment.Bow.GetRandomElement();
                missionWeapon = new MissionWeapon(itemObject, agent.WieldedWeapon.ItemModifier, agent.Origin.Banner);
             }
 
             AddAmmo(agent, missionWeapon);
          }
          else
          {
             itemObject = JoustingEquipment.EquipmentItems.Where(x => x.ItemType != ItemObject.ItemTypeEnum.Bow && x.ItemType != ItemObject.ItemTypeEnum.Crossbow).GetRandomElement();
          }
 
          if ((itemObject.ItemType == ItemObject.ItemTypeEnum.Shield) & hasShield)
          {
             IEnumerable<ItemObject> source = JoustingEquipment.EquipmentItems.Where(x => x.ItemType != ItemObject.ItemTypeEnum.Shield);
             if (hasBow || index > 2) source = source.Where(x => x.ItemType != ItemObject.ItemTypeEnum.Bow && x.ItemType != ItemObject.ItemTypeEnum.Crossbow);
             itemObject = source.GetRandomElement();
          }
 
          return itemObject;
       }
 
       #endregion
    }*/
}