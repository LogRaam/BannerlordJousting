// Code written by Gabriel Mailhot, 22/04/2023.

#region

using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

#endregion

namespace LogRaamJousting
{
   internal class Renown
   {
      public void GiveBonusRenown(Hero hero, float renown)
      {
         Clan clan = Hero.MainHero.Clan;
         int num = MathF.Round(renown);
         clan.Renown += renown;
      }
   }
}