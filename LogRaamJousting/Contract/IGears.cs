// Code written by Gabriel Mailhot, 09/02/2021.

#region

using LogRaamJousting.Gears;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Contract
{
   public interface IGears
   {
      public Equipment AssignEquipment(Weapons weapons, Clothing clothing);
   }
}