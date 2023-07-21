// Code written by Gabriel Mailhot, 23/04/2023.

#region

#endregion

#region

using TaleWorlds.Core;

#endregion

namespace LogRaamJousting
{
   public static class Runtime
   {
      public static readonly JoustParticipant Participant = new JoustParticipant();
      public static CultureCode HostCulture { get; set; }
      public static bool IsCulturalEvent { get; set; }
   }
}