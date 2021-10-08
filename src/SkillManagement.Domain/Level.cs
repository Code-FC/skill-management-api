using System;

namespace SkillManagement.Domain
{
    public sealed class Level
    {
        public Level(int weight, string title)
        {
            Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentNullException(nameof(title)) : title;

            if (weight < 0) throw new IndexOutOfRangeException();

            Weight = weight;
        }

        public int Weight { get; }
        public string Title { get; }
    }
}