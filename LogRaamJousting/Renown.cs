// Code written by Gabriel Mailhot, 22/04/2023.

#region

using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

#endregion

namespace LogRaamJousting
{
   public class Renown
   {
      public void GiveBonusRenown(Hero hero, float renown)
      {
         Clan clan = hero.Clan;
         clan.Renown += MathF.Round(renown);
      }
   }
}