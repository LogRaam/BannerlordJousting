// Code written by Gabriel Mailhot, 23/01/2021.

#region

using System;
using LogRaamJousting.Avatar;
using LogRaamJousting.Contract;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.Source.TournamentGames;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting
{
   public class JoustParticipant
   {
      internal void EquipParticipant(TournamentParticipant participant)
      {
         participant.MatchEquipment = Equip(participant);
      }

      #region private

      private Equipment CulturalEventGears(TournamentParticipant participant)
      {
         switch (Runtime.HostCulture)
         {
            case CultureCode.Empire:  return new HeavyOneHanded(participant).Equipment;
            case CultureCode.Sturgia: return new Wrestler().Equipment;
            case CultureCode.Aserai:  return new HeavyThrower(participant).Equipment;
            case CultureCode.Vlandia:
            {
               var p = new HeavyPolearm(participant);
               p.AddMount();

               return p.Equipment;
            }
            case CultureCode.Khuzait:
            {
               var p = new LightArcher(participant);
               p.AddMount();

               return p.Equipment;
            }
            case CultureCode.Battania: return new HeavyTwoHanded(participant).Equipment;
         }

         throw new AppDomainUnloadedException("JOUSTING: Error, cannot setup a cultural event because culture code is not recognized. Please report this issue to LogRaam.");
      }

      private Equipment Equip(TournamentParticipant participant)
      {
         //return new LightTwoHanded(participant.Character.Culture.GetCultureCode()).Equipment; //for testing only

         if (Runtime.IsCulturalEvent) return CulturalEventGears(participant);

         if (participant.IsPlayer) return EquipPlayer(participant);

         switch (participant.Character.Culture.GetCultureCode())
         {
            case CultureCode.Empire:   return EquipEmpire(participant);
            case CultureCode.Sturgia:  return EquipSturgia(participant);
            case CultureCode.Aserai:   return EquipAserai(participant);
            case CultureCode.Vlandia:  return EquipSturgia(participant);
            case CultureCode.Khuzait:  return EquipKhuzait(participant);
            case CultureCode.Battania: return EquipBattanian(participant);
         }

         return EquipPlayer(participant);
      }

      private Equipment EquipAserai(TournamentParticipant participant)
      {
         if (participant.Character.Occupation == Occupation.Lord) return EquipAseraiLord(participant);

         IWeaponUser p = null;
         if (participant.Character.IsArcher)
            p = LogRaamRandom.EvalPercentage(25)
               ? new HeavyArcher(participant)
               : new LightArcher(participant);

         int i = LogRaamRandom.GenerateRandomNumber(40);

         if (i <= 10)
            p = LogRaamRandom.EvalPercentage(25)
               ? new HeavyTwoHanded(participant)
               : new LightTwoHanded(participant);

         else if (i <= 20)
            p = LogRaamRandom.EvalPercentage(75)
               ? new HeavyOneHanded(participant)
               : new LightOneHanded(participant);

         else if (i <= 30)
            p = LogRaamRandom.EvalPercentage(50)
               ? new HeavyThrower(participant)
               : new LightThrower(participant);

         else if (i <= 40)
            p = LogRaamRandom.EvalPercentage(50)
               ? new HeavyPolearm(participant)
               : new LightPolearm(participant);


         if (participant.Character.IsMounted) p.AddMount();

         return p.Equipment;
      }

      private Equipment EquipAseraiLord(TournamentParticipant participant)
      {
         IWeaponUser p = null;

         int i = LogRaamRandom.GenerateRandomNumber(40);

         if (i <= 10) p = new HeavyTwoHanded(participant);

         else if (i <= 20) p = new HeavyOneHanded(participant);

         else if (i <= 40) p = new HeavyPolearm(participant);

         p.AddMount();

         return p.Equipment;
      }

      private Equipment EquipBattaniaLord(TournamentParticipant participant)
      {
         IWeaponUser p = null;

         int i = LogRaamRandom.GenerateRandomNumber(30);

         if (i <= 10) p = new HeavyTwoHanded(participant);

         else if (i <= 20) p = new HeavyOneHanded(participant);

         else if (i <= 40) p = new HeavyPolearm(participant);


         p.AddMount();

         return p.Equipment;
      }


      private Equipment EquipBattanian(TournamentParticipant participant)
      {
         if (participant.Character.Occupation == Occupation.Lord) return EquipBattaniaLord(participant);

         IWeaponUser p = null;
         if (participant.Character.IsArcher)
            p = LogRaamRandom.EvalPercentage(50)
               ? new HeavyArcher(participant)
               : new LightArcher(participant);

         int i = LogRaamRandom.GenerateRandomNumber(40);

         if (i <= 10)
            p = LogRaamRandom.EvalPercentage(75)
               ? new HeavyTwoHanded(participant)
               : new LightTwoHanded(participant);

         else if (i <= 20)
            p = LogRaamRandom.EvalPercentage(50)
               ? new HeavyOneHanded(participant)
               : new LightOneHanded(participant);

         else if (i <= 30)
            p = LogRaamRandom.EvalPercentage(25)
               ? new HeavyThrower(participant)
               : new LightThrower(participant);

         else if (i <= 40)
            p = LogRaamRandom.EvalPercentage(25)
               ? new HeavyPolearm(participant)
               : new LightPolearm(participant);


         if (participant.Character.IsMounted) p.AddMount();

         return p.Equipment;
      }


      private Equipment EquipEmpire(TournamentParticipant participant)
      {
         if (participant.Character.Occupation == Occupation.Lord) return EquipEmpireLord(participant);

         IWeaponUser p = null;

         if (participant.Character.IsArcher)
            p = LogRaamRandom.EvalPercentage(25)
               ? new HeavyArcher(participant)
               : new LightArcher(participant);

         int i = LogRaamRandom.GenerateRandomNumber(40);

         if (i <= 10)
            p = LogRaamRandom.EvalPercentage(50)
               ? new HeavyTwoHanded(participant)
               : new LightTwoHanded(participant);

         else if (i <= 20)
            p = LogRaamRandom.EvalPercentage(75)
               ? new HeavyOneHanded(participant)
               : new LightOneHanded(participant);

         else if (i <= 30)
            p = LogRaamRandom.EvalPercentage(50)
               ? new HeavyThrower(participant)
               : new LightThrower(participant);

         else if (i <= 40)
            p = LogRaamRandom.EvalPercentage(25)
               ? new HeavyPolearm(participant)
               : new LightPolearm(participant);


         if (participant.Character.IsMounted) p.AddMount();

         return p.Equipment;
      }

      private Equipment EquipEmpireLord(TournamentParticipant participant)
      {
         IWeaponUser p = null;

         int i = LogRaamRandom.GenerateRandomNumber(30);

         if (i <= 10) p = new HeavyTwoHanded(participant);

         else if (i <= 20) p = new HeavyOneHanded(participant);

         else if (i <= 30) p = new HeavyPolearm(participant);


         p.AddMount();

         return p.Equipment;
      }


      private Equipment EquipKhuzait(TournamentParticipant participant)
      {
         if (participant.Character.Occupation == Occupation.Lord) return EquipKhuzaitLord(participant);

         IWeaponUser p = null;
         if (participant.Character.IsArcher)
            p = LogRaamRandom.EvalPercentage(75)
               ? new HeavyArcher(participant)
               : new LightArcher(participant);

         int i = LogRaamRandom.GenerateRandomNumber(40);

         if (i <= 10)
            p = LogRaamRandom.EvalPercentage(25)
               ? new HeavyTwoHanded(participant)
               : new LightTwoHanded(participant);

         else if (i <= 20)
            p = LogRaamRandom.EvalPercentage(25)
               ? new HeavyOneHanded(participant)
               : new LightOneHanded(participant);

         else if (i <= 30)
            p = LogRaamRandom.EvalPercentage(50)
               ? new HeavyThrower(participant)
               : new LightThrower(participant);

         else if (i <= 40)
            p = LogRaamRandom.EvalPercentage(50)
               ? new HeavyPolearm(participant)
               : new LightPolearm(participant);


         if (participant.Character.IsMounted) p.AddMount();

         return p.Equipment;
      }

      private Equipment EquipKhuzaitLord(TournamentParticipant participant)
      {
         IWeaponUser p = null;

         int i = LogRaamRandom.GenerateRandomNumber(30);

         if (i <= 10) p = new HeavyTwoHanded(participant);

         else if (i <= 20) p = new HeavyOneHanded(participant);

         else if (i <= 40) p = new HeavyPolearm(participant);


         p.AddMount();

         return p.Equipment;
      }


      private Equipment EquipPlayer(TournamentParticipant participant)
      {
         IWeaponUser p = null;
         int i = LogRaamRandom.GenerateRandomNumber(100);

         if (i <= 10) p = new HeavyArcher(participant);
         else if (i <= 20) p = new HeavyOneHanded(participant);
         else if (i <= 30) p = new HeavyPolearm(participant);
         else if (i <= 40) p = new HeavyThrower(participant);
         else if (i <= 50) p = new HeavyTwoHanded(participant);
         else if (i <= 60) p = new LightArcher(participant);
         else if (i <= 70) p = new LightOneHanded(participant);
         else if (i <= 80) p = new LightPolearm(participant);
         else if (i <= 90) p = new LightThrower(participant);
         else if (i <= 100) p = new LightTwoHanded(participant);


         if (LogRaamRandom.EvalPercentage(50)) p.AddMount();

         return p.Equipment;
      }

      private Equipment EquipSturgia(TournamentParticipant participant)
      {
         if (participant.Character.Occupation == Occupation.Lord) return EquipSturgiaLord(participant);

         IWeaponUser p = null;
         if (participant.Character.IsArcher)
            p = LogRaamRandom.EvalPercentage(25)
               ? new HeavyArcher(participant)
               : new LightArcher(participant);

         int i = LogRaamRandom.GenerateRandomNumber(40);

         if (i <= 10)
            p = LogRaamRandom.EvalPercentage(50)
               ? new HeavyTwoHanded(participant)
               : new LightTwoHanded(participant);

         else if (i <= 20)
            p = LogRaamRandom.EvalPercentage(50)
               ? new HeavyOneHanded(participant)
               : new LightOneHanded(participant);

         else if (i <= 30)
            p = LogRaamRandom.EvalPercentage(75)
               ? new HeavyThrower(participant)
               : new LightThrower(participant);

         else if (i <= 40)
            p = LogRaamRandom.EvalPercentage(25)
               ? new HeavyPolearm(participant)
               : new LightPolearm(participant);


         if (participant.Character.IsMounted) p.AddMount();

         return p.Equipment;
      }

      private Equipment EquipSturgiaLord(TournamentParticipant participant)
      {
         IWeaponUser p = null;

         int i = LogRaamRandom.GenerateRandomNumber(30);

         if (i <= 10) p = new HeavyTwoHanded(participant);

         else if (i <= 20) p = new HeavyOneHanded(participant);

         else if (i <= 30) p = new HeavyPolearm(participant);


         p.AddMount();

         return p.Equipment;
      }

      private Equipment EquipVlandia(TournamentParticipant participant)
      {
         if (participant.Character.Occupation == Occupation.Lord) return EquipVlandiaLord(participant);

         IWeaponUser p = null;
         if (participant.Character.IsArcher)
            p = LogRaamRandom.EvalPercentage(50)
               ? new HeavyArcher(participant)
               : new LightArcher(participant);

         int i = LogRaamRandom.GenerateRandomNumber(40);

         if (i <= 10)
            p = LogRaamRandom.EvalPercentage(25)
               ? new HeavyTwoHanded(participant)
               : new LightTwoHanded(participant);

         else if (i <= 20)
            p = LogRaamRandom.EvalPercentage(50)
               ? new HeavyOneHanded(participant)
               : new LightOneHanded(participant);

         else if (i <= 30)
            p = LogRaamRandom.EvalPercentage(25)
               ? new HeavyThrower(participant)
               : new LightThrower(participant);

         else if (i <= 40)
            p = LogRaamRandom.EvalPercentage(75)
               ? new HeavyPolearm(participant)
               : new LightPolearm(participant);


         if (participant.Character.IsMounted) p.AddMount();

         return p.Equipment;
      }

      private Equipment EquipVlandiaLord(TournamentParticipant participant)
      {
         IWeaponUser p = null;

         int i = LogRaamRandom.GenerateRandomNumber(40);

         if (i <= 10) p = new HeavyTwoHanded(participant);

         else if (i <= 20) p = new HeavyOneHanded(participant);

         else if (i <= 40) p = new HeavyPolearm(participant);


         p.AddMount();

         return p.Equipment;
      }

      #endregion
   }
}