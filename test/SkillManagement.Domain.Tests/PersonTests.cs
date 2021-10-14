using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace SkillManagement.Domain.Tests
{
    public class PersonTests
    {
        [Theory]
        [AutoData]
        public void GivenNameIsNull_ThrowArgumentNullException(string email)
        {
            Action action = () => _ = new Person(null!, email);

            action.Should().ThrowExactly<ArgumentNullException>();
        }

        [Theory]
        [AutoData]
        public void GivenNameIsEmpty_ThrowArgumentNullException(string email)
        {
            Action action = () => _ = new Person(string.Empty, email);

            action.Should().ThrowExactly<ArgumentNullException>();
        }

        [Theory]
        [AutoData]
        public void GivenEmailIsNull_ThrowArgumentNullException(string name)
        {
            Action action = () => _ = new Person(name, null!);

            action.Should().ThrowExactly<ArgumentNullException>();
        }

        [Theory]
        [AutoData]
        public void GivenEmailIsEmpty_ThrowArgumentNullException(string name)
        {
            Action action = () => _ = new Person(name, string.Empty);

            action.Should().ThrowExactly<ArgumentNullException>();
        }

        [Theory, AutoData]
        public void GivenValidParameters_PersonIsCreatedSuccessfully(string name, string email)
        {
            var person = new Person(email, name);

            person.Name.Should().Be(name);
            person.Email.Should().Be(email);
        }
    }
}