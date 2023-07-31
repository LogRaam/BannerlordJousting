// Code written by Gabriel Mailhot, 25/06/2023.

#region

using LogRaamJousting.Configuration;
using LogRaamJousting.Factory;
using LogRaamJousting.Options;

#endregion

namespace LogRaamJoustingTest.Substitutes
{
   internal class SetupSubstitute : ISetup
   {
      public SetupSubstitute()
      {
         ConfigLoader = new ConfigLoaderSubstitute();
         Configuration = new ConfigurationSubstitute();
         CultureOptions = new CultureOptions(ConfigLoader);
      }

      public SetupSubstitute(IConfigLoader configLoader, IConfig configuration, IOptions options)
      {
         ConfigLoader = configLoader;
         Configuration = configuration;
         CultureOptions = options;
      }

      public IConfigLoader ConfigLoader { get; }
      public IConfig Configuration { get; }
      public IOptions CultureOptions { get; }
   }
}