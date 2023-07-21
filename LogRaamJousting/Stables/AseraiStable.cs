// Code written by Gabriel Mailhot, 23/04/2023.

#region

using System.Linq;
using LogRaamJousting.Decoupling;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Stables
{
   public class AseraiStable : IStable
   {
      public EquipmentElement RequestMount((EquipmentElement weapon0, EquipmentElement? weapon1, EquipmentElement? weapon2, EquipmentElement? weapon3) weaponry)
      {
         return RequestMount();
      }

      public EquipmentElement RequestMount()
      {
         var result = LogRaamRandom.EvalPercentage(70)
            ? new EquipmentElement(new Items().All.FirstOrDefault(n => n.StringId.Contains("camel_tournament"))?.ToEquipmentElement())
            : new EquipmentElement(new Items().All.FirstOrDefault(n => n.StringId == "aserai_horse_tournament")?.ToEquipmentElement());

         return result;
      }
   }
}