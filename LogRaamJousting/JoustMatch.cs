// Code written by Gabriel Mailhot, 28/04/2023.

#region

using System.Collections.Generic;
using LogRaamJousting.Decoupling;
using LogRaamJousting.Factory;

#endregion

namespace LogRaamJousting
{
   public class JoustMatch
   {
      private readonly IKit _equip;
      private readonly GameNetwork _gameNetwork;
      private readonly ISetup _get;
      private readonly string _hostCulture;
      private readonly List<Participant> _participants;

      public JoustMatch(GameNetwork gameNetwork, string hostCulture, bool isCulturalEvent, ref List<Participant> participants, ISetup setup, IKit kits)
      {
         _gameNetwork = gameNetwork;
         _hostCulture = hostCulture.ToUpper();
         Runtime.IsCulturalEvent = isCulturalEvent;
         _participants = participants;
         _get = setup;
         _equip = kits;
      }

      public void Start()
      {
         if (_gameNetwork.IsClientOrReplay) return;
         if (!_get.Configuration.ShouldApplyModForThisMatch(_hostCulture)) return;

         foreach (var participant in _participants)
         {
            var tournamentCulture = DefineTournamentCulture(_hostCulture, participant);

            if (tournamentCulture == "INVALID") continue;
            if (tournamentCulture == "ANYOTHERCULTURE") continue;

            if (tournamentCulture == "ASERAI") participant.RefToGameParticipant().MatchEquipment = _equip.DefaultAseraiKit(participant, _hostCulture);
            if (tournamentCulture == "EMPIRE") participant.RefToGameParticipant().MatchEquipment = _equip.DefaultEmpireKit(participant, _hostCulture);
            if (tournamentCulture == "STURGIA") participant.RefToGameParticipant().MatchEquipment = _equip.DefaultSturgiaKit(participant, _hostCulture);
            if (tournamentCulture == "VLANDIA") participant.RefToGameParticipant().MatchEquipment = _equip.DefaultVlandiaKit(participant, _hostCulture);
            if (tournamentCulture == "KHUZAIT") participant.RefToGameParticipant().MatchEquipment = _equip.DefaultKhuzaitKit(participant, _hostCulture);
            if (tournamentCulture == "BATTANIA") participant.RefToGameParticipant().MatchEquipment = _equip.DefaultBattaniaKit(participant, _hostCulture);
            if (tournamentCulture == "BYZANTINE") participant.RefToGameParticipant().MatchEquipment = _equip.DefaultByzantineKit(participant, _hostCulture);
            if (tournamentCulture == "AYYUBID") participant.RefToGameParticipant().MatchEquipment = _equip.DefaultAyyubidKit(participant, _hostCulture);
         }
      }

      #region private

      private string DefineTournamentCulture(string hostCulture, Participant participant)
      {
         var tournamentCulture = _get.Configuration.IsHostEnforcingHisCulture(hostCulture)
            ? hostCulture
            : participant.Culture.ToUpper();

         return tournamentCulture;
      }

      #endregion
   }
}