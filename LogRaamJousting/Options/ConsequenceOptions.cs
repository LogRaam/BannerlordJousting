// Code written by Gabriel Mailhot, 22/06/2023.

#region

using LogRaamJousting.Configuration;

#endregion

namespace LogRaamJousting.Options
{
   public class ConsequenceOptions
   {
      private const string PlayerGainExtraRenownPointsWhenNudeLineToFind = "[X] The player gains even more renown points if he wins a tournament while nude.";
      private const string PlayerGainRenownPointsLineToFind = "[X] The player gains renown points when he wins a tournament.";
      private const string PlayerLosesRenownPointsLineToFind = "[X] The player loses renown points when he loses a tournament.";
      private readonly IConfigLoader _loader;

      private readonly IOptions _options;

      public ConsequenceOptions(IOptions baseOptions, IConfigLoader loader)
      {
         _options = baseOptions;
         _loader = loader;
      }


      public ConsequenceOptions()
      {
         _options = new CultureOptions();
         _loader = new ConfigLoader();
      }


      public bool PlayerShouldGainExtraRenownPointsWhenNude(string[] options)
      {
         return ShouldGainExtraRenown(options, PlayerGainExtraRenownPointsWhenNudeLineToFind);
      }

      public bool PlayerShouldGainRenownPoints(string[] options)
      {
         return ShouldGainRenown(options, PlayerGainRenownPointsLineToFind);
      }

      public bool PlayerShouldLosesRenownPoints(string[] options)
      {
         return ShouldLosesRenown(options, PlayerLosesRenownPointsLineToFind);
      }

      #region private

      private bool ShouldGainExtraRenown(string[] options, string lineToFind)
      {
         return _loader.IsLineExistInStruct(options, lineToFind);
      }

      private bool ShouldGainRenown(string[] options, string lineToFind)
      {
         return _loader.IsLineExistInStruct(options, lineToFind);
      }

      private bool ShouldLosesRenown(string[] options, string lineToFind)
      {
         return _loader.IsLineExistInStruct(options, lineToFind);
      }

      #endregion
   }
}