// Code written by Gabriel Mailhot, 23/04/2023.

#region

using System.Linq;
using LogRaamJousting.Decoupling;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Weapons
{
   public class SturgiaWeaponry : IWeaponry
   {
      public SturgiaWeaponry(Items items)
      {
         Items = items;
      }

      public Items Items { get; set; }
      
      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestCulturalEventWeapon()
      {
         return CulturalEventThrowingAxes();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestFactionLeaderWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 10) return LordThrowingAxe();
         if (r <= 20) return LordAxe();
         if (r <= 40) return LordAxeAndShield();
         if (r <= 70) return LordSpearAndShield();

         return LordSwordAndShield();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestHeroWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 15) return ThrowingAxe();
         if (r <= 40) return SwordAndShield();
         if (r <= 60) return AxeAndShield();
         if (r <= 80) return Axe();

         return SpearAndShield();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestLordWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 10) return LordThrowingAxe();
         if (r <= 25) return LordAxe();
         if (r <= 50) return LordAxeAndShield();
         if (r <= 70) return LordSpearAndShield();

         return LordSwordAndShield();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestParticipantWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 30) return ThrowingAxe();
         if (r <= 60) return Axe();
         if (r <= 80) return AxeAndShield();
         if (r <= 90) return SwordAndShield();

         return SpearAndShield();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestPlayerWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 20) return ThrowingAxe();
         if (r <= 40) return SwordAndShield();
         if (r <= 60) return AxeAndShield();
         if (r <= 80) return Axe();

         return SpearAndShield();
      }

      #region private

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) Axe()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "sturgia_axe_2_t2_blunt").ToEquipmentElement());

         return (weapon0, null, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) AxeAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "sturgia_axe_2_t2_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "sturgia_old_shield_b").ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) CulturalEventThrowingAxes()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_throwing_axe_1_t1_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_throwing_axe_1_t1_blunt").ToEquipmentElement());
         var weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_throwing_axe_1_t1_blunt").ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_throwing_axe_1_t1_blunt").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordAxe()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "sturgia_axe_2_t2_blunt").ToEquipmentElement());

         return (weapon0, null, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordAxeAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "sturgia_axe_2_t2_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_round_sparring_shield").ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordSpearAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_spear_1_t2_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_round_sparring_shield").ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordSwordAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_round_sparring_shield").ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordThrowingAxe()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_throwing_axe_1_t1_blunt").ToEquipmentElement());
         var weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_throwing_axe_1_t1_blunt").ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_throwing_axe_1_t1_blunt").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SpearAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_spear_1_t2_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "sturgia_old_shield_b").ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SwordAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "sturgia_old_shield_b").ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) ThrowingAxe()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "seax_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_throwing_axe_1_t1_blunt").ToEquipmentElement());
         var weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_throwing_axe_1_t1_blunt").ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_throwing_axe_1_t1_blunt").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      #endregion
   }
}