// Code written by Gabriel Mailhot, 01/03/2023.

namespace LogRaamJousting.Options
{
   public class EmpireOptions : ICultureOption
   {
      private const string ShouldBeNakedLineToFind = "[X] Undressed Empire";
      private const string ShouldHappensLineToFind = "[X] Apply to Empire";
      private const string ShouldProvideArmorsLineToFind = "[X] Empire tournament provides armors";
      private const string ShouldProvideWeaponsLineToFind = "[X] Empire tournament provides weapons";
      private const string ShouldUseHostCultureLineToFind = "[X] Empire enforce its culture during tournaments";
      private const string ShouldUseTheirEquipmentLineToFind = "[X] Empire tournament's participants must bring their own equipment";

      private readonly IOptions _options;

      public EmpireOptions(IOptions baseOptions)
      {
         _options = baseOptions;
      }


      public string Culture => "EMPIRE";

      public bool ParticipantShouldUseItsOwnEquipment(string[] options)
      {
         return _options.ShouldUseTheirEquipment(options, ShouldUseTheirEquipmentLineToFind);
      }

      public bool ShouldBeNaked(string[] options)
      {
         return _options.ShouldBeNaked(options, ShouldBeNakedLineToFind);
      }

      public bool ShouldBeNaked(string lineToFind)
      {
         return _options.ShouldBeNaked(lineToFind);
      }

      public bool ShouldHappens(string[] options)
      {
         return _options.ShouldHappens(options, ShouldHappensLineToFind);
      }

      public bool ShouldProvideArmors(string[] options)
      {
         return _options.ShouldProvideArmors(options, ShouldProvideArmorsLineToFind);
      }

      public bool ShouldProvideWeapons(string[] options)
      {
         return _options.ShouldProvideWeapons(options, ShouldProvideWeaponsLineToFind);
      }

      public bool ShouldUseHostCulture(string[] options)
      {
         return _options.ShouldUseHostCulture(options, ShouldUseHostCultureLineToFind);
      }

      public bool ShouldUseHostCulture(string lineToFind)
      {
         return _options.ShouldUseHostCulture(lineToFind);
      }
   }
}