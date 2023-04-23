// Code written by Gabriel Mailhot, 15/01/2023.

#region

using System;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting
{
   public class FootmanCulturalPreferencesDistribution
   {
      public int Archer(CultureCode culture)
      {
         return new FootmenWarCulture(culture).ArcherPercentage;
      }

      public int OneHander(CultureCode culture)
      {
         return new FootmenWarCulture(culture).OneHanderPercentage;
      }


      public int Polearm(CultureCode culture)
      {
         return new FootmenWarCulture(culture).PolearmPercentage;
      }

      public int Thrower(CultureCode culture)
      {
         return new FootmenWarCulture(culture).ThrowerPercentage;
      }

      public int TwoHander(CultureCode culture)
      {
         return new FootmenWarCulture(culture).TwoHanderPercentage;
      }
   }

   public class FootmenWarCulture
   {
      public readonly int ArcherPercentage;
      public readonly int OneHanderPercentage;
      public readonly int PolearmPercentage;
      public readonly int ThrowerPercentage;
      public readonly int TwoHanderPercentage;
      private readonly int[] _values = {50, 27, 15, 6, 2};

      public FootmenWarCulture(CultureCode culture)
      {
         var orderByPreference = GetOrderResultFor(culture);

         for (var i = 0; i < orderByPreference.Length; i++)
            switch (orderByPreference[i])
            {
               case BuildType.ONEHANDER:
                  OneHanderPercentage = _values[i];

                  break;
               case BuildType.TWOHANDER:
                  TwoHanderPercentage = _values[i];

                  break;
               case BuildType.POLEARM:
                  PolearmPercentage = _values[i];

                  break;
               case BuildType.ARCHER:
                  ArcherPercentage = _values[i];

                  break;
               case BuildType.THROWER:
                  ThrowerPercentage = _values[i];

                  break;
               default:
                  throw new ArgumentOutOfRangeException();
            }
      }

      #region private

      private BuildType[] GetOrderResultFor(CultureCode culture)
      {
         switch (culture)
         {
            case CultureCode.Empire:
               return new[] {BuildType.POLEARM, BuildType.ONEHANDER, BuildType.THROWER, BuildType.ARCHER, BuildType.TWOHANDER};
            case CultureCode.Sturgia:
               return new[] {BuildType.ONEHANDER, BuildType.POLEARM, BuildType.TWOHANDER, BuildType.THROWER, BuildType.ARCHER};
            case CultureCode.Aserai:
               return new[] {BuildType.ONEHANDER, BuildType.THROWER, BuildType.ARCHER, BuildType.TWOHANDER, BuildType.POLEARM};
            case CultureCode.Vlandia:
               return new[] {BuildType.POLEARM, BuildType.ONEHANDER, BuildType.ARCHER, BuildType.TWOHANDER, BuildType.THROWER};
            case CultureCode.Khuzait:
               return new[] {BuildType.ARCHER, BuildType.POLEARM, BuildType.ONEHANDER, BuildType.THROWER, BuildType.TWOHANDER};
            case CultureCode.Battania:
               return new[] {BuildType.TWOHANDER, BuildType.ARCHER, BuildType.POLEARM, BuildType.ARCHER, BuildType.ONEHANDER};
            default:
               return new[] {BuildType.THROWER, BuildType.TWOHANDER, BuildType.POLEARM, BuildType.ARCHER, BuildType.ONEHANDER};
         }
      }

      #endregion
   }
}