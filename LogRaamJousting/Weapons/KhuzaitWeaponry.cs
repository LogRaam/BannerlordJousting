// Code written by Gabriel Mailhot, 23/04/2023.

#region

using System.Linq;
using LogRaamJousting.Decoupling;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Weapons
{
   public class KhuzaitWeaponry : IWeaponry
   {
      public KhuzaitWeaponry(Items items)
      {
         Items = items;
      }

      public Items Items { get; set; }
      public JoustLogger Logger { get; set; }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestCulturalEventWeapon()
      {
         return CulturalEventBow();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestFactionLeaderWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 20) return LordSwordAndDagger();
         if (r <= 60) return LordArcherWithSword();

         return LordSpear();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestHeroWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 33) return ArcherWithSword();
         if (r <= 67) return Spear();

         return SwordAndDagger();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestLordWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 20) return LordSwordAndDagger();
         if (r <= 80) return LordArcherWithSword();

         return LordSpear();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestParticipantWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 40) return ArcherWithSword();
         if (r <= 70) return Spear();

         return SwordAndDagger();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestPlayerWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 40) return ArcherWithSword();
         if (r <= 70) return Spear();

         return SwordAndDagger();
      }

      #region private

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) ArcherWithSword()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "training_bow").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "blunt_arrows").ToEquipmentElement());
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "blunt_arrows").ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) CulturalEventBow()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "training_bow").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "blunt_arrows").ToEquipmentElement());
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "blunt_arrows").ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "blunt_arrows").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordArcherWithSword()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "training_bow").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "blunt_arrows").ToEquipmentElement());
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "blunt_arrows").ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordSpear()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "khuzait_polearm_1_t4_blunt").ToEquipmentElement());

         return (weapon0, null, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordSwordAndDagger()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "leafblade_throwing_knife").ToEquipmentElement());
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "leafblade_throwing_knife").ToEquipmentElement());
         EquipmentElement? weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "leafblade_throwing_knife").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) Spear()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "eastern_spear_1_t2_blunt").ToEquipmentElement()); //practice_spear_t1

         return (weapon0, null, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SwordAndDagger()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "leafblade_throwing_knife").ToEquipmentElement());
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "leafblade_throwing_knife").ToEquipmentElement());
         EquipmentElement? weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "leafblade_throwing_knife").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      #endregion
   }
}