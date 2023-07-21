// Code written by Gabriel Mailhot, 30/04/2023.

#region

using System.Xml;
using FluentAssertions;
using LogRaamJousting;
using LogRaamJousting.Armors;
using LogRaamJousting.Decoupling;
using LogRaamJousting.Equipments;
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
      public void GivenIsCulturalEvent_WhenEquip_ThenParticipantShouldHaveThrowingKnives()
      {
         //Arrange
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

         var items = new List<LogRaamJousting.Decoupling.ItemObject> {
            decoupledThrowingKnife
         };

         var setup = new SetupSubstitute();
         var sut = new AseraiKit(setup, new EquipmentPlugin());
         var ExpectedResult = "desert_throwing_knife_blunt";

         //Act
         var actualResult = sut.Equip(new AseraiWeaponry(new Items()), new AseraiArmoury(), new AseraiStable());

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

         var sut = new AseraiKit(new SetupSubstitute(), new EquipmentPlugin());
         var ExpectedResult = "desert_throwing_knife_blunt";

         //Act
         var actualResult = sut.Equip(new AseraiWeaponry(new Items()), new AseraiArmoury(), new AseraiStable());

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