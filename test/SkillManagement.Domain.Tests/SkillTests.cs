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
            Action action = () => _ = new Skill(null!, anyDescription);

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
        public void GivenIdIsDefault_ThrowsArgumentNullException(string anyTitle, string anyDescription)
        {
            Action action = () => _ = new Skill(Guid.Empty, anyTitle, anyDescription);

            action.Should().ThrowExactly<ArgumentNullException>().And.ParamName.Should().Be("id");
        }

        [Theory]
        [AutoData]
        public void GivenValidTitleAndDescription_NewObjectIsCreatedSuccessfullyWithGeneratedId(string title,
            string description)
        {
            var skill = new Skill(title, description);

            skill.Id.Should().NotBe(default(Guid));
            skill.Title.Should().Be(title);
            skill.Description.Should().Be(description);
        }

        [Theory]
        [AutoData]
        public void GivenValidIdAndTitleAndDescription_NewObjectIsCreatedSuccessfully(Guid id, string title,
            string description)
        {
            var skill = new Skill(id, title, description);

            skill.Id.Should().Be(id);
            skill.Title.Should().Be(title);
            skill.Description.Should().Be(description);
        }

        [Theory, AutoData]
        public void GivenTwoSkillObjectsWithSameId_TheyAreConsideredEqual(Guid id,
            string titleLeft,
            string descriptionLeft,
            string titleRight,
            string descriptionRight)
        {
            var left = new Skill(id, titleLeft, descriptionLeft);
            var right = new Skill(id, titleRight, descriptionRight);

            left.Equals(right).Should().Be(true);
        }

        [Theory, AutoData]
        public void GivenTwoSkillObjectsWithSameTitle_TheyAreConsideredEqual(
            string title,
            string descriptionLeft,
            string descriptionRight)
        {
            var left = new Skill(title, descriptionLeft);
            var right = new Skill(title, descriptionRight);

            left.Equals(right).Should().BeTrue();
            (left == right).Should().BeTrue();
            (left != right).Should().BeFalse();

            left.GetHashCode().Should().Be(left.Id.GetHashCode());
        }
    }
}
