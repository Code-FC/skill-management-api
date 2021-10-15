using System;

namespace SkillManagement.Domain
{
    public sealed class Skill
    {
        public Skill(string title, string description) : this(Guid.NewGuid(), title, description)
        {
        }

        public Skill(Guid id, string title, string description)
        {
            Id = id == default ? throw new ArgumentNullException(nameof(id)) : id;
            Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentNullException(nameof(title)) : title;
            Description = description;
        }

        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }

        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) ||
                   (obj is Skill other &&
                    (Id.Equals(other.Id) ||
                     string.Equals(Title, other.Title, StringComparison.InvariantCultureIgnoreCase)));
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Skill? left, Skill? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Skill? left, Skill? right)
        {
            return !Equals(left, right);
        }
    }
}
