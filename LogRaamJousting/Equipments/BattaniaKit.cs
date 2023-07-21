// Code written by Gabriel Mailhot, 23/04/2023.

#region

using System.Linq;
using LogRaamJousting.Armors;
using LogRaamJousting.Factory;
using LogRaamJousting.Stables;
using LogRaamJousting.Weapons;
using TaleWorlds.CampaignSystem.TournamentGames;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Equipments
{
   public class BattaniaKit : IPlugin
   {
      private const string Culture = "Battania";
      private const int MountedChanceBonus = -20;
      private readonly EquipmentPlugin _equipment;
      private readonly ISetup _get;

      public BattaniaKit(ISetup setup, EquipmentPlugin equipment)
      {
         _get = setup;
         _equipment = equipment;
      }

      public BattaniaKit()
      {
         _get = new DefaultSetup();
         _equipment = new EquipmentPlugin(new DefaultSetup());
      }


      public TournamentParticipant ReferredParticipant { get; set; }

      public Equipment Equip(IWeaponry weaponry, IArmoury armoury, IStable stable)
      {
         if (Runtime.IsCulturalEvent) _equipment.EquipCulturalEvent(weaponry, armoury, stable);

         if (_get.Configuration.ParticipantsUsesTheirOwnEquipments(Culture)) return _equipment.Participant.RefToGameParticipant().Character.BattleEquipments.First();

         if (_equipment.Participant.IsPlayer) return _equipment.EquipPlayer(_get.ConfigLoader, Culture, weaponry, armoury, stable, MountedChanceBonus);
         if (_equipment.Participant.IsFactionLeader) return _equipment.EquipFactionLeader(_get.ConfigLoader, Culture, weaponry, armoury, stable);
         if (_equipment.Participant.IsLord) return _equipment.EquipLord(_get.ConfigLoader, Culture, weaponry, armoury, stable);
         if (_equipment.Participant.IsHero) return _equipment.EquipHero(_get.ConfigLoader, Culture, weaponry, armoury, stable, MountedChanceBonus);

         return _equipment.EquipParticipant(_get.ConfigLoader, Culture, weaponry, armoury);
      }
   }
}