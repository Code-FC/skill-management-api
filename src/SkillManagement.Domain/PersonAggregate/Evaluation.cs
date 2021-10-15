using System;

namespace SkillManagement.Domain.PersonAggregate
{
    public sealed class Evaluation
    {
        internal Evaluation(Skill skill, EvaluationLevel level)
        {
            Skill = skill ?? throw new ArgumentNullException(nameof(skill));
            Level = level;
        }

        public Skill Skill { get; }
        public EvaluationLevel Level { get; }
    }
}
