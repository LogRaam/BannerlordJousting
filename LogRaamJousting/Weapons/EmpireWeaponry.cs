// Code written by Gabriel Mailhot, 23/04/2023.

#region

using System.Linq;
using LogRaamJousting.Decoupling;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Weapons
{
   public class EmpireWeaponry : IWeaponry
   {
      public EmpireWeaponry(Items items)
      {
         Items = items;
      }

      public Items Items { get; set; }
      
      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestCulturalEventWeapon()
      {
         return CulturalEventJavelin();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestFactionLeaderWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 10) return LordJavelinThrower();
         if (r <= 20) return LordFork();
         if (r <= 50) return LordSpearAndShield();

         return LordSwordAndShield();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestHeroWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 25) return Fork();
         if (r <= 50) return JavelinThrower();
         if (r <= 75) return SpearAndShield();

         return SwordAndShield();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestLordWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 10) return LordJavelinThrower();
         if (r <= 20) return LordFork();
         if (r <= 60) return LordSpearAndShield();

         return LordSwordAndShield();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestParticipantWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 33) return Fork();
         if (r <= 66) return JavelinThrower();

         return SpearAndShield();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestPlayerWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 25) return Fork();
         if (r <= 50) return JavelinThrower();
         if (r <= 75) return SpearAndShield();

         return SwordAndShield();
      }

      #region private

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) CulturalEventJavelin()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "western_javelin_1_t2_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "western_javelin_1_t2_blunt").ToEquipmentElement());
         var weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "western_javelin_1_t2_blunt").ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "western_javelin_1_t2_blunt").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) Fork()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "military_fork_t2").ToEquipmentElement());

         return (weapon0, null, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) JavelinThrower()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "western_javelin_1_t2_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "western_javelin_1_t2_blunt").ToEquipmentElement());
         var weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "western_javelin_1_t2_blunt").ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordFork()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "military_fork_pike_t3").ToEquipmentElement());

         return (weapon0, null, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordJavelinThrower()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "western_javelin_1_t2_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "western_javelin_1_t2_blunt").ToEquipmentElement());
         var weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "western_javelin_1_t2_blunt").ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordSpearAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "empire_lance_1_t3_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.Where(n => n.StringId == "simple_horsemans_kite_shield" || n.StringId == "simple_kite_shield" || n.StringId == "worn_kite_shield").ToList().GetRandomElement().ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordSwordAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.Where(n => n.StringId == "simple_kite_shield" || n.StringId == "worn_kite_shield").ToList().GetRandomElement().ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SpearAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "empire_lance_1_t3_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.Where(n => n.StringId == "simple_horsemans_kite_shield" || n.StringId == "simple_kite_shield" || n.StringId == "worn_kite_shield").ToList().GetRandomElement().ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SwordAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.Where(n => n.StringId == "simple_kite_shield" || n.StringId == "worn_kite_shield").ToList().GetRandomElement().ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      #endregion
   }
}