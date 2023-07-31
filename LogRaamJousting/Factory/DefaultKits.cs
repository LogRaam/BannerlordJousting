// Code written by Gabriel Mailhot, 25/06/2023.

#region

using LogRaamJousting.Armors;
using LogRaamJousting.Configuration;
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
      private readonly IBaseArmoury _baseArmoury;
      private readonly ISetup _get;
      private readonly IConfigLoader _loader;

      public DefaultKits(ISetup setup, IConfigLoader configLoader, IBaseArmoury baseArmoury)
      {
         _get = setup;
         _loader = configLoader;
         _baseArmoury = baseArmoury;
      }

      /*
      public DefaultKits()
      {
         _get = new DefaultSetup();
      }
      */

      public Equipment DefaultAseraiKit(Participant participant, string hostCulture)
      {
         return new AseraiKit(_get, new EquipmentPlugin(new DefaultSetup(), new Config(), hostCulture, participant), _loader) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new AseraiWeaponry(new Items()), new AseraiArmoury(_baseArmoury), new AseraiStable());
      }

      public Equipment DefaultAyyubidKit(Participant participant, string hostCulture)
      {
         return new AseraiKit(_get, new EquipmentPlugin(new DefaultSetup(), new Config(), hostCulture, participant), _loader) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new AseraiWeaponry(new Items()), new AseraiArmoury(_baseArmoury), new AseraiStable());
      }

      public Equipment DefaultBattaniaKit(Participant participant, string hostCulture)
      {
         return new BattaniaKit(_get, new EquipmentPlugin(new DefaultSetup(), new Config(), hostCulture, participant), _loader) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new BattaniaWeaponry(new Items()), new BattaniaArmoury(_baseArmoury), new BattaniaStable());
      }

      public Equipment DefaultByzantineKit(Participant participant, string hostCulture)
      {
         return new EmpireKit(_get, new EquipmentPlugin(new DefaultSetup(), new Config(), hostCulture, participant), _loader) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new EmpireWeaponry(new Items()), new EmpireArmoury(_baseArmoury), new EmpireStable());
      }

      public Equipment DefaultEmpireKit(Participant participant, string hostCulture)
      {
         return new EmpireKit(_get, new EquipmentPlugin(new DefaultSetup(), new Config(), hostCulture, participant), _loader) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new EmpireWeaponry(new Items()), new EmpireArmoury(_baseArmoury), new EmpireStable());
      }

      public Equipment DefaultKhuzaitKit(Participant participant, string hostCulture)
      {
         return new KhuzaitKit(_get, new EquipmentPlugin(new DefaultSetup(), new Config(), hostCulture, participant), _loader) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new KhuzaitWeaponry(new Items()), new KhuzaitArmoury(_baseArmoury), new KhuzaitStable());
      }

      public Equipment DefaultSturgiaKit(Participant participant, string hostCulture)
      {
         return new SturgiaKit(_get, new EquipmentPlugin(new DefaultSetup(), new Config(), hostCulture, participant), _loader) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new SturgiaWeaponry(new Items()), new SturgiaArmoury(_baseArmoury), new SturgiaStable());
      }

      public Equipment DefaultVlandiaKit(Participant participant, string hostCulture)
      {
         return new VlandiaKit(_get, new EquipmentPlugin(new DefaultSetup(), new Config(), hostCulture, participant), _loader) {
            ReferredParticipant = participant.RefToGameParticipant()
         }.Equip(new VlandiaWeaponry(new Items()), new VlandiaArmoury(_baseArmoury), new VlandiaStable());
      }
   }
}