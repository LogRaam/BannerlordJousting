// Code written by Gabriel Mailhot, 23/04/2023.

#region

using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace LogRaamJoustingTest
{
   [TestFixture]
   internal class PluginTest
   {
      [Test]
      public void TestingDynamicCastingStrategy()
      {
         //Arrange
         var culture = "Aserai";
         var n = $"LogRaamJousting.Options.{culture}Options, LogRaamJousting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
         var plugin = Type.GetType(n);

         plugin.Should().NotBe(null);

         if (plugin == null) return;

         object? participant = Activator.CreateInstance(plugin);

         MethodInfo? method = participant?.GetType().GetMethod("ShouldBeNaked");
         var expectedResult = true;

         //Act
         object? actualResult = method?.Invoke(participant, new object?[] {
            new[] {
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

         //Assert
         actualResult.Should().Be(expectedResult);
      }
   }
}