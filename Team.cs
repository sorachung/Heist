using System;
using System.Collections.Generic;
using System.Linq;

namespace Heist
{
    public class Team
    {
        public List<Member> Members { get; set; }
        public int MembersCount
        {
            get
            {
                return Members.Count;
            }
        }
        public Team()
        {
            Members = new List<Member>();
        }
        public void AddMember(Member member)
        {
            Members.Add(member);
        }

        public void DisplayMembers()
        {
            foreach (Member member in Members)
            {
                Console.WriteLine(member.MemberDescription());
            }
        }

        public int TotalSkillLevel()
        {
            // creates new List<int> of skill levels then sums them up
            return Members.ConvertAll<int>(member => member.SkillLevel).Sum();
        }
    }

}
