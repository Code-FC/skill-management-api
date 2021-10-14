using System;

namespace SkillManagement.Domain
{
    public class Endorsement
    {
        public Endorsement(Person endorser, Person endorsee, Skill skill, string comment)
        {
            Endorser = endorser ?? throw new ArgumentNullException(nameof(endorser));
            Endorsee = endorsee ?? throw new ArgumentNullException(nameof(endorsee));
            Skill = skill ?? throw new ArgumentNullException(nameof(skill));
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
        }

        public Person Endorser { get; }
        public Person Endorsee { get; }
        public Skill Skill { get; }
        public string Comment { get; }
    }
}
