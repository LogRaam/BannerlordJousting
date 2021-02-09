// Code written by Gabriel Mailhot, 23/01/2021.

#region

using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.Source.TournamentGames;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting
{
   public class JoustParticipant
   {
      private CultureObject _culture = new CultureObject();


      internal void EquipParticipant(CultureObject cultureObject, TournamentParticipant participant)
      {
         _culture = cultureObject;
         participant.MatchEquipment = Equip(participant);
      }

      #region private

      private Equipment AssignEquipment(EquipmentElement weapon0, EquipmentElement weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3, EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes)
      {
         var result = new Equipment();

         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon0, weapon0);
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon1, weapon1);
         if (weapon2 != null) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon2, (EquipmentElement) weapon2);
         if (weapon3 != null) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon3, (EquipmentElement) weapon3);

         if (_culture.GetCultureCode() == CultureCode.Battania)
            if (Runtime.Config.Option == Options.DRESSED || Runtime.Config.Option == Options.UNDRESSEDEMPIRE)
               AssignGears(bodyArmor, headArmor, shoes, ref result);

         if (_culture.GetCultureCode() == CultureCode.Empire)
            if (Runtime.Config.Option == Options.DRESSED || Runtime.Config.Option == Options.UNDRESSEDBATTANIA)
               AssignGears(bodyArmor, headArmor, shoes, ref result);

         if (_culture.GetCultureCode() != CultureCode.Battania && _culture.GetCultureCode() != CultureCode.Empire && Runtime.Config.Option != Options.UNDRESSED) AssignGears(bodyArmor, headArmor, shoes, ref result);

         return result;
      }

      private void AssignGears(EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes, ref Equipment result)
      {
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Body, bodyArmor);
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Head, headArmor);
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Leg, shoes);
      }

      private void BuildMount(ref Equipment equipment, TournamentParticipant participant)
      {
         switch (participant.Character.Culture.GetCultureCode())
         {
            case CultureCode.Aserai:
               if (LogRaamRandom.EvalPercentage(50))
               {
                  equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.AseraiMounts.GetRandomElement()));
                  equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.HorseHarness, new EquipmentElement(Runtime.Equipment.Saddles.Find(n => n.StringId.Contains("camel"))));
               }
               else
               {
                  equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.EmpireMounts.GetRandomElement()));
                  equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.HorseHarness, new EquipmentElement(Runtime.Equipment.Saddles.Find(n => !n.StringId.Contains("camel"))));
               }

               return;
            case CultureCode.Empire:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.EmpireMounts.GetRandomElement()));

               break;
            case CultureCode.Sturgia:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.SturgiaMounts.GetRandomElement()));

               break;

            case CultureCode.Vlandia:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.VlandiaMounts.GetRandomElement()));

               break;
            case CultureCode.Khuzait:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.KhuzaitMounts.GetRandomElement()));

               break;
            case CultureCode.Battania:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Runtime.Equipment.BattaniaMounts.GetRandomElement()));

               break;
         }

         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.HorseHarness, new EquipmentElement(Runtime.Equipment.Saddles.Find(n => !n.StringId.Contains("camel"))));
      }

      private Equipment Equip(TournamentParticipant participant)
      {
         if (participant.IsPlayer) return EquipPlayer(participant);

         switch (participant.Character.Culture.GetCultureCode())
         {
            case CultureCode.Empire: return EquipEmpire(participant);
            case CultureCode.Sturgia: return EquipSturgia(participant);
            case CultureCode.Aserai: return EquipAserai(participant);
            case CultureCode.Vlandia: return EquipVlandia(participant);
            case CultureCode.Khuzait: return EquipKhuzait(participant);
            case CultureCode.Battania: return EquipBattanian(participant);
         }

         return EquipUnknown(participant);
      }

      private Equipment EquipAserai(TournamentParticipant participant)
      {
         if (participant.Character.IsMounted) return EquipAseraiMounted(participant);
         if (participant.Character.IsArcher) return EquipAseraiArcher();

         int i = LogRaamRandom.GenerateRandomNumber(50);

         if (i <= 5) return EquipAseraiTwoHander();
         if (i <= 25) return EquipAseraiOneHander();
         if (i <= 30) return EquipAseraiPolearm();

         return EquipAseraiThrower();
      }

      private Equipment EquipAseraiArcher()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.Bow.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Arrows.ToList().GetRandomElement());
         EquipmentElement weapon2 = weapon1;
         var weapon3 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());

         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipAseraiGears();

         return new Equipment(AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes));
      }

      private (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) EquipAseraiGears()
      {
         var bodyArmor = new EquipmentElement(Runtime.Equipment.AseraiBodyArmors.GetRandomElement());
         var headArmor = new EquipmentElement(Runtime.Equipment.AseraiHeadArmors.GetRandomElement());
         var shoes = new EquipmentElement(Runtime.Equipment.Boots.GetRandomElement());

         return (bodyArmor, headArmor, shoes);
      }

      private Equipment EquipAseraiMounted(TournamentParticipant participant)
      {
         EquipmentElement weapon0;
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (LogRaamRandom.EvalPercentage(50))
         {
            weapon0 = new EquipmentElement(Runtime.Equipment.Polearm.Find(n => n.StringId.Contains("spear")));
         }
         else if (LogRaamRandom.EvalPercentage(50))
         {
            weapon0 = new EquipmentElement(Runtime.Equipment.OneHanded.Where(n => n.StringId.Contains("sword")).ToList().GetRandomElement());
         }
         else if (LogRaamRandom.EvalPercentage(50))
         {
            weapon0 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
            weapon2 = new EquipmentElement(Runtime.Equipment.Polearm.Find(n => n.StringId == "bo_staff"));
         }
         else
         {
            weapon0 = new EquipmentElement(Runtime.Equipment.Bow.GetRandomElement());
            weapon2 = new EquipmentElement(Runtime.Equipment.Arrows.GetRandomElement());
            weapon3 = new EquipmentElement(Runtime.Equipment.Arrows.GetRandomElement());
         }

         var weapon1 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());

         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipAseraiGears();

         Equipment result = AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
         BuildMount(ref result, participant);

         return result;
      }

      private Equipment EquipAseraiOneHander()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.OneHanded.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipAseraiGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipAseraiPolearm()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipAseraiGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipAseraiThrower()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement weapon1 = weapon0;
         EquipmentElement weapon2 = weapon0;
         var weapon3 = new EquipmentElement(Runtime.Equipment.Polearm.Find(n => n.StringId == "bo_staff"));
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipAseraiGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipAseraiTwoHander()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.TwoHanded.Where(n => !n.StringId.Contains("axe") || !n.StringId.Contains("sword")).ToList().GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipAseraiGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) EquipBattaniaGears()
      {
         var bodyArmor = new EquipmentElement(Runtime.Equipment.BattaniaBodyArmors.GetRandomElement());
         var headArmor = new EquipmentElement(Runtime.Equipment.BattaniaHeadArmors.GetRandomElement());
         var shoes = new EquipmentElement(Runtime.Equipment.Boots.GetRandomElement());

         return (bodyArmor, headArmor, shoes);
      }

      private Equipment EquipBattanian(TournamentParticipant participant)
      {
         if (participant.Character.IsArcher) return EquipBattanianArcher();
         if (participant.Character.IsMounted) return EquipBattanianMounted(participant);

         int i = LogRaamRandom.GenerateRandomNumber(100);

         if (i <= 75) return EquipBattanianTwoHander();

         return EquipBattanianOneHander();
      }

      private Equipment EquipBattanianArcher()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.Bow.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Arrows.GetRandomElement());
         EquipmentElement weapon2 = weapon1;
         var weapon3 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipBattaniaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipBattanianMounted(TournamentParticipant participant)
      {
         EquipmentElement weapon0;
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (LogRaamRandom.EvalPercentage(50))
         {
            weapon0 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());
         }
         else if (LogRaamRandom.EvalPercentage(50))
         {
            weapon0 = new EquipmentElement(Runtime.Equipment.OneHanded.Where(n => n.StringId.Contains("sword")).ToList().GetRandomElement());
         }
         else
         {
            weapon0 = new EquipmentElement(Runtime.Equipment.Bow.GetRandomElement());
            weapon2 = new EquipmentElement(Runtime.Equipment.Arrows.GetRandomElement());
            weapon3 = new EquipmentElement(Runtime.Equipment.Arrows.GetRandomElement());
         }

         var weapon1 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());

         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipBattaniaGears();

         Equipment result = AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
         BuildMount(ref result, participant);

         return result;
      }

      private Equipment EquipBattanianOneHander()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.OneHanded.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipBattaniaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipBattanianPolearm()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.TwoHanded.Where(n => !n.StringId.Contains("spear")).ToList().GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipBattaniaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipBattanianThrower()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement weapon1 = weapon0;
         EquipmentElement weapon2 = weapon0;
         var weapon3 = new EquipmentElement(Runtime.Equipment.Polearm.Find(n => n.StringId == "bo_staff"));
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipBattaniaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipBattanianTwoHander()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.TwoHanded.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipBattaniaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipEmpire(TournamentParticipant participant)
      {
         if (participant.Character.IsArcher) return EquipEmpireArcher();
         if (participant.Character.IsMounted) return EquipEmpireMounted(participant);

         int i = LogRaamRandom.GenerateRandomNumber(100);

         if (i <= 10) return EquipEmpireTwoHander();
         if (i <= 33) return EquipEmpireOneHander();
         if (i <= 66) return EquipEmpirePolearm();

         return EquipEmpireThrower();
      }

      private Equipment EquipEmpireArcher()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.Bow.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Arrows.Find(n => n.StringId == "tournament_arrows"));
         EquipmentElement weapon2 = weapon1;
         var weapon3 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipEmpireGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) EquipEmpireGears()
      {
         var bodyArmor = new EquipmentElement(Runtime.Equipment.EmpireBodyArmors.GetRandomElement());
         var headArmor = new EquipmentElement(Runtime.Equipment.EmpireHeadArmors.GetRandomElement());
         var shoes = new EquipmentElement(Runtime.Equipment.Boots.GetRandomElement());

         return (bodyArmor, headArmor, shoes);
      }

      private Equipment EquipEmpireMounted(TournamentParticipant tournamentParticipant)
      {
         EquipmentElement weapon0;
         EquipmentElement? weapon3 = null;

         if (LogRaamRandom.EvalPercentage(50))
         {
            weapon0 = new EquipmentElement(Runtime.Equipment.Polearm.Where(n => n.StringId.Contains("spear")).ToList().GetRandomElement());
         }
         else if (LogRaamRandom.EvalPercentage(50))
         {
            weapon0 = new EquipmentElement(Runtime.Equipment.OneHanded.Where(n => n.StringId.Contains("sword")).ToList().GetRandomElement());
         }
         else
         {
            weapon0 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
            weapon3 = new EquipmentElement(Runtime.Equipment.Polearm.Find(n => n.StringId == "bo_staff"));
         }

         var weapon1 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement? weapon2 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipEmpireGears();
         Equipment result = AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
         BuildMount(ref result, tournamentParticipant);

         return result;
      }

      private Equipment EquipEmpireOneHander()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.OneHanded.Where(n => n.StringId.Contains("sword")).ToList().GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipEmpireGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipEmpirePolearm()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.Polearm.First(n => n.StringId.Contains("spear")));
         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipEmpireGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipEmpireThrower()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement weapon1 = weapon0;
         EquipmentElement weapon2 = weapon0;
         var weapon3 = new EquipmentElement(Runtime.Equipment.Polearm.Find(n => n.StringId == "bo_staff"));
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipEmpireGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipEmpireTwoHander()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.TwoHanded.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipEmpireGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipKhuzait(TournamentParticipant participant)
      {
         if (participant.Character.IsArcher) return EquipKhuzaitArcher();
         if (participant.Character.IsMounted) return EquipKhuzaitMounted(participant);

         int i = LogRaamRandom.GenerateRandomNumber(100);

         if (i <= 65) return EquipKhuzaitPolearm();

         return EquipKhuzaitThrower();
      }

      private Equipment EquipKhuzaitArcher()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.Bow.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Arrows.GetRandomElement());
         EquipmentElement weapon2 = weapon1;
         var weapon3 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipKhuzaitGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) EquipKhuzaitGears()
      {
         var bodyArmor = new EquipmentElement(Runtime.Equipment.KhuzaitBodyArmors.GetRandomElement());
         var headArmor = new EquipmentElement(Runtime.Equipment.KhuzaitHeadArmors.GetRandomElement());
         var shoes = new EquipmentElement(Runtime.Equipment.Boots.GetRandomElement());

         return (bodyArmor, headArmor, shoes);
      }

      private Equipment EquipKhuzaitMounted(TournamentParticipant participant)
      {
         EquipmentElement weapon0;
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (LogRaamRandom.EvalPercentage(50))
         {
            weapon0 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());
         }
         else
         {
            weapon0 = new EquipmentElement(Runtime.Equipment.Bow.GetRandomElement());
            weapon2 = new EquipmentElement(Runtime.Equipment.Arrows.GetRandomElement());
            weapon3 = new EquipmentElement(Runtime.Equipment.Arrows.GetRandomElement());
         }

         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());

         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipKhuzaitGears();

         Equipment result = AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
         BuildMount(ref result, participant);

         return result;
      }

      private Equipment EquipKhuzaitOneHander()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.OneHanded.Where(n => n.StringId.Contains("sword")).ToList().GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon2 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipKhuzaitGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipKhuzaitPolearm()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipKhuzaitGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipKhuzaitThrower()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement weapon1 = weapon0;
         EquipmentElement weapon2 = weapon0;
         var weapon3 = new EquipmentElement(Runtime.Equipment.Polearm.Find(n => n.StringId == "spear"));
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipKhuzaitGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipKhuzaitTwoHander()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.TwoHanded.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipKhuzaitGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipPlayer(TournamentParticipant participant)
      {
         int i = LogRaamRandom.GenerateRandomNumber(60);

         switch (participant.Character.Culture.GetCultureCode())
         {
            case CultureCode.Empire:
            {
               if (i <= 10) return EquipEmpireArcher();
               if (i <= 20) return EquipEmpireMounted(participant);
               if (i <= 30) return EquipEmpireOneHander();
               if (i <= 40) return EquipEmpireTwoHander();
               if (i <= 50) return EquipEmpirePolearm();
               if (i <= 60) return EquipEmpireThrower();

               break;
            }


            case CultureCode.Sturgia:
            {
               if (i <= 10) return EquipSturgiaArcher();
               if (i <= 20) return EquipSturgiaMounted(participant);
               if (i <= 30) return EquipSturgiaOneHander();
               if (i <= 40) return EquipSturgiaTwoHander();
               if (i <= 50) return EquipSturgiaPolearm();
               if (i <= 60) return EquipSturgiaThrower();

               break;
            }
            case CultureCode.Aserai:
            {
               if (i <= 10) return EquipAseraiArcher();
               if (i <= 20) return EquipAseraiMounted(participant);
               if (i <= 30) return EquipAseraiOneHander();
               if (i <= 40) return EquipAseraiTwoHander();
               if (i <= 50) return EquipAseraiPolearm();
               if (i <= 60) return EquipAseraiThrower();

               break;
            }
            case CultureCode.Vlandia:
            {
               if (i <= 10) return EquipVlandiaArcher();
               if (i <= 20) return EquipVlandiaMounted(participant);
               if (i <= 30) return EquipVlandiaOneHander();
               if (i <= 40) return EquipVlandiaTwoHander();
               if (i <= 50) return EquipVlandiaPolearm();
               if (i <= 60) return EquipVlandiaThrower();

               break;
            }
            case CultureCode.Khuzait:
            {
               if (i <= 10) return EquipKhuzaitArcher();
               if (i <= 20) return EquipKhuzaitMounted(participant);
               if (i <= 30) return EquipKhuzaitOneHander();
               if (i <= 40) return EquipKhuzaitTwoHander();
               if (i <= 50) return EquipKhuzaitPolearm();
               if (i <= 60) return EquipKhuzaitThrower();

               break;
            }
            case CultureCode.Battania:
            {
               if (i <= 10) return EquipBattanianArcher();
               if (i <= 20) return EquipBattanianMounted(participant);
               if (i <= 30) return EquipBattanianOneHander();
               if (i <= 40) return EquipBattanianTwoHander();
               if (i <= 50) return EquipBattanianPolearm();
               if (i <= 60) return EquipBattanianThrower();

               break;
            }
         }

         if (i <= 10) return EquipEmpireArcher();
         if (i <= 20) return EquipEmpireMounted(participant);
         if (i <= 30) return EquipEmpireOneHander();
         if (i <= 40) return EquipEmpireTwoHander();
         if (i <= 50) return EquipVlandiaPolearm();

         return EquipEmpireThrower();
      }

      private Equipment EquipSturgia(TournamentParticipant participant)
      {
         if (participant.Character.IsArcher) return EquipSturgiaArcher();
         if (participant.Character.IsMounted) return EquipSturgiaMounted(participant);

         int i = LogRaamRandom.GenerateRandomNumber(100);

         if (i <= 25) return EquipSturgiaTwoHander();
         if (i <= 50) return EquipSturgiaOneHander();
         if (i <= 75) return EquipSturgiaPolearm();

         return EquipSturgiaThrower();
      }

      private Equipment EquipSturgiaArcher()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.Bow.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Arrows.Find(n => n.StringId == "tournament_arrows"));
         EquipmentElement weapon2 = weapon1;
         var weapon3 = new EquipmentElement(Runtime.Equipment.OneHanded.GetRandomElement());
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipSturgiaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) EquipSturgiaGears()
      {
         var bodyArmor = new EquipmentElement(Runtime.Equipment.SturgiaBodyArmors.GetRandomElement());
         var headArmor = new EquipmentElement(Runtime.Equipment.SturgiaHeadArmors.GetRandomElement());
         var shoes = new EquipmentElement(Runtime.Equipment.Boots.GetRandomElement());

         return (bodyArmor, headArmor, shoes);
      }

      private Equipment EquipSturgiaMounted(TournamentParticipant participant)
      {
         EquipmentElement weapon0;
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         weapon0 = LogRaamRandom.EvalPercentage(50)
            ? new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement())
            : new EquipmentElement(Runtime.Equipment.OneHanded.GetRandomElement());

         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());

         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipSturgiaGears();

         Equipment result = AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
         BuildMount(ref result, participant);

         return result;
      }

      private Equipment EquipSturgiaOneHander()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.OneHanded.Where(n => n.StringId.Contains("sword")).ToList().GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon2 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipSturgiaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipSturgiaPolearm()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.Polearm.Where(n => n.StringId.Contains("spear")).ToList().GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipSturgiaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipSturgiaThrower()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement weapon1 = weapon0;
         EquipmentElement weapon2 = weapon0;
         var weapon3 = new EquipmentElement(Runtime.Equipment.Polearm.Find(n => n.StringId == "bo_staff"));
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipSturgiaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipSturgiaTwoHander()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.TwoHanded.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipSturgiaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipUnknown(TournamentParticipant participant)
      {
         if (participant.Character.IsArcher) return EquipUnknownArcher();
         if (participant.Character.IsMounted) return EquipUnknownMounted(participant);

         int i = LogRaamRandom.GenerateRandomNumber(100);

         if (i <= 25) return EquipUnknownTwoHander();
         if (i <= 50) return EquipUnknownOneHander();
         if (i <= 75) return EquipUnknownPolearm();

         return EquipUnknownThrower();
      }

      private Equipment EquipUnknownArcher()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.Bow.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Arrows.GetRandomElement());
         EquipmentElement weapon2 = weapon1;
         var weapon3 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipUnknownGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) EquipUnknownGears()
      {
         var bodyArmor = new EquipmentElement(Runtime.Equipment.EmpireBodyArmors.GetRandomElement());
         var headArmor = new EquipmentElement(Runtime.Equipment.VlandiaHeadArmors.GetRandomElement());
         var shoes = new EquipmentElement(Runtime.Equipment.Boots.GetRandomElement());

         return (bodyArmor, headArmor, shoes);
      }

      private Equipment EquipUnknownMounted(TournamentParticipant participant)
      {
         EquipmentElement weapon0;
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (LogRaamRandom.EvalPercentage(50))
         {
            weapon0 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());
         }
         else
         {
            weapon0 = new EquipmentElement(Runtime.Equipment.Bow.GetRandomElement());
            weapon2 = new EquipmentElement(Runtime.Equipment.Arrows.GetRandomElement());
            weapon3 = new EquipmentElement(Runtime.Equipment.Arrows.GetRandomElement());
         }

         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());

         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipUnknownGears();

         Equipment result = AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
         BuildMount(ref result, participant);

         return result;
      }

      private Equipment EquipUnknownOneHander()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.OneHanded.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipUnknownGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipUnknownPolearm()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipUnknownGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipUnknownThrower()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement weapon1 = weapon0;
         EquipmentElement weapon2 = weapon0;
         var weapon3 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipUnknownGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipUnknownTwoHander()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.TwoHanded.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipUnknownGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipVlandia(TournamentParticipant participant)
      {
         if (participant.Character.IsArcher) return EquipVlandiaArcher();
         if (participant.Character.IsMounted) return EquipVlandiaMounted(participant);

         int i = LogRaamRandom.GenerateRandomNumber(100);

         if (i <= 25) return EquipVlandiaTwoHander();
         if (i <= 50) return EquipVlandiaOneHander();

         return EquipVlandiaPolearm();
      }

      private Equipment EquipVlandiaArcher()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.Bow.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Arrows.Find(n => n.StringId == "tournament_arrows"));
         EquipmentElement weapon2 = weapon1;
         var weapon3 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipVlandiaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) EquipVlandiaGears()
      {
         var bodyArmor = new EquipmentElement(Runtime.Equipment.VlandiaBodyArmors.GetRandomElement());
         var headArmor = new EquipmentElement(Runtime.Equipment.VlandiaHeadArmors.GetRandomElement());
         var shoes = new EquipmentElement(Runtime.Equipment.Boots.GetRandomElement());

         return (bodyArmor, headArmor, shoes);
      }

      private Equipment EquipVlandiaMounted(TournamentParticipant participant)
      {
         EquipmentElement weapon0;
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (LogRaamRandom.EvalPercentage(50))
            weapon0 = new EquipmentElement(Runtime.Equipment.Polearm.Where(n => n.StringId.Contains("spear")).ToList().GetRandomElement());
         else if (LogRaamRandom.EvalPercentage(50))
            weapon0 = new EquipmentElement(Runtime.Equipment.OneHanded.Where(n => n.StringId.Contains("sword")).ToList().GetRandomElement());
         else
            weapon0 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());


         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());

         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipVlandiaGears();
         Equipment result = AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
         BuildMount(ref result, participant);

         return result;
      }

      private Equipment EquipVlandiaOneHander()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.OneHanded.Where(n => n.StringId.Contains("sword")).ToList().GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipVlandiaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipVlandiaPolearm()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.Polearm.Where(n => n.StringId.Contains("spear") || n.StringId.Contains("lance")).ToList().GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipVlandiaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipVlandiaThrower()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.ThrownWeapon.GetRandomElement());
         EquipmentElement weapon1 = weapon0;
         var weapon2 = new EquipmentElement(Runtime.Equipment.Polearm.GetRandomElement());
         var weapon3 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipVlandiaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      private Equipment EquipVlandiaTwoHander()
      {
         var weapon0 = new EquipmentElement(Runtime.Equipment.TwoHanded.GetRandomElement());
         var weapon1 = new EquipmentElement(Runtime.Equipment.Shield.GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;
         (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) = EquipVlandiaGears();

         return AssignEquipment(weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);
      }

      #endregion
   }
}