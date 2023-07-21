// Code written by Gabriel Mailhot, 25/04/2023.

#region

using FluentAssertions;
using LogRaamJousting.Configuration;
using LogRaamJousting.Options;
using LogRaamJoustingTest.Substitutes;
using NUnit.Framework;

#endregion

namespace LogRaamJoustingTest
{
   public class KhuzaitConfigTest
   {
      [Test]
      public void TournamentKhuzait_ApplyCHECK_EnforceCHECK_ItShouldEnforce()
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

[X] Undressed Empire 
[X] Undressed Sturgia
[X] Undressed Aserai
[X] Undressed Vlandia
[X] Undressed Khuzait
[X] Undressed Battania

Modded cultures:
[X] Undressed Ayyubid
[X] Undressed Byzantine


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
[X] Apply to Byzantine at 100%

Note that you can change the percentage value of each of the above lines.
";

         var settings = file.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

         var configLoader = new ConfigLoaderSubstitute {
            Content = settings
         };
         var sut = new Config(new CultureOptions(configLoader), configLoader);
         var param1 = "KHUZAIT";
         var expectedResult = true;

         //Act
         var actualResult = sut.IsHostEnforcingHisCulture(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void TournamentKhuzait_ApplyCHECK_EnforceUNCHECK_ItShouldNotEnforce()
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
[] Aserai enforce its culture during tournaments
[X] Vlandia enforce its culture during tournaments
[] Khuzait enforce its culture during tournaments
[X] Battania enforce its culture during tournaments

Modded cultures:
[X] Ayyubid enforce its culture during tournaments
[X] Byzantine enforce its culture during tournaments


--- --- --- --- --- --- --- 
Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬
--- --- --- --- --- --- --- 
The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.

[X] Undressed Empire 
[X] Undressed Sturgia
[X] Undressed Aserai
[X] Undressed Vlandia
[X] Undressed Khuzait
[X] Undressed Battania

Modded cultures:
[X] Undressed Ayyubid
[X] Undressed Byzantine


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
[X] Apply to Byzantine at 100%

Note that you can change the percentage value of each of the above lines.
";

         var settings = file.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

         var configLoader = new ConfigLoaderSubstitute {
            Content = settings
         };
         var sut = new Config(new CultureOptions(configLoader), configLoader);
         var param1 = "KHUZAIT";
         var expectedResult = false;

         //Act
         var actualResult = sut.IsHostEnforcingHisCulture(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void TournamentKhuzait_ApplyCHECK_ItShouldApplyMod()
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

[] Apply to Empire   at 100%
[] Apply to Sturgia  at 100%
[X] Apply to Aserai   at 100%
[X] Apply to Vlandia  at 100%
[X] Apply to Khuzait  at 100%
[] Apply to Battania at 100%

Modded cultures:
[] Apply to Ayyubid at 100%
[] Apply to Byzantine at 100%

Note that you can change the percentage value of each of the above lines.
";

         var settings = file.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

         var configLoader = new ConfigLoaderSubstitute {
            Content = settings
         };
         var sut = new Config(new CultureOptions(configLoader), configLoader);
         var param1 = "KHUZAIT";
         var expectedResult = true;

         //Act
         var actualResult = sut.ShouldApplyModForThisMatch(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void TournamentKhuzait_ApplyCHECK_UndressCHECK_ItShouldUndress()
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
[X] Undressed Khuzait
[] Undressed Battania

Modded cultures:
[] Undressed Ayyubid
[] Undressed Byzantine


--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   
Select the cultures that should apply this mod, as well as the percentage of chance to happens
--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  
This is a multiple choice section.

[] Apply to Empire   at 100%
[] Apply to Sturgia  at 100%
[] Apply to Aserai   at 100%
[] Apply to Vlandia  at 100%
[X] Apply to Khuzait  at 100%
[] Apply to Battania at 100%

Modded cultures:
[] Apply to Ayyubid at 100%
[] Apply to Byzantine at 100%

Note that you can change the percentage value of each of the above lines.
";

         var settings = file.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

         var configLoader = new ConfigLoaderSubstitute {
            Content = settings
         };
         var sut = new Config(new CultureOptions(configLoader), configLoader);
         var param1 = "KHUZAIT";
         var expectedResult = true;

         //Act
         var actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void TournamentKhuzait_ApplyCHECK_UndressUNCHECK_ItShouldNotUndress()
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

[X] Undressed Empire 
[X] Undressed Sturgia
[X] Undressed Aserai
[X] Undressed Vlandia
[] Undressed Khuzait
[X] Undressed Battania

Modded cultures:
[X] Undressed Ayyubid
[X] Undressed Byzantine


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
[X] Apply to Byzantine at 100%

Note that you can change the percentage value of each of the above lines.
";

         var settings = file.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

         var configLoader = new ConfigLoaderSubstitute {
            Content = settings
         };
         var sut = new Config(new CultureOptions(configLoader), configLoader);
         var param1 = "KHUZAIT";
         var expectedResult = false;

         //Act
         var actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void TournamentKhuzait_ApplyUNCHECK_EnforceCHECK_ItShouldNotEnforce()
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

[X] Undressed Empire 
[X] Undressed Sturgia
[X] Undressed Aserai
[X] Undressed Vlandia
[X] Undressed Khuzait
[X] Undressed Battania

Modded cultures:
[X] Undressed Ayyubid
[X] Undressed Byzantine


--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   
Select the cultures that should apply this mod, as well as the percentage of chance to happens
--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  
This is a multiple choice section.

[X] Apply to Empire   at 100%
[X] Apply to Sturgia  at 100%
[X] Apply to Aserai   at 100%
[X] Apply to Vlandia  at 100%
[] Apply to Khuzait  at 100%
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
         var param1 = "KHUZAIT";
         var expectedResult = false;

         //Act
         var actualResult = sut.IsHostEnforcingHisCulture(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void TournamentKhuzait_ApplyUNCHECK_ItShouldNotApplyMod()
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
[] Apply to Khuzait  at 100%
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
         var param1 = "KHUZAIT";
         var expectedResult = false;

         //Act
         var actualResult = sut.ShouldApplyModForThisMatch(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }


      [Test]
      public void TournamentKhuzait_ApplyUNCHECK_UndressCHECK_ItShouldNotUndress()
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
[X] Undressed Aserai
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

[] Apply to Empire   at 100%
[] Apply to Sturgia  at 100%
[] Apply to Aserai   at 100%
[] Apply to Vlandia  at 100%
[] Apply to Khuzait  at 100%
[] Apply to Battania at 100%

Modded cultures:
[] Apply to Ayyubid at 100%
[] Apply to Byzantine at 100%

Note that you can change the percentage value of each of the above lines.
";

         var settings = file.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

         var configLoader = new ConfigLoaderSubstitute {
            Content = settings
         };
         var sut = new Config(new CultureOptions(configLoader), configLoader);
         var param1 = "KHUZAIT";
         var expectedResult = false;

         //Act
         var actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void TournamentKhuzait_ApplyUNCHECK_UndressUNCHECK_ItShouldNotUndress()
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

[X] Undressed Empire 
[X] Undressed Sturgia
[X] Undressed Aserai
[X] Undressed Vlandia
[] Undressed Khuzait
[X] Undressed Battania

Modded cultures:
[X] Undressed Ayyubid
[X] Undressed Byzantine


--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   
Select the cultures that should apply this mod, as well as the percentage of chance to happens
--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  
This is a multiple choice section.

[X] Apply to Empire   at 100%
[X] Apply to Sturgia  at 100%
[X] Apply to Aserai   at 100%
[X] Apply to Vlandia  at 100%
[] Apply to Khuzait  at 100%
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
         var param1 = "KHUZAIT";
         var expectedResult = false;

         //Act
         var actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectedResult);
      }
   }
}