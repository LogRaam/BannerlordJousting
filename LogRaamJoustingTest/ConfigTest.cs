// Code written by Gabriel Mailhot, 02/03/2023.

#region

using FluentAssertions;
using LogRaamJousting;
using LogRaamJousting.Configuration;
using NUnit.Framework;
using TaleWorlds.Core;

#endregion

namespace LogRaamJoustingTest
{
   [TestFixture]
   public class ConfigTest
   {
      [Test]
      public void GivenAseraiHostATournament_AndHostEquipmentIsMandatory_WhenEquipping_ThenIShouldHaveWeaponsFromAseraiCulture()
      {
         //Arrange
         var configContent = new[] {
            "--- --- --- --- --- --- --- ---",
            "   Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
            "--- --- --- --- --- --- --- ---",
            "When enforcing culture, all tournament participants must use the equipment style of the event host.  ",
            "If unchecked, each participant will maintain their own cultural style of dress during the tournament.",
            "",
            "[] Empire enforce its culture during tournaments",
            "[] Sturgia enforce its culture during tournaments",
            "[X] Aserai enforce its culture during tournaments",
            "[] Vlandia enforce its culture during tournaments",
            "[] Khuzait enforce its culture during tournaments",
            "[] Battania enforce its culture during tournaments"
         };

         var tournamentCulture = CultureCode.Aserai;
         var participantCulture = CultureCode.Battania;
         var expectedResult = CultureCode.Aserai;

         //Act
         CultureCode actualResult = new Armoury(new ConfigLoaderSubstitute {
            Content = configContent
         }).GetCultureCodeBasedOnOption(tournamentCulture, participantCulture);

         //Assert
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void GivenAseraiHostATournament_AndHostEquipmentIsNotMandatory_WhenEquipping_ThenIShouldHaveWeaponsFromParticipantCulture()
      {
         //Arrange
         var configContent = new[] {
            "--- --- --- --- --- --- --- ---",
            "   Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
            "--- --- --- --- --- --- --- ---",
            "When enforcing culture, all tournament participants must use the equipment style of the event host.  ",
            "If unchecked, each participant will maintain their own cultural style of dress during the tournament.",
            "",
            "[] Empire enforce its culture during tournaments",
            "[] Sturgia enforce its culture during tournaments",
            "[] Aserai enforce its culture during tournaments",
            "[] Vlandia enforce its culture during tournaments",
            "[] Khuzait enforce its culture during tournaments",
            "[] Battania enforce its culture during tournaments"
         };

         var tournamentCulture = CultureCode.Aserai;
         var participantCulture = CultureCode.Battania;
         var expectedResult = CultureCode.Battania;

         //Act
         CultureCode actualResult = new Armoury(new ConfigLoaderSubstitute {
            Content = configContent
         }).GetCultureCodeBasedOnOption(tournamentCulture, participantCulture);

         //Assert
         actualResult.Should().Be(expectedResult);
      }

      [Test]
      public void GivenINeedToKnowIfAseraiTournamentShouldHappens_WhenAseraiIsActivated_AndThereIs100pcChanceToHappens_ThenTheTournamentShouldHappens()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute());
         var expectResult = true;
         var param1 = CultureCode.Aserai;

         //Act
         bool actualResult = sut.HaveToApplyModFor(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfAseraiTournamentShouldNotHappens_WhenAseraiIsNotActivated_AndThereIs0pcChanceToHappens_ThenTheTournamentShouldNotHappens()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   ",
               "Select the cultures that should apply this mod, as well as the percentage of chance to happens",
               "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  ",
               "[X] Apply to Empire   at 100%",
               "[X] Apply to Sturgia  at 100%",
               "[X] Apply to Aserai   at 0%",
               "[X] Apply to Vlandia  at 100%",
               "[X] Apply to Khuzait  at 100%",
               "[X] Apply to Battania at 100%"
            }
         });
         var expectResult = false;
         var param1 = CultureCode.Aserai;

         //Act
         bool actualResult = sut.HaveToApplyModFor(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfBattaniaTournamentShouldHappens_WhenBattaniaIsActivated_AndThereIs100pcChanceToHappens_ThenTheTournamentShouldHappens()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute());
         var expectResult = true;
         var param1 = CultureCode.Battania;

         //Act
         bool actualResult = sut.HaveToApplyModFor(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }


      [Test]
      public void GivenINeedToKnowIfBattaniaTournamentShouldNotHappens_WhenBattaniaIsNotActivated_AndThereIs0pcChanceToHappens_ThenTheTournamentShouldNotHappens()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   ",
               "Select the cultures that should apply this mod, as well as the percentage of chance to happens",
               "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  ",
               "[X] Apply to Empire   at 100%",
               "[X] Apply to Sturgia  at 100%",
               "[X] Apply to Aserai   at 100%",
               "[X] Apply to Vlandia  at 100%",
               "[X] Apply to Khuzait  at 1000%",
               "[X] Apply to Battania at 0%"
            }
         });
         var expectResult = false;
         var param1 = CultureCode.Battania;

         //Act
         bool actualResult = sut.HaveToApplyModFor(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfEmpireTournamentShouldHappens_WhenEmpireIsActivated_AndThereIs100pcChanceToHappens_ThenTheTournamentShouldHappens()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute());
         var expectResult = true;
         var param1 = CultureCode.Empire;

         //Act
         bool actualResult = sut.HaveToApplyModFor(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }


      [Test]
      public void GivenINeedToKnowIfEmpireTournamentShouldHappens_WhenEmpireIsActivated_AndThereIs25pcChanceToHappens_AndIRunRandom10Times_ThenTheTournamentShouldHappens()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   ",
               "Select the cultures that should apply this mod, as well as the percentage of chance to happens",
               "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  ",
               "[X] Apply to Empire   at 25%",
               "[X] Apply to Sturgia  at 100%",
               "[X] Apply to Aserai   at 100%",
               "[X] Apply to Vlandia  at 100%",
               "[X] Apply to Khuzait  at 100%",
               "[X] Apply to Battania at 100%"
            }
         });
         var expectResult = true;
         var param1 = CultureCode.Empire;
         var result = false;

         //Act
         for (var i = 0; i < 10; i++)
         {
            bool actualResult = sut.HaveToApplyModFor(param1);
            if (actualResult) result = true;
         }


         //Assert
         result.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfEmpireTournamentShouldNotHappens_WhenEmpireIsNotActivated_AndThereIs0pcChanceToHappens_ThenTheTournamentShouldNotHappens()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   ",
               "Select the cultures that should apply this mod, as well as the percentage of chance to happens",
               "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  ",
               "[X] Apply to Empire   at 0%",
               "[X] Apply to Sturgia  at 100%",
               "[X] Apply to Aserai   at 100%",
               "[X] Apply to Vlandia  at 100%",
               "[X] Apply to Khuzait  at 100%",
               "[X] Apply to Battania at 100%"
            }
         });
         var expectResult = false;
         var param1 = CultureCode.Empire;

         //Act
         bool actualResult = sut.HaveToApplyModFor(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfKhuzaitTournamentShouldHappens_WhenKhuzaitIsActivated_AndThereIs100pcChanceToHappens_ThenTheTournamentShouldHappens()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute());
         var expectResult = true;
         var param1 = CultureCode.Khuzait;

         //Act
         bool actualResult = sut.HaveToApplyModFor(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }


      [Test]
      public void GivenINeedToKnowIfKhuzaitTournamentShouldNotHappens_WhenKhuzaitIsNotActivated_AndThereIs0pcChanceToHappens_ThenTheTournamentShouldNotHappens()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   ",
               "Select the cultures that should apply this mod, as well as the percentage of chance to happens",
               "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  ",
               "[X] Apply to Empire   at 100%",
               "[X] Apply to Sturgia  at 100%",
               "[X] Apply to Aserai   at 100%",
               "[X] Apply to Vlandia  at 100%",
               "[X] Apply to Khuzait  at 0%",
               "[X] Apply to Battania at 100%"
            }
         });
         var expectResult = false;
         var param1 = CultureCode.Khuzait;

         //Act
         bool actualResult = sut.HaveToApplyModFor(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfParticipantShouldBeNaked_WhenCultureIsAserai_AndEmpireShouldBeUndressed_ThenParticipantShouldBeUndressed()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- ",
               "   Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ",
               "The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.",
               "",
               "[] Undressed Empire ",
               "[] Undressed Sturgia",
               "[X] Undressed Aserai",
               "[] Undressed Vlandia",
               "[] Undressed Khuzait",
               "[] Undressed Battania"
            }
         });

         var expectResult = true;
         var param1 = CultureCode.Aserai;

         //Act
         bool actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfParticipantShouldBeNaked_WhenCultureIsAserai_AndEmpireShouldNotBeUndressed_ThenParticipantShouldNotBeUndressed()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- ",
               "   Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ",
               "The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.",
               "",
               "[] Undressed Empire ",
               "[] Undressed Sturgia",
               "[] Undressed Aserai",
               "[] Undressed Vlandia",
               "[] Undressed Khuzait",
               "[] Undressed Battania"
            }
         });

         var expectResult = false;
         var param1 = CultureCode.Aserai;

         //Act
         bool actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfParticipantShouldBeNaked_WhenCultureIsBattania_AndEmpireShouldBeUndressed_ThenParticipantShouldBeUndressed()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- ",
               "   Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ",
               "The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.",
               "",
               "[] Undressed Empire ",
               "[] Undressed Sturgia",
               "[] Undressed Aserai",
               "[] Undressed Vlandia",
               "[] Undressed Khuzait",
               "[X] Undressed Battania"
            }
         });

         var expectResult = true;
         var param1 = CultureCode.Battania;

         //Act
         bool actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfParticipantShouldBeNaked_WhenCultureIsBattania_AndEmpireShouldNotBeUndressed_ThenParticipantShouldNotBeUndressed()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- ",
               "   Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ",
               "The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.",
               "",
               "[] Undressed Empire ",
               "[] Undressed Sturgia",
               "[] Undressed Aserai",
               "[] Undressed Vlandia",
               "[] Undressed Khuzait",
               "[] Undressed Battania"
            }
         });

         var expectResult = false;
         var param1 = CultureCode.Battania;

         //Act
         bool actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }


      [Test]
      public void GivenINeedToKnowIfParticipantShouldBeNaked_WhenCultureIsEmpire_AndEmpireShouldBeUndressed_ThenParticipantShouldBeUndressed()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- ",
               "   Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ",
               "The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.",
               "",
               "[X] Undressed Empire ",
               "[] Undressed Sturgia",
               "[] Undressed Aserai",
               "[] Undressed Vlandia",
               "[] Undressed Khuzait",
               "[X] Undressed Battania"
            }
         });

         var expectResult = true;
         var param1 = CultureCode.Empire;

         //Act
         bool actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfParticipantShouldBeNaked_WhenCultureIsEmpire_AndEmpireShouldNotBeUndressed_ThenParticipantShouldNotBeUndressed()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- ",
               "   Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ",
               "The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.",
               "",
               "[] Undressed Empire ",
               "[] Undressed Sturgia",
               "[] Undressed Aserai",
               "[] Undressed Vlandia",
               "[] Undressed Khuzait",
               "[X] Undressed Battania"
            }
         });

         var expectResult = false;
         var param1 = CultureCode.Empire;

         //Act
         bool actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfParticipantShouldBeNaked_WhenCultureIsKhuzait_AndEmpireShouldBeUndressed_ThenParticipantShouldBeUndressed()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- ",
               "   Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ",
               "The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.",
               "",
               "[] Undressed Empire ",
               "[] Undressed Sturgia",
               "[] Undressed Aserai",
               "[] Undressed Vlandia",
               "[X] Undressed Khuzait",
               "[] Undressed Battania"
            }
         });

         var expectResult = true;
         var param1 = CultureCode.Khuzait;

         //Act
         bool actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfParticipantShouldBeNaked_WhenCultureIsKhuzait_AndEmpireShouldNotBeUndressed_ThenParticipantShouldNotBeUndressed()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- ",
               "   Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ",
               "The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.",
               "",
               "[] Undressed Empire ",
               "[] Undressed Sturgia",
               "[] Undressed Aserai",
               "[] Undressed Vlandia",
               "[] Undressed Khuzait",
               "[] Undressed Battania"
            }
         });

         var expectResult = false;
         var param1 = CultureCode.Khuzait;

         //Act
         bool actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfParticipantShouldBeNaked_WhenCultureIsSturgia_AndEmpireShouldBeUndressed_ThenParticipantShouldBeUndressed()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- ",
               "   Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ",
               "The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.",
               "",
               "[] Undressed Empire ",
               "[X] Undressed Sturgia",
               "[] Undressed Aserai",
               "[] Undressed Vlandia",
               "[] Undressed Khuzait",
               "[] Undressed Battania"
            }
         });

         var expectResult = true;
         var param1 = CultureCode.Sturgia;

         //Act
         bool actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfParticipantShouldBeNaked_WhenCultureIsSturgia_AndEmpireShouldNotBeUndressed_ThenParticipantShouldNotBeUndressed()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- ",
               "   Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ",
               "The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.",
               "",
               "[] Undressed Empire ",
               "[] Undressed Sturgia",
               "[] Undressed Aserai",
               "[] Undressed Vlandia",
               "[] Undressed Khuzait",
               "[] Undressed Battania"
            }
         });

         var expectResult = false;
         var param1 = CultureCode.Sturgia;

         //Act
         bool actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfParticipantShouldBeNaked_WhenCultureIsVlandia_AndEmpireShouldBeUndressed_ThenParticipantShouldBeUndressed()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- ",
               "   Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ",
               "The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.",
               "",
               "[] Undressed Empire ",
               "[] Undressed Sturgia",
               "[] Undressed Aserai",
               "[X] Undressed Vlandia",
               "[] Undressed Khuzait",
               "[] Undressed Battania"
            }
         });

         var expectResult = true;
         var param1 = CultureCode.Vlandia;

         //Act
         bool actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfParticipantShouldBeNaked_WhenCultureIsVlandia_AndEmpireShouldNotBeUndressed_ThenParticipantShouldNotBeUndressed()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- ",
               "   Dress 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ",
               "The cities that will hold tournaments where participants are naked (wearing underwear).  This is a multiple choice section.",
               "",
               "[] Undressed Empire ",
               "[] Undressed Sturgia",
               "[] Undressed Aserai",
               "[] Undressed Vlandia",
               "[] Undressed Khuzait",
               "[] Undressed Battania"
            }
         });

         var expectResult = false;
         var param1 = CultureCode.Vlandia;

         //Act
         bool actualResult = sut.ShouldBeNaked(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfSturgiaTournamentShouldHappens_WhenSturgiaIsActivated_AndThereIs100pcChanceToHappens_ThenTheTournamentShouldHappens()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute());
         var expectResult = true;
         var param1 = CultureCode.Sturgia;

         //Act
         bool actualResult = sut.HaveToApplyModFor(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfSturgiaTournamentShouldNotHappens_WhenSturgiaIsNotActivated_AndThereIs0pcChanceToHappens_ThenTheTournamentShouldNotHappens()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   ",
               "Select the cultures that should apply this mod, as well as the percentage of chance to happens",
               "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  ",
               "[X] Apply to Empire   at 100%",
               "[X] Apply to Sturgia  at 0%",
               "[X] Apply to Aserai   at 100%",
               "[X] Apply to Vlandia  at 100%",
               "[X] Apply to Khuzait  at 100%",
               "[X] Apply to Battania at 100%"
            }
         });
         var expectResult = false;
         var param1 = CultureCode.Sturgia;

         //Act
         bool actualResult = sut.HaveToApplyModFor(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }


      [Test]
      public void GivenINeedToKnowIfTournamentHostShouldEnforceCulture_WhenCultureIsAserai_AndAseraiShouldEnforce_ThenTheResponseIsTrue()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "--- --- --- --- --- --- --- ---",
               "   Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ---",
               "When enforcing culture, all tournament participants must use the equipment style of the event host.  ",
               "If unchecked, each participant will maintain their own cultural style of dress during the tournament.",
               "",
               "[] Empire enforce its culture during tournaments",
               "[] Sturgia enforce its culture during tournaments",
               "[X] Aserai enforce its culture during tournaments",
               "[] Vlandia enforce its culture during tournaments",
               "[] Khuzait enforce its culture during tournaments",
               "[] Battania enforce its culture during tournaments"
            }
         });

         var expectResult = true;
         var param1 = CultureCode.Aserai;

         //Act
         bool actualResult = sut.ShouldUseHostCulture(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfTournamentHostShouldEnforceCulture_WhenCultureIsAserai_AndAseraiShouldNotEnforce_ThenTheResponseIsFalse()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "--- --- --- --- --- --- --- ---",
               "   Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ---",
               "When enforcing culture, all tournament participants must use the equipment style of the event host.  ",
               "If unchecked, each participant will maintain their own cultural style of dress during the tournament.",
               "",
               "[] Empire enforce its culture during tournaments",
               "[] Sturgia enforce its culture during tournaments",
               "[] Aserai enforce its culture during tournaments",
               "[] Vlandia enforce its culture during tournaments",
               "[] Khuzait enforce its culture during tournaments",
               "[] Battania enforce its culture during tournaments"
            }
         });

         var expectResult = false;
         var param1 = CultureCode.Aserai;

         //Act
         bool actualResult = sut.ShouldUseHostCulture(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }


      [Test]
      public void GivenINeedToKnowIfTournamentHostShouldEnforceCulture_WhenCultureIsBattania_AndBattaniaShouldEnforce_ThenTheResponseIsTrue()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "--- --- --- --- --- --- --- ---",
               "   Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ---",
               "When enforcing culture, all tournament participants must use the equipment style of the event host.  ",
               "If unchecked, each participant will maintain their own cultural style of dress during the tournament.",
               "",
               "[] Empire enforce its culture during tournaments",
               "[] Sturgia enforce its culture during tournaments",
               "[] Aserai enforce its culture during tournaments",
               "[] Vlandia enforce its culture during tournaments",
               "[] Khuzait enforce its culture during tournaments",
               "[X] Battania enforce its culture during tournaments"
            }
         });

         var expectResult = true;
         var param1 = CultureCode.Battania;

         //Act
         bool actualResult = sut.ShouldUseHostCulture(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfTournamentHostShouldEnforceCulture_WhenCultureIsBattania_AndBattaniaShouldNotEnforce_ThenTheResponseIsFalse()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "--- --- --- --- --- --- --- ---",
               "   Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ---",
               "When enforcing culture, all tournament participants must use the equipment style of the event host.  ",
               "If unchecked, each participant will maintain their own cultural style of dress during the tournament.",
               "",
               "[] Empire enforce its culture during tournaments",
               "[] Sturgia enforce its culture during tournaments",
               "[] Aserai enforce its culture during tournaments",
               "[] Vlandia enforce its culture during tournaments",
               "[] Khuzait enforce its culture during tournaments",
               "[] Battania enforce its culture during tournaments"
            }
         });

         var expectResult = false;
         var param1 = CultureCode.Khuzait;

         //Act
         bool actualResult = sut.ShouldUseHostCulture(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfTournamentHostShouldEnforceCulture_WhenCultureIsEmpire_AndEmpireShouldEnforce_ThenTheResponseIsTrue()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "--- --- --- --- --- --- --- ---",
               "   Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ---",
               "When enforcing culture, all tournament participants must use the equipment style of the event host.  ",
               "If unchecked, each participant will maintain their own cultural style of dress during the tournament.",
               "",
               "[X] Empire enforce its culture during tournaments",
               "[] Sturgia enforce its culture during tournaments",
               "[] Aserai enforce its culture during tournaments",
               "[] Vlandia enforce its culture during tournaments",
               "[] Khuzait enforce its culture during tournaments",
               "[] Battania enforce its culture during tournaments"
            }
         });

         var expectResult = true;
         var param1 = CultureCode.Empire;

         //Act
         bool actualResult = sut.ShouldUseHostCulture(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfTournamentHostShouldEnforceCulture_WhenCultureIsEmpire_AndEmpireShouldNotEnforce_ThenTheResponseIsFalse()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "--- --- --- --- --- --- --- ---",
               "   Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ---",
               "When enforcing culture, all tournament participants must use the equipment style of the event host.  ",
               "If unchecked, each participant will maintain their own cultural style of dress during the tournament.",
               "",
               "[] Empire enforce its culture during tournaments",
               "[] Sturgia enforce its culture during tournaments",
               "[] Aserai enforce its culture during tournaments",
               "[] Vlandia enforce its culture during tournaments",
               "[] Khuzait enforce its culture during tournaments",
               "[] Battania enforce its culture during tournaments"
            }
         });

         var expectResult = false;
         var param1 = CultureCode.Empire;

         //Act
         bool actualResult = sut.ShouldUseHostCulture(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }


      [Test]
      public void GivenINeedToKnowIfTournamentHostShouldEnforceCulture_WhenCultureIsKhuzait_AndKhuzaitShouldEnforce_ThenTheResponseIsTrue()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "--- --- --- --- --- --- --- ---",
               "   Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ---",
               "When enforcing culture, all tournament participants must use the equipment style of the event host.  ",
               "If unchecked, each participant will maintain their own cultural style of dress during the tournament.",
               "",
               "[] Empire enforce its culture during tournaments",
               "[] Sturgia enforce its culture during tournaments",
               "[] Aserai enforce its culture during tournaments",
               "[] Vlandia enforce its culture during tournaments",
               "[X] Khuzait enforce its culture during tournaments",
               "[] Battania enforce its culture during tournaments"
            }
         });

         var expectResult = true;
         var param1 = CultureCode.Khuzait;

         //Act
         bool actualResult = sut.ShouldUseHostCulture(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfTournamentHostShouldEnforceCulture_WhenCultureIsKhuzait_AndKhuzaitShouldNotEnforce_ThenTheResponseIsFalse()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "--- --- --- --- --- --- --- ---",
               "   Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ---",
               "When enforcing culture, all tournament participants must use the equipment style of the event host.  ",
               "If unchecked, each participant will maintain their own cultural style of dress during the tournament.",
               "",
               "[] Empire enforce its culture during tournaments",
               "[] Sturgia enforce its culture during tournaments",
               "[] Aserai enforce its culture during tournaments",
               "[] Vlandia enforce its culture during tournaments",
               "[] Khuzait enforce its culture during tournaments",
               "[] Battania enforce its culture during tournaments"
            }
         });

         var expectResult = false;
         var param1 = CultureCode.Khuzait;

         //Act
         bool actualResult = sut.ShouldUseHostCulture(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfTournamentHostShouldEnforceCulture_WhenCultureIsSturgia_AndSturgiaShouldEnforce_ThenTheResponseIsTrue()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "--- --- --- --- --- --- --- ---",
               "   Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ---",
               "When enforcing culture, all tournament participants must use the equipment style of the event host.  ",
               "If unchecked, each participant will maintain their own cultural style of dress during the tournament.",
               "",
               "[] Empire enforce its culture during tournaments",
               "[X] Sturgia enforce its culture during tournaments",
               "[] Aserai enforce its culture during tournaments",
               "[] Vlandia enforce its culture during tournaments",
               "[] Khuzait enforce its culture during tournaments",
               "[] Battania enforce its culture during tournaments"
            }
         });

         var expectResult = true;
         var param1 = CultureCode.Sturgia;

         //Act
         bool actualResult = sut.ShouldUseHostCulture(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfTournamentHostShouldEnforceCulture_WhenCultureIsSturgia_AndSturgiaShouldNotEnforce_ThenTheResponseIsFalse()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "--- --- --- --- --- --- --- ---",
               "   Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ---",
               "When enforcing culture, all tournament participants must use the equipment style of the event host.  ",
               "If unchecked, each participant will maintain their own cultural style of dress during the tournament.",
               "",
               "[] Empire enforce its culture during tournaments",
               "[] Sturgia enforce its culture during tournaments",
               "[] Aserai enforce its culture during tournaments",
               "[] Vlandia enforce its culture during tournaments",
               "[] Khuzait enforce its culture during tournaments",
               "[] Battania enforce its culture during tournaments"
            }
         });

         var expectResult = false;
         var param1 = CultureCode.Sturgia;

         //Act
         bool actualResult = sut.ShouldUseHostCulture(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }


      [Test]
      public void GivenINeedToKnowIfTournamentHostShouldEnforceCulture_WhenCultureIsVlandia_AndVlandiaShouldEnforce_ThenTheResponseIsTrue()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "--- --- --- --- --- --- --- ---",
               "   Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ---",
               "When enforcing culture, all tournament participants must use the equipment style of the event host.  ",
               "If unchecked, each participant will maintain their own cultural style of dress during the tournament.",
               "",
               "[] Empire enforce its culture during tournaments",
               "[] Sturgia enforce its culture during tournaments",
               "[] Aserai enforce its culture during tournaments",
               "[X] Vlandia enforce its culture during tournaments",
               "[] Khuzait enforce its culture during tournaments",
               "[] Battania enforce its culture during tournaments"
            }
         });

         var expectResult = true;
         var param1 = CultureCode.Vlandia;

         //Act
         bool actualResult = sut.ShouldUseHostCulture(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }

      [Test]
      public void GivenINeedToKnowIfTournamentHostShouldEnforceCulture_WhenCultureIsVlandia_AndVlandiaShouldNotEnforce_ThenTheResponseIsFalse()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "--- --- --- --- --- --- --- ---",
               "   Culture 𝐨𝐩𝐭𝐢𝐨𝐧𝐬 𝐟𝐨𝐫 𝐭𝐨𝐮𝐫𝐧𝐚𝐦𝐞𝐧𝐭𝐬",
               "--- --- --- --- --- --- --- ---",
               "When enforcing culture, all tournament participants must use the equipment style of the event host.  ",
               "If unchecked, each participant will maintain their own cultural style of dress during the tournament.",
               "",
               "[] Empire enforce its culture during tournaments",
               "[] Sturgia enforce its culture during tournaments",
               "[] Aserai enforce its culture during tournaments",
               "[] Vlandia enforce its culture during tournaments",
               "[] Khuzait enforce its culture during tournaments",
               "[] Battania enforce its culture during tournaments"
            }
         });

         var expectResult = false;
         var param1 = CultureCode.Vlandia;

         //Act
         bool actualResult = sut.ShouldUseHostCulture(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }


      [Test]
      public void GivenINeedToKnowIfVlandiaTournamentShouldHappens_WhenVlandiaIsActivated_AndThereIs100pcChanceToHappens_ThenTheTournamentShouldHappens()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute());
         var expectResult = true;
         var param1 = CultureCode.Vlandia;

         //Act
         bool actualResult = sut.HaveToApplyModFor(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }


      [Test]
      public void GivenINeedToKnowIfVlandiaTournamentShouldNotHappens_WhenVlandiaIsNotActivated_AndThereIs0pcChanceToHappens_ThenTheTournamentShouldNotHappens()
      {
         //Arrange
         var sut = new Config(new ConfigLoaderSubstitute {
            Content = new[] {
               "",
               "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---   ",
               "Select the cultures that should apply this mod, as well as the percentage of chance to happens",
               "--- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---  ",
               "[X] Apply to Empire   at 100%",
               "[X] Apply to Sturgia  at 100%",
               "[X] Apply to Aserai   at 100%",
               "[X] Apply to Vlandia  at 0%",
               "[X] Apply to Khuzait  at 100%",
               "[X] Apply to Battania at 100%"
            }
         });
         var expectResult = false;
         var param1 = CultureCode.Vlandia;

         //Act
         bool actualResult = sut.HaveToApplyModFor(param1);

         //Assert
         actualResult.Should().Be(expectResult);
      }
   }
}