using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using SandBox;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.Source.TournamentGames;
using TaleWorlds.Core;
using TaleWorlds.ObjectSystem;

namespace LogRaamJousting
{
  public class Helpers
  {
    internal static List<ItemObject> EquipmentItems;
    internal static List<ItemObject> Arrows;
    internal static List<ItemObject> Bolts;
    internal static List<ItemObject> Mounts;
    internal static List<ItemObject> Saddles;
    internal static readonly Random Rng = new Random();

    internal static Equipment BuildViableEquipmentSet()
    {
      Equipment equipment = new Equipment();
      bool flag1 = false;
      bool flag2 = false;

      for (int index = 0; index < 4; ++index)
      {
        EquipmentElement equipmentElement;
        int num;
        if (index == 3)
        {
          equipmentElement = equipment.GetEquipmentFromSlot(EquipmentIndex.Weapon3);
          num = !equipmentElement.IsEmpty ? 1 : 0;
        }
        else
          num = 0;
        if (num == 0)
        {
          ItemObject randomElement = (ItemObject) Helpers.EquipmentItems.GetRandomElement<ItemObject>();
          equipmentElement = equipment.GetEquipmentFromSlot(EquipmentIndex.Weapon3);
          if (!((EquipmentElement) ref equipmentElement).get_IsEmpty() && index == 3 && (randomElement.get_ItemType() == 8 || randomElement.get_ItemType() == 9))
            randomElement = (ItemObject) Extensions.GetRandomElement<ItemObject>((IEnumerable<M0>) ((IEnumerable<ItemObject>) Helpers.EquipmentItems).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() != 8 && x.get_ItemType() != 9)));
          if (randomElement.get_ItemType() == 8 || randomElement.get_ItemType() == 9)
          {
            if (index < 3)
            {
              if (flag2)
              {
                --index;
                continue;
              }
              flag2 = true;
              equipment.set_Item(index, new EquipmentElement(randomElement, (ItemModifier) null));
              if (randomElement.get_ItemType() == 8)
                equipment.set_Item(3, new EquipmentElement(((IEnumerable<ItemObject>) Helpers.Arrows).ToList<ItemObject>()[Helpers.Rng.Next(0, Helpers.Arrows.Count)], (ItemModifier) null));
              if (randomElement.get_ItemType() == 9)
              {
                equipment.set_Item(3, new EquipmentElement(((IEnumerable<ItemObject>) Helpers.Bolts).ToList<ItemObject>()[Helpers.Rng.Next(0, Helpers.Bolts.Count)], (ItemModifier) null));
                continue;
              }
              continue;
            }
            randomElement = (ItemObject) Extensions.GetRandomElement<ItemObject>((IEnumerable<M0>) ((IEnumerable<ItemObject>) Helpers.EquipmentItems).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() != 8 && x.get_ItemType() != 9)));
          }
          if (randomElement.get_ItemType() == 7)
          {
            if (flag1)
            {
              --index;
              continue;
            }
            flag1 = true;
          }
          equipment.set_Item(index, new EquipmentElement(randomElement, (ItemModifier) null));
        }
        else
          break;
      }
      if (Helpers.Rng.NextDouble() < 0.200000002980232)
      {
        ItemObject randomElement = (ItemObject) Extensions.GetRandomElement<ItemObject>((IEnumerable<M0>) Helpers.Mounts);
        string lower = ((MBObjectBase) randomElement).get_StringId().ToLower();
        equipment.set_Item(10, new EquipmentElement(randomElement, (ItemModifier) null));
        if (lower.Contains("camel"))
          equipment.set_Item(11, new EquipmentElement((ItemObject) Extensions.GetRandomElement<ItemObject>((IEnumerable<M0>) ((IEnumerable<ItemObject>) Helpers.Saddles).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_Name().ToLower().Contains("camel")))), (ItemModifier) null));
        else
          equipment.set_Item(11, new EquipmentElement((ItemObject) Extensions.GetRandomElement<ItemObject>((IEnumerable<M0>) ((IEnumerable<ItemObject>) Helpers.Saddles).Where<ItemObject>((Func<ItemObject, bool>) (x => !x.get_Name().ToLower().Contains("camel")))), (ItemModifier) null));
      }
      return equipment.Clone(false);
    }




    internal static float SumTeamEquipmentValue(TournamentTeam team)
    {
      float num1 = 0.0f;
      try
      {
        using (IEnumerator<TournamentParticipant> enumerator = team.get_Participants().GetEnumerator())
        {
          while (((IEnumerator) enumerator).MoveNext())
          {
            TournamentParticipant current = enumerator.Current;
            EquipmentElement equipmentElement;
            for (int index = 0; index < 4; ++index)
            {
              double num2 = (double) num1;
              equipmentElement = current.get_MatchEquipment().get_Item(index);
              double tierf = (double) ((EquipmentElement) ref equipmentElement).get_Item().get_Tierf();
              num1 = (float) (num2 + tierf);
            }
            equipmentElement = current.get_MatchEquipment().get_Item(10);
            if (((EquipmentElement) ref equipmentElement).get_IsEmpty())
              return num1;
            double num3 = (double) num1;
            equipmentElement = current.get_MatchEquipment().get_Item(10);
            double tierf1 = (double) ((EquipmentElement) ref equipmentElement).get_Item().get_Tierf();
            num1 = (float) (num3 + tierf1);
            equipmentElement = current.get_MatchEquipment().get_Item(11);
            if (((EquipmentElement) ref equipmentElement).get_IsEmpty())
              return num1;
            double num4 = (double) num1;
            equipmentElement = current.get_MatchEquipment().get_Item(11);
            double tierf2 = (double) ((EquipmentElement) ref equipmentElement).get_Item().get_Tierf();
            num1 = (float) (num4 + tierf2);
          }
        }
      }
      catch (Exception ex)
      {
        Mod.Log((object) ex);
      }
      return num1;
    }

    internal static void EquipParticipant(
      TournamentFightMissionController __instance,
      CultureObject ____culture,
      TournamentTeam team,
      Dictionary<TournamentTeam, int> mountMap,
      TournamentParticipant participant)
    {
      Equipment equipment = Helpers.BuildViableEquipmentSet();
      Mod.Log((object) new string('-', 50));
      Helpers.LogWeaponsAndMount(equipment);
      EquipmentElement equipmentElement = equipment.get_Item(10);
      if (!((EquipmentElement) ref equipmentElement).get_IsEmpty())
        mountMap[team]++;
      participant.set_MatchEquipment(equipment);
      AccessTools.Method(typeof (TournamentFightMissionController), "AddRandomClothes", (Type[]) null, (Type[]) null).Invoke((object) __instance, new object[2]
      {
        (object) ____culture,
        (object) participant
      });
    }

    private static void LogWeaponsAndMount(Equipment equipment)
    {
      Mod.Log((object) equipment.get_Item(0));
      Mod.Log((object) equipment.get_Item(1));
      Mod.Log((object) equipment.get_Item(2));
      Mod.Log((object) equipment.get_Item(3));
      EquipmentElement equipmentElement1 = equipment.get_Item(10);
      if (((EquipmentElement) ref equipmentElement1).get_IsEmpty())
        return;
      Mod.Log((object) equipment.get_Item(10));
      EquipmentElement equipmentElement2 = equipment.get_Item(11);
      if (((EquipmentElement) ref equipmentElement2).get_IsEmpty())
        return;
      Mod.Log((object) equipment.get_Item(11));
    }
  }
}
