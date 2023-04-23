// Code written by Gabriel Mailhot, 10/03/2023.

#region

using System.Linq;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting
{
   public class Weaponry
   {
      public (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) SelectWeaponsForParticipant(CultureCode tournamentCulture, CultureCode participantCulture, bool isHero)
      {
         var armoury = new Armoury();
         var weapon0 = new EquipmentElement(Items.All.First(n => n.StringId == "wooden_sword_t1"));

         EquipmentElement? weapon1 = null;
         EquipmentElement? weapon2 = null;
         EquipmentElement? weapon3 = null;

         CultureCode c = armoury.GetCultureCodeBasedOnOption(tournamentCulture, participantCulture);

         int r = LogRaamRandom.GenerateRandomNumber(100);

         switch (c)
         {
            case CultureCode.Empire:

               if (r <= 25) return armoury.EmpireSpearAndShield();
               if (r <= 50) return armoury.EmpireJavelinThrower(isHero);
               if (r <= 75) return armoury.EmpireSwordAndShield(isHero);
               if (r <= 100) return armoury.EmpireFork(isHero);

               break;
            case CultureCode.Sturgia:

               if (r <= 20) return armoury.SturgiaThrowingAxe();
               if (r <= 40) return armoury.SturgiaSwordAndShield(isHero);
               if (r <= 60) return armoury.SturgiaAxeAndShield(isHero);
               if (r <= 80) return armoury.SturgiaAxe();
               if (r <= 100) return armoury.SturgiaSpearAndShield(isHero);

               break;
            case CultureCode.Aserai:
               if (r <= 25) return armoury.AseraiSword(isHero);
               if (r <= 50) return armoury.AseraiLongSpearAndShield(isHero);
               if (r <= 75) return armoury.AseraiThrowingKnivesAndSword(isHero);
               if (r <= 100) return armoury.AseraiSwordAndShield(isHero);

               break;
            case CultureCode.Vlandia:
               if (r <= 33) return armoury.VlandiaSwordAndShield(isHero);
               if (r <= 67) return armoury.VlandiaLanceAndShield(isHero);
               if (r <= 100) return armoury.VlandiaCrossbowAndSword(isHero);

               break;
            case CultureCode.Khuzait:
               if (r <= 33) return armoury.KhuzaitArcherWithSword(isHero);
               if (r <= 67) return armoury.KhuzaitSpear(isHero);
               if (r <= 100) return armoury.KhuzaitSwordAndDagger(isHero);

               break;
            case CultureCode.Battania:
               if (r <= 25) return armoury.Battania2hSword();
               if (r <= 50) return armoury.BattaniaArcherWithSwordAndShield(isHero);
               if (r <= 100) return armoury.Battania2hMaul(isHero);

               break;
         }


         return (weapon0, weapon1, weapon2, weapon3);
      }
   }
}