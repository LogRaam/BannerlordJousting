// Code written by Gabriel Mailhot, 09/02/2021.

#region

using System.Linq;
using LogRaamJousting.Contract;
using LogRaamJousting.Gears;
using TaleWorlds.CampaignSystem.SandBox.Source.TournamentGames;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Avatar
{
   public class LightArcher : GearsBase, IWeaponUser
   {
      private readonly CultureCode _culture;

      public LightArcher(TournamentParticipant participant)
      {
         _culture = participant.Character.Culture.GetCultureCode();
         Equipment = AssignEquipment(SetWeapons(), new ClothingFactory(participant).GetClothes());
      }

      public Equipment Equipment { get; set; }

      public void AddMount()
      {
         if (!IsMountedThisTime(_culture)) return;

         Equipment = AssignMount(Equipment, _culture);
      }

      #region private

      private Weapons SetWeapons()
      {
         int index1 = LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.Bow.Count - 1);
         int index2 = LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.Arrows.Count - 1);
         int index3 = LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.Polearm.Count - 3);
         int index4 = LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.OneHanded.Count - 3);

         var result = new Weapons
         {
            MainWeapon = new EquipmentElement(Runtime.Equipment.Bow.OrderBy(n => n.Effectiveness).ToList()[index1]),
            Arrows = new EquipmentElement(Runtime.Equipment.Arrows.OrderBy(n => n.Effectiveness).ToList()[index2]),
            SecondaryWeapon = LogRaamRandom.EvalPercentage(50)
               ? new EquipmentElement(Runtime.Equipment.Polearm.OrderBy(n => n.Effectiveness).ToList()[index3])
               : new EquipmentElement(Runtime.Equipment.OneHanded.OrderBy(n => n.Effectiveness).ToList()[index4])
         };


         return result;
      }

      #endregion
   }
}