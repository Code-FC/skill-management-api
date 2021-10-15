using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillManagement.Domain.PersonAggregate
{
    public sealed class Person
    {
        private readonly List<Endorsement> _endorsements = new List<Endorsement>();
        private readonly List<Evaluation> _evaluations = new List<Evaluation>();

        public Person(string email, string name) : this(Guid.NewGuid(), email, name)
        {
        }

        public Person(Guid id, string email, string name)
        {
            Email = string.IsNullOrWhiteSpace(email) ? throw new ArgumentNullException(nameof(email)) : email;
            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
            Id = id == default ? throw new ArgumentNullException(nameof(id)) : id;
        }

        public Guid Id { get; }
        public string Email { get; }
        public string Name { get; }
        public IReadOnlyCollection<Endorsement> Endorsements => _endorsements;
        public IReadOnlyCollection<Evaluation> Evaluations => _evaluations;

        public void AddEndorsement(Person endorser, Skill skill, string comment)
        {
            var endorsement = new Endorsement(endorser, skill, comment);
            _endorsements.Add(endorsement);
            SaveEvaluation(skill, EvaluationLevel.NotEvaluated);
        }

        public void SaveEvaluation(Skill skill, EvaluationLevel level)
        {
            var evaluation = new Evaluation(skill, level);
            var existingEvaluation = _evaluations.FirstOrDefault(e => e.Skill.Equals(skill));

            if (existingEvaluation is null || level != EvaluationLevel.NotEvaluated)
            {
                _evaluations.RemoveAll(e => e.Skill.Equals(skill));
                _evaluations.Add(evaluation);
            }
        }
    }
}
