// Code written by Gabriel Mailhot, 23/04/2023.

#region

using LogRaamJousting.Equipments;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Armors
{
   public class AseraiArmoury : IArmoury
   {
      private readonly IBaseArmoury _base;
      /*
    public AseraiArmoury()
    {
       _base = new BaseArmoury();
    }
      */

      public AseraiArmoury(IBaseArmoury baseArmoury)
      {
         _base = baseArmoury;
      }

      public (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) RequestArmorForLevel(ArmorTier level)
      {
         return _base.RequestArmorForLevel("Aserai", level);
      }
   }
}