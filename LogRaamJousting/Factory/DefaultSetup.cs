// Code written by Gabriel Mailhot, 25/06/2023.

#region

using LogRaamJousting.Configuration;
using LogRaamJousting.Options;

#endregion

namespace LogRaamJousting.Factory
{
   internal class DefaultSetup : ISetup
   {
      public IConfigLoader ConfigLoader { get; } = new ConfigLoader();
      public IConfig Configuration { get; } = new Config();
      public IOptions CultureOptions { get; } = new CultureOptions();
   }
}