// Code written by Gabriel Mailhot, 30/04/2023.

#region

using System.Xml;
using FluentAssertions;
using LogRaamJousting;
using LogRaamJousting.Armors;
using LogRaamJousting.Decoupling;
using LogRaamJousting.Equipments;
using LogRaamJousting.Options;
using LogRaamJousting.Stables;
using LogRaamJousting.Weapons;
using LogRaamJoustingTest.Substitutes;
using NUnit.Framework;
using TaleWorlds.Core;
using TaleWorlds.ObjectSystem;
using ItemObject = TaleWorlds.Core.ItemObject;

#endregion

namespace LogRaamJoustingTest
{
   [TestFixture]
   public class AseraiKitTest
   {
      [Test]
      public void GivenAseraiTournamentRequestParticipantToBeNaked_WhenEquipPlayer_PlayerShouldBeNaked()
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
[] Undressed Sturgia
[X] Undressed Aserai

[] Undressed Vlandia
[] Undressed Khuzait
[] Undressed Battania

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

         Runtime.IsCulturalEvent = false;
         Runtime.HostCulture = CultureCode.Aserai;

         var configLoaderSubstitute = new ConfigLoaderSubstitute {
            Content = new[] {
               file
            }
         };

         MBObjectManager.Init();
         var knife = GetXmlNodeFrom(DesertThrowingKnifeXml());
         var aserai = GetXmlNodeFrom(AseraiCultureXml());

         var culture = new BasicCultureObject();
         culture.Deserialize(MBObjectManager.Instance, aserai);

         MBObjectManager.Instance.CreateObjectWithoutDeserialize(knife);
         var desert_scale_armor = MBObjectManager.Instance.CreateObject<ItemObject>("cr_y_desert_scale_armor");

         var decoupleddesert_scale_armor = new LogRaamJousting.Decoupling.ItemObject(desert_scale_armor) {
            Culture = culture,
            ItemType = ItemObject.ItemTypeEnum.BodyArmor,
            Tier = ItemObject.ItemTiers.Tier1,
            Id = new MBGUID(),
            IsReady = true,
            StringId = "cr_y_desert_scale_armor"
         };

         var decoupleddesert_scale_armor2 = new LogRaamJousting.Decoupling.ItemObject(desert_scale_armor) {
            Culture = culture,
            ItemType = ItemObject.ItemTypeEnum.BodyArmor,
            Tier = ItemObject.ItemTiers.Tier2,
            Id = new MBGUID(),
            IsReady = true,
            StringId = "cr_y_desert_scale_armor"
         };

         var items = new List<LogRaamJousting.Decoupling.ItemObject> {
            decoupleddesert_scale_armor, decoupleddesert_scale_armor2
         };

         var setupSubstitute = new SetupSubstitute(configLoaderSubstitute, new ConfigurationSubstitute {
            _hostShouldProvideArmors = true
         }, new CultureOptions(configLoaderSubstitute));

         var sut = new AseraiKit(setupSubstitute, new EquipmentPlugin(setupSubstitute, new ConfigurationSubstitute {
            _shouldBeNaked = true
         }, "Aserai", new Participant {
            IsPlayer = true
         }), configLoaderSubstitute);

         var ExpectedResult = "cr_y_desert_scale_armor";


         //Act
         var actualResult = sut.Equip(new AseraiWeaponry(new Items()), new AseraiArmoury(new BaseArmoury(new Items {
            All = items
         }, new Items(), new Items())), new AseraiStable());

         //Assert
         actualResult[EquipmentIndex.Body].Item.Should().BeNull();
      }


      [Test]
      public void GivenAseraiTournamentRequestParticipantToNotBeNaked_WhenEquipPlayer_PlayerShouldNotBeNaked()
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
[] Undressed Sturgia
[X] Undressed Aserai

[] Undressed Vlandia
[] Undressed Khuzait
[] Undressed Battania

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

         Runtime.IsCulturalEvent = false;
         Runtime.HostCulture = CultureCode.Aserai;

         var configLoaderSubstitute = new ConfigLoaderSubstitute {
            Content = new[] {
               file
            }
         };

         MBObjectManager.Init();
         var knife = GetXmlNodeFrom(DesertThrowingKnifeXml());
         var aserai = GetXmlNodeFrom(AseraiCultureXml());

         var culture = new BasicCultureObject();
         culture.Deserialize(MBObjectManager.Instance, aserai);

         MBObjectManager.Instance.CreateObjectWithoutDeserialize(knife);
         var desert_scale_armor = MBObjectManager.Instance.CreateObject<ItemObject>("cr_y_desert_scale_armor");

         var decoupleddesert_scale_armor = new LogRaamJousting.Decoupling.ItemObject(desert_scale_armor) {
            Culture = culture,
            ItemType = ItemObject.ItemTypeEnum.BodyArmor,
            Tier = ItemObject.ItemTiers.Tier1,
            Id = new MBGUID(),
            IsReady = true,
            StringId = "cr_y_desert_scale_armor"
         };

         var decoupleddesert_scale_armor2 = new LogRaamJousting.Decoupling.ItemObject(desert_scale_armor) {
            Culture = culture,
            ItemType = ItemObject.ItemTypeEnum.BodyArmor,
            Tier = ItemObject.ItemTiers.Tier2,
            Id = new MBGUID(),
            IsReady = true,
            StringId = "cr_y_desert_scale_armor"
         };

         var items = new List<LogRaamJousting.Decoupling.ItemObject> {
            decoupleddesert_scale_armor, decoupleddesert_scale_armor2
         };

         var setupSubstitute = new SetupSubstitute(configLoaderSubstitute, new ConfigurationSubstitute {
            _hostShouldProvideArmors = true
         }, new CultureOptions(configLoaderSubstitute));

         var sut = new AseraiKit(setupSubstitute, new EquipmentPlugin(setupSubstitute, new ConfigurationSubstitute {
            _shouldBeNaked = false
         }, "Aserai", new Participant {
            IsPlayer = true
         }), configLoaderSubstitute);

         var ExpectedResult = "cr_y_desert_scale_armor";


         //Act
         var actualResult = sut.Equip(new AseraiWeaponry(new Items()), new AseraiArmoury(new BaseArmoury(new Items {
            All = items
         }, new Items(), new Items())), new AseraiStable());

         //Assert
         actualResult[EquipmentIndex.Body].Item.StringId.Should().Be(ExpectedResult);
      }

      [Test]
      public void GivenIsCulturalEvent_WhenEquip_ThenParticipantShouldHaveThrowingKnives()
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
[] Undressed Sturgia
[] Undressed Aserai

[] Undressed Vlandia
[] Undressed Khuzait
[] Undressed Battania

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
         Runtime.IsCulturalEvent = true;

         MBObjectManager.Init();
         var knife = GetXmlNodeFrom(DesertThrowingKnifeXml());
         var aserai = GetXmlNodeFrom(AseraiCultureXml());

         var culture = new BasicCultureObject();
         culture.Deserialize(MBObjectManager.Instance, aserai);

         MBObjectManager.Instance.CreateObjectWithoutDeserialize(knife);
         var coupledThrowingKnife = MBObjectManager.Instance.CreateObject<ItemObject>("desert_throwing_knife_blunt");

         var decoupledThrowingKnife = new LogRaamJousting.Decoupling.ItemObject(coupledThrowingKnife) {
            Culture = culture
         };
         var configLoaderSubstitute = new ConfigLoaderSubstitute {
            Content = new[] {
               file
            }
         };
         var items = new List<LogRaamJousting.Decoupling.ItemObject> {
            decoupledThrowingKnife
         };
         var setupSubstitute = new SetupSubstitute(configLoaderSubstitute, new ConfigurationSubstitute {
            _hostShouldProvideArmors = true
         }, new CultureOptions(configLoaderSubstitute));
         var config = new ConfigLoaderSubstitute {
            _shouldBeNaked = false
         };
         var sut = new AseraiKit(new SetupSubstitute(new ConfigLoaderSubstitute {
            _shouldUseTheirEquipment = false
         }, new ConfigurationSubstitute(), new ConfigLoaderSubstitute()), new EquipmentPlugin(setupSubstitute, new ConfigurationSubstitute(), "Aserai", new Participant {
            IsPlayer = true,
            Culture = "Aserai"
         }), new ConfigLoaderSubstitute());
         var ExpectedResult = "desert_throwing_knife_blunt";

         //Act
         var actualResult = sut.Equip(new AseraiWeaponry(new Items {
            All = items
         }), new AseraiArmoury(new BaseArmoury()), new AseraiStable());

         //Assert
         actualResult.GetEquipmentFromSlot(EquipmentIndex.Weapon0).Item.StringId.Should().Be(ExpectedResult);
         actualResult.GetEquipmentFromSlot(EquipmentIndex.Weapon1).Item.StringId.Should().Be(ExpectedResult);
         actualResult.GetEquipmentFromSlot(EquipmentIndex.Weapon2).Item.StringId.Should().Be(ExpectedResult);
         actualResult.GetEquipmentFromSlot(EquipmentIndex.Weapon3).Item.StringId.Should().Be(ExpectedResult);
      }

      [Test]
      public void GivenParticipantIsPlayer_AndThisIsNotCulturalEvent_WhenEquip_ThenParticipantShouldHaveThrowingKnives()
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
[] Undressed Sturgia
[] Undressed Aserai

[] Undressed Vlandia
[] Undressed Khuzait
[] Undressed Battania

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
         Runtime.IsCulturalEvent = true;

         MBObjectManager.Init();
         var knife = GetXmlNodeFrom(DesertThrowingKnifeXml());
         var aserai = GetXmlNodeFrom(AseraiCultureXml());

         var culture = new BasicCultureObject();
         culture.Deserialize(MBObjectManager.Instance, aserai);

         MBObjectManager.Instance.CreateObjectWithoutDeserialize(knife);
         var coupledThrowingKnife = MBObjectManager.Instance.CreateObject<ItemObject>("desert_throwing_knife_blunt");

         var decoupledThrowingKnife = new LogRaamJousting.Decoupling.ItemObject(coupledThrowingKnife) {
            Culture = culture
         };
         var configLoaderSubstitute = new ConfigLoaderSubstitute {
            Content = new[] {
               file
            }
         };
         var setupSubstitute = new SetupSubstitute(configLoaderSubstitute, new ConfigurationSubstitute {
            _hostShouldProvideArmors = true
         }, new CultureOptions(configLoaderSubstitute));
         var sut = new AseraiKit(new SetupSubstitute(), new EquipmentPlugin(setupSubstitute, new ConfigurationSubstitute(), "Aserai", new Participant {
            IsPlayer = true
         }), new ConfigLoaderSubstitute());
         var ExpectedResult = "desert_throwing_knife_blunt";

         var items = new List<LogRaamJousting.Decoupling.ItemObject> {
            decoupledThrowingKnife
         };

         //Act
         var actualResult = sut.Equip(new AseraiWeaponry(new Items {All = items}), new AseraiArmoury(new BaseArmoury()), new AseraiStable());

         //Assert
         actualResult.GetEquipmentFromSlot(EquipmentIndex.Weapon0).Item.StringId.Should().Be(ExpectedResult);
         actualResult.GetEquipmentFromSlot(EquipmentIndex.Weapon1).Item.StringId.Should().Be(ExpectedResult);
         actualResult.GetEquipmentFromSlot(EquipmentIndex.Weapon2).Item.StringId.Should().Be(ExpectedResult);
         actualResult.GetEquipmentFromSlot(EquipmentIndex.Weapon3).Item.StringId.Should().Be(ExpectedResult);
      }

      #region private

      private string AseraiCultureXml()
      {
         return "<Culture id=\"aserai\" name=\"{=aseraifaction}Aserai\" is_main_culture=\"true\" default_face_key=\"000fa92e90004202aced5d976886573d5d679585a376fdd605877a7764b8987c00000000000007520000037f0000000f00000037049140010000000000000000\" color=\"FF965228\" color2=\"FF4F2212\" cloth_alternative_color1=\"FF4F2212\" cloth_alternative_color2=\"FF965228\" banner_background_color1=\"FFA97435\" banner_foreground_color1=\"FF41281B\" banner_background_color2=\"FF41281B\" banner_foreground_color2=\"FFA97435\" faction_banner_key=\"11.45.122.4345.4345.764.764.1.0.0.463.0.1.512.512.764.764.1.0.0\" />";
      }

      private string DesertThrowingKnifeXml()
      {
         return $"<CraftedItem id=\"desert_throwing_knife_blunt tier=1\" "
                + $"name=\"{{=es77bJBa}}Sparring Throwing Dagger\" "
                + $"crafting_template=\"ThrowingKnife\" "
                + $"is_merchandise=\"false\" "
                + $"culture=\"Culture.aserai\" "
                + $"has_modifier=\"false\"> "
                + $"<Pieces> "
                + $"<Piece id=\"dagger_blade_13_blunt\" "
                + $"Type=\"Blade\" "
                + $"scale_factor=\"110\" /> "
                + $"<Piece id=\"aserai_dagger_guard_4\" "
                + $"Type=\"Guard\" /> "
                + $"<Piece id=\"aserai_grip_8\" "
                + $"Type=\"Handle\" /> "
                + $"</Pieces> "
                + $"<Piece id=\"aserai_pommel_3\"\r\n"
                + $"Type=\"Pommel\" />\r\n"
                + $"</CraftedItem>";
      }

      private XmlNode? GetXmlNodeFrom(string xml)
      {
         var xmlContent = xml;
         var doc = new XmlDocument();
         doc.LoadXml(xmlContent);
         XmlNode? newNode = doc.DocumentElement;

         return newNode;
      }

      #endregion
   }
}