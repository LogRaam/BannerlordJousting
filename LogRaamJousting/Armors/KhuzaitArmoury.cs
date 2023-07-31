// Code written by Gabriel Mailhot, 23/04/2023.

#region

using LogRaamJousting.Equipments;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Armors
{
   public class KhuzaitArmoury : BaseArmoury, IArmoury
   {
      private readonly IBaseArmoury _baseArmoury;

      public KhuzaitArmoury(IBaseArmoury baseArmoury)
      {
         _baseArmoury = baseArmoury;
      }

      public (EquipmentElement bodyArmor, EquipmentElement headArmor, EquipmentElement shoes) RequestArmorForLevel(ArmorTier level)
      {
         //return (new EquipmentElement(), new EquipmentElement(), new EquipmentElement());
         var (body, head, legs) = base.RequestArmorForLevel("Khuzait", level);

         //body = new EquipmentElement(); //BUG: Seems to have an issue with body armor: when request, game crash.  But when disabled (nude), game crashed trying to fetch armor factor of bones.
         //head = new EquipmentElement();
         //legs = new EquipmentElement();

         return (body, head, legs);
      }
   }
}