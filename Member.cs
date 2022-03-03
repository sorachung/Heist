using System;

namespace Heist
{
    public class Member
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public double CourageFactor { get; set; }

        public string MemberDescription()
        {
            return $"Team member {Name} has a skill level of {SkillLevel} and a courage factor of {CourageFactor}.";
        }
    }
}