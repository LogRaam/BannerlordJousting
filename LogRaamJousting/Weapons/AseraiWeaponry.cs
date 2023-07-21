// Code written by Gabriel Mailhot, 23/04/2023.

#region

using System.Linq;
using LogRaamJousting.Decoupling;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Weapons
{
   public class AseraiWeaponry : IWeaponry
   {
      public AseraiWeaponry(Items items)
      {
         Items = items;
      }

      public Items Items { get; set; }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestCulturalEventWeapon()
      {
         return CulturalEventThrowingKnives();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestFactionLeaderWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 10) return SingleSwordForFactionLeader();
         if (r <= 20) return ThrowingKnivesAndSwordForFactionLeader();
         if (r <= 50) return SwordAndShieldForFactionLeader();

         return LongSpearAndShieldForFactionLeader();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestHeroWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 25) return SingleSword();
         if (r <= 50) return ThrowingKnivesAndSword();
         if (r <= 75) return LongSpearAndShield();

         return SwordAndShield();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestLordWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 10) return SingleSwordForLord();
         if (r <= 20) return ThrowingKnivesAndSwordForLord();
         if (r <= 50) return LongSpearAndShieldForLord();

         return SwordAndShieldForLord();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestParticipantWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 25) return SingleSword();
         if (r <= 75) return ThrowingKnivesAndSword();

         return SwordAndShield();
      }

      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestPlayerWeapon()
      {
         int r = LogRaamRandom.GenerateRandomNumber(100);

         if (r <= 25) return SingleSword();
         if (r <= 50) return LongSpearAndShield();
         if (r <= 75) return ThrowingKnivesAndSword();

         return SwordAndShield();
      }

      #region private

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) CulturalEventThrowingKnives()
      {
         var weapon0 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "desert_throwing_knife_blunt")?.ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "desert_throwing_knife_blunt")?.ToEquipmentElement());
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "desert_throwing_knife_blunt")?.ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "desert_throwing_knife_blunt")?.ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LongSpearAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "eastern_spear_1_t2_blunt")?.ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.Where(n => n.StringId == "Bound_desert_round_sparring_shield" || n.StringId == "bound_adarga").ToList().GetRandomElement().ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LongSpearAndShieldForFactionLeader()
      {
         var weapon0 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "eastern_spear_1_t2_blunt")?.ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.Where(n => n.StringId == "curved_round_shield").ToList().GetRandomElement()?.ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) LongSpearAndShieldForLord()
      {
         var weapon0 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "eastern_spear_1_t2_blunt")?.ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.Where(n => n.StringId == "curved_round_shield").ToList().GetRandomElement()?.ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SingleSword()
      {
         var weapon0 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "wooden_sword_t1")?.ToEquipmentElement());

         return (weapon0, null, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SingleSwordForFactionLeader()
      {
         var weapon0 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "wooden_sword_t2")?.ToEquipmentElement());

         return (weapon0, null, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SingleSwordForLord()
      {
         var weapon0 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "wooden_sword_t2")?.ToEquipmentElement());

         return (weapon0, null, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SwordAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "wooden_sword_t1")?.ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.Where(n => n.StringId == "Bound_desert_round_sparring_shield" || n.StringId == "bound_adarga").ToList().GetRandomElement()?.ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SwordAndShieldForFactionLeader()
      {
         var weapon0 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "wooden_sword_t2")?.ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.Where(n => n.StringId == "curved_round_shield").ToList().GetRandomElement()?.ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SwordAndShieldForLord()
      {
         var weapon0 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "wooden_sword_t2")?.ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.Where(n => n.StringId == "curved_round_shield").ToList().GetRandomElement()?.ToEquipmentElement());

         return (weapon0, weapon1, null, null);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) ThrowingKnivesAndSword()
      {
         var weapon0 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "wooden_sword_t1")?.ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "desert_throwing_knife_blunt")?.ToEquipmentElement());
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "desert_throwing_knife_blunt")?.ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "desert_throwing_knife_blunt")?.ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) ThrowingKnivesAndSwordForFactionLeader()
      {
         var weapon0 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "wooden_sword_t2")?.ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "desert_throwing_knife_blunt")?.ToEquipmentElement());
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "desert_throwing_knife_blunt")?.ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "desert_throwing_knife_blunt")?.ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      private (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) ThrowingKnivesAndSwordForLord()
      {
         var weapon0 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "wooden_sword_t2")?.ToEquipmentElement());
         var weapon1 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "desert_throwing_knife_blunt")?.ToEquipmentElement());
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "desert_throwing_knife_blunt")?.ToEquipmentElement());
         var weapon3 = new EquipmentElement(Items.All.FirstOrDefault(n => n.StringId == "desert_throwing_knife_blunt")?.ToEquipmentElement());

         return (weapon0, weapon1, weapon2, weapon3);
      }

      #endregion
   }
}