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
   public class HeavyPolearm : GearsBase, IWeaponUser
   {
      private readonly CultureCode _culture;

      public HeavyPolearm(TournamentParticipant participant)
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
         int index1 = LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.Polearm.Count - 1);
         int index2 = LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.Shield.Count - 1);


         var result = new Weapons
         {
            MainWeapon = new EquipmentElement(Runtime.Equipment.Polearm.OrderByDescending(n => n.Effectiveness).ToList()[index1]),
            Shield = new EquipmentElement(Runtime.Equipment.Shield.OrderByDescending(n => n.Effectiveness).ToList()[index2])
         };


         return result;
      }

      #endregion
   }
}