// Code written by Gabriel Mailhot, 02/02/2021.

using LogRaamJousting.Configuration;
using TaleWorlds.Core;


namespace LogRaamJousting
{
   public static class Runtime
   {
      public static readonly Config Config = new Config();
      public static readonly EquipmentStock Equipment = new EquipmentStock();
      public static readonly JoustParticipant Participant = new JoustParticipant();
      public static CultureCode HostCulture { get; set; }
      public static bool IsCulturalEvent { get; set; }
   }
}