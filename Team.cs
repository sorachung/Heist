using System;
using System.Collections.Generic;

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
    }

}
