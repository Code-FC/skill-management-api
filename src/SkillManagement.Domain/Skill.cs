using System;

namespace SkillManagement.Domain
{
    public sealed class Skill
    {
        public Skill(string title, string description)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            Description = description;
        }

        public string Title { get; }
        public string Description { get; }
    }
}
