// Code written by Gabriel Mailhot, 23/04/2023.

#region

using System.Linq;
using LogRaamJousting.Decoupling;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Weapons
{
   public class VlandiaWeaponry : IWeaponry
   {
      public VlandiaWeaponry(Items items)
      {
         Items = items;
      }

      public Items Items { get; set; }
      
      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestCulturalEventWeapon()
      {
         return CulturalEventCrossbow();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestFactionLeaderWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 33) return LordSwordAndShield();
         if (r <= 67) return LordLanceAndShield();

         return LordCrossbowAndSword();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestHeroWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 33) return SwordAndShield();
         if (r <= 67) return LanceAndShield();

         return CrossbowAndSword();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestLordWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 40) return LordSwordAndShield();
         if (r <= 70) return LordLanceAndShield();

         return LordCrossbowAndSword();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestParticipantWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 50) return BillhookPolearm();

         return LanceAndShield();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestPlayerWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 33) return SwordAndShield();
         if (r <= 67) return LanceAndShield();
         if (r <= 100) return CrossbowAndSword();

         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2").ToEquipmentElement());

         return (weapon0, null, null, null);
      }

      #region private

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) BillhookPolearm()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "billhook_polearm_t2_blunt").ToEquipmentElement());

         return (weapon0, null, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) CrossbowAndSword()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "crossbow_a_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "tournament_bolts").ToEquipmentElement());
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "tournament_bolts").ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) CulturalEventCrossbow()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "crossbow_a_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "tournament_bolts").ToEquipmentElement());
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "tournament_bolts").ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "tournament_bolts").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LanceAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "vlandia_lance_1_t3_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.Where(n => n.StringId == "western_kite_sparring_shield" || n.StringId == "western_riders_kite_sparring_shield").ToList().GetRandomElement().ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordCrossbowAndSword()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "crossbow_a_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "tournament_bolts").ToEquipmentElement());
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "tournament_bolts").ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2").ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordLanceAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "vlandia_lance_1_t3_blunt").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "jousting_shield").ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LordSwordAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "jousting_shield").ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SwordAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1").ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.Where(n => n.StringId == "western_kite_sparring_shield" || n.StringId == "western_riders_kite_sparring_shield").ToList().GetRandomElement().ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      #endregion
   }
}