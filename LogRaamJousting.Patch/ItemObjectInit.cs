using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using SandBox.View.Map;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace LogRaamJousting.Patch
{
    [HarmonyPatch]
  public class ItemObjectInit
  {
    private static IEnumerable<MethodBase> TargetMethods()
    {
      yield return (MethodBase) AccessTools.Method(typeof (MBGameManager), "OnCampaignStart", (Type[]) null, (Type[]) null);
      yield return (MethodBase) AccessTools.Method(typeof (MapScreen), "OnInitialize", (Type[]) null, (Type[]) null);
    }

    private static void Postfix()
    {
      List<ItemObject> list = ((IEnumerable<ItemObject>) ItemObject.get_All()).Where<ItemObject>((Func<ItemObject, bool>) (x => !x.get_Name().Contains("Crafted") && !x.get_Name().Contains("Wooden") && (!x.get_Name().Contains("Practice") && ((object) x.get_Name()).ToString() != "Torch") && (((object) x.get_Name()).ToString() != "Horse Whip" && ((object) x.get_Name()).ToString() != "Push Fork") && ((object) x.get_Name()).ToString() != "Bound Crossbow")).ToList<ItemObject>();
      IEnumerable<ItemObject> first = ((IEnumerable<ItemObject>) list).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() == 2));
      IEnumerable<ItemObject> second1 = ((IEnumerable<ItemObject>) list).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() == 3));
      IEnumerable<ItemObject> second2 = ((IEnumerable<ItemObject>) list).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() == 4));
      IEnumerable<ItemObject> second3 = ((IEnumerable<ItemObject>) list).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() == 10 && ((object) x.get_Name()).ToString() != "Boulder" && ((object) x.get_Name()).ToString() != "Fire Pot"));
      IEnumerable<ItemObject> second4 = ((IEnumerable<ItemObject>) list).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() == 7));
      IEnumerable<ItemObject> second5 = ((IEnumerable<ItemObject>) list).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() == 8 || x.get_ItemType() == 9));
      Helpers.Arrows = ((IEnumerable<ItemObject>) list).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() == 5)).Where<ItemObject>((Func<ItemObject, bool>) (x => !x.get_Name().Contains("Ballista"))).ToList<ItemObject>();
      Helpers.Bolts = ((IEnumerable<ItemObject>) list).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() == 6)).ToList<ItemObject>();
      Helpers.Mounts = ((IEnumerable<ItemObject>) list).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() == 1)).Where<ItemObject>((Func<ItemObject, bool>) (x => !((MBObjectBase) x).get_StringId().Contains("unmountable"))).ToList<ItemObject>();
      Helpers.Saddles = ((IEnumerable<ItemObject>) list).Where<ItemObject>((Func<ItemObject, bool>) (x => x.get_ItemType() == 23 && !((MBObjectBase) x).get_StringId().ToLower().Contains("mule"))).ToList<ItemObject>();
      List<ItemObject> itemObjectList = new List<ItemObject>((IEnumerable<ItemObject>) first.Concat<ItemObject>(second1).Concat<ItemObject>(second2).Concat<ItemObject>(second3).Concat<ItemObject>(second4).Concat<ItemObject>(second5).ToList<ItemObject>());
      Helpers.EquipmentItems = new List<ItemObject>();
      CollectionExtensions.Do<ItemObject>((IEnumerable<M0>) itemObjectList, (Action<M0>) (x =>
      {
        List<ItemObject> equipmentItems = Helpers.EquipmentItems;
        EquipmentElement equipmentElement = new EquipmentElement(x, (ItemModifier) null);
        ItemObject itemObject = ((EquipmentElement) ref equipmentElement).get_Item();
        equipmentItems.Add(itemObject);
      }));
    }
  }
}
