// Code written by Gabriel Mailhot, 09/02/2021.

#region

using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Gears
{
   public class GearsBase
   {
      private protected Equipment AssignEquipment(Weapons weapons, Clothing clothing)
      {
         var result = new Equipment();

         if (!weapons.MainWeapon.IsEmpty) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon0, weapons.MainWeapon);
         if (!weapons.SecondaryWeapon.IsEmpty) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon1, weapons.SecondaryWeapon);
         if (!weapons.Arrows.IsEmpty) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon2, weapons.Arrows);
         if (!weapons.Shield.IsEmpty) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon3, weapons.Shield);
         if (!weapons.ThrowingWeapon.IsEmpty) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon4, weapons.ThrowingWeapon);

         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Body, clothing.BodyArmor);
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Head, clothing.HeadArmor);
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Leg, clothing.Shoes);

         return result;
      }

      private protected Equipment AssignMount(Equipment equipment, CultureCode culture)
      {
         switch (culture)
         {
            case CultureCode.Aserai:
               if (LogRaamRandom.EvalPercentage(50))
               {
                  equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.AseraiMounts[LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.AseraiMounts.Count)]));
                  equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.HorseHarness, new EquipmentElement(Runtime.Equipment.Saddles.Find(n => n.StringId.Contains("camel"))));
               }
               else
               {
                  equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.EmpireMounts[LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.EmpireMounts.Count)]));
                  equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.HorseHarness, new EquipmentElement(Runtime.Equipment.Saddles.Find(n => !n.StringId.Contains("camel"))));
               }

               return equipment;
            case CultureCode.Empire:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.EmpireMounts[LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.EmpireMounts.Count)]));

               break;
            case CultureCode.Sturgia:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.SturgiaMounts[LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.SturgiaMounts.Count)]));

               break;

            case CultureCode.Vlandia:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.VlandiaMounts[LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.VlandiaMounts.Count)]));

               break;
            case CultureCode.Khuzait:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.KhuzaitMounts[LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.KhuzaitMounts.Count)]));

               break;
            case CultureCode.Battania:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.BattaniaMounts[LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.BattaniaMounts.Count)]));

               break;
         }


         var a = 't';

         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.HorseHarness, new EquipmentElement(Runtime.Equipment.Saddles.Find(n => !n.StringId.Contains("camel"))));

         return equipment;
      }


      private protected bool IsMountedThisTime(CultureCode culture)
      {
         var chance = 20;
         if (culture == CultureCode.Sturgia) chance += 5;
         if (culture == CultureCode.Battania) chance += 10;
         if (culture == CultureCode.Empire) chance += 15;
         if (culture == CultureCode.Aserai) chance += 20;
         if (culture == CultureCode.Vlandia) chance += 25;
         if (culture == CultureCode.Khuzait) chance += 30;

         if (Runtime.HostCulture == CultureCode.Khuzait) chance += 25;
         if (Runtime.HostCulture == CultureCode.Vlandia) chance += 15;
         if (Runtime.HostCulture == CultureCode.Battania) chance -= 5;
         if (Runtime.HostCulture == CultureCode.Sturgia) chance -= 10;

         return LogRaamRandom.EvalPercentage(chance);
      }
   }
}