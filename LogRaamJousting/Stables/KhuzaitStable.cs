﻿// Code written by Gabriel Mailhot, 23/04/2023.

#region

using System.Linq;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Stables
{
   public class KhuzaitStable : IStable
   {
      public EquipmentElement RequestMount((EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) weaponry)
      {
         return RequestMount();
      }

      public EquipmentElement RequestMount()
      {
         var result = new EquipmentElement(Items.All.First(n => n.StringId == "khuzait_horse_tournament"));

         return result;
      }
   }
}