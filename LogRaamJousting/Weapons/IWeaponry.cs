// Code written by Gabriel Mailhot, 23/04/2023.

#region

using LogRaamJousting.Decoupling;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Weapons
{
   public interface IWeaponry
   {
      Items Items { get; set; }
      (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestCulturalEventWeapon();
      (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestFactionLeaderWeapon();
      (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestHeroWeapon();
      (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestLordWeapon();
      (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestParticipantWeapon();
      (EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) RequestPlayerWeapon();
   }
}