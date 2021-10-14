using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace SkillManagement.Domain.Tests
{
    public class LevelTests
    {
        [Theory]
        [AutoData]
        public void GivenWeightIsNegative_ThrowIndexOutOfRangeException(string anyTitle)
        {
            Action action = () => _ = new Level(-1, anyTitle);

            action.Should().ThrowExactly<IndexOutOfRangeException>();
        }

        [Theory]
        [AutoData]
        public void GivenTitleIsNull_ThrowArgumentNullException(int anyWeight)
        {
            Action action = () => _ = new Level(anyWeight, null);

            action.Should().ThrowExactly<ArgumentNullException>();
        }

        [Theory]
        [AutoData]
        public void GivenTitleIsEmpty_ThrowArgumentNullException(int anyWeight)
        {
            Action action = () => _ = new Level(anyWeight, string.Empty);

            action.Should().ThrowExactly<ArgumentNullException>();
        }

        [Theory]
        [AutoData]
        public void GivenValidWeightAndTitle_CreateObjectSuccessfully(int anyWeight, string anyTitle)
        {
            var level = new Level(anyWeight, anyTitle);

            level.Weight.Should().Be(anyWeight);
            level.Title.Should().Be(anyTitle);
        }
    }
}