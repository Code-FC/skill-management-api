using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace SkillManagement.Domain.Tests
{
    public class SkillTests
    {
        [Theory]
        [AutoData]
        public void GivenTitleIsNull_ThrowsArgumentNullException(string anyDescription)
        {
            Action action = () => _ = new Skill(null, anyDescription);

            action.Should().ThrowExactly<ArgumentNullException>().And.ParamName.Should().Be("title");
        }

        [Theory]
        [AutoData]
        public void GivenTitleIsEmpty_ThrowsArgumentNullException(string anyDescription)
        {
            Action action = () => _ = new Skill(string.Empty, anyDescription);

            action.Should().ThrowExactly<ArgumentNullException>().And.ParamName.Should().Be("title");
        }

        [Theory]
        [AutoData]
        public void GivenValidTitleAndDescription_NewObjectIsCreatedSuccessfully(string title, string description)
        {
            var skill = new Skill(title, description);

            skill.Title.Should().Be(title);
            skill.Description.Should().Be(description);
        }
    }
}