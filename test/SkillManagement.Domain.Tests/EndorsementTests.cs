using AutoFixture;
using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace SkillManagement.Domain.Tests
{
    public class EndorsementTests
    {
        [Fact]
        public void GuardConstructorParametersAgainstNullValues()
        {
            var fixture = new Fixture();
            var assertion = new GuardClauseAssertion(fixture);
            assertion.Verify(typeof(Endorsement).GetConstructors());
        }

        [Theory, AutoData]
        public void GivenValidParameters_EndorsementIsCreatedSuccessfully(
            Person endorser,
            Person endorsee,
            Skill skill,
            string comment)
        {
            var endorsement = new Endorsement(endorser, endorsee, skill, comment);

            endorsement.Comment.Should().Be(comment);
            endorsement.Endorser.Should().Be(endorser);
            endorsement.Endorsee.Should().Be(endorsee);
            endorsement.Skill.Should().Be(skill);
        }
    }
}