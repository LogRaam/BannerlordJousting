// Code written by Gabriel Mailhot, 23/04/2023.

#region

using LogRaamJousting.Options;

#endregion

namespace LogRaamJousting.Plugins
{
   public class Aserai : IPlugin
   {
      public IOptions Options = new AseraiOptions();
   }
}