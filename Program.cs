using System;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new team to add members to later
            Team team = new Team();

            // opening message
            Console.WriteLine("Plan Your Heist!");

            // prompt user for bank difficulty level in int
            int bankDifficultyLevel = 0;
            do
            {
                try
                {
                    Console.Write("Please enter a difficulty level of the bank: ");
                    string bankDifficultyLevelStr = Console.ReadLine();
                    bankDifficultyLevel = int.Parse(bankDifficultyLevelStr);

                    if (bankDifficultyLevel <= 0)
                    {
                        throw new FormatException("Please enter a positive integer!");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (bankDifficultyLevel <= 0);

            // prompt user for team members' info
            do
            {
                Member member = new Member();

                // ask for team member's name
                Console.WriteLine();
                Console.Write("What is your team member's name? ");
                string name = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(name))
                {
                    break;
                }
                member.Name = name;

                // ask for team member's skill level
                int skillLevelInt = 0;
                do
                {
                    try
                    {
                        Console.WriteLine();
                        Console.Write("What is your team member's skill level? ");
                        string skillLevelStr = Console.ReadLine();
                        skillLevelInt = int.Parse(skillLevelStr);
                        if (skillLevelInt <= 0)
                        {
                            throw new FormatException("Please enter a positive integer!");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (skillLevelInt <= 0);

                member.SkillLevel = skillLevelInt;

                // ask for team member's courage factor
                double courageFactorDouble = -1;
                do
                {
                    try
                    {
                        Console.WriteLine();
                        Console.Write("What is your team member's courage factor? ");
                        string courageFactorStr = Console.ReadLine();
                        courageFactorDouble = double.Parse(courageFactorStr);
                        if (courageFactorDouble < 0 || courageFactorDouble > 2)
                        {
                            throw new FormatException("Please enter a decimal between 0.0 and 2.0!");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                while (courageFactorDouble < 0 || courageFactorDouble > 2);

                member.CourageFactor = courageFactorDouble;

                team.AddMember(member);

                Console.WriteLine();
                Console.WriteLine($"The total number of members on the team is {team.MembersCount}.");
            }
            while (true);

            // total up team's skill level
            int teamSkillLevel = team.TotalSkillLevel();

            // prompt user for number of trials
            int numOfTrials = 0;
            do
            {
                try
                {
                    Console.WriteLine();
                    Console.Write("How many trial runs would you like to run? ");
                    string numOfTrialsStr = Console.ReadLine();
                    numOfTrials = int.Parse(numOfTrialsStr);
                    if (numOfTrials <= 0)
                    {
                        throw new FormatException("Please enter a positive integer!");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (numOfTrials <= 0);

            // run trials and keep track of number of successful runs vs failed runs
            int successfulRuns = numOfTrials;
            for (int i = 1; i <= numOfTrials; i++)
            {

                Console.WriteLine();
                Console.WriteLine($"Trial #{i}:");
                int heistLuckValue = new Random().Next(-10, 11);
                int adjustedBankDifficultyLevel = bankDifficultyLevel + heistLuckValue;

                Console.WriteLine($"Team's combined skill level: {teamSkillLevel}");
                Console.WriteLine($"Bank's difficulty level: {adjustedBankDifficultyLevel}");

                if (teamSkillLevel >= adjustedBankDifficultyLevel)
                {
                    Console.WriteLine("Y'all've successfully pulled off a heist!");
                }
                else
                {
                    Console.WriteLine("Pfft, y'all suck. Off to prison you go!");
                    successfulRuns--;
                }
            }

            // final report for successful and failed runs
            Console.WriteLine();
            Console.WriteLine($"Successful runs: {successfulRuns}");
            Console.WriteLine($"Failed runs: {numOfTrials - successfulRuns}");
        }
    }
}
