using System;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new team to add members to later
            Team team = new Team();

            // prompt user for bank difficulty level in int
            Console.Write("Please enter a difficulty level of the bank: ");
            int bankDifficultyLevel = int.Parse(Console.ReadLine());

            Console.WriteLine("Plan Your Heist!");

            do
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

                Console.WriteLine($"The total number of members on the team is {team.MembersCount}.");
            }
            while (true);

            // 
            int teamSkillLevel = team.TotalSkillLevel();

            Console.Write("How many trial runs would you like to run? ");
            int numOfTrials = int.Parse(Console.ReadLine());
            int successfulRuns = numOfTrials;
            for (int i = 1; i <= numOfTrials; i++)
            {
                Console.WriteLine($"Trial #{i}:");
                int heistLuckValue = new Random().Next(-10, 11);
                bankDifficultyLevel += heistLuckValue;

                Console.WriteLine($"Team's combined skill level: {teamSkillLevel}");
                Console.WriteLine($"Bank's difficulty level: {bankDifficultyLevel}");

                if (teamSkillLevel >= bankDifficultyLevel)
                {
                    Console.WriteLine("Y'all've successfully pulled off a heist!");
                }
                else
                {
                    Console.WriteLine("Pfft, y'all suck. Off to prison you go!");
                    successfulRuns--;
                }
            }

            Console.WriteLine($"Successful runs: {successfulRuns}");
            Console.WriteLine($"Failed runs: {numOfTrials - successfulRuns}");
        }
    }
}
