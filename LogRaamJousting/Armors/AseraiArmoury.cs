// Code written by Gabriel Mailhot, 23/04/2023.

#region

using LogRaamJousting.Equipments;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Armors
{
   public class AseraiArmoury : BaseArmoury, IArmoury
   {
      public (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) RequestArmorForLevel(ArmorTier level)
      {
         return base.RequestArmorForLevel("Aserai", level);
      }
   }
}