// Code written by Gabriel Mailhot, 23/04/2023.

#region

using LogRaamJousting.Armors;
using LogRaamJousting.Stables;
using LogRaamJousting.Weapons;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Equipments
{
   public interface IPlugin
   {
      Equipment Equip(IWeaponry weaponry, IArmoury armoury, IStable stable);
      //Equipment EquipCulturalEvent();
   }
}