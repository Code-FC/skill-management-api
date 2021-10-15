using System;

namespace SkillManagement.Domain.PersonAggregate
{
    public sealed class Endorsement
    {
        internal Endorsement(Person endorser, Skill skill, string comment)
        {
            Endorser = endorser ?? throw new ArgumentNullException(nameof(endorser));
            Skill = skill ?? throw new ArgumentNullException(nameof(skill));
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
        }

        public Person Endorser { get; }
        public Skill Skill { get; }
        public string Comment { get; }
    }
}
