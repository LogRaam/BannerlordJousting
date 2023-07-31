// Code written by Gabriel Mailhot, 21/07/2023.

#region

using LogRaamJousting.Equipments;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Armors
{
   public interface IBaseArmoury
   {
      public (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) RequestArmorForLevel(string culture, ArmorTier occupation);
   }
}