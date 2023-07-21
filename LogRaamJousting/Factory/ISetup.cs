// Code written by Gabriel Mailhot, 25/06/2023.

#region

using LogRaamJousting.Configuration;
using LogRaamJousting.Options;

#endregion

namespace LogRaamJousting.Factory
{
   public interface ISetup
   {
      public IConfigLoader ConfigLoader { get; }
      public IConfig Configuration { get; }
      public IOptions CultureOptions { get; }
   }
}