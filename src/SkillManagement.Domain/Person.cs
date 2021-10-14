using System;

namespace SkillManagement.Domain
{
    public sealed class Person
    {
        public string Email { get; }
        public string Name { get; }

        public Person(string email, string name)
        {
            Email = string.IsNullOrWhiteSpace(email) ? throw new ArgumentNullException(nameof(email)) : email;
            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
        }
    }
}