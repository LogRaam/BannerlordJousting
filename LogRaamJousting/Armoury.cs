// Code written by Gabriel Mailhot, 15/01/2023.

#region

using System.Collections.Generic;
using System.Linq;
using LogRaamJousting.Configuration;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.TournamentGames;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting
{
   public class Armoury
   {
      public readonly Config _config;
      private readonly bool _activeLog = false;

      public Armoury()
      {
         _config = new Config(new ConfigLoader());
      }

      public Armoury(IConfigLoader configLoader)
      {
         _config = new Config(configLoader);
      }

      public JoustLogger Logger { get; set; }

      public CultureCode GetCultureCodeBasedOnOption(CultureCode tournamentCulture, CultureCode participantCulture)
      {
         return _config.ShouldUseHostCulture(tournamentCulture)
            ? tournamentCulture
            : participantCulture;
      }

      public Equipment RequestEquipmentFor(CultureCode tournamentCulture, TournamentParticipant participant)
      {
         if (_activeLog) Logger.LogHeaderInfoToFile(tournamentCulture, participant);

         var (weapon0, weapon1, weapon2, weapon3) = new Weaponry().SelectWeaponsForParticipant(tournamentCulture, participant.Character.Culture.GetCultureCode(), participant.Character.IsHero);

         Equipment result = PrepareEquipmentForParticipant(tournamentCulture, participant, weapon0, weapon1, weapon2, weapon3);

         if (_activeLog) Logger.LogToFile("____" + participant.Character.Name);

         return result;
      }

      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) AseraiLongSpearAndShield(bool isHero)
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "eastern_spear_1_t2_blunt"));
         EquipmentElement weapon1 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "curved_round_shield"))
            : new EquipmentElement(Items.All.Where(n => n.StringId == "Bound_desert_round_sparring_shield" || n.StringId == "bound_adarga").ToList().GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("AseraiLongSpearAndShield");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) AseraiSword(bool isHero)
      {
         EquipmentElement weapon0 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1"));
         EquipmentElement? weapon1 = null;
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("AseraiSword");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) AseraiSwordAndShield(bool isHero)
      {
         EquipmentElement weapon0 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1"));
         EquipmentElement weapon1 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "curved_round_shield"))
            : new EquipmentElement(Items.All.Where(n => n.StringId == "Bound_desert_round_sparring_shield" || n.StringId == "bound_adarga").ToList().GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("AseraiSwordAndShield");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) AseraiThrowingKnivesAndSword(bool isHero)
      {
         EquipmentElement weapon0 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1"));
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "desert_throwing_knife_blunt"));
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "desert_throwing_knife_blunt"));
         var weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "desert_throwing_knife_blunt"));

         if (_activeLog) Logger.LogToFile("AseraiThrowingKnivesAndSword");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) Battania2hMaul(bool isHero)
      {
         EquipmentElement weapon0 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "peasant_maul_t1_2"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "peasant_maul_t1"));
         EquipmentElement? weapon1 = null;
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("Battania2hMaul");

         return (weapon0, weapon1, weapon2, weapon3);
      }


      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) Battania2hSword()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_2hsword_t1"));
         EquipmentElement? weapon1 = null;
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("Battania2hSword");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) BattaniaArcherWithSwordAndShield(bool isHero)
      {
         EquipmentElement weapon0 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1"));
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "battania_targe_b_sparring"));
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "hunting_bow"));
         EquipmentElement? weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "blunt_arrows"));

         if (_activeLog) Logger.LogToFile("BattaniaArcherWithSwordAndShield");

         return (weapon0, weapon1, weapon2, weapon3);
      }


      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) EmpireFork(bool isHero)
      {
         EquipmentElement weapon0 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "military_fork_pike_t3"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "military_fork_t2"));
         EquipmentElement? weapon1 = null;
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("EmpireFork");

         return (weapon0, weapon1, weapon2, weapon3);
      }


      internal (EquipmentElement weapon0, EquipmentElement weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) EmpireJavelinThrower(bool isHero)
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "western_javelin_1_t2_blunt"));
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "western_javelin_1_t2_blunt"));
         var weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "western_javelin_1_t2_blunt"));
         EquipmentElement weapon3 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1"));

         if (_activeLog) Logger.LogToFile("EmpireJavelinThrower");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) EmpireSpearAndShield()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "empire_lance_1_t3_blunt"));
         var weapon1 = new EquipmentElement(Items.All.Where(n => n.StringId == "simple_horsemans_kite_shield" || n.StringId == "simple_kite_shield" || n.StringId == "worn_kite_shield").ToList().GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("EmpireSpearAndShieldGears");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) EmpireSwordAndShield(bool isHero)
      {
         EquipmentElement weapon0 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1"));
         var weapon1 = new EquipmentElement(Items.All.Where(n => n.StringId == "simple_kite_shield" || n.StringId == "worn_kite_shield").ToList().GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("EmpireSwordAndShield");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) KhuzaitArcherWithSword(bool isHero)
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "training_bow"));
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "blunt_arrows"));
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "blunt_arrows"));
         EquipmentElement weapon3 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1"));

         if (_activeLog) Logger.LogToFile("KhuzaitArcherWithSword");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) KhuzaitSpear(bool isHero)
      {
         EquipmentElement weapon0 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "eastern_spear_2_t3"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "khuzait_polearm_1_t4_blunt"));
         EquipmentElement? weapon1 = null;
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("KhuzaitSpear");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) KhuzaitSwordAndDagger(bool isHero)
      {
         EquipmentElement weapon0 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1"));
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "leafblade_throwing_knife"));
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "leafblade_throwing_knife"));
         EquipmentElement? weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "leafblade_throwing_knife"));

         if (_activeLog) Logger.LogToFile("KhuzaitSwordAndDagger");

         return (weapon0, weapon1, weapon2, weapon3);
      }


      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SturgiaAxe()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "sturgia_axe_2_t2_blunt"));
         EquipmentElement? weapon1 = null;
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("SturgiaAxe");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SturgiaAxeAndShield(bool isHero)
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "sturgia_axe_2_t2_blunt"));
         EquipmentElement weapon1 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "northern_round_sparring_shield"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "sturgia_old_shield_b"));
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("SturgiaAxeAndShield");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SturgiaSpearAndShield(bool isHero)
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_spear_1_t2_blunt"));
         EquipmentElement weapon1 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "northern_round_sparring_shield"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "sturgia_old_shield_b"));
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("SturgiaSpearAndShield");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SturgiaSwordAndShield(bool isHero)
      {
         EquipmentElement weapon0 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1"));
         EquipmentElement weapon1 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "northern_round_sparring_shield"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "sturgia_old_shield_b"));
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("SturgiaSwordAndShield");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SturgiaThrowingAxe()
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "seax_blunt"));
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_throwing_axe_1_t1_blunt"));
         var weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_throwing_axe_1_t1_blunt"));
         var weapon3 = new EquipmentElement(Items.All.First(n => n.StringId == "northern_throwing_axe_1_t1_blunt"));

         if (_activeLog) Logger.LogToFile("SturgiaThrowingAxe");

         return (weapon0, weapon1, weapon2, weapon3);
      }


      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) VlandiaCrossbowAndSword(bool isHero)
      {
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "crossbow_a_blunt"));
         var weapon1 = new EquipmentElement(Items.All.First(n => n.StringId == "tournament_bolts"));
         EquipmentElement? weapon2 = new EquipmentElement(Items.All.First(n => n.StringId == "tournament_bolts"));
         EquipmentElement weapon3 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1"));

         if (_activeLog) Logger.LogToFile("VlandiaCrossbowAndStaff");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) VlandiaLanceAndShield(bool isHero)
      {
         EquipmentElement weapon0 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "vlandia_lance_1_t3_blunt"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "military_fork_pike_t3"));
         EquipmentElement weapon1 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "jousting_shield"))
            : new EquipmentElement(Items.All.Where(n => n.StringId == "western_kite_sparring_shield" || n.StringId == "western_riders_kite_sparring_shield").ToList().GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("VlandiaLanceAndShield");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      internal (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) VlandiaSwordAndShield(bool isHero)
      {
         EquipmentElement weapon0 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t2"))
            : new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1"));
         EquipmentElement weapon1 = isHero
            ? new EquipmentElement(Items.All.First(n => n.StringId == "jousting_shield"))
            : new EquipmentElement(Items.All.Where(n => n.StringId == "western_kite_sparring_shield" || n.StringId == "western_riders_kite_sparring_shield").ToList().GetRandomElement());
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         if (_activeLog) Logger.LogToFile("VlandiaSwordAndShield");

         return (weapon0, weapon1, weapon2, weapon3);
      }

      #region private

      private void AssignGears(EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes, ref Equipment result)
      {
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Body, bodyArmor);
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Head, headArmor);
         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Leg, shoes);
      }


      private List<ItemObject> BodyArmor(CultureCode culture, TournamentParticipant tournamentParticipant)
      {
         //CultureCode c = GetCultureCodeBasedOnOption(culture, tournamentParticipant.Character.Culture.GetCultureCode());
         ItemObject.ItemTiers t = tournamentParticipant.Character.IsHero
            ? ItemObject.ItemTiers.Tier2
            : ItemObject.ItemTiers.Tier1;

         List<ItemObject> r0 = Items.All
                                    .Where(n => n.ItemType == ItemObject.ItemTypeEnum.BodyArmor)
                                    .Where(n => !n.StringId.Contains("dress"))
                                    .Where(n => n.Tier == t).ToList();

         List<ItemObject> r1 = FilterByCulture(culture, tournamentParticipant, r0);

         foreach (ItemObject o in r1)
            if (_activeLog)
               Logger.LogToFile(o.Name.ToString());


         return r1;
      }

      private void BuildMount(ref Equipment equipment, CultureCode tournamentCulture, TournamentParticipant tournamentParticipant)
      {
         CultureCode c = GetCultureCodeBasedOnOption(tournamentCulture, tournamentParticipant.Character.Culture.GetCultureCode());

         if (c == CultureCode.Aserai && LogRaamRandom.EvalPercentage(60))
            EquipCamel(ref equipment);
         else
            EquipHorse(ref equipment, tournamentCulture, tournamentParticipant);
      }

      private bool CannotBeUsedOnHorse(EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3)
      {
         var weapons = new[] {"military_fork_pike_t3", "peasant_hammer_2_t1", "sturgia_axe_2_t2_blunt"};

         foreach (string weapon in weapons)
         {
            if (weapon0.Item.StringId == weapon) return true;
            if (weapon1.HasValue && weapon1.Value.Item.StringId == weapon) return true;
            if (weapon2.HasValue && weapon2.Value.Item.StringId == weapon) return true;
            if (weapon3.HasValue && weapon3.Value.Item.StringId == weapon) return true;
         }

         return false;
      }

      private void EquipCamel(ref Equipment equipment)
      {
         equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Items.All.First(n => n.StringId.Contains("camel_tournament"))));
         if (_activeLog) Logger.LogToFile("EquipCamel");
      }

      private void EquipHorse(ref Equipment equipment, CultureCode tournamentCulture, TournamentParticipant participant)
      {
         CultureCode c = GetCultureCodeBasedOnOption(tournamentCulture, participant.Character.Culture.GetCultureCode());
         switch (c)
         {
            case CultureCode.Empire:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Items.All.First(n => n.StringId == "empire_horse_tournament")));

               break;
            case CultureCode.Sturgia:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Items.All.First(n => n.StringId == "sturgia_horse_tournament")));

               break;
            case CultureCode.Aserai:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Items.All.First(n => n.StringId == "aserai_horse_tournament")));

               break;
            case CultureCode.Vlandia:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Items.All.First(n => n.StringId == "vlandia_horse_tournament")));

               break;
            case CultureCode.Khuzait:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Items.All.First(n => n.StringId == "khuzait_horse_tournament")));

               break;
            case CultureCode.Battania:
               equipment.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Horse, new EquipmentElement(Items.All.First(n => n.StringId == "battania_horse_tournament")));

               break;
         }

         if (_activeLog) Logger.LogToFile("EquipHorse");
      }


      private bool EvalIfMounted(CultureCode tournamentCulture, TournamentParticipant participant)
      {
         if (participant.Character.HeroObject != null)
            if (participant.IsPlayer) return LogRaamRandom.EvalPercentage(participant.Character.Level * 2);
            else if (participant.Character.HeroObject.IsLord) return true;

         CultureCode c = GetCultureCodeBasedOnOption(tournamentCulture, participant.Character.Culture.GetCultureCode());

         switch (c)
         {
            case CultureCode.Empire:
               return LogRaamRandom.EvalPercentage(20);
            case CultureCode.Sturgia:
               return LogRaamRandom.EvalPercentage(15);
            case CultureCode.Aserai:
               return LogRaamRandom.EvalPercentage(50);
            case CultureCode.Vlandia:
               return LogRaamRandom.EvalPercentage(60);
            case CultureCode.Khuzait:
               return LogRaamRandom.EvalPercentage(70);
            case CultureCode.Battania:
               return LogRaamRandom.EvalPercentage(10);

            default:
               return false;
         }
      }

      private List<ItemObject> FilterByCulture(CultureCode culture, TournamentParticipant tournamentParticipant, List<ItemObject> items)
      {
         CultureCode c = GetCultureCodeBasedOnOption(culture, tournamentParticipant.Character.Culture.GetCultureCode());

         var result = new List<ItemObject>();

         foreach (ItemObject item in items)
         {
            CultureCode? t = item.Culture?.GetCultureCode();
            if (t == c) result.Add(item);
         }

         return result;
      }

      private List<ItemObject> HeadArmor(CultureCode culture, TournamentParticipant tournamentParticipant)
      {
         if (culture == CultureCode.Battania && new Config(new ConfigLoader()).ShouldUseHostCulture(culture)) return new List<ItemObject>();
         if (tournamentParticipant.Character.Culture.GetCultureCode() == CultureCode.Battania && !new Config(new ConfigLoader()).ShouldUseHostCulture(culture)) return new List<ItemObject>();


         ItemObject.ItemTiers t = tournamentParticipant.Character.IsHero
            ? ItemObject.ItemTiers.Tier2
            : ItemObject.ItemTiers.Tier1;

         if (tournamentParticipant.Character.HeroObject != null)
         {
            if (tournamentParticipant.Character.HeroObject.IsLord)
               t = ItemObject.ItemTiers.Tier4;
            if (tournamentParticipant.Character.HeroObject.IsFactionLeader)
               t = ItemObject.ItemTiers.Tier6;
         }

         if (tournamentParticipant.IsPlayer)
         {
            int num = tournamentParticipant.Character.Level;

            if (num < 5) t = ItemObject.ItemTiers.Tier1;
            else if (num < 10) t = ItemObject.ItemTiers.Tier2;
            else if (num < 15) t = ItemObject.ItemTiers.Tier3;
            else if (num < 20) t = ItemObject.ItemTiers.Tier4;
            else if (num < 25) t = ItemObject.ItemTiers.Tier5;
            else t = ItemObject.ItemTiers.Tier6;
         }

         IEnumerable<ItemObject> r0 = Items.All.ToList().Where(n => n.ItemType == ItemObject.ItemTypeEnum.HeadArmor).Where(n => n.Tier == t);
         List<ItemObject> r1 = FilterByCulture(culture, tournamentParticipant, r0.ToList()).ToList();

         return r1;
      }

      private Equipment PrepareEquipment(CultureCode culture, TournamentParticipant tournamentParticipant, EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3, EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes)
      {
         CultureCode c = GetCultureCodeBasedOnOption(culture, tournamentParticipant.Character.Culture.GetCultureCode());
         var config = new Config(new ConfigLoader());
         var result = new Equipment();

         result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon0, weapon0);
         if (weapon1 != null) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon1, (EquipmentElement) weapon1);
         if (weapon2 != null) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon2, (EquipmentElement) weapon2);
         if (weapon3 != null) result.AddEquipmentToSlotWithoutAgent(EquipmentIndex.Weapon3, (EquipmentElement) weapon3);

         c = config.ShouldUseHostCulture(culture)
            ? culture
            : tournamentParticipant.Character.Culture.GetCultureCode();

         if (!config.ShouldBeNaked(c)) AssignGears(bodyArmor, headArmor, shoes, ref result);
         else if (_activeLog) Logger.LogToFile("> NAKED <");

         return result;
      }

      private Equipment PrepareEquipmentForParticipant(CultureCode tournamentCulture, TournamentParticipant participant, EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3)
      {
         var (bodyArmor, headArmor, shoes) = SelectProtectiveGearsFor(tournamentCulture, participant);

         Equipment result = PrepareEquipment(tournamentCulture, participant, weapon0, weapon1, weapon2, weapon3, bodyArmor, headArmor, shoes);

         if (CannotBeUsedOnHorse(weapon0, weapon1, weapon2, weapon3)) return result;

         if (EvalIfMounted(tournamentCulture, participant))
            BuildMount(ref result, tournamentCulture, participant);

         return result;
      }


      private List<ItemObject> Saddles()
      {
         List<ItemObject> r0 = Items.All.ToList();

         List<ItemObject> r1 = r0.Where(n => n.ItemType == ItemObject.ItemTypeEnum.HorseHarness).ToList();
         if (!r1.Any()) r1 = r0;
         List<ItemObject> r2 = r1.Where(x => x.StringId == "light_harness" || x.StringId.Contains("camel")).ToList();
         if (!r2.Any()) r2 = r1;

         return r2;
      }

      private (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) SelectProtectiveGearsFor(CultureCode tournamentCulture, TournamentParticipant participant)
      {
         ItemObject a = FilterByCulture(tournamentCulture, participant, BodyArmor(tournamentCulture, participant)).GetRandomElement();
         ItemObject b = FilterByCulture(tournamentCulture, participant, HeadArmor(tournamentCulture, participant)).GetRandomElement();
         ItemObject c = TournamentBoots().GetRandomElement();

         if (_activeLog) Logger.LogEquipmentToFile(a, b, c);

         var bodyArmor = new EquipmentElement(a);
         var headArmor = new EquipmentElement(b);
         var shoes = new EquipmentElement(c);

         return (bodyArmor, headArmor, shoes);
      }


      private List<ItemObject> TournamentBoots()
      {
         List<ItemObject> r0 = Items.All.ToList();

         List<ItemObject> r1 = r0.Where(n => n.StringId == "strapped_shoes" || n.StringId == "wrapped_shoes").ToList();
         if (!r1.Any()) r1 = r0;

         return r1;
      }

      #endregion
   }
}