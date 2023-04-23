// Code written by Gabriel Mailhot, 02/03/2023.

#region

using System.IO;

#endregion

namespace LogRaamJousting.Configuration
{
   public class ConfigLoader : IConfigLoader
   {
      public string[] RetrieveConfigDetails()
      {
         DirectoryInfo directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;

         if (directoryInfo == null) return new[] {""};

         string str = directoryInfo.FullName + "\\Modules\\LogRaamJousting\\JOUSTING_OPTIONS.txt";

         return File.ReadAllLines(str);
      }
   }
}