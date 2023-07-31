// Code written by Gabriel Mailhot, 25/06/2023.

#region

using LogRaamJousting.Configuration;
using LogRaamJousting.Options;

#endregion

namespace LogRaamJousting.Factory
{
   internal class DefaultSetup : ISetup
   {
      public DefaultSetup()
      {
         ConfigLoader = new ConfigLoader();
         Configuration = new Config();
         CultureOptions = new CultureOptions(ConfigLoader);
      }


      public IConfigLoader ConfigLoader { get; }
      public IConfig Configuration { get; }
      public IOptions CultureOptions { get; }
   }
}