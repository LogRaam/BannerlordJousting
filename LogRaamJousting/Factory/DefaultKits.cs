// Code written by Gabriel Mailhot, 25/06/2023.

#region

using LogRaamJousting.Armors;
using LogRaamJousting.Decoupling;
using LogRaamJousting.Equipments;
using LogRaamJousting.Stables;
using LogRaamJousting.Weapons;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Factory
{
   public class DefaultKits : IKit
   {
      private readonly EquipmentPlugin _equipment;
      private readonly ISetup _get;

      public DefaultKits(ISetup setup, EquipmentPlugin plugin)
      {
         _get = setup;
         _equipment = plugin;
      }

      public DefaultKits()
      {
         _get = new DefaultSetup();
         _equipment = new EquipmentPlugin(_get);
      }

      public Equipment DefaultAseraiKit(Participant participant, string hostCulture)
      {
         return new AseraiKit(_get, _equipment) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new AseraiWeaponry(new Items()), new AseraiArmoury(), new AseraiStable());
      }

      public Equipment DefaultAyyubidKit(Participant participant, string hostCulture)
      {
         return new AseraiKit(_get, _equipment) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new AseraiWeaponry(new Items()), new AseraiArmoury(), new AseraiStable());
      }

      public Equipment DefaultBattaniaKit(Participant participant, string hostCulture)
      {
         return new BattaniaKit(_get, _equipment) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new BattaniaWeaponry(new Items()), new BattaniaArmoury(), new BattaniaStable());
      }

      public Equipment DefaultByzantineKit(Participant participant, string hostCulture)
      {
         return new EmpireKit(_get, _equipment) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new EmpireWeaponry(new Items()), new EmpireArmoury(), new EmpireStable());
      }

      public Equipment DefaultEmpireKit(Participant participant, string hostCulture)
      {
         return new EmpireKit(_get, _equipment) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new EmpireWeaponry(new Items()), new EmpireArmoury(), new EmpireStable());
      }

      public Equipment DefaultKhuzaitKit(Participant participant, string hostCulture)
      {
         return new KhuzaitKit(_get, _equipment) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new KhuzaitWeaponry(new Items()), new KhuzaitArmoury(), new KhuzaitStable());
      }

      public Equipment DefaultSturgiaKit(Participant participant, string hostCulture)
      {
         return new SturgiaKit(_get, _equipment) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new SturgiaWeaponry(new Items()), new SturgiaArmoury(), new SturgiaStable());
      }

      public Equipment DefaultVlandiaKit(Participant participant, string hostCulture)
      {
         return new VlandiaKit(_get, _equipment) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new VlandiaWeaponry(new Items()), new VlandiaArmoury(), new VlandiaStable());
      }
   }
}