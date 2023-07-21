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
      public IConfigLoader ConfigLoader { get; } = new ConfigLoader();
      public IConfig Configuration { get; }
      public IOptions CultureOptions { get; }
   }
}