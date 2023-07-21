// Code written by Gabriel Mailhot, 23/04/2023.

#region

using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Stables
{
   public interface IStable
   {
      EquipmentElement RequestMount((EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) weaponry);
      EquipmentElement RequestMount();
   }
}