// Code written by Gabriel Mailhot, 25/06/2023.

#region

using LogRaamJousting.Decoupling;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Factory
{
   public interface IKit
   {
      Equipment DefaultAseraiKit(Participant participant, string hostCulture);
      Equipment DefaultAyyubidKit(Participant participant, string hostCulture);
      Equipment DefaultBattaniaKit(Participant participant, string hostCulture);
      Equipment DefaultByzantineKit(Participant participant, string hostCulture);
      Equipment DefaultEmpireKit(Participant participant, string hostCulture);
      Equipment DefaultKhuzaitKit(Participant participant, string hostCulture);
      Equipment DefaultSturgiaKit(Participant participant, string hostCulture);
      Equipment DefaultVlandiaKit(Participant participant, string hostCulture);
   }
}