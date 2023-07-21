// Code written by Gabriel Mailhot, 23/04/2023.

#region

using System.Linq;
using LogRaamJousting.Decoupling;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Weapons
{
   public class BattaniaWeaponry : IWeaponry
   {
      public BattaniaWeaponry(Items items)
      {
         Items = items;
      }

      public Items Items { get; set; }
      
      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestCulturalEventWeapon()
      {
         return Lord2hMaul();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestFactionLeaderWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 40) return Lord2hSword();
         if (r <= 80) return LordArcherWithSwordAndTarge();

         return Lord2hMaul();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestHeroWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 35) return TwoHandedSword();
         if (r <= 70) return ArcherWithSwordAndTarge();

         return TwoHandedMaul();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestLordWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 30) return Lord2hSword();
         if (r <= 70) return LordArcherWithSwordAndTarge();

         return Lord2hMaul();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestParticipantWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 25) return TwoHandedSword();
         if (r <= 70) return ArcherWithSwordAndTarge();

         return TwoHandedMaul();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestPlayerWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 40) return TwoHandedSword();
         if (r <= 70) return ArcherWithSwordAndTarge();

         return TwoHandedMaul();
      }

      #region private

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) ArcherWithSwordAndTarge()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "battania_targe_b_sparring").ToEquipmentElement());
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "hunting_bow").ToEquipmentElement());
         EquipmentElement? weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "blunt_arrows").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) Lord2hMaul()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "peasant_maul_t1_2").ToEquipmentElement());

         return (weapon0, null, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) Lord2hSword()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "battania_2hsword_1_t2_blunt").ToEquipmentElement());

         return (weapon0, null, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordArcherWithSwordAndTarge()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "battania_targe_b_sparring").ToEquipmentElement());
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "hunting_bow").ToEquipmentElement());
         EquipmentElement? weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "blunt_arrows").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) TwoHandedMaul()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "peasant_maul_t1").ToEquipmentElement());

         return (weapon0, null, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) TwoHandedSword()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_2hsword_t1").ToEquipmentElement());

         return (weapon0, null, null, null);
      }

      #endregion
   }
}