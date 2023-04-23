// Code written by Gabriel Mailhot, 02/03/2023.

#region

#endregion


#region

using LogRaamJousting.Options;
using TaleWorlds.Core;

#endregion

namespace LogRaamJousting.Configuration
{
   public class Config
   {
      private readonly IConfigLoader _loader;

      public Config(IConfigLoader loader)
      {
         _loader = loader;
      }

      private string[] _settings => _loader.RetrieveConfigDetails();


      public bool HaveToApplyModFor(CultureCode culture)
      {
         switch (culture)
         {
            case CultureCode.Empire:
               return new EmpireOptions().ShouldHappens(_settings);
            case CultureCode.Sturgia:
               return new SturgiaOptions().ShouldHappens(_settings);
            case CultureCode.Aserai:
               return new AseraiOptions().ShouldHappens(_settings);
            case CultureCode.Vlandia:
               return new VlandiaOptions().ShouldHappens(_settings);
            case CultureCode.Khuzait:
               return new KhuzaitOptions().ShouldHappens(_settings);
            case CultureCode.Battania:
               return new BattaniaOptions().ShouldHappens(_settings);
            default:
               return true;
         }
      }


      public bool ShouldBeNaked(CultureCode culture)
      {
         switch (culture)
         {
            case CultureCode.Empire:
               return new EmpireOptions().ShouldBeNaked(_settings);
            case CultureCode.Sturgia:
               return new SturgiaOptions().ShouldBeNaked(_settings);
            case CultureCode.Aserai:
               return new AseraiOptions().ShouldBeNaked(_settings);
            case CultureCode.Vlandia:
               return new VlandiaOptions().ShouldBeNaked(_settings);
            case CultureCode.Khuzait:
               return new KhuzaitOptions().ShouldBeNaked(_settings);
            case CultureCode.Battania:
               return new BattaniaOptions().ShouldBeNaked(_settings);
            default:
               return true;
         }
      }


      public bool ShouldUseHostCulture(CultureCode culture)
      {
         switch (culture)
         {
            case CultureCode.Empire:
               return new EmpireOptions().ShouldUseHostCulture(_settings);
            case CultureCode.Sturgia:
               return new SturgiaOptions().ShouldUseHostCulture(_settings);
            case CultureCode.Aserai:
               return new AseraiOptions().ShouldUseHostCulture(_settings);
            case CultureCode.Vlandia:
               return new VlandiaOptions().ShouldUseHostCulture(_settings);
            case CultureCode.Khuzait:
               return new KhuzaitOptions().ShouldUseHostCulture(_settings);
            case CultureCode.Battania:
               return new BattaniaOptions().ShouldUseHostCulture(_settings);
            default:
               return true;
         }
      }
   }
}