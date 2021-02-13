// Code written by Gabriel Mailhot, 09/02/2021.

#region

#endregion


#region

using System.IO;

#endregion

namespace LogRaamJousting.Configuration
{
   public class Config
   {
      public Options Option = Options.DRESSED;

      public Config()
      {
         DirectoryInfo directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;

         if (directoryInfo == null) return;

         string str = directoryInfo.FullName + "\\Modules\\LogRaamJousting\\JOUSTING_OPTIONS.txt";

         string[] settings = File.ReadAllLines(str);
         Option = ParseConfigFrom(settings);
      }

      #region private

      private Options ParseConfigFrom(string[] settings)
      {
         foreach (string t in settings)
         {
            if (t.ToUpper().Contains("[X] DRESSED")) return Options.DRESSED;
            if (t.ToUpper().Contains("[X] UNDRESSED BATTANIA ONLY")) return Options.UNDRESSEDBATTANIA;
            if (t.ToUpper().Contains("[X] UNDRESSED EMPIRE ONLY")) return Options.UNDRESSEDEMPIRE;
            if (t.ToUpper().Contains("[X] UNDRESSED MIXED")) return Options.UNDRESSEDMIXED;
            if (t.ToUpper().Contains("[X] UNDRESSED")) return Options.UNDRESSED;
         }

         return Options.UNDRESSEDBATTANIA;
      }

      #endregion
   }
}