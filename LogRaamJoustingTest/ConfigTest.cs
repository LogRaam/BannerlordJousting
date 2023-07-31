// Code written by Gabriel Mailhot, 02/03/2023.

#region

using FluentAssertions;
using LogRaamJousting.Configuration;
using LogRaamJousting.Options;
using LogRaamJoustingTest.Substitutes;
using NUnit.Framework;

#endregion

namespace LogRaamJoustingTest
{
   [TestFixture]
   public class ConfigTest
   {
      [Test]
      public void TournamentAyyubid_ApplyCHECK_ItShouldApplyMod()
      {
         //Arrange
         var file =
            @"--- --- --- --- --- --- --- ---
Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬
--- --- --- --- --- --- --- ---
When enforcing culture, all tournament participants must use the equipment style of the event host.  
If unchecked, each participant will maintain their own cultural style of dress during the tournament.

[X] Empire enforce its culture during tournaments
[X] Sturgia enforce its culture during tournaments
[X] Aserai enforce its culture during tournaments
[X] Vlandia enforce its culture during tournaments
[X] Khuzait enforce its culture during tournaments
[X] Battania enforce its culture during tournaments

Modded cultures:
[X] Ayyubid enforce its culture during tournaments
[X] Byzantine enforce its culture during tournaments


--- --- --- --- --- --- --- 
Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬
--- --- --- --- --- --- --- 
The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.

[] Undressed Empire 
[] Undressed Sturgia
[] Undressed Aserai
[] Undressed Vlandia
[] Undressed Khuzait
[] Undressed Battania

Modded cultures:
[] Undressed Ayyubid
[] Undressed Byzantine


--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   
Select the cultures that should apply this mod, as well as the percentage of chance to happens
--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  
This is a multiple choice section.

[X] Apply to Empire   at 100%
[X] Apply to Sturgia  at 100%
[X] Apply to Aserai   at 100%
[X] Apply to Vlandia  at 100%
[X] Apply to Khuzait  at 100%
[X] Apply to Battania at 100%

Modded cultures:
[X] Apply to Ayyubid at 100%
[] Apply to Byzantine at 100%

Note that you can change the percentage value of each of the above lines.
";

         var settings = file.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

         var configLoader = new ConfigLoaderSubstitute {
            Content = settings
         };

         var sut = new Config(new CultureOptions(configLoader), configLoader);
         var param1 = "AYYUBID";
         var expectedResult = true;

         //Act
         var actualResult = sut.ShouldApplyModForThisMatch(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void TournamentAyyubid_ApplyUNCHECK_ItShouldNotApplyMod()
      {
         //Arrange
         var file =
            @"--- --- --- --- --- --- --- ---
Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬
--- --- --- --- --- --- --- ---
When enforcing culture, all tournament participants must use the equipment style of the event host.  
If unchecked, each participant will maintain their own cultural style of dress during the tournament.

[X] Empire enforce its culture during tournaments
[X] Sturgia enforce its culture during tournaments
[X] Aserai enforce its culture during tournaments
[X] Vlandia enforce its culture during tournaments
[X] Khuzait enforce its culture during tournaments
[X] Battania enforce its culture during tournaments

Modded cultures:
[X] Ayyubid enforce its culture during tournaments
[X] Byzantine enforce its culture during tournaments


--- --- --- --- --- --- --- 
Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬
--- --- --- --- --- --- --- 
The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.

[] Undressed Empire 
[] Undressed Sturgia
[] Undressed Aserai
[] Undressed Vlandia
[] Undressed Khuzait
[] Undressed Battania

Modded cultures:
[] Undressed Ayyubid
[] Undressed Byzantine


--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   
Select the cultures that should apply this mod, as well as the percentage of chance to happens
--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  
This is a multiple choice section.

[X] Apply to Empire   at 100%
[X] Apply to Sturgia  at 100%
[X] Apply to Aserai   at 100%
[X] Apply to Vlandia  at 100%
[X] Apply to Khuzait  at 100%
[X] Apply to Battania at 100%

Modded cultures:
[] Apply to Ayyubid at 100%
[X] Apply to Byzantine at 100%

Note that you can change the percentage value of each of the above lines.
";

         var settings = file.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

         var configLoader = new ConfigLoaderSubstitute {
            Content = settings
         };
         var sut = new Config(new CultureOptions(configLoader), configLoader);
         var param1 = "AYYUBID";
         var expectedResult = false;

         //Act
         var actualResult = sut.ShouldApplyModForThisMatch(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void TournamentByzantine_ApplyCHECK_ItShouldApplyMod()
      {
         //Arrange
         var file =
            @"--- --- --- --- --- --- --- ---
Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬
--- --- --- --- --- --- --- ---
When enforcing culture, all tournament participants must use the equipment style of the event host.  
If unchecked, each participant will maintain their own cultural style of dress during the tournament.

[X] Empire enforce its culture during tournaments
[X] Sturgia enforce its culture during tournaments
[X] Aserai enforce its culture during tournaments
[X] Vlandia enforce its culture during tournaments
[X] Khuzait enforce its culture during tournaments
[X] Battania enforce its culture during tournaments

Modded cultures:
[X] Ayyubid enforce its culture during tournaments
[X] Byzantine enforce its culture during tournaments


--- --- --- --- --- --- --- 
Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬
--- --- --- --- --- --- --- 
The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.

[] Undressed Empire 
[] Undressed Sturgia
[] Undressed Aserai
[] Undressed Vlandia
[] Undressed Khuzait
[] Undressed Battania

Modded cultures:
[] Undressed Ayyubid
[] Undressed Byzantine


--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   
Select the cultures that should apply this mod, as well as the percentage of chance to happens
--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  
This is a multiple choice section.

[X] Apply to Empire   at 100%
[X] Apply to Sturgia  at 100%
[X] Apply to Aserai   at 100%
[X] Apply to Vlandia  at 100%
[X] Apply to Khuzait  at 100%
[X] Apply to Battania at 100%

Modded cultures:
[] Apply to Ayyubid at 100%
[X] Apply to Byzantine at 100%

Note that you can change the percentage value of each of the above lines.
";

         var settings = file.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

         var configLoader = new ConfigLoaderSubstitute {
            Content = settings
         };
         var sut = new Config(new CultureOptions(configLoader), configLoader);
         var param1 = "BYZANTINE";
         var expectedResult = true;

         //Act
         var actualResult = sut.ShouldApplyModForThisMatch(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void TournamentByzantine_ApplyUNCHECK_ItShouldNotApplyMod()
      {
         //Arrange
         var file =
            @"--- --- --- --- --- --- --- ---
Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬
--- --- --- --- --- --- --- ---
When enforcing culture, all tournament participants must use the equipment style of the event host.  
If unchecked, each participant will maintain their own cultural style of dress during the tournament.

[X] Empire enforce its culture during tournaments
[X] Sturgia enforce its culture during tournaments
[X] Aserai enforce its culture during tournaments
[X] Vlandia enforce its culture during tournaments
[X] Khuzait enforce its culture during tournaments
[X] Battania enforce its culture during tournaments

Modded cultures:
[X] Ayyubid enforce its culture during tournaments
[X] Byzantine enforce its culture during tournaments


--- --- --- --- --- --- --- 
Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬
--- --- --- --- --- --- --- 
The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.

[] Undressed Empire 
[] Undressed Sturgia
[] Undressed Aserai
[] Undressed Vlandia
[] Undressed Khuzait
[] Undressed Battania

Modded cultures:
[] Undressed Ayyubid
[] Undressed Byzantine


--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   
Select the cultures that should apply this mod, as well as the percentage of chance to happens
--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  
This is a multiple choice section.

[X] Apply to Empire   at 100%
[X] Apply to Sturgia  at 100%
[X] Apply to Aserai   at 100%
[X] Apply to Vlandia  at 100%
[X] Apply to Khuzait  at 100%
[X] Apply to Battania at 100%

Modded cultures:
[X] Apply to Ayyubid at 100%
[] Apply to Byzantine at 100%

Note that you can change the percentage value of each of the above lines.
";

         var settings = file.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

         var configLoader = new ConfigLoaderSubstitute {
            Content = settings
         };
         var sut = new Config(new CultureOptions(configLoader), configLoader);
         var param1 = "BYZANTINE";
         var expectedResult = false;

         //Act
         var actualResult = sut.ShouldApplyModForThisMatch(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void TournamentSturgia_ApplyUNCHECK_ItShouldNotApplyMod()
      {
         //Arrange
         var file =
            @"--- --- --- --- --- --- --- ---
Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬
--- --- --- --- --- --- --- ---
When enforcing culture, all tournament participants must use the equipment style of the event host.  
If unchecked, each participant will maintain their own cultural style of dress during the tournament.

[X] Empire enforce its culture during tournaments
[X] Sturgia enforce its culture during tournaments
[X] Aserai enforce its culture during tournaments
[X] Vlandia enforce its culture during tournaments
[X] Khuzait enforce its culture during tournaments
[X] Battania enforce its culture during tournaments

Modded cultures:
[X] Ayyubid enforce its culture during tournaments
[X] Byzantine enforce its culture during tournaments


--- --- --- --- --- --- --- 
Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬
--- --- --- --- --- --- --- 
The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.

[] Undressed Empire 
[] Undressed Sturgia
[] Undressed Aserai
[] Undressed Vlandia
[] Undressed Khuzait
[] Undressed Battania

Modded cultures:
[] Undressed Ayyubid
[] Undressed Byzantine


--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   
Select the cultures that should apply this mod, as well as the percentage of chance to happens
--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  
This is a multiple choice section.

[X] Apply to Empire   at 100%
[] Apply to Sturgia  at 100%
[X] Apply to Aserai   at 100%
[X] Apply to Vlandia  at 100%
[X] Apply to Khuzait  at 100%
[X] Apply to Battania at 100%

Modded cultures:
[X] Apply to Ayyubid at 100%
[X] Apply to Byzantine at 100%

Note that you can change the percentage value of each of the above lines.
";

         var settings = file.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

         var configLoader = new ConfigLoaderSubstitute {
            Content = settings
         };
         var sut = new Config(new CultureOptions(configLoader), configLoader);
         var param1 = "STURGIA";
         var expectedResult = false;

         //Act
         var actualResult = sut.ShouldApplyModForThisMatch(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void TournamentSturgia_ApplyUNDRESS_PlayerShouldBeUndress()
      {
         //Arrange
         var file = @"--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   
Section 1 - Select the cultures that should apply this mod, as well as the percentage of chance to happens
--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  
When the mod is not applied, standard equipment will be used for the tournament (Vanilla or from another activated mod).
This is a multiple choice section.

[X] Apply to Empire   at 100%
[X] Apply to Sturgia  at 100%
[X] Apply to Aserai   at 100%
[X] Apply to Vlandia  at 100%
[X] Apply to Khuzait  at 100%
[X] Apply to Battania at 100%

Modded cultures:
[X] Apply to Ayyubid at 100%
[X] Apply to Byzantine at 100%

Note that you can change the percentage value of each of the above lines.

--- --- --- --- --- --- --- --- --- --- ---
Section 2 - Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬
--- --- --- --- --- --- --- --- --- --- ---
When enforcing culture, all tournament participants must use the equipment style of the event host.  
If unchecked, each participant will maintain their own cultural style of dress during the tournament.

[X] Empire enforce its culture during tournaments
[X] Sturgia enforce its culture during tournaments
[X] Aserai enforce its culture during tournaments
[X] Vlandia enforce its culture during tournaments
[X] Khuzait enforce its culture during tournaments
[X] Battania enforce its culture during tournaments

Modded cultures:
[X] Ayyubid enforce its culture during tournaments
[X] Byzantine enforce its culture during tournaments


--- --- --- --- --- --- --- --- --- ---
Section 3 - Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬
--- --- --- --- --- --- --- --- --- ---
The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.

[] Undressed Empire
[X] Undressed Sturgia
[] Undressed Aserai

[] Undressed Vlandia
[] Undressed Khuzait
[X] Undressed Battania

Modded cultures:
[] Undressed Ayyubid
[] Undressed Byzantine


--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
Section 4 - Tournament Host provides equipments for their tournament
--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- 
You can choose whether or not this mod should apply the assignment of weapons or armor to tournament participants.
If equipment is not supplied by the tournament host, it must be provided by the participant.
This is a multiple choice section.

[X] Empire tournament provides weapons
[X] Empire tournament provides armors

[X] Sturgia tournament provides weapons
[X] Sturgia tournament provides armors

[X] Aserai tournament provides weapons
[X] Aserai tournament provides armors

[X] Vlandia tournament provides weapons
[X] Vlandia tournament provides armors

[X] Khuzait tournament provides weapons
[X] Khuzait tournament provides armors

[X] Battania tournament provides weapons
[X] Battania tournament provides armors


--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- 
Section 5 - Tournament participants must bring their own equipment (Weapons and Armors)
--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
When you select this option, participants will use their own equipment and mounts for the duration of the tournament.  
Please note that this option takes precedence over the dress options (section 4).  This is a multiple choice section.

[] Empire tournament's participants must bring their own equipment
[] Sturgia tournament's participants must bring their own equipment
[] Aserai tournament's participants must bring their own equipment
[] Vlandia tournament's participants must bring their own equipment
[] Khuzait tournament's participants must bring their own equipment
[] Battania tournament's participants must bring their own equipment


--- --- --- --- --- --- --- --- --- ---  
Section 6 - Wins or loses Consequences
--- --- --- --- --- --- --- --- --- ---  
when activated, these options causes the player to gain or lose renown points when he win or loses a tournament.

[X] The player loses renown points when he loses a tournament.
[X] The player gains renown points when he wins a tournament.
[X] The player gains even more renown points if he wins a tournament while nude.";
         var settings = file.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

         var configLoader = new ConfigLoaderSubstitute {
            Content = settings
         };
         var sut = new Config(new CultureOptions(configLoader), configLoader);
         var param1 = "STURGIA";
         var expectedResult = true;

         //Act
         var actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }
   }
}