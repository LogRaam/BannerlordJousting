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
   public class LightTwoHanded : GearsBase, IWeaponUser
   {
      private readonly CultureCode _culture;

      public LightTwoHanded(TournamentParticipant participant)
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
         int twIndex = LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.TwoHanded.Count - 2);
         int thIndex = LogRaamRandom.GenerateRandomNumber(Runtime.Equipment.ThrownWeapon.Count - 3);

         var result = new Weapons
         {
            MainWeapon = new EquipmentElement(Runtime.Equipment.TwoHanded.OrderBy(n => n.Effectiveness).ToList()[twIndex]),
            ThrowingWeapon = new EquipmentElement(Runtime.Equipment.ThrownWeapon.OrderBy(n => n.Effectiveness).ToList()[thIndex])
         };


         return result;
      }

      #endregion
   }
}