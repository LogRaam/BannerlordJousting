// Code written by Gabriel Mailhot, 23/01/2021.

#region

using System;
using System.Collections.Generic;
using System.Linq;
using SandBox;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.Source.TournamentGames;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting
{
   public static class JoustingEquipParticipant
   {
      public static List<ItemObject> BodyArmor;
      public static List<ItemObject> Boots;
      public static List<ItemObject> Bow;
      public static List<ItemObject> HeadArmor;
      public static List<ItemObject> OneHanded;
      public static List<ItemObject> Polearm;
      public static List<ItemObject> Shield;
      public static List<ItemObject> ThrownWeapon;
      public static List<ItemObject> TwoHanded;
      internal static List<ItemObject> Arrows;
      internal static List<ItemObject> Bolts;
      internal static List<ItemObject> Mounts;
      internal static List<ItemObject> Saddles;

      internal static void EquipParticipant(TournamentFightMissionController __instance, CultureObject ____culture, TournamentParticipant participant)
      {
         participant.MatchEquipment = BuildViableEquipmentSet(____culture, participant);

         //AccessTools.Method(typeof(TournamentFightMissionController), "AddRandomClothes").Invoke(__instance, new object[] {____culture, participant});
      }

      #region private

      private static void BuildArmor(ref Equipment equipment, TournamentParticipant participant)
      {
         switch (participant.Character.Culture.GetCultureCode())
         {
            case CultureCode.Empire:
               ChooseArmorForEmpireParticipant(ref equipment);

               break;
            case CultureCode.Sturgia:
               ChooseArmorForSturgianParticipant(ref equipment);

               break;
            case CultureCode.Aserai:
               ChooseArmorForAseraiParticipant(ref equipment);

               break;
            case CultureCode.Vlandia:
               ChooseArmorForVlandianParticipant(ref equipment);

               break;
            case CultureCode.Khuzait:
               ChooseArmorForKhuzaitParticipant(ref equipment);

               break;
            case CultureCode.Battania:
               ChooseArmorForBattanianParticipant(ref equipment);

               break;
         }
      }

      private static void BuildMount(ref Equipment equipment, TournamentParticipant participant)
      {
         var p = 20;

         switch (participant.Character.Culture.GetCultureCode())
         {
            case CultureCode.Empire:
               p -= 10;

               break;
            case CultureCode.Sturgia:
               p -= 30;

               break;
            case CultureCode.Aserai:
               p += 10;

               break;
            case CultureCode.Vlandia:
               p += 20;

               break;
            case CultureCode.Khuzait:
               p += 30;

               break;
            case CultureCode.Battania:
               p -= 20;

               break;
         }

         if (participant.Character.DefaultFormationClass == FormationClass.Cavalry ||
             participant.Character.DefaultFormationClass == FormationClass.HeavyCavalry ||
             participant.Character.DefaultFormationClass == FormationClass.HorseArcher ||
             participant.Character.DefaultFormationClass == FormationClass.LightCavalry) p += 20;

         if (!LogRaamRandom.EvalPercentage(p)) return;
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Mounts.GetRandomElement()));
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.HorseHarness, new EquipmentElement(Saddles.GetRandomElement()));
      }

      private static Equipment BuildViableEquipmentSet(CultureObject culture, TournamentParticipant participant)
      {
         Equipment equipment = BuildWeapons(participant.Character.Culture);

         BuildMount(ref equipment, participant);
         BuildArmor(ref equipment, participant);

         return equipment.Clone();
      }

      private static Equipment BuildWeapons(CultureObject culture)
      {
         Equipment result;

         switch (ChooseBuildType(culture))
         {
            case BuildType.ONEHANDER:
            {
               result = GenerateOneHanderGears();

               break;
            }
            case BuildType.TWOHANDER:
            {
               result = GenerateTwoHanderGears();

               break;
            }
            case BuildType.POLEARM:
            {
               result = GeneratePolearmGears();

               break;
            }
            case BuildType.ARCHER:
            {
               result = GenerateArcherGears();

               break;
            }
            case BuildType.THROWER:
            {
               result = GenerateThrowerGears();

               break;
            }
            default:
               throw new ArgumentOutOfRangeException();
         }

         return result;
      }

      private static void ChooseArmorForAseraiParticipant(ref Equipment equipment)
      {
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Body, new EquipmentElement(BodyArmor.Where(n => n.StringId.Contains("coat")).GetRandomElement()));
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Head, new EquipmentElement(HeadArmor.GetRandomElement()));
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Leg, new EquipmentElement(Boots.GetRandomElement()));
      }

      private static void ChooseArmorForBattanianParticipant(ref Equipment equipment)
      {
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Body, new EquipmentElement(BodyArmor.Where(n => n.StringId.Contains("battanian") || n.StringId.Contains("underwear")).GetRandomElement()));
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Head, new EquipmentElement(HeadArmor.GetRandomElement()));
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Leg, new EquipmentElement(Boots.GetRandomElement()));
      }

      private static void ChooseArmorForEmpireParticipant(ref Equipment equipment)
      {
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Body, new EquipmentElement(BodyArmor.Where(n => n.StringId.Contains("empire")).GetRandomElement()));
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Head, new EquipmentElement(HeadArmor.GetRandomElement()));
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Leg, new EquipmentElement(Boots.GetRandomElement()));
      }

      private static void ChooseArmorForKhuzaitParticipant(ref Equipment equipment)
      {
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Body, new EquipmentElement(BodyArmor.Where(n => n.StringId.Contains("khuzait")).GetRandomElement()));
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Head, new EquipmentElement(HeadArmor.GetRandomElement()));
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Leg, new EquipmentElement(Boots.GetRandomElement()));
      }

      private static void ChooseArmorForSturgianParticipant(ref Equipment equipment)
      {
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Body, new EquipmentElement(BodyArmor.Where(n => n.StringId.Contains("bandit")).GetRandomElement()));
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Head, new EquipmentElement(HeadArmor.GetRandomElement()));
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Leg, new EquipmentElement(Boots.GetRandomElement()));
      }

      private static void ChooseArmorForVlandianParticipant(ref Equipment equipment)
      {
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Body, new EquipmentElement(BodyArmor.Where(n => n.StringId.Contains("vlandia")).GetRandomElement()));
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Head, new EquipmentElement(HeadArmor.GetRandomElement()));
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Leg, new EquipmentElement(Boots.GetRandomElement()));
      }

      private static BuildType ChooseBuildType(CultureObject culture)
      {
         int i = LogRaamRandom.GenerateRandomNumber(50);

         switch (culture.GetCultureCode())
         {
            case CultureCode.Empire:
               break;
            case CultureCode.Sturgia:
               i -= LogRaamRandom.GenerateRandomNumber(5);

               break;
            case CultureCode.Aserai:
               i += LogRaamRandom.GenerateRandomNumber(7);

               break;
            case CultureCode.Vlandia:
               i += LogRaamRandom.GenerateRandomNumber(5);

               break;
            case CultureCode.Khuzait:
               i += LogRaamRandom.GenerateRandomNumber(10);

               break;
            case CultureCode.Battania:
               i -= LogRaamRandom.GenerateRandomNumber(10);

               break;
         }

         if (i <= 10) return BuildType.TWOHANDER;
         if (i <= 20) return BuildType.ONEHANDER;
         if (i <= 30) return BuildType.POLEARM;
         if (i <= 40) return BuildType.THROWER;

         return BuildType.ARCHER;
      }

      private static Equipment GenerateArcherGears()
      {
         var result = new Equipment();

         var eq = new EquipmentElement(Bow.GetRandomElement());

         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon0, new EquipmentElement(OneHanded.GetRandomElement()));
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon1, eq);
         if (LogRaamRandom.EvalPercentage(50)) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon2, new EquipmentElement(Arrows.GetRandomElement()));
         if (LogRaamRandom.EvalPercentage(50)) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon4, new EquipmentElement(Arrows.GetRandomElement()));

         bool rollShield = LogRaamRandom.EvalPercentage(LogRaamRandom.GenerateRandomNumber(100));
         if (rollShield) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon3, new EquipmentElement(Shield.GetRandomElement()));

         if (eq.Item.Name.ToString() == "training_longbow") return result;

         if (LogRaamRandom.EvalPercentage(20)) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Mounts.GetRandomElement()));

         return result;
      }

      private static Equipment GenerateOneHanderGears()
      {
         var result = new Equipment();

         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon0, new EquipmentElement(OneHanded.GetRandomElement()));

         bool rollShield = LogRaamRandom.EvalPercentage(LogRaamRandom.GenerateRandomNumber(100));
         if (rollShield) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon3, new EquipmentElement(Shield.GetRandomElement()));

         return result;
      }

      private static Equipment GeneratePolearmGears()
      {
         var result = new Equipment();

         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon0, new EquipmentElement(Polearm.GetRandomElement()));

         bool rollShield = LogRaamRandom.EvalPercentage(LogRaamRandom.GenerateRandomNumber(100));
         if (rollShield) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon3, new EquipmentElement(Shield.GetRandomElement()));

         return result;
      }

      private static Equipment GenerateThrowerGears()
      {
         var result = new Equipment();

         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon0, new EquipmentElement(OneHanded.GetRandomElement()));
         if (LogRaamRandom.EvalPercentage(50)) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon1, new EquipmentElement(ThrownWeapon.GetRandomElement()));
         if (LogRaamRandom.EvalPercentage(50)) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon2, new EquipmentElement(ThrownWeapon.GetRandomElement()));

         bool rollShield = LogRaamRandom.EvalPercentage(LogRaamRandom.GenerateRandomNumber(100));
         if (rollShield) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon3, new EquipmentElement(Shield.GetRandomElement()));

         return result;
      }

      private static Equipment GenerateTwoHanderGears()
      {
         var result = new Equipment();

         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon0, new EquipmentElement(TwoHanded.GetRandomElement()));

         bool rollShield = LogRaamRandom.EvalPercentage(LogRaamRandom.GenerateRandomNumber(100));
         if (rollShield) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon3, new EquipmentElement(Shield.GetRandomElement()));

         return result;
      }

      #endregion
   }
}