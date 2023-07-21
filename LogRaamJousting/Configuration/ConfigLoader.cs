// Code written by Gabriel Mailhot, 02/03/2023.

#region

using System.IO;

#endregion

namespace LogRaamJousting.Configuration
{
   public class ConfigLoader : IConfigLoader
   {
      public bool IsLineExistInStruct(string[] options, string lineToFind)
      {
         foreach (var option in options)
         {
            if (!option.Contains(lineToFind)) continue;

            return true;
         }

         return false;
      }

      public string[] RetrieveConfigDetails()
      {
         var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;

         if (directoryInfo == null) return new[] {""};

         var str = directoryInfo.FullName + "\\Modules\\LogRaamJousting\\JOUSTING_OPTIONS.txt";

         return File.ReadAllLines(str);
      }
   }
}