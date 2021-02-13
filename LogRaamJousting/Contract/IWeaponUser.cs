// Code written by Gabriel Mailhot, 09/02/2021.

#region

#endregion

#region

using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Contract
{
   public interface IWeaponUser
   {
      Equipment Equipment { get; set; }

      public void AddMount();
   }
}