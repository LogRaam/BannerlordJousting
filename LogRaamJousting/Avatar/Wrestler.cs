// Code written by Gabriel Mailhot, 09/02/2021.

#region

using LogRaamJousting.Contract;
using LogRaamJousting.Gears;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Avatar
{
   public class Wrestler : GearsBase, IWeaponUser
   {
      public Wrestler()
      {
         Equipment = AssignEquipment(SetWeapons(), new Clothing
         {
            HeadArmor = new EquipmentElement(),
            BodyArmor = new EquipmentElement(),
            Shoes = new EquipmentElement()
         });
      }

      public Equipment Equipment { get; set; }

      public void AddMount()
      {
      }

      #region private

      private Weapons SetWeapons()
      {
         var result = new Weapons
         {
            MainWeapon = new EquipmentElement(),
            Arrows = new EquipmentElement(),
            Shield = new EquipmentElement(),
            SecondaryWeapon = new EquipmentElement(),
            ThrowingWeapon = new EquipmentElement()
         };

         return result;
      }

      #endregion
   }
}