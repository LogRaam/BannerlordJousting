// Code written by Gabriel Mailhot, 23/04/2023.

#region

using System.Linq;
using LogRaamJousting.Armors;
using LogRaamJousting.Configuration;
using LogRaamJousting.Decoupling;
using LogRaamJousting.Factory;
using LogRaamJousting.Options;
using LogRaamJousting.Stables;
using LogRaamJousting.Weapons;
using TaleWorlds.CampaignSystem.TournamentGames;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Equipments
{
   public class EquipmentPlugin
   {
      private ISetup _get;


      public EquipmentPlugin(ISetup setup)
      {
         _get = setup;
      }

      public EquipmentPlugin()
      {
         _get = new DefaultSetup();
      }

      public ICultureOption Options { get; set; }
      public Participant Participant { get; set; }
      public TournamentTeam Team { get; set; }
      public string TournamentCulture { get; set; }


      public ArmorTier ArmorQualityBonus()
      {
         if (Participant.IsPlayer) return ArmorTier.Wanderer;
         if (Participant.IsSoldier) return ArmorTier.Soldier;
         if (Participant.IsWanderer) return ArmorTier.Wanderer;
         if (Participant.IsLord) return ArmorTier.Lord;
         if (Participant.IsFactionLeader) return ArmorTier.FactionLeader;

         return ArmorTier.Wanderer;
      }

      public Equipment EquipCulturalEvent(IWeaponry weaponry, IArmoury armoury, IStable stable)
      {
         var result = new Equipment();

         var (weapon0, weapon1, weapon2, weapon3) = weaponry.RequestCulturalEventWeapon();
         PrepareWeapons(weapon0, weapon1, weapon2, weapon3, ref result);

         var (bodyArmor, headArmor, shoes) = armoury.RequestArmorForLevel(ArmorQualityBonus());
         PrepareProtectiveGears(bodyArmor, headArmor, shoes, ref result);

         var mount = stable.RequestMount();
         PrepareMount(mount, ref result);

         return result;
      }

      public Equipment EquipFactionLeader(IConfigLoader configLoader, string culture, IWeaponry weaponry, IArmoury armoury, IStable stable)
      {
         var result = new Equipment();

         (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) weapons = RetrieveParticipantWeapons();
         if (_get.Configuration.HostShouldProvideWeapons(culture)) weapons = weaponry.RequestFactionLeaderWeapon();
         PrepareWeapons(weapons.weapon0, weapons.weapon1, weapons.weapon2, weapons.weapon3, ref result);

         EquipArmor(configLoader, culture, armoury, ref result);

         var mount = stable.RequestMount(weapons);
         PrepareMount(mount, ref result);

         return result;
      }

      public Equipment EquipHero(IConfigLoader configLoader, string culture, IWeaponry weaponry, IArmoury armoury, IStable stable, int MountedChanceBonus)
      {
         var result = new Equipment();

         (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) weapons = RetrieveParticipantWeapons();
         if (_get.Configuration.HostShouldProvideWeapons(culture)) weapons = weaponry.RequestHeroWeapon();
         PrepareWeapons(weapons.weapon0, weapons.weapon1, weapons.weapon2, weapons.weapon3, ref result);

         EquipArmor(configLoader, culture, armoury, ref result);

         if (!LogRaamRandom.EvalPercentage(20 + Participant.Level)) return result; //TODO: REmove as it's a double
         if (CannotBeUsedOnHorse(weapons.weapon0, weapons.weapon1, weapons.weapon2, weapons.weapon3)) return result;

         if (!LogRaamRandom.EvalPercentage(MountedChanceBonus + Participant.Level)) return result;

         var mount = stable.RequestMount(weapons);
         PrepareMount(mount, ref result);

         return result;
      }

      public Equipment EquipLord(IConfigLoader configLoader, string culture, IWeaponry weaponry, IArmoury armoury, IStable stable)
      {
         var result = new Equipment();

         (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) weapons = RetrieveParticipantWeapons();
         if (_get.Configuration.HostShouldProvideWeapons(culture)) weapons = weaponry.RequestFactionLeaderWeapon();
         PrepareWeapons(weapons.weapon0, weapons.weapon1, weapons.weapon2, weapons.weapon3, ref result);

         EquipArmor(configLoader, culture, armoury, ref result);

         var mount = stable.RequestMount(weapons);
         PrepareMount(mount, ref result);

         return result;
      }

      public Equipment EquipParticipant(IConfigLoader configLoader, string culture, IWeaponry weaponry, IArmoury armoury)
      {
         var result = new Equipment();

         (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) weapons = RetrieveParticipantWeapons();
         if (_get.Configuration.HostShouldProvideWeapons(culture)) weapons = weaponry.RequestParticipantWeapon();
         PrepareWeapons(weapons.weapon0, weapons.weapon1, weapons.weapon2, weapons.weapon3, ref result);

         EquipArmor(configLoader, culture, armoury, ref result);

         return result;
      }

      public Equipment EquipPlayer(IConfigLoader configLoader, string culture, IWeaponry weaponry, IArmoury armoury, IStable stable, int MountedChanceBonus)
      {
         var result = new Equipment();

         (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) weapons = RetrieveParticipantWeapons();
         if (_get.Configuration.HostShouldProvideWeapons(culture)) weapons = weaponry.RequestPlayerWeapon();
         PrepareWeapons(weapons.weapon0, weapons.weapon1, weapons.weapon2, weapons.weapon3, ref result);

         EquipArmor(configLoader, culture, armoury, ref result);

         if (CannotBeUsedOnHorse(weapons.weapon0, weapons.weapon1, weapons.weapon2, weapons.weapon3)) return result;
         if (!LogRaamRandom.EvalPercentage(MountedChanceBonus + Participant.Level)) return result;

         var mount = stable.RequestMount(weapons);
         PrepareMount(mount, ref result);

         return result;
      }

      public void PrepareMount(EquipmentElement mount, ref Equipment equipment)
      {
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, mount);
      }

      public void PrepareProtectiveGears(EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes, ref Equipment result)
      {
         if (Options.ShouldBeNaked(TournamentCulture)) return;

         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Body, bodyArmor);
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Head, headArmor);
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Leg, shoes);
      }

      public void PrepareWeapons(EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3, ref Equipment result)
      {
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon0, weapon0);
         if (weapon1 != null) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon1, (EquipmentElement) weapon1);
         if (weapon2 != null) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon2, (EquipmentElement) weapon2);
         if (weapon3 != null) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon3, (EquipmentElement) weapon3);
      }

      public (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) RetrieveParticipantArmors()
      {
         var p = Participant.RefToGameParticipant().Character.BattleEquipments.First();
         var body = p.GetEquipmentFromSlot(EquipmentIndex.Body);
         var head = p.GetEquipmentFromSlot(EquipmentIndex.Head);
         var shoes = p.GetEquipmentFromSlot(EquipmentIndex.Leg);

         return (body, head, shoes);
      }

      public (EquipmentElement weapon0, EquipmentElement weapon1, EquipmentElement weapon2, EquipmentElement weapon3) RetrieveParticipantWeapons()
      {
         var p = Participant.RefToGameParticipant().Character.BattleEquipments.First();
         var w0 = p.GetEquipmentFromSlot(EquipmentIndex.Weapon0);
         var w1 = p.GetEquipmentFromSlot(EquipmentIndex.Weapon1);
         var w2 = p.GetEquipmentFromSlot(EquipmentIndex.Weapon2);
         var w3 = p.GetEquipmentFromSlot(EquipmentIndex.Weapon3);

         return (w0, w1, w2, w3);
      }

      public void SetSetup(ISetup setup)
      {
         _get = setup;
      }


      protected bool CannotBeUsedOnHorse(EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3)
      {
         var weapons = new[] {"military_fork_pike_t3", "peasant_hammer_2_t1", "sturgia_axe_2_t2_blunt"};

         foreach (var weapon in weapons)
         {
            if (weapon0.Item.StringId == weapon) return true;
            if (weapon1.HasValue && weapon1.Value.Item.StringId == weapon) return true;
            if (weapon2.HasValue && weapon2.Value.Item.StringId == weapon) return true;
            if (weapon3.HasValue && weapon3.Value.Item.StringId == weapon) return true;
         }

         return false;
      }

      protected bool EvalIfMounted(int percent)
      {
         return LogRaamRandom.EvalPercentage(percent);
      }

      protected Equipment PrepareEquipment(EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3, EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes, EquipmentElement? mount)
      {
         var result = new Equipment();

         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon0, weapon0);
         if (weapon1 != null) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon1, (EquipmentElement) weapon1);
         if (weapon2 != null) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon2, (EquipmentElement) weapon2);
         if (weapon3 != null) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon3, (EquipmentElement) weapon3);

         var c = Options.ShouldUseHostCulture(TournamentCulture)
            ? TournamentCulture
            : Participant.Culture;

         if (!Options.ShouldBeNaked(c)) AssignGears(bodyArmor, headArmor, shoes, ref result);

         return result;
      }

      #region private

      private void AssignGears(EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes, ref Equipment result)
      {
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Body, bodyArmor);
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Head, headArmor);
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Leg, shoes);
      }

      private Equipment EquipArmor(IConfigLoader configLoader, string culture, IArmoury armoury, ref Equipment result)
      {
         var armors = RetrieveParticipantArmors();
         if (_get.Configuration.HostShouldProvideArmors(culture)) armors = armoury.RequestArmorForLevel(ArmorQualityBonus());
         PrepareProtectiveGears(armors.bodyArmor, armors.headArmor, armors.shoes, ref result);

         return result;
      }

      #endregion
   }
}