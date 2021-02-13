// Code written by Gabriel Mailhot, 09/02/2021.

#region

using System.Collections.Generic;
using System.Linq;
using LogRaamJousting.Contract;
using LogRaamJousting.Gears;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Avatar
{
   public class Custom : GearsBase, IWeaponUser
   {
      public Custom(Weapons weapons, Clothing clothes)
      {
         Equipment = AssignEquipment(weapons, clothes);
      }

      public Equipment Equipment { get; set; }

      public void AddMount()
      {
         if (!Equipment.GetEquipmentFromSlot(EquipmentIndex.Weapon0).Item.IsMountable)
         {
            List<ItemObject> eq = Runtime.Equipment.Bow.Where(n => n.IsMountable).ToList();
            var t = new EquipmentElement(eq[LogRaamRandom.GenerateRandomNumber(eq.Count)]);
            Equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon0, t);
         }


         Equipment = AssignMount(Equipment);
      }

      #region private

      private Equipment AssignMount(Equipment equipment)
      {
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.EmpireMounts.First()));
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.HorseHarness, new EquipmentElement(Runtime.Equipment.Saddles.First()));

         return equipment;
      }

      #endregion
   }
}