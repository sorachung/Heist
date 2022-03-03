using System;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new team to add members to later
            Team team = new Team();

            // flag for when to end the prompts
            bool prompting = true;

            Console.WriteLine("Plan Your Heist!");

            while (prompting)
            {
                Member member = new Member();

                Console.Write("What is your team member's name? ");
                string name = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(name))
                {
                    break;
                }
                member.Name = name;

                Console.Write("What is your team member's skill level? ");
                string skillLevelStr = Console.ReadLine();
                try
                {
                    int skillLevelInt = int.Parse(skillLevelStr);
                    if (skillLevelInt <= 0)
                    {
                        throw new FormatException("Please enter a positive integer!");
                    }
                    member.SkillLevel = skillLevelInt;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter a positive integer!");
                }

                Console.Write("What is your team member's courage factor? ");
                member.CourageFactor = double.Parse(Console.ReadLine());

                team.AddMember(member);

                Console.WriteLine(member.MemberDescription());
            }

            Console.WriteLine($"The total number of members on the team is {team.MembersCount}.");
        }
    }
}
