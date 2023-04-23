// Code written by Gabriel Mailhot, 09/02/2021.

#region

using System.Collections.Generic;
using System.Linq;
using LogRaamJousting.Configuration;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.Source.TournamentGames;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Gears
{
   public class ClothingFactory : Clothing
   {
      public ClothingFactory(TournamentParticipant participant)
      {
         if (Runtime.Config.Option == Options.UNDRESSED) return;
         if (Runtime.HostCulture == CultureCode.Battania && Runtime.Config.Option == Options.UNDRESSEDBATTANIA) return;
         if (Runtime.HostCulture == CultureCode.Battania && Runtime.Config.Option == Options.UNDRESSEDMIXED) return;
         if (Runtime.HostCulture == CultureCode.Empire && Runtime.Config.Option == Options.UNDRESSEDEMPIRE) return;
         if (Runtime.HostCulture == CultureCode.Empire && Runtime.Config.Option == Options.UNDRESSEDMIXED) return;

         ChooseGearsFor(participant);
      }

      public Clothing GetClothes()
      {
         return new Clothing
         {
            HeadArmor = HeadArmor,
            BodyArmor = BodyArmor,
            Shoes = Shoes
         };
      }

      #region private

      private void ChooseEquipmentsFor(TournamentParticipant participant, List<ItemObject> bodyArmors, List<ItemObject> headArmors, List<ItemObject> boots)
      {
         var lordIndex = 4;
         if (participant.Character.Occupation == Occupation.Lord)
         {
            BodyArmor = new EquipmentElement(bodyArmors.OrderByDescending(n => n.Value).ToList()[LogRaamRandom.GenerateRandomNumber(lordIndex)]);
            HeadArmor = new EquipmentElement(headArmors.OrderByDescending(n => n.Value).ToList()[LogRaamRandom.GenerateRandomNumber(headArmors.Count)]);
            Shoes = new EquipmentElement(boots.OrderByDescending(n => n.Value).ToList()[LogRaamRandom.GenerateRandomNumber(boots.Count)]);
         }
         else
         {
            BodyArmor = new EquipmentElement(bodyArmors.OrderBy(n => n.Value).ToList()[LogRaamRandom.GenerateRandomNumber(bodyArmors.Count - lordIndex)]);
            HeadArmor = LogRaamRandom.EvalPercentage(25)
               ? new EquipmentElement(headArmors.OrderBy(n => n.Value).ToList()[LogRaamRandom.GenerateRandomNumber(headArmors.Count)])
               : new EquipmentElement();
            Shoes = new EquipmentElement(boots.OrderBy(n => n.Value).ToList()[LogRaamRandom.GenerateRandomNumber(boots.Count)]);
         }
      }

      private void ChooseGearsFor(TournamentParticipant participant)
      {
         switch (participant.Character.Culture.GetCultureCode())
         {
            case CultureCode.Invalid:
            case CultureCode.AnyOtherCulture:
            case CultureCode.Nord:
            case CultureCode.Darshi:
            case CultureCode.Vakken:
            case CultureCode.Empire:
            {
               ChooseEquipmentsFor(participant, Runtime.Equipment.EmpireBodyArmors, Runtime.Equipment.EmpireHeadArmors, Runtime.Equipment.Boots);

               break;
            }
            case CultureCode.Sturgia:
            {
               ChooseEquipmentsFor(participant, Runtime.Equipment.SturgiaBodyArmors, Runtime.Equipment.SturgiaHeadArmors, Runtime.Equipment.Boots);

               break;
            }
            case CultureCode.Aserai:
            {
               ChooseEquipmentsFor(participant, Runtime.Equipment.AseraiBodyArmors, Runtime.Equipment.AseraiHeadArmors, Runtime.Equipment.Boots);

               break;
            }
            case CultureCode.Vlandia:
            {
               ChooseEquipmentsFor(participant, Runtime.Equipment.VlandiaBodyArmors, Runtime.Equipment.VlandiaHeadArmors, Runtime.Equipment.Boots);

               break;
            }
            case CultureCode.Khuzait:
            {
               ChooseEquipmentsFor(participant, Runtime.Equipment.KhuzaitBodyArmors, Runtime.Equipment.KhuzaitHeadArmors, Runtime.Equipment.Boots);

               break;
            }
            case CultureCode.Battania:
            {
               ChooseEquipmentsFor(participant, Runtime.Equipment.BattaniaBodyArmors, Runtime.Equipment.BattaniaHeadArmors, Runtime.Equipment.Boots);

               break;
            }
         }
      }

      #endregion
   }
}