﻿// Code written by Gabriel Mailhot, 23/04/2023.

#region

using LogRaamJousting.Armors;
using LogRaamJousting.Configuration;
using LogRaamJousting.Factory;
using LogRaamJousting.Stables;
using LogRaamJousting.Weapons;
using TaleWorlds.CampaignSystem.TournamentGames;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Equipments
{
   public class EmpireKit : IPlugin
   {
      private const string Culture = "Empire";
      private const int MountedChanceBonus = 0;

      public TournamentParticipant ReferredParticipant;
      private readonly EquipmentPlugin _equipment;
      private readonly ISetup _get;
      private readonly IConfigLoader _loader;

      public EmpireKit(ISetup setup, EquipmentPlugin plugin, IConfigLoader configLoader)
      {
         _get = setup;
         _equipment = plugin;
         _loader = configLoader;
      }

      public Equipment Equip(IWeaponry weaponry, IArmoury armoury, IStable stable)
      {
         if (Runtime.IsCulturalEvent) _equipment.EquipCulturalEvent(weaponry, armoury, stable);

         if (_get.Configuration.ParticipantsUsesTheirOwnEquipments(Culture)) return _equipment.Participant.GetBattleEquipments();

         if (_equipment.Participant.IsPlayer) return _equipment.EquipPlayer(_get.ConfigLoader, Culture, weaponry, armoury, stable, MountedChanceBonus);
         if (_equipment.Participant.IsFactionLeader) return _equipment.EquipFactionLeader(_get.ConfigLoader, Culture, weaponry, armoury, stable);
         if (_equipment.Participant.IsLord) return _equipment.EquipLord(_get.ConfigLoader, Culture, weaponry, armoury, stable);
         if (_equipment.Participant.IsHero) return _equipment.EquipHero(_get.ConfigLoader, Culture, weaponry, armoury, stable, MountedChanceBonus);

         return _equipment.EquipParticipant(_get.ConfigLoader, Culture, weaponry, armoury);
      }
   }
}