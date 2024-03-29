﻿// Code written by Gabriel Mailhot, 02/03/2023.

namespace LogRaamJousting.Configuration
{
   public interface IConfigLoader
   {
      bool IsLineExistInStruct(string[] options, string lineToFind);
      string[] RetrieveConfigDetails();
   }
}