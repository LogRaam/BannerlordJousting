﻿// Code written by Gabriel Mailhot, 23/04/2023.

#region

using LogRaamJousting.Equipments;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Armors
{
   public class SturgiaArmoury : BaseArmoury, IArmoury
   {
      private readonly IBaseArmoury _baseArmoury;

      public SturgiaArmoury(IBaseArmoury baseArmoury)
      {
         _baseArmoury = baseArmoury;
      }

      public (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) RequestArmorForLevel(ArmorTier level)
      {
         return base.RequestArmorForLevel("Sturgia", level);
      }
   }
}