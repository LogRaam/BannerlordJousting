// Code written by Gabriel Mailhot, 28/04/2023.

#region

using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.TournamentGames;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Decoupling
{
   public class Participant
   {
      private readonly TournamentParticipant _participant;
      private string _culture;
      private bool _isFactionLeader;
      private bool _isHero;
      private bool _isLord;
      private bool _isPlayer;
      private bool _isSoldier;
      private bool _isWanderer;
      private int _level;
      private Equipment _matchEquipment;


      public Participant(ref TournamentParticipant participant)
      {
         _participant = participant;
         _matchEquipment = _participant.MatchEquipment;

         _level = participant.Character.Level;
         if (participant.Character.HeroObject != null) _isFactionLeader = participant.Character.HeroObject.IsFactionLeader;
         _isLord = participant.Character.Occupation == Occupation.Lord;
         _isPlayer = participant.IsPlayer;
         _culture = participant.Character.Culture.GetCultureCode().ToString();
         _isSoldier = participant.Character.Occupation == Occupation.Soldier;
         _isWanderer = participant.Character.Occupation == Occupation.Wanderer;
      }

      public Participant() { }

      public string Culture
      {
         get
         {
            var state = new CampaignState();

            if (_participant.Character.Culture == null) return _culture;

            return state.GameStarted() || state.CampaignStarted()
               ? _participant.Character.Culture.GetCultureCode().ToString()
               : _culture;
         }
         set => _culture = value;
      }

      public bool IsFactionLeader
      {
         get
         {
            var state = new CampaignState();

            if (!state.GameStarted() && !state.CampaignStarted()) return _isFactionLeader;
            if (_participant.Character.HeroObject == null) return false;

            return _participant.Character.HeroObject.IsFactionLeader;
         }
         set => _isFactionLeader = value;
      }

      public bool IsHero
      {
         get
         {
            var state = new CampaignState();

            return state.GameStarted() || state.CampaignStarted()
               ? _participant.Character.IsHero
               : _isHero;
         }
         set => _isHero = value;
      }

      public bool IsLord
      {
         get
         {
            var state = new CampaignState();

            return state.GameStarted() || state.CampaignStarted()
               ? _participant.Character.Occupation == Occupation.Lord
               : _isLord;
         }
         set => _isLord = value;
      }

      public bool IsPlayer
      {
         get
         {
            var state = new CampaignState();

            return state.GameStarted() || state.CampaignStarted()
               ? _participant.IsPlayer
               : _isPlayer;
         }
         set => _isPlayer = value;
      }

      public bool IsSoldier
      {
         get
         {
            var state = new CampaignState();

            return state.GameStarted() || state.CampaignStarted()
               ? _participant.Character.Occupation == Occupation.Soldier
               : _isSoldier;
         }
         set => _isSoldier = value;
      }

      public bool IsWanderer
      {
         get
         {
            var state = new CampaignState();

            return state.GameStarted() || state.CampaignStarted()
               ? _participant.Character.Occupation == Occupation.Wanderer
               : _isWanderer;
         }
         set => _isWanderer = value;
      }

      public int Level
      {
         get
         {
            var state = new CampaignState();

            return state.GameStarted() || state.CampaignStarted()
               ? _participant.Character.Level
               : _level;
         }
         set => _level = value;
      }


      public Equipment MatchEquipment
      {
         get => _matchEquipment;
         set
         {
            var state = new CampaignState();
            if (state.GameStarted() || state.CampaignStarted()) _participant.MatchEquipment = _matchEquipment;
            _matchEquipment = value;
         }
      }

      public Equipment GetBattleEquipments()
      {
         var state = new CampaignState();

         if (state.GameStarted() && state.CampaignStarted()) return RefToGameParticipant().Character.BattleEquipments.First();

         return new Equipment();
      }

      public TournamentParticipant RefToGameParticipant() //bug: lorsque j'appel un type TournamentParticipant avec nUnit, j'ai un NullRef car le jeu ne roule pas et le ctor ne fonctionne qu'avec le runtime du jeu.  Je dois trouver une façon de ne pas utiliser ce type dans mes tests.
      {
         if (_participant == null) return new TournamentParticipant(new CharacterObject());

         return _participant;
      }
   }
}